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
		public MouliForm()
		{
			InitializeComponent();
		}
		public void setServeurs(List<MeoServeur> serveurs) {
			this.serveurs=serveurs;
		}
		public void setInstances(List<MeoInstance> instances) {
			this.instances=instances;
		}
		public void prepare() {
			puttyLink.Visible=false;
			populateTargets(targetTreeView);
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
		void GoButtonClick(object sender, EventArgs e)
		{
			goButton.Enabled=false;
			try {
				MouliProgram.doTraitement(pathLabel.Text, null);
			} catch(Exception ex) {
				MessageBox.Show(" Exception : "+ex.Message +"\n"+ex.Source + "\n"+ex.StackTrace);
			}
			goButton.Enabled=true;
		}

		public void updateProgression(int progression)
		{
			progressBar1.Value=progression;
			progressBar1.Refresh();
		}
		public void setPath(string sourceMoulinette)
		{
			pathLabel.Text=sourceMoulinette;
		}
		void ExitButtonClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		void TargetTreeViewAfterSelect(object sender, TreeViewEventArgs e)
		{
			TreeView tv = (TreeView) sender;
			TreeNode node = tv.SelectedNode;
			int level=node.Level;
			String text =node.Text;
			String serverName=null;
			if(level==0) {
				serverName=text;
			} else if(level==1) {
				text=node.Parent.Text;
				MeoInstance instance=MeoInstance.findInstanceByServerName(instances, text);
				if(instance!=null) {
					serverName=instance.getServeur();
				}
			}
			
			if (serverName!=null) {
				MeoServeur serveur = MeoServeur.findServeurByName(serveurs, serverName);
				if (serveur!=null) {
					puttyLink.Text=("putty "+serverName);
					puttyLink.Tag=serveur; //TODO:write putty args
					puttyLink.Visible=true;
				}
			}
		}
		void PuttyLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			
			CmdUtil util = new CmdUtil();
			LinkLabel label = (LinkLabel) sender;
			if (label.Tag!=null) {
				MeoServeur server = (MeoServeur) label.Tag;
				String args=util.buildPuttyArgs(server);
				util.executeCommand(Mouliconfig.puttyPath, args);
			}
		}
		
	}
}

