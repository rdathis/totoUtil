/*
 * Utilisateur: Renaud
 * Date: 03/14/2017
 * Heure: 13:29
 * 
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using cmdUtils.Objets;

namespace EcUtil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class ECUtilMainForm : Form
	{
		MouliUtil mouliUtil = new MouliUtil();
		CmdUtil cmdUtils = new CmdUtil();
		public ECUtilMainForm()
		{
			InitializeComponent();
			populate();
			
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			
		}

		void populateWorkspaces(string text)
		{
			String [] tab = System.IO.Directory.GetDirectories(text,"w*");
			for(int i=0;i<tab.Length;i++) {
				wkspacesLView.Items.Add(tab[i]);
			}
		}

		private void populate() {
			workspacesBaseLabel.Text="m:/workspaces/";
			ecPathLabel.Text="m:/eclipse-2016/eclipse.exe";
			populateWorkspaces(workspacesBaseLabel.Text);
		}
		private String getWorkspace() {
			String value=null;
			if(wkspacesLView.SelectedItems.Count > 0) {
				value = wkspacesLView.SelectedItems[0].Text;
			}
			return value;
		}
		void WkspacesLViewDoubleClick(object sender, EventArgs e)
		{
			String value = getWorkspace();
			if(value != null) {
				String cmd=ecPathLabel.Text;
				String args = value;
				args=" -data \""+args+"\"";
				Debug.Print(" cmd : "+cmd +" args : "+args);
				
				cmdUtils.executeCommandAsDetachedProcess(cmd, args);
				if(!stayAliveCheckBox.Checked) {
					Application.Exit();
				}
			}
		}
		
		void WkspacesLViewClick(object sender, EventArgs e)
		{
			String value=getWorkspace();
			newNameBox.Text = value;
			copyBtn.Text = "&Copy "+value +" as : ";
		}
		
	}
}
