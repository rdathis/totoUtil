/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/10/2016
 * Heure: 13:28:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Renci.SshNet;
using cmdUtils.Objets;
using cmdUtils.Objets.utils;
using MoulUtil.Forms;
using MoulUtil.Forms.utils;

namespace MoulUtil
{
	/// <summary>
	/// 
	/// Form de preparation de moulinette
	/// </summary>
	public partial class MouliPrepaForm : Form
	{
		private MouliPrepaUtil mouliPrepaUtil;
		private System.Diagnostics.Process plinkProcess;
		private ConfigDto configDto;
		private MouliSQLForm sqlForm;
		private MouliUtil mouliUtil = null;
		private MouliUtilOptions mouliUtilOptions = null;
		protected CmdUtil cmdUtil = null;
		private RegistryUtil registryUtil = null;
		private SshClient sshClientAdmin = null;
		private ConnectServerBackgroundWorker connectWorker = null;
		private readonly log4net.ILog  LOGGER;
		//Pour le timer
		private String statusMessage=null;
		private String infoMessage=null;
		private String sauvegardeProgressMessage=null;
		private Double sauvegardeProgressValue=-1;
		
		
		public MouliPrepaForm(ConfigDto configDto, log4net.ILog  LOGGER)
		{
			InitializeComponent();
			this.configDto = configDto;
			this.LOGGER = LOGGER;
			prepare();
			
			rechMagIdBox.Focus();
		}

		private void prepare() {
			this.rechMagIdBtn.Enabled = false;
			prepareTimer();
			//
			registryUtil = new RegistryUtil();
			String workspacePath = registryUtil.getHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key);
			mouliPrepaUtil = new MouliPrepaUtil(this, configDto, LOGGER);
			if (!String.IsNullOrEmpty(workspacePath)) {
				workspacePath += "" + configDto.getWorkingDir().Replace("\\", "/");
			} else {
				workspacePath = configDto.getWorkingDir();
			}
			workspacePath=workspacePath.Replace("\\", "/");
			
			this.workingDirBox.Text = workspacePath;
			this.workspaceBaseBox.Text = workspacePath;
			mouliUtil = new MouliUtil(LOGGER);
			cmdUtil = new CmdUtil();
			new TreeViewUtil(configDto.instances, configDto.serveurs).populateTargets(targetTreeView);
			//
			zonePrepaNavigatorUserControl.setBox(workspaceBaseBox);
			workspaceNavigatorUserControl.setBoxes(workspaceBaseBox, workspaceZoneBox);
			svgBaseNavigatorUserControl.setBox(targetSvgPathBox);
			svgFinalNavigatorUserControl.setBoxes(targetSvgPathBox, targetNameBox);
		}
		void prepareTimer()
		{
			connectTimer.Interval=500;
			connectTimer.Tick += new EventHandler(TimerEventProcessor);
			connectTimer.Start();
		}
		public void controleRegistre()
		{
			if (!registryUtil.existsHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key)) {
				;
				Console.WriteLine("Creation de la clef de registre");
				registryUtil.setHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key, Directory.GetCurrentDirectory() + "\\");
			}
		}
		void MouliPrepaLoad(object sender, EventArgs e)
		{
			doConnectAdmin(true);
		}
		private void doConnectAdmin(Boolean check)
		{
			if (check) {
				MeoInstance adminInstance = MeoInstance.findInstanceByInstanceName(configDto.instances, "administration");
				MeoServeur meoServeur = MeoServeur.findServeurByName(configDto.serveurs, adminInstance.serveur);
				
				String tunnelStr = meoServeur.getTunnel();
				int leftPort = int.Parse(tunnelStr.Substring(0, tunnelStr.IndexOf(":", StringComparison.Ordinal)));
				int rightPort = int.Parse(tunnelStr.Substring(tunnelStr.IndexOf(":", StringComparison.Ordinal) + 1));
				
				LOGGER.Info("avant bw");
				connectWorker = new ConnectServerBackgroundWorker();
				
				LOGGER.Info("avant go");
				connectWorker.prepare(sshClientAdmin, meoServeur, leftPort, rightPort, rechMagIdBox);
				
				MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = str => {
					LOGGER.InfoFormat("Notification received for: {0}", str);
					try {
						statusMessage = "connecting to " + meoServeur.nom + " by ssh (" + tunnelStr + ")...";
					} catch (Exception ex) {
						LOGGER.Error("still exception here ..." + ex.Message);
					}
				};
				//

				MouliProgressWorker.EndWorkerSshClientCallBack endWorkerCallBack = (message, sshClient, textbox) => {
					if (sshClient == null) {
						Console.WriteLine("Exception message :" + message);
						statusMessage = "SSH : Exception message :" + message;
						
					} else {
						//
						Console.WriteLine("connected on server");
						LOGGER.Info("connected");
						sshClientAdmin = sshClient;
						statusMessage = "connected at "+meoServeur.nom +":/"+adminInstance.nom;
						infoMessage= "connected";
					}
				};

				connectWorker.setStartWorkerCallBack(startWorkerCallBack);
				connectWorker.setEndWorkerSshClientCallBack(endWorkerCallBack);
				connectWorker.RunWorkerAsync();
			} else {
				plinkProcess = mouliPrepaUtil.startPlink(configDto, rechMagIdBox);
			}
		}
		void WorkspaceBoxTextChanged(object sender, EventArgs e)
		{
			mouliUtil.safeCreateDirectory(configDto.getWorkingDir());
		}
		void PrepareBtnClick(object sender, EventArgs e)
		{
			if (mouliUtilOptions == null) {
				return;
			}
			if (workspaceBaseBox.Text.Length > 0 && workspaceZoneBox.Text.Length > 0) {
//
				mouliUtilOptions.setWorkspacePath(workspaceBaseBox.Text);
				String path = workspaceZoneBox.Text;
				if (path.StartsWith("workspace/", StringComparison.Ordinal)) {
					path = path.Replace("workspace/", "");
				}
				mouliUtilOptions.setWorkingPath(path);
				if(!Directory.Exists(workspaceBaseBox.Text + path)) {
					toolTipLabel.Text = ("chemin absent : '"+workspaceBaseBox.Text + path+"'");
					return;
				}
//
				MouliActionForm form = new MouliActionForm(mouliUtilOptions, configDto, LOGGER, workspaceZoneBox.Text);
				form.ShowDialog();
			} else {
				workspaceBaseBox.Focus();
			}
		}

		public void setTargetSvgPath(string str)
		{
			this.targetSvgPathBox.Text = str;
		}
		public void setWorkspacePath(string sourceMoulinette)
		{
			workspaceZoneBox.Text = sourceMoulinette;
		}
		void SauvegardeBtnClick(object sender, EventArgs e)
		{
			
			//vire le 'workspace'
			if (!Directory.Exists(workspaceBaseBox.Text)) {
				MessageBox.Show("Répertoire absent : " + workspaceBaseBox.Text);
				return;
			}
			
			//? String tmpDir = new DirectoryInfo(workspaceBaseBox.Text).Parent.FullName;
			String tmpDir = new DirectoryInfo(workspaceBaseBox.Text).FullName;
			String sourceDir = tmpDir + "/" + workspaceZoneBox.Text;
			String targetDir = Path.GetFullPath(targetSvgPathBox.Text) + "\\" + targetNameBox.Text;
			if(!Directory.Exists(sourceDir)) {
				toolTipLabel.Text = ("chemin absent : '"+sourceDir+"'");
				return;
			}
			if(!Directory.Exists(targetSvgPathBox.Text)) {
				toolTipLabel.Text = ("chemin absent : '"+targetSvgPathBox.Text+"'");
				return;
			}
			
			sauvegardeBtn.Enabled = false;
			statusMessage = "Préparation de la sauvegarde ...";
			tmpDir = Path.GetFullPath(targetDir).Replace('/', '\\');
			tmpDir = new DirectoryInfo(tmpDir).Parent.FullName;
			if (!Directory.Exists(tmpDir)) {
				mouliUtil.safeCreateDirectory(tmpDir);
			}
			LOGGER.Info("->" + tmpDir);
			cmdUtil.executeCommande("explorer", tmpDir);
			
			SauvegardeBackgroundWorker worker = getSauvegardeBackgroundWorker();
			
			MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = name => {
				try {
					statusMessage = "begin";
					sauvegardeProgressMessage = " debut";
					sauvegardeBtn.Visible = false;
					sauvegardeProgressValue=-1;
				} catch (Exception ex) {
					Console.WriteLine("still exception here ..." + ex.Message);
				}
			};
			MouliProgressWorker.ProgressWorkerCallBack progressWorkerCallBack = value => {
				//if(value<=100) sauvegardeProgressTextBox.Value =value;//bug
				double prc = 0;
				if (worker.getNbOperation() != 0) {
					prc = value / ((double)worker.getNbOperation()) * 100;
					prc = Math.Round(prc, 3);
				}
				sauvegardeProgressValue = prc;
				sauvegardeProgressMessage = (value + " / " + worker.getNbOperation() + " (" + prc + ")%");
				statusMessage = "progression : " + (value) + "%  - x / " + worker.getNbOperation();
				sauvegardeProgressMessage = statusMessage;
			};
			MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
				sauvegardeBtn.Enabled = true;
				sauvegardeProgressValue=-1;
				sauvegardeProgressMessage= "sauvegarde finie";
			};
			//
			worker.setStartWorkerCallBack(startWorkerCallBack);
			worker.setProgressWorkerCallBack(progressWorkerCallBack);
			worker.setEndWorkerCallBack(endWorkerCallBack);
			//
			worker.prepare(mouliPrepaUtil, mouliUtilOptions, sourceDir, targetSvgPathBox.Text);
			worker.RunWorkerAsync();
		}
		void RechMagIdBtnClick(object sender, EventArgs e)
		{
			rechercheMagasin();
		}

		void rechercheMagasin()
		{
			if ((rechMagIdBox.Text != "0") && (sshClientAdmin == null || !sshClientAdmin.IsConnected)) {
				infoMessage = "La liaison ssh est fermée.";
				return;
			}
			String workingPath = workspaceBaseBox.Text;
			MeoInstance adminInstance = MeoInstance.findInstanceByInstanceName(configDto.instances, "administration");
			MeoServeur adminServeur = MeoServeur.findServeurByName(configDto.serveurs, adminInstance.serveur);
			
			mouliUtilOptions = mouliPrepaUtil.rechercheMagasin(adminServeur, rechMagIdBox, magDescBox, propositionBox, workingPath, sqlBtn);
			if (mouliUtilOptions != null) {
				calculeMoulinettePath();
				String path = workspaceZoneBox.Text;
				mouliUtilOptions.setArchiveName(mouliUtil.calculeArchiveName(workingPath+path));
				Console.WriteLine("name: " + mouliUtilOptions.getarchiveName());
			}
		}

		public void CreateBtnClick(object sender, EventArgs e)
		{
			String proposition = workingDirBox.Text+propositionBox.Text;
			if (proposition.Length > 0) {
				mouliUtil.createArbo(proposition);
				if (sender != null) {// cause mag zero
					cmdUtil.executeCommande("explorer", Path.GetFullPath(proposition));
				}
			}
		}
		void CopyBtnClick(object sender, EventArgs e)
		{
			calculeMoulinettePath();
		}
		
		private String calculeMoulinettePath()
		{
			String str = propositionBox.Text.Trim();
			if (str.Length > 0) {
				String subPath = "MEO" + DateTime.Now.Year + "/";
				mouliUtil.safeCreateDirectory(targetSvgPathBox.Text + "/" + subPath);
				workspaceZoneBox.Text = str;
				targetNameBox.Text = subPath + str.Replace(workingDirBox.Text, "");
			}
			return str;
		}
		void MouliPrepaFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (plinkProcess != null) {
				plinkProcess.Close();
			}
		}
		void SqlBtnClick(object sender, EventArgs e)
		{
			sqlForm = new MouliSQLForm(LOGGER, this.rechMagIdBox.Text, mouliUtilOptions);
			sqlForm.Show();
		}
		void ConfigBtnClick(object sender, EventArgs e)
		{
			
			MouliEditForm form = new MouliEditForm(configDto);
			form.ShowDialog();
		}
		void ServeursContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			Console.WriteLine("in menu");
		}
		void PuttyToolStripMenuItemClick(object sender, EventArgs e)
		{
			actionPutty(targetTreeView);
		}

		void RechMagIdBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue.Equals(13)) {
				try {
					rechercheMagasin();
				} catch (Exception ex) {
					LOGGER.Error(ex);
				}
			}

		}
		void TargetTreeViewDoubleClick(object sender, EventArgs e)
		{
			actionPutty(targetTreeView);
		}
		MeoServeur getSelectedServeur(TreeView tv)
		{
			TreeNode node = tv.SelectedNode;
			int level = node.Level;
			String text = node.Text;
			MeoServeur meoServeur = null;

			if (level == 0) {
				meoServeur = MeoServeur.findServeurByName(configDto.serveurs, text);
			}
			return meoServeur;
		}
		MeoInstance getSelectedInstance(TreeView tv)
		{
			TreeNode node = tv.SelectedNode;
			int level = node.Level;
			String text = node.Text;
			String serverName = null;
			MeoInstance instance = null;

			
			if (level == 0) {
				serverName = text;
			} else if (level == 1) {
				instance = MeoInstance.findInstanceByInstanceName(configDto.instances, text);
				if (instance != null) {
					serverName = instance.getServeur();
				}
			}
			return instance;
		}
		void TargetTreeViewMouseClick(object sender, MouseEventArgs e)
		{
			
			if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				serveursContextMenu.Show();
			}
		}

		void MysqlToolStripMenuItemClick(object sender, EventArgs e)
		{
			actionMysql(getSelectedInstance(targetTreeView));
		}
		
		void actionMysql(MeoInstance meoInstance)
		{
			LOGGER.Debug("actionMysql()");
			//todo
		}

		
		void actionPutty(TreeView treeView)
		{
			LOGGER.Debug("actionPutty()");
			MeoServeur meoServeur = null;
			MeoInstance meoInstance = getSelectedInstance(treeView);
			if (meoInstance != null) {
				meoServeur = MeoServeur.findServeurByName(configDto.serveurs, meoInstance.serveur);
			} else {
				meoServeur = getSelectedServeur(treeView);
			}
			if (meoServeur != null) {
				String args = cmdUtil.buildPuttyArgs(meoServeur);
				cmdUtil.executeCommandAsDetachedProcess(MouliConfig.puttyPath, args);
			}
		}
		
		void HistoryLabelClick(object sender, EventArgs e)
		{
			ConfigParam param = configDto.getConfigParamByName(ConfigParam.ParamNamesType.history);
			if (param != null) {
				mouliPrepaUtil.startBrowser(param.Value);
			}
		}
		private SauvegardeBackgroundWorker getSauvegardeBackgroundWorker()
		{
			SauvegardeBackgroundWorker worker = new SauvegardeBackgroundWorker();
			worker.WorkerSupportsCancellation = true;
			worker.WorkerReportsProgress = true;
			worker.DoWork += new DoWorkEventHandler(worker.sauvegardeBW_DoWork);
			worker.ProgressChanged += new ProgressChangedEventHandler(worker.sauvegardeBW_ProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker.sauvegardeBW_RunWorkerCompleted);
			return worker;
		}
		private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
			try {
				if(infoMessage!=null) {
					magDescBox.Text = infoMessage;
					infoMessage=null;
					rechMagIdBtn.Enabled=true;
					rechercheMagasin();
				}
				if(statusMessage!=null) {
					statusStrip1.Text=statusMessage;
					toolTipLabel.Text = statusMessage;
					statusMessage=null;
				}
				if(sauvegardeProgressMessage!=null) {
					sauvegardeProgressTextBox.Text= sauvegardeProgressMessage;
					sauvegardeProgressMessage=null;
				}
				if(sauvegardeProgressValue>=0) {
					toolStripProgressBar.Value = (int) sauvegardeProgressValue;
					sauvegardeProgressValue=-1;
				}
			} catch (Exception exception) {
				LOGGER.Error(exception);
			}
		}
	}
}