/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/10/2016
 * Heure: 13:28:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
		private readonly log4net.ILog LOGGER;
		//Pour le timer
		private String statusMessage = null;
		private String infoMessage = null;
		private String sauvegardeProgressMessage = null;
		private Double sauvegardeProgressValue = -1;
		private ToolTipUtil	toolTipUtil = new ToolTipUtil();
		private int sauvegardeBtnEnabled = -1;
		private int sauvegardeBtnVisible = -1;
		private string versionInfo;
		
		
		public MouliPrepaForm(ConfigDto configDto, log4net.ILog  LOGGER, String versionInfo)
		{
			InitializeComponent();
			this.configDto = configDto;
			this.LOGGER = LOGGER;
			this.versionInfo=versionInfo;
			prepare();
			
			rechMagIdBox.Focus();
		}

		private void prepare()
		{
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
			workspacePath = workspacePath.Replace("\\", "/");
			
			this.workingDirBox.Text = workspacePath;
			this.workspaceBaseBox.Text = workspacePath;
			mouliUtil = new MouliUtil(LOGGER);
			magIrrisBox.Text = mouliUtil.getMagasinIrris();
			cmdUtil = new CmdUtil();
			populateTargetBox(null);
			
			//
			zonePrepaNavigatorUserControl.setBox(workspaceBaseBox);
			workspaceNavigatorUserControl.setBoxes(workspaceBaseBox, workspaceZoneBox);
			svgBaseNavigatorUserControl.setBox(targetSvgPathBox);
			svgFinalNavigatorUserControl.setBoxes(targetSvgPathBox, targetNameBox);
			sourceNavigatorUserControl.setBox(sourceBaseComboBox);
			populateSourceBox(configDto.getConfigParamValueByName(ConfigParam.ParamNamesType.moulinetteSource));
			sourceBaseComboBox.Text = configDto.getConfigParamValueByName(ConfigParam.ParamNamesType.defaultSourcePath);
			populateToolTips();
			populateVersionInfo();
		}

		private void populateTargetBox(String instanceName)
		{
			new TreeViewUtil(configDto.instances, configDto.serveurs).populateTargets(targetTreeView, instanceName);
		}

		void populateVersionInfo()
		{
			toolStripVersionInfo.Text = versionInfo;
		}

		void populateToolTips()
		{
			toolTipUtil.add(this.rechMagIdBox, "MagId magasin");
			toolTipUtil.add(this.workingDirBox, "Espace de travail (workspace)");
			toolTipUtil.add(this.magDescBox, "Description du magasin");
			toolTipUtil.add(this.propositionBox, "Proposition de chemin pour les données à préparer");
			toolTipUtil.add(this.sourceBaseComboBox, "Liste des sources des données possibles");
			toolTipUtil.add(this.sourceFilterBox, "Filtrage dans les sources");
			toolTipUtil.add(this.sourceListBox, "Choix de la source de donnée");
//
			toolTipUtil.add(this.workspaceBaseBox, "Répertoire de base");
			toolTipUtil.add(this.workspaceZoneBox, "répertoire de travail");
//
			toolTipUtil.add(this.targetSvgPathBox, "Répertoire des sauvegardes");
			toolTipUtil.add(this.targetNameBox, "nom de la sauvegarde");
//
			toolTipUtil.add(this.sqlBtn, "Accès aux requêtes (totaux, purges...)");
			toolTipUtil.add(this.configBtn, "Paramètrages");
//
			toolTipUtil.add(this.historyLabel, "Accès à l'historique");
			toolTipUtil.add(this.serveursContextMenu, "Connection directs aux serveurs (Putty)");
//
			toolTipUtil.add(this.rechMagIdBtn, "Rechercher un magasin avec ce magId");
			toolTipUtil.add(this.createBtn, "Créer ce répertoire de travail ");
			toolTipUtil.add(this.sauvegardeBtn, "Sauvegarder les données");
			toolTipUtil.add(this.prepareBtn, "Préparer les données");
			toolTipUtil.add(this.copyBtn, "Copier le chemin proposé vers la préparation et la sauvegarde");
		}
		void populateSourceBox(string str)
		{
			sourceBaseComboBox.Items.Clear();
			string[] tablo = str.Split('|');
			for (int i = 0; i < tablo.Length; i++) {
				sourceBaseComboBox.Items.Add(tablo[i]);
			}
		}

		void prepareTimer()
		{
			connectTimer.Interval = 500;
			connectTimer.Tick += new EventHandler(TimerEventProcessor);
			connectTimer.Start();
		}
		public void controleRegistre()
		{
			if (!registryUtil.existsHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key)) {
				LOGGER.Warn("Creation de la clef de registre");
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
				if(adminInstance!=null) {
					MeoServeur meoServeur = MeoServeur.findServeurByName(configDto.serveurs, adminInstance.serveur);
					if(meoServeur!=null) {
						String tunnelStr = meoServeur.getTunnel();
						int leftPort = int.Parse(tunnelStr.Substring(0, tunnelStr.IndexOf(":", StringComparison.Ordinal)));
						int rightPort = int.Parse(tunnelStr.Substring(tunnelStr.IndexOf(":", StringComparison.Ordinal) + 1));
						
						LOGGER.Info("avant bw");
						connectWorker = new ConnectServerBackgroundWorker();
						
						LOGGER.Info("avant go");
						connectWorker.prepare(sshClientAdmin, meoServeur, leftPort, rightPort, rechMagIdBox, LOGGER);
						
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
								LOGGER.Error("Exception message :" + message);
								statusMessage = "SSH : Exception message :" + message;
								
							} else {
								//
								Console.WriteLine("connected on server");
								LOGGER.Info("connected");
								sshClientAdmin = sshClient;
								statusMessage = "connected at " + meoServeur.nom + ":/" + adminInstance.nom;
								infoMessage = "connected";
							}
						};

						connectWorker.setStartWorkerCallBack(startWorkerCallBack);
						connectWorker.setEndWorkerSshClientCallBack(endWorkerCallBack);
						connectWorker.RunWorkerAsync();
					} else {
						MessageBox.Show("Pas de serveur pour admin instance");
					}
				} else {
					MessageBox.Show("Pas de d'admin instance");
				}
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
			prepareMouliUtilOptions();
			if (mouliUtilOptions == null) {
				LOGGER.Info("options are null");
				return;
			}
			
			if (workspaceBaseBox.Text.Length > 0 && workspaceZoneBox.Text.Length > 0) {
				MouliActionForm form = new MouliActionForm(mouliUtilOptions, configDto, LOGGER, workspaceZoneBox.Text);
				form.ShowDialog();
				prepareBtn.ForeColor = Color.Blue;
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
			if (!Directory.Exists(sourceDir)) {
				toolTipLabel.Text = ("chemin absent : '" + sourceDir + "'");
				return;
			}
			if (!Directory.Exists(targetSvgPathBox.Text)) {
				toolTipLabel.Text = ("chemin absent : '" + targetSvgPathBox.Text + "'");
				return;
			}

			String targetBaseDir =new DirectoryInfo(targetDir).Parent.FullName;
			const string rapports="/rapports/";
			if(!Directory.Exists(targetBaseDir +rapports)) {
				try {
					Directory.CreateDirectory(targetBaseDir +rapports);
				} catch (Exception ex) {
					LOGGER.Error("error : "+targetBaseDir +rapports);
					LOGGER.Error(ex.Message);
				}
			}
			if(Directory.Exists(targetBaseDir +rapports)) {
				try {
					File.Copy(sourceDir+mouliUtilOptions.getHtmlRecapFile(),targetBaseDir +rapports +mouliUtilOptions.getHtmlRecapFile());
				} catch (Exception ex) {
					LOGGER.Error("error : "+targetBaseDir +rapports);
					LOGGER.Error(ex.Message);
				}
				
			}
			sauvegardeBtnEnabled = 0;
			//sauvegardeBtn.Enabled = false;
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
					//sauvegardeBtn.Visible = false;
					sauvegardeBtnVisible = 0;
					sauvegardeProgressValue = -1;
				} catch (Exception ex) {
					LOGGER.Error(ex);
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
				statusMessage = "progression : " + (prc) + "%  - " + value + " / " + worker.getNbOperation();
				sauvegardeProgressMessage = statusMessage;
			};
			MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
				//sauvegardeBtn.Enabled = true;
				sauvegardeBtnEnabled = 1;
				sauvegardeProgressValue = 0; //100 %
				sauvegardeProgressMessage = "sauvegarde finie";
				statusMessage = sauvegardeProgressMessage;
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
			sourceFilterBox.Text = "*" + rechMagIdBox.Text + "*";
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
			
			mouliUtilOptions = mouliPrepaUtil.rechercheMagasin(adminServeur, rechMagIdBox, magDescBox, propositionBox, workingPath, sqlBtn, magIrrisBox.Text);
			if (mouliUtilOptions != null) {
				calculeMoulinettePath();
				String path = workspaceZoneBox.Text;
				mouliUtilOptions.setArchiveName(mouliUtil.calculeArchiveName(workingPath + path));
				LOGGER.Info("name: " + mouliUtilOptions.getarchiveName());
				
				populateTargetBox(mouliUtilOptions.getInstanceName());
				sourceFilterBox.Text="*"+rechMagIdBox.Text+"*";
			}
			String fi = workspaceBaseBox.Text + workspaceZoneBox.Text + "magasin.txt";
			if (File.Exists(fi)) {
				try {
					StreamReader sr = new StreamReader(fi);
					String val = sr.ReadLine();
					sr.Close();
					if ((val.Length == 2) && (val != magIrrisBox.Text)) {
						magIrrisBox.Text = val;
						calculeMoulinettePath();
					}
				} catch (Exception ex) {
					LOGGER.Error(ex);
				}
			}
			if(sourceBaseComboBox.Text!=null) {
				populateSourceListBox(sourceBaseComboBox.Text);
				if(sourceListBox.Items.Count==1) {
					sourceListBox.SelectedIndex=0;
					choisirSource();
				}
			}
			rechMagIdBtn.ForeColor = Color.Blue;
		}

		public void CreateBtnClick(object sender, EventArgs e)
		{
			String proposition = workingDirBox.Text + propositionBox.Text;
			if (proposition.Length > 0) {
				mouliUtil.setMagasinIrris(magIrrisBox.Text);
				mouliUtil.createArbo(proposition);
				if (sender != null) {// cause mag zero
					cmdUtil.executeCommande("explorer", Path.GetFullPath(proposition));
				}
				createBtn.ForeColor = Color.Blue;
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
				try {
					mouliUtil.safeCreateDirectory(targetSvgPathBox.Text + "/" + subPath);
				} catch(Exception exception) {
					MessageBox.Show("impossible d'accéder à "+ targetSvgPathBox.Text + "/" + subPath);
					return str;
				}
				
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
			sqlForm = new MouliSQLForm(LOGGER, this.rechMagIdBox.Text, mouliUtilOptions, configDto);
			sqlForm.Show();
			sqlBtn.ForeColor = Color.Blue;
		}
		void ConfigBtnClick(object sender, EventArgs e)
		{
			
			MouliEditForm form = new MouliEditForm(configDto);
			form.ShowDialog();
		}
		void ServeursContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			LOGGER.Info("in menu");
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
		private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
		{
			try {
				if (infoMessage != null) {
					magDescBox.Text = infoMessage;
					infoMessage = null;
					rechMagIdBtn.Enabled = true;
					
					//not really corrected
					if(rechMagIdBox.Text.Length>3) {
						rechercheMagasin();
					}
				}
				if (statusMessage != null) {
					statusStrip1.Text = statusMessage;
					toolTipLabel.Text = statusMessage;
					statusMessage = null;
				}
				if (sauvegardeProgressMessage != null) {
					sauvegardeProgressTextBox.Text = sauvegardeProgressMessage;
					sauvegardeProgressMessage = null;
				}
				if (sauvegardeProgressValue >= 0) {
					toolStripProgressBar.Value = (int)sauvegardeProgressValue;
					sauvegardeProgressValue = -1;
				}
				if (sauvegardeBtnVisible > -1) {
					sauvegardeBtnVisible = -1;
					if (sauvegardeBtnVisible == 0) {
						sauvegardeBtn.Visible = false;
					} else {
						sauvegardeBtn.Visible = true;
					}
				}
				if (sauvegardeBtnEnabled > -1) {
					sauvegardeBtnEnabled = -1;
					if (sauvegardeBtnEnabled == 0) {
						sauvegardeBtn.Enabled = false;
					} else {
						sauvegardeBtn.Enabled = true;
						sauvegardeBtn.ForeColor = Color.Blue;
					}
				}
			} catch (Exception exception) {
				LOGGER.Error(exception);
			}
		}
		void MockBtnClick(object sender, EventArgs e)
		{
			if (propositionBox.Text != "") {
				CreateBtnClick(null, null);
				
				mouliPrepaUtil.createMock(workingDirBox.Text + propositionBox.Text, magIrrisBox.Text);
				MockBtn.ForeColor = Color.Blue;
			}
		}
		void SourceBaseComboBoxTextUpdate(object sender, EventArgs e)
		{
			populateSourceListBox(sourceBaseComboBox.Text);
		}
		void SourceBaseComboBoxSelectionChangeCommitted(object sender, EventArgs e)
		{
			populateSourceListBox(sourceBaseComboBox.SelectedItem.ToString());
		}
		void populateSourceListBox(String path)
		{
			this.sourceListBox.Items.Clear();
			List<String> liste = mouliPrepaUtil.populateSourceBaseListBox(path, this.sourceFilterBox.Text);
			if (liste != null) {
				int idx = -1;
				foreach (String str in liste) {
					idx = this.sourceListBox.Items.Add(str);
				}
				this.sourceListBox.Sorted = true;
			}
		}
		void SourceFilterBoxKeyUp(object sender, KeyEventArgs e)
		{
			populateSourceListBox(sourceBaseComboBox.Text);
		}
		void SourceListBoxDoubleClick(object sender, EventArgs e)
		{
			if (sourceListBox.SelectedItem != null && sourceListBox.SelectedItem.ToString() != "") {
				cmdUtil.openWindowsExplorer(sourceListBox.SelectedItem.ToString());
			}
		}
		void DefinirToolStripMenuItemClick(object sender, EventArgs e)
		{
			actionDefinirInstance(targetTreeView);
		}
		void actionDefinirInstance(TreeView treeView)
		{
			LOGGER.Debug("actionDefinirInstance()");
			MeoInstance meoInstance = getSelectedInstance(treeView);
			if (meoInstance != null) {
				populateTargetBox(meoInstance.nom);
				mouliUtilOptions.setInstanceName(meoInstance.nom);
				mouliUtilOptions.setInstanceCommande(meoInstance.meocli);
				mouliUtilOptions.setInstancePath(meoInstance.meopath);
			}
		}
		void TriDataBtnClick(object sender, EventArgs e)
		{
			prepareMouliUtilOptions();
			List<String> liste=new List<string>();
			for(int i=0;i<	sourceListBox.Items.Count;i++) {
				liste.Add(sourceListBox.Items[i].ToString());
			}
			ExtraireForm extraireForm = new ExtraireForm(LOGGER,  liste, mouliUtilOptions);
			extraireForm.Show();
			triDataBtn.ForeColor = Color.Blue;
		}
		void ChoisirToolStripMenuItemClick(object sender, EventArgs e)
		{
			choisirSource();
		}
		private void choisirSource() {
			//
			if(sourceListBox.SelectedItem!=null && (String) sourceListBox.SelectedItem!="") {
				sourceBaseComboBox.Text =sourceListBox.SelectedItem.ToString();
				sourceFilterBox.Text="*";
				SourceBaseComboBoxTextUpdate(null, null);
			}
			//
		}
		private void prepareMouliUtilOptions() {
			if (mouliUtilOptions == null) {
				return;
			}
			
			if (workspaceBaseBox.Text.Length > 0 && workspaceZoneBox.Text.Length > 0) {
//
				mouliUtilOptions.setNumeroMagasinIrris(magIrrisBox.Text);
				mouliUtilOptions.setWorkspacePath(workspaceBaseBox.Text);
				String path = workspaceZoneBox.Text;
				if (path.StartsWith("workspace/", StringComparison.Ordinal)) {
					path = path.Replace("workspace/", "");
				}
				mouliUtilOptions.setWorkingPath(path);
				if (!Directory.Exists(workspaceBaseBox.Text + path)) {
					toolTipLabel.Text = ("chemin absent : '" + workspaceBaseBox.Text + path + "'");
					LOGGER.Info(toolTipLabel.Text);
					return;
				}
				try {
					StreamWriter sw = new StreamWriter(workspaceBaseBox.Text + path + "magasin.txt");
					sw.Write(magIrrisBox.Text);
					sw.Close();
				} catch (Exception ex) {
					LOGGER.Error(ex);
				}
			}
			
		}
	}
}