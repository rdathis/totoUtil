/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 02/09/2016
 * Heure: 16:23:52
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MoulUtil.Forms.utils;
using cmdUtils;
using cmdUtils.Objets;

namespace MoulUtil
{
	/// <summary>
	/// Screen to pilot the work
	/// </summary>
	public partial class MouliActionForm : Form
	{
		private List<MeoServeur> serveurs=null;
		private List<MeoInstance> instances=null;
		private MouliJob job=null;
		private ConfigDto configDto;
		private String magId=null;
		private MouliUtilOptions options=null;

		public MouliActionForm(MouliUtilOptions options, ConfigDto configDto, string path)
		{
			InitializeComponent();
			this.options=options;
			setConfigDto(configDto);
			setServeurs(configDto.getServeurs());
			setInstances(configDto.getInstances());
			setPath(path);
			setMagId(options.getMagId());
			setMagasinIrris("01");
			
			prepare();
			setMeoInstance(options.getInstanceName());
		}

		// disable once ParameterHidesMember
		void setConfigDto(ConfigDto configDto)	{
			this.configDto=configDto;
		}

		public void setServeurs(List<MeoServeur> serveurs) {
			this.serveurs=serveurs;
		}

		void setMagasinIrris(string str)
		{
			irrisMagTBox.Text=str;
		}

		public void setInstances(List<MeoInstance> instances) {
			this.instances=instances;
		}
		public void prepare() {
			puttyLink.Visible=false;
			pscpLink.Visible=false;
			targetTreeView.Enabled = false;
			new TreeViewUtil(instances, serveurs).populateTargets(targetTreeView);
			
			dateTimePicker.Value = new MouliUtil().calculeNextPlannedJob();
			
			activeExtension(purgeClientChkBox, options.getExtensionClient());
			activeExtension(purgeStockChkBox, options.getExtensionStock());
		}

		void activeExtension(CheckBox chkBox, MoulinettePurgeOptionTypes moulinettePurgeOptionTypes)
		{
			Boolean value=true;
			if(MoulinettePurgeOptionTypes.CLIENT_POSSEDE_EXTENSION==moulinettePurgeOptionTypes) {
				value=false;
			}
			chkBox.Enabled=value;
			chkBox.Checked=value;
			
		}
		// disable once ParameterHidesMember
		void analyseJob(MouliJob job, CheckedListBox box)
		{
			if (job!=null) {
				MouliStatRecap recap = job.getStatRecap();
				if (recap!=null) {
					//[0]client [1]stock [2]joint [3]ord01
					box.SetItemChecked(0, (recap.mag01FilesTotal> 0));
					box.SetItemChecked(1, box.GetItemChecked(0));
					box.SetItemChecked(2,(recap.jointDocsTotal > 0));
					box.SetItemChecked(3,(recap.ord01DocsTotal> 0));
					// box.SetItemChecked(4,(recap.doc01DocsTotal> 0));
				}
			}
		}


		private void toto(String str) {
			
		}
		void GoButtonClick(object sender, EventArgs e)
		{
			
			
			goButton.Enabled=false;
			uploadButton.Enabled = false;
			toolStripStatusLabel1.Text = "doing archive";
			try {
				options=updateMouliUtilOption(getSelectedInstance());
				job= MouliProgram.doTraitement(pathLabel.Text, options);
				//job.setzzz(pathLabel.Text);
				analyseJob(job, checkedListBox1);
				//progressTextBox.inv
				CreateArchiveBackgroundWorker worker = CreateArchiveBackgroundWorker.createWorker();
				worker.prepare(job);
				
				MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = name => {
					//Console.WriteLine("Notification received for: {0}", name);
					//?? plantage: toolStripStatusLabel1.Text = name;
					try {
						progressTextBox.Text=" debut";
						toolStripProgressBar1.Value=0;
					} catch (Exception ex) {
						Console.WriteLine("still exception here ..."+ex.Message);
					}
				};
				MouliProgressWorker.ProgressWorkerCallBack progressWorkerCallBack = value =>  {
					if(value<=100) toolStripProgressBar1.Value =value;//bug
					toolStripStatusLabel1.Text = "progression : "+(value)  + "%  - x / "+worker.getNbOperation();
					progressTextBox.Text=toolStripStatusLabel1.Text ;
				};
				MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
					toolStripStatusLabel1.Text = "fini";
					toolStripProgressBar1.Value=0;
					goButton.Enabled=true;
					uploadButton.Enabled = true;
					if(pscpLink.Tag!=null) {
						pscpLink.Visible=true;
					}
				};
				//
				worker.setStartWorkerCallBack(startWorkerCallBack);
				worker.setProgressWorkerCallBack(progressWorkerCallBack);
				worker.setEndWorkerCallBack(endWorkerCallBack);
				//
				job.setBackgroundWorker(worker);
				worker.RunWorkerAsync();

			} catch(Exception ex) {
				MessageBox.Show(" Exception : "+ex.Message +"\n"+ex.Source + "\n"+ex.StackTrace);
			}
			goButton.Enabled=true;
		}

		public void updateProgression(int progression)
		{
			//progressBar1.Value=progression;
			// progressBar1.Refresh();
			toolStripProgressBar1.Value=progression;
			
			
		}
		public void setPath(string sourceMoulinette)
		{
			pathLabel.Text=sourceMoulinette;
			pathTextBox.Text=sourceMoulinette;
			pathTextBox.Enabled=false;
			
		}
		void ExitButtonClick(object sender, EventArgs e)
		{
			//Application.Exit();
			Hide();
		}
		void TargetTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeView tv = (TreeView) sender;
			String serverName=null;
			MeoInstance instance = getSelectedInstance(tv);
			String instanceName="";
			if(instance!=null) {
				serverName=instance.getServeur();
				instanceName=instance.getNom();
			}
			
			if (serverName!=null) {
				MeoServeur serveur = MeoServeur.findServeurByName(serveurs, serverName);
				if (serveur!=null) {
					puttyLink.Text=("putty "+serverName);
					puttyLink.Tag=serveur;
					pscpLink.Tag=serveur;
					puttyLink.Visible=true;
					
					
					targetLabel.Text = "-> "+serverName+ "/"+instanceName;
					targetLabel.Text+=getRecapWork();
					targetLabel.BackColor=Color.Beige;
					targetLabel.ForeColor=Color.Red;
					
					if (job!=null) {
						pscpLink.Visible=true;
					}
				}
			}
		}
		//UGLY CODE
		String getRecapWork() {
			String r="";
			if(checkedListBox1.GetItemChecked(1)) {
				r+="S";//S before C (201703:LH)
			}
			if(checkedListBox1.GetItemChecked(0)) {
				r+="C";
			}
			if(checkedListBox1.GetItemChecked(2)) {
				r+="J";
			}
			if(checkedListBox1.GetItemChecked(2)) {
				r+="D";
			}
			return r;
		}
		void PuttyLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			
			CmdUtil util = new CmdUtil();
			LinkLabel label = (LinkLabel) sender;
			if (label.Tag!=null) {
				MeoServeur server = (MeoServeur) label.Tag;
				String args=util.buildPuttyArgs(server);
				util.executeCommande(MouliConfig.puttyPath, args);
			}
		}
		void PscpLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (job!=null) {
				CmdUtil util = new CmdUtil();
				LinkLabel label = (LinkLabel) sender;
				if (label.Tag!=null) {
					MeoServeur server = (MeoServeur) label.Tag;
					String args=util.buildPscpArgs(server, job);
					util.executeCommande(MouliConfig.pscpPath, args);
				}
			}
		}
		void PuttyLinkClick(object sender, EventArgs e)
		{
			//TODO:check if usefull
		}

		private string calculateLots()
		{
			String retour="";
			CheckedListBox  box = checkedListBox1;
			if(box.GetItemChecked(0)) {
				retour+="C";
			}
			if(box.GetItemChecked(1)) {
				retour+="S";
			}
			if(box.GetItemChecked(2)) {
				retour+="J";
			}
			if(box.GetItemChecked(3)) {
				retour+="D";
			}
			return retour;

		}
		MouliUtilOptions updateMouliUtilOption(MeoInstance instance)
		{
			options = new MouliUtilOptions();
			options.setInstanceCommande(instance.getMeocli());
			options.setInstanceName(instance.getNom());
			
			options.setIsJoint(false);
			options.setDefaultEmail(configDto.getDefaultEmail());
			
			options.setLots(calculateLots()); //todo:calculer
			options.setDateJob(dateTimePicker.Value);
			options.setNumeroMagasinIrris(irrisMagTBox.Text);
			options.setMagId(magId);
			
			options.setExtensionClient(calculExtension(purgeClientChkBox));
			options.setExtensionStock(calculExtension(purgeStockChkBox));
			return options;
		}

		MoulinettePurgeOptionTypes calculExtension(CheckBox checkBox)
		{
			if(checkBox.Enabled) {
				if(checkBox.Checked) {
					return MoulinettePurgeOptionTypes.PURGE_DEMANDEE;
				} else {
					return MoulinettePurgeOptionTypes.PURGE_REFUSEE;
				}
				
			} else {
				return MoulinettePurgeOptionTypes.CLIENT_POSSEDE_EXTENSION;
			}
			
		}
		MeoInstance getSelectedInstance()
		{
			return getSelectedInstance(targetTreeView);
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
				instance=MeoInstance.findInstanceByInstanceName(instances, text);
				if(instance!=null) {
					serverName=instance.getServeur();
				}
			}
			return instance;
		}
		void CmdLabelClick(object sender, System.EventArgs e)
		{
			CmdUtil util = new CmdUtil();
			util.launchWindowsCmd();
		}

		
		void UploadButtonClick(object sender, EventArgs e)
		{
			if (job!=null) {
				toolStripStatusLabel1.Text = "uploading archive...";
				CmdUtil util = new CmdUtil();
				LinkLabel label = pscpLink;
				if (label.Tag!=null) {
					MeoServeur server = (MeoServeur) label.Tag;
					SshUtil sshUtil = new SshUtil();
					try {
						sshUtil.uploadArchive(server, "/database/transpo/", job.getArchiveName());
						toolStripStatusLabel1.Text = "done, unzip...";
						sshUtil.unzipArchive(server, "/database/transpo/", job);
						
						MouliUtil mouliUtil = new MouliUtil();
						
						CmdUtil cmdUtil = new CmdUtil();
						String cmd=mouliUtil.getUnzipCmd(server, "/database/transpo/", job);
						String commandeFile = job.getMoulinettePath() +"install.file";
						mouliUtil.writeInstallMoulinetteFile(cmd, commandeFile);
						// plink -pw (password) -l (user) -m (command.file) server
						cmd="-pw "+server.password+" -l "+server.utilisateur+" -m "+commandeFile+" "+server.adresse;
						
						cmdUtil.executeCommande(MouliConfig.plinkPath, cmd);
						
						toolStripStatusLabel1.Text="finished";
					} catch(Exception ex) {
						MessageBox.Show("Erreur envoi data : "+ex.Message + "\n"+ex.Source + "\n" +ex.StackTrace);
					}
				}
			}
		}

		// disable once ParameterHidesMember
		void setMagId(string magId)
		{
			this.magId=magId;
			magIdTextBox.Text=magId;
			magIdTextBox.Enabled=false;
		}

		void setMeoInstance(string instanceName)
		{
			MeoInstance instance = MeoInstance.findInstanceByInstanceName(instances, instanceName);
			TreeView tv = targetTreeView;
			if(instance!=null) {
				foreach (TreeNode serveurNode in tv.Nodes) {
					foreach(TreeNode instanceNode in serveurNode.Nodes) {
						System.Diagnostics.Debug.Print("dbg:" + instanceNode.Text + "/"+instance.getNom());
						if(instanceNode.Text == instance.getNom()) {
							tv.SelectedNode=instanceNode;
							return; // pas break, car 2 foreach()
						}
					}
				}
			}
		}
		void CheckedListBox1ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(!CheckState.Checked.Equals(e.NewValue)) {
				return;
			}
			int newidx=e.Index;
			int oldIdx=0;
			if(newidx==2) {
				oldIdx=3;
			} else if(newidx==3) {
				oldIdx=2;
			} else {
				return;
			}
			bool newv=checkedListBox1.GetItemChecked(newidx);
			bool oldv=checkedListBox1.GetItemChecked(oldIdx);
			if(checkedListBox1.GetItemChecked(oldIdx)) {
				checkedListBox1.SetItemChecked(oldIdx, false);
			}
		}
		void TargetTreeViewDoubleClick(object sender, EventArgs e)
		{
			targetTreeView.Enabled = true;
		}
	}
}