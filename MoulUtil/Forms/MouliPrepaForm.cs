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
using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
		//protected String magasinUrl="";
		private MouliSQLForm sqlForm;
		private MouliUtil mouliUtil = null;
		private MouliUtilOptions options = null;
		protected CmdUtil cmdUtil = null;
		private RegistryUtil registryUtil=null;
		public MouliPrepaForm(ConfigDto configDto)
		{
			InitializeComponent();
			this.rechMagIdBox.Visible=false;
			registryUtil=new RegistryUtil();
			String workspacePath=registryUtil.getHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key);
			mouliPrepaUtil = new MouliPrepaUtil(this, configDto);
			this.configDto = configDto;
			if(!String.IsNullOrEmpty( workspacePath)) {
				workspacePath+= ""+configDto.getWorkingDir().Replace("\\", "/");
			} else {
				workspacePath=configDto.getWorkingDir();
			}
			
			this.workingDirBox.Text=workspacePath;
			mouliUtil = new MouliUtil();
			cmdUtil=new CmdUtil();
			new TreeViewUtil(configDto.instances,configDto.serveurs).populateTargets(targetTreeView);
			//
			zonePrepaNavigatorUserControl.setBox(workspaceBaseBox);
			workspaceNavigatorUserControl.setBoxes(workspaceBaseBox, workspaceZoneBox);
			svgBaseNavigatorUserControl.setBox(targetSvgPathBox);
			svgFinalNavigatorUserControl.setBoxes(targetSvgPathBox, targetNameBox);
			
			rechMagIdBox.Focus();
		}

		public void controleRegistre()
		{
			if(! registryUtil.existsHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key) ) {;
				Console.WriteLine("Creation de la clef de registre");
				registryUtil.setHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key, Directory.GetCurrentDirectory() + "\\");
			}
		}

		void MouliPrepaLoad(object sender, EventArgs e)
		{
			plinkProcess= mouliPrepaUtil.startPlink(configDto, rechMagIdBox);
		}
		void WorkspaceBoxTextChanged(object sender, EventArgs e)
		{
			mouliUtil.safeCreateDirectory( configDto.getWorkingDir());
		}
		void PrepareBtnClick(object sender, EventArgs e)
		{
			if(options==null) return;
			if (workspaceBaseBox.Text.Length > 0 && workspaceZoneBox.Text.Length > 0) {
				MouliActionForm form = new MouliActionForm(options, configDto, workspaceZoneBox.Text);
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
			
			String sourceDir=workspaceBaseBox.Text+""+workspaceZoneBox.Text;
			String targetDir = Path.GetFullPath(targetSvgPathBox.Text)+"\\" + targetNameBox.Text;
			//mouliUtil.createArbo(targetDir);
			//copier le resultat.zip dans le sousrep,
			//generer un zip du rep tmp dans le sousrep. (comment le nommer ?)
			sauvegardeBtn.Enabled=false;
			statusStrip1.Text = "Préparation de la sauvegarde ...";
			String tmpDir=Path.GetFullPath(targetDir).Replace('/', '\\');
			tmpDir = new DirectoryInfo(tmpDir).Parent.FullName;
			if(!Directory.Exists(tmpDir)) {
				mouliUtil.safeCreateDirectory(tmpDir);
			}
			Console.WriteLine("->"+tmpDir);
			cmdUtil.executeCommande("explorer", tmpDir);
			
			SauvegardeBackgroundWorker worker = getSauvegardeBackgroundWorker();
			
			//statusStrip1, sauvegardeBtn, sauvegardeProgressTextBox
			MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = name => {
				//Console.WriteLine("Notification received for: {0}", name);
				//?? plantage: toolStripStatusLabel1.Text = name;
				try {
					statusStrip1.Text = "begin";
					sauvegardeBtn.Visible=false;
					sauvegardeProgressTextBox.Text=" debut";
					//toolStripProgressBar1.Value=0;
				} catch (Exception ex) {
					Console.WriteLine("still exception here ..."+ex.Message);
				}
			};
			MouliProgressWorker.ProgressWorkerCallBack progressWorkerCallBack = value =>  {
				//if(value<=100) sauvegardeProgressTextBox.Value =value;//bug
				double prc=0;
				if( worker.getNbOperation()!=0) {
					prc = value / ((double)worker.getNbOperation()) * 100;
					prc = Math.Round(prc, 3) ;
				}
				sauvegardeProgressTextBox.Text = (value +" / "+worker.getNbOperation()+  " ("+prc+")%");
				statusStrip1.Text = "progression : "+(value)  + "%  - x / "+worker.getNbOperation();
				sauvegardeProgressTextBox.Text=statusStrip1.Text ;
			};
			MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
				sauvegardeBtn.Visible=true;
				//statusStrip1.Text = "fini";
				sauvegardeProgressTextBox.Text = "fini";
			};
			//
			worker.setStartWorkerCallBack(startWorkerCallBack);
			worker.setProgressWorkerCallBack(progressWorkerCallBack);
			worker.setEndWorkerCallBack(endWorkerCallBack);
			
			
			
			worker.prepare(mouliPrepaUtil, options, sourceDir, targetSvgPathBox.Text);
			worker.RunWorkerAsync();
			//mouliPrepaUtil.sauvegardeMoulinette(sourceDir, targetSvgPathBox.Text, options, sauveMoulinetteBackgroundWorker);
			//statusStrip1.Text = "sauvegarde terminée...";
			//sauvegardeBtn.Enabled=true;

			//TODO:copy src files to target dir.
		}
		void RechMagIdBtnClick(object sender, EventArgs e)
		{
			rechercheMagasin();
		}

		void rechercheMagasin() {
			String workingPath=workspaceBaseBox.Text;
			options=mouliPrepaUtil.rechercheMagasin(rechMagIdBox, magDescBox, propositionBox, workingPath, sqlBtn);
			if(options!=null) {
				calculeMoulinettePath();
				String path=workspaceZoneBox.Text;
				options.setArchiveName(mouliUtil.calculeArchiveName(path ));
				Console.WriteLine("name: "+options.getarchiveName());
			}

		}

		public void CreateBtnClick(object sender, EventArgs e)
		{
			String proposition = propositionBox.Text;
			if (proposition.Length > 0) {
				mouliUtil.createArbo(proposition);
				cmdUtil.executeCommande("explorer", Path.GetFullPath(proposition));
			}
		}
		void CopyBtnClick(object sender, EventArgs e)
		{
			calculeMoulinettePath();
		}
		
		///TODO:move in MPUtil
		private String calculeMoulinettePath() {
			String str = propositionBox.Text.Trim();
			if (str.Length > 0) {
				String subPath="MEO"+DateTime.Now.Year+"/";
				mouliUtil.safeCreateDirectory(targetSvgPathBox.Text+"/"+subPath);
				workspaceZoneBox.Text = str;
				targetNameBox.Text = subPath+ str.Replace(workingDirBox.Text, "");
			}
			return str;
		}
		void MouliPrepaFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(plinkProcess!=null) {
				plinkProcess.Close();
			}
		}
		void SqlBtnClick(object sender, EventArgs e)
		{
			sqlForm = new MouliSQLForm(this.rechMagIdBox.Text, options);
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
				} catch(Exception ex) {
					Console.WriteLine(ex.Message);
					//reportError(ex);
				}
			}

		}
		void TargetTreeViewDoubleClick(object sender, EventArgs e)
		{
			actionPutty(targetTreeView);
		}
		MeoServeur getSelectedServeur(TreeView tv) {
			TreeNode node = tv.SelectedNode;
			int level=node.Level;
			String text =node.Text;
			MeoServeur meoServeur =null;

			if(level==0) {
				meoServeur = MeoServeur.findServeurByName(configDto.serveurs, text);
			}
			return meoServeur;
		}
		MeoInstance getSelectedInstance(TreeView tv)
		{
			TreeNode node = tv.SelectedNode;
			int level=node.Level;
			String text =node.Text;
			String serverName=null;
			MeoInstance instance=null;

			
			if(level==0) {
				serverName=text;
			} else if(level==1) {
				instance=MeoInstance.findInstanceByInstanceName(configDto.instances, text);
				if(instance!=null) {
					serverName=instance.getServeur();
				}
			}
			return instance;
		}
		void TargetTreeViewMouseClick(object sender, MouseEventArgs e)
		{
			
			if(e.Button==System.Windows.Forms.MouseButtons.Right) {
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
			MeoServeur meoServeur= null;
			MeoInstance meoInstance = getSelectedInstance(treeView);
			if(meoInstance!=null) {
				meoServeur = MeoServeur.findServeurByName(configDto.serveurs, meoInstance.serveur);
			} else {
				meoServeur = 	getSelectedServeur(treeView);
			}
			if(meoServeur!= null) {
				String args=cmdUtil.buildPuttyArgs(meoServeur);
				cmdUtil.executeCommandAsDetachedProcess(MouliConfig.puttyPath, args);
			}
		}
		
		void HistoryLabelClick(object sender, EventArgs e)
		{
			ConfigParam param = configDto.getConfigParamByName(ConfigParam.ParamNamesType.history);
			if(param!=null) {
				mouliPrepaUtil.startBrowser(param.Value);
			} else {
				//historyLabel.Enabled=false;
			}
		}
		private SauvegardeBackgroundWorker getSauvegardeBackgroundWorker() {
			SauvegardeBackgroundWorker worker = new SauvegardeBackgroundWorker();
			worker.WorkerSupportsCancellation = true;
			worker.WorkerReportsProgress = true;
			worker.DoWork +=new DoWorkEventHandler(worker.sauvegardeBW_DoWork);
			worker.ProgressChanged += new ProgressChangedEventHandler(worker.sauvegardeBW_ProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker.sauvegardeBW_RunWorkerCompleted);
			return worker;
		}
	}
}