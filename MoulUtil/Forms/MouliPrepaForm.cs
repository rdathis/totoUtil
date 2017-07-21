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
using System.Timers;
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
		private System.Timers.Timer timer;
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
		private log4net.ILog ILOG;
		
		public MouliPrepaForm(ConfigDto configDto, log4net.ILog ILOG)
		{
			InitializeComponent();
			
			timer = new System.Timers.Timer();
			timer.Interval = 1000;
			timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
			
			
			this.rechMagIdBox.Enabled = true;
			registryUtil = new RegistryUtil();
			String workspacePath = registryUtil.getHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key);
			mouliPrepaUtil = new MouliPrepaUtil(this, configDto);
			this.configDto = configDto;
			this.ILOG = ILOG;
			if (!String.IsNullOrEmpty(workspacePath)) {
				workspacePath += "" + configDto.getWorkingDir().Replace("\\", "/");
			} else {
				workspacePath = configDto.getWorkingDir();
			}
			
			this.workingDirBox.Text = workspacePath;
			this.workspaceBaseBox.Text = workspacePath;
			mouliUtil = new MouliUtil();
			cmdUtil = new CmdUtil();
			new TreeViewUtil(configDto.instances, configDto.serveurs).populateTargets(targetTreeView);
			//
			zonePrepaNavigatorUserControl.setBox(workspaceBaseBox);
			workspaceNavigatorUserControl.setBoxes(workspaceBaseBox, workspaceZoneBox);
			svgBaseNavigatorUserControl.setBox(targetSvgPathBox);
			svgFinalNavigatorUserControl.setBoxes(targetSvgPathBox, targetNameBox);
			
			
			rechMagIdBox.Focus();
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
				String tunnelStr = configDto.getConfigParamValueByName(ConfigParam.ParamNamesType.databaseTunneling);
				int leftPort = int.Parse(tunnelStr.Substring(0, tunnelStr.IndexOf(":", StringComparison.Ordinal)));
				int rightPort = int.Parse(tunnelStr.Substring(tunnelStr.IndexOf(":", StringComparison.Ordinal) + 1));
				
				ILOG.Info("avant bw");
				connectWorker = new ConnectServerBackgroundWorker();
				
				//String serverName = configDto.getConfigParamValueByName(ConfigParam.ParamNamesType.
				MeoInstance adminInstance = MeoInstance.findInstanceByInstanceName(configDto.instances, "administration");
				MeoServeur meoServeur = MeoServeur.findServeurByName(configDto.serveurs, adminInstance.serveur);
				ILOG.Info("avant go");
				connectWorker.prepare(sshClientAdmin, meoServeur, leftPort, rightPort, rechMagIdBox);
				
				MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = str => {
					Console.WriteLine("Notification received for: {0}", str);
					//?? plantage: toolStripStatusLabel1.Text = name;
					try {
						statusStrip1.Text = "connecting to " + meoServeur.nom + " by ssh (" + tunnelStr + ")...";
					} catch (Exception ex) {
						Console.WriteLine("still exception here ..." + ex.Message);
					}
				};
				//

				MouliProgressWorker.EndWorkerSshClientCallBack endWorkerCallBack = (message, sshClient, textbox) => {
					if (sshClient == null) {
						Console.WriteLine("Exception message :" + message);
						statusStrip1.Text = "SSH : Exception message :" + message;
					} else {
						Console.WriteLine("connected on server");
						ILOG.Info("connected");
						sshClientAdmin = sshClient;
						magDescBox.Text = "connected";
						//textbox.Enabled=true;
						//textbox.Focus();
						statusStrip1.Text = "connected";
						//rechMagIdBox.Enabled=true;
						//rechMagIdBox.Focus();
					}
				};

				connectWorker.setStartWorkerCallBack(startWorkerCallBack);
				connectWorker.setEndWorkerSshClientCallBack(endWorkerCallBack);
				connectWorker.RunWorkerAsync();
				//timer.Enabled=true;
				//sshClientAdmin = mouliPrepaUtil.startSSHClientAdmin(configDto, rechMagIdBox);
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
//
				MouliActionForm form = new MouliActionForm(mouliUtilOptions, configDto, workspaceZoneBox.Text);
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
			String tmpDir = new DirectoryInfo(workspaceBaseBox.Text).Parent.FullName;
			String sourceDir = tmpDir + "/" + workspaceZoneBox.Text;
			String targetDir = Path.GetFullPath(targetSvgPathBox.Text) + "\\" + targetNameBox.Text;
			//mouliUtil.createArbo(targetDir);
			//copier le resultat.zip dans le sousrep,
			//generer un zip du rep tmp dans le sousrep. (comment le nommer ?)
			sauvegardeBtn.Enabled = false;
			statusStrip1.Text = "Préparation de la sauvegarde ...";
			tmpDir = Path.GetFullPath(targetDir).Replace('/', '\\');
			tmpDir = new DirectoryInfo(tmpDir).Parent.FullName;
			if (!Directory.Exists(tmpDir)) {
				mouliUtil.safeCreateDirectory(tmpDir);
			}
			Console.WriteLine("->" + tmpDir);
			cmdUtil.executeCommande("explorer", tmpDir);
			
			SauvegardeBackgroundWorker worker = getSauvegardeBackgroundWorker();
			
			MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = name => {
				//Console.WriteLine("Notification received for: {0}", name);
				//?? plantage: toolStripStatusLabel1.Text = name;
				try {
					statusStrip1.Text = "begin";
					sauvegardeBtn.Visible = false;
					sauvegardeProgressTextBox.Text = " debut";
					//toolStripProgressBar1.Value=0;
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
				sauvegardeProgressTextBox.Text = (value + " / " + worker.getNbOperation() + " (" + prc + ")%");
				statusStrip1.Text = "progression : " + (value) + "%  - x / " + worker.getNbOperation();
				sauvegardeProgressTextBox.Text = statusStrip1.Text;
			};
			MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
				sauvegardeBtn.Enabled = true;
				//statusStrip1.Text = "fini";
				sauvegardeProgressTextBox.Text = "fini";
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
				magDescBox.Text = "La liaison ssh est fermée.";
				return;
			}
			String workingPath = workspaceBaseBox.Text;
			
			mouliUtilOptions = mouliPrepaUtil.rechercheMagasin(rechMagIdBox, magDescBox, propositionBox, workingPath, sqlBtn);
			if (mouliUtilOptions != null) {
				calculeMoulinettePath();
				String path = workspaceZoneBox.Text;
				mouliUtilOptions.setArchiveName(mouliUtil.calculeArchiveName(path));
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
		
		///TODO:move in MPUtil
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
			sqlForm = new MouliSQLForm(this.rechMagIdBox.Text, mouliUtilOptions);
			//form.ShowDialog();
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
					Console.WriteLine(ex.Message);
					//reportError(ex);
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
			System.Diagnostics.Debug.Print("actionMysql()");
			//todo
		}

		
		void actionPutty(TreeView treeView)
		{
			System.Diagnostics.Debug.Print("actionPutty()");
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
			} else {
				//historyLabel.Enabled=false;
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
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			//brancher ici le travail du timer pour les backgroundWorker
			//Console.WriteLine("Hello World!");
			if (connectWorker != null && !connectWorker.IsBusy) {
				magDescBox.Text = "connected";
				statusStrip1.Text = "connected";
				timer.Enabled = false;
			}
		}
	}
}