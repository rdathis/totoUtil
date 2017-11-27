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
using System.IO;

namespace EcUtil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class ECUtilMainForm : Form
	{
		//MouliUtil mouliUtil = new MouliUtil();
		CmdUtil cmdUtils = new CmdUtil();
		List<String> files = new List<string>();
		List<String> directories = new List<string>();

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
			wkspacesLView.Items.Clear();
			for(int i=0;i<tab.Length;i++) {
				wkspacesLView.Items.Add(tab[i]);
			}
		}

		private void populate() {
			cmdTextBox.ReadOnly=true;
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
				majCmd(cmd + " "+args);
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

		private Boolean confirmBox(String msg, String title) {
			DialogResult result= MessageBox.Show(msg, title, MessageBoxButtons.OKCancel);
			return (result==DialogResult.OK);
		}
		void actionCopy(string wSrc, string wTgt, bool copyREcl, bool copyDevProp)		{
			try {
				if(Directory.Exists(wTgt)) {
					if(!confirmBox("la cible existe déjà ("+wTgt+"), ok pour supprimer ?", "confirmez")) {
						return;
					}
					progressLabel.Text = "deleting "+wTgt;
					Directory.Delete(wTgt, true);
				}
				Directory.CreateDirectory(wTgt);
				FileCopyUtil fileCopyUtil = new FileCopyUtil();
				progressLabel.Text = "copying "+wSrc+" -> "+wTgt;
				fileCopyUtil.DirectoryCopy(wSrc, wTgt, true);
				if(parsePreferences()) {
					String detail = "";
					detail+=" directories:\n";
					foreach(String str in directories) {
						detail+=" * "+str+"\n";
					}
					detail+=" files:\n";
					foreach(String str in files) {
						detail+=" * "+str+"\n";
					}
					
					if(confirmBox("appliquer les préférences ("+detail+") ?", "confirmez")) {
						//
						foreach(String str in directories) {
							progressLabel.Text = "copying "+wSrc+str+" -> "+wTgt+str;
							fileCopyUtil.DirectoryCopy(wSrc+str, wTgt+str, true);
						}
						//
						foreach(String str in files) {
							String tmpStr=str.Trim();
							int x = tmpStr.IndexOf(" ");
							if(x>0) {
								String fileName = tmpStr.Substring(0, x).Trim();
								String pathName =  tmpStr.Substring(x).Trim();
								
								if((File.Exists("preferences/"+fileName) && (Directory.Exists(wTgt+pathName)))) {
									progressLabel.Text = "copying "+"preferences/"+fileName+" -> "+wTgt+pathName;
									File.Copy("preferences/"+fileName, wTgt+pathName, true);
								}
								
								
							}
						}
					}
					
				}
			} catch(Exception exception) {
				MessageBox.Show("Erreur duplication : \n"+exception.Message+"\n\n"+exception.StackTrace);
			}
		}

		void CopyBtnClick(object sender, EventArgs e)
		{
			actionCopy(getWorkspace(), newNameBox.Text, copyREclipChBox.Checked, copyDevePropChBox.Checked);
			populate();
		}

		private Boolean parsePreferences() {
			files.Clear();
			directories.Clear();
			const String wordFile="file";
			const String wordDirectory="directory";
			const String preferenceFile="preferences/fichiers.conf";
			//
			if(File.Exists(preferenceFile)) {
				String [] lst = File.ReadAllLines(preferenceFile);
				for(int i=0;i<lst.Length;i++) {
					String line = lst[i].Trim();
					// disable once StringStartsWithIsCultureSpecific
					if(line.StartsWith(wordFile)) {
						line = line.Substring(wordFile.Length).Trim();
						files.Add(line);
						// disable once StringStartsWithIsCultureSpecific
					} else if (line.StartsWith(wordDirectory)) {
						line = line.Substring(wordDirectory.Length).Trim();
						directories.Add(line);
					}
				}
				return true;
			} else {
				return false;
			}
		}
		void WkspacesLViewSelectedIndexChanged(object sender, EventArgs e)
		{
			String value = getWorkspace();
			if(value != null) {
				String cmd=ecPathLabel.Text;
				String args = value;
				args=" -data \""+args+"\"";
				Debug.Print(" cmd : "+cmd +" args : "+args);
				majCmd(cmd + " "+args);
				
			}
		}
		private void majCmd(String cmd) {
			cmdTextBox.Text = cmd.Replace("/", "\\");;
		}
	}
}
