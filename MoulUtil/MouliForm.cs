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

using cmdUtils;
using cmdUtils.Objets;

namespace MoulUtil
{
	/// <summary>
	/// Screen to pilot the work
	/// </summary>
	public partial class MouliForm : Form
	{
		private List<MeoServeur> serveurs=null;
		private List<MeoInstance> instances=null;
		private MouliJob job=null;

		public MouliForm(List<MeoServeur> serveurs, List<MeoInstance> instances, String magId, String path)
		{
			InitializeComponent();
			setServeurs(serveurs);
			setInstances(instances);
			setPath(path);
			setMagId(magId);
			prepare();
		}
		public void setServeurs(List<MeoServeur> serveurs) {
			this.serveurs=serveurs;
		}
		public void setInstances(List<MeoInstance> instances) {
			this.instances=instances;
		}
		public void prepare() {
			puttyLink.Visible=false;
			pscpLink.Visible=false;
			populateTargets(targetTreeView);
			dateTimePicker.Value = new MouliUtil().calculeNextPlannedJob();
		}
		private void populateTargets(TreeView tv) {
			if(serveurs!=null) {
				foreach(MeoServeur serveur in serveurs) {
					TreeNode node= tv.Nodes.Add (serveur.getNom());
					completeInstances(node, serveur.getNom());
					node.ExpandAll();
				}
			}
		}
		private void completeInstances(TreeNode node, String serverName) {
			foreach(MeoInstance instance in instances) {
				if (instance.getServeur()== serverName) {
					TreeNode childNode=node.Nodes.Add(instance.getNom());
				}
			}
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


		void GoButtonClick(object sender, EventArgs e)
		{
			goButton.Enabled=false;
			try {
				MouliUtilOptions options=updateMouliUtilOption(getSelectedInstance());
				job= MouliProgram.doTraitement(pathLabel.Text, options);
				//job.setzzz(pathLabel.Text);
				analyseJob(job, checkedListBox1);
				
				MouliProgram.doArchive(job);
				pscpLink.Text = "pscp ZIP" ;
				if(pscpLink.Tag!=null) {
					pscpLink.Visible=true;
				}
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
			Application.Exit();
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
			if(checkedListBox1.GetItemChecked(0)) {
			   	r+="C";
			   }
			if(checkedListBox1.GetItemChecked(1)) {
			   	r+="S";
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
		
		MouliUtilOptions updateMouliUtilOption(MeoInstance instance)
		{
			MouliUtilOptions options = new MouliUtilOptions();
			options.setInstanceCommande(instance.getMeocli());
			options.setInstanceName(instance.getNom());
			
			
//			# ici
			// options.setIsDoc01(false);
			options.setIsJoint(false);
//			# fin ici
			
			options.setLots("CS"); //todo:calculer
			options.setDateJob(dateTimePicker.Value);
			return options;
			
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
				text=node.Parent.Text;
				instance=MeoInstance.findInstanceByServerName(instances, text);
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
			// cmdUtils.
		}

		
		void UploadButtonClick(object sender, EventArgs e)
		{
			if (job!=null) {
				CmdUtil util = new CmdUtil();
				LinkLabel label = pscpLink;
				if (label.Tag!=null) {
					MeoServeur server = (MeoServeur) label.Tag;
					SshUtil sshUtil = new SshUtil();
					try {
						sshUtil.uploadArchive(server, "/database/transpo/", job.getArchiveName());
						sshUtil.unzipArchive(server, "/database/transpo/", job);
					} catch(Exception ex) {
						MessageBox.Show("Erreur envoi data : "+ex.Message + "\n"+ex.Source + "\n" +ex.StackTrace);
					}
				}
			}
		}

		void setMagId(string magId)
		{
			magIdTextBox.Text=magId;
			magIdTextBox.Enabled=false;
		}
	}
}