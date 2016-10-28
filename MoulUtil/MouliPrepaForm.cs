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
using System.Drawing;
using System.Windows.Forms;
using Renci.SshNet;
using cmdUtils;
using cmdUtils.Objets;

namespace MoulUtil
{
	/// <summary>
	/// Description of MouliPrepa.
	/// </summary>
	public partial class MouliPrepaForm : Form
	{
		private ConfigDto configDto;
		public MouliPrepaForm(ConfigDto configDto)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.configDto=configDto;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MouliPrepaLoad(object sender, EventArgs e)
		{
		}
		void WorkspaceBoxTextChanged(object sender, EventArgs e)
		{
		}
		void PrepareBtnClick(object sender, EventArgs e)
		{
			if(workspaceBaseBox.Text.Length>0 && workspaceBox.Text.Length > 0) {
				MouliForm form = new MouliForm(configDto.getServeurs(), configDto.getInstances(), "?", workspaceBox.Text);
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
			workspaceBox.Text=sourceMoulinette;
		}
		void SauvegardeBtnClick(object sender, EventArgs e)
		{
			//TODO:
		}
		void RechMagIdBtnClick(object sender, EventArgs e)
		{
			List <MeoServeur> serveurs = configDto.getServeurs();
			
			// TODO:find serveur, tunnel SSH pour mysql
			MeoServeur adminServeur=MeoServeur.findServeurByName(serveurs, "meo1");
			SshClient sshClient = getAdminServeur(adminServeur);
			MyUtil myUtil = new MyUtil();
			//TODO:add in config dto
			String user="";
			String pwd="";
			String sql="";
			String database="";
			
			String cnxString=myUtil.buildconnString(database, "127.0.0.1", user, pwd, 23306);
			sql="select a from b where c="+rechMagIdBox.Text;
			List<String> result =myUtil.getListResultSimple(cnxString, sql);
			if (result.Count == 1) {
				magDescBox.Text = result[0];
			}
		}
		private static SshClient getAdminServeur(MeoServeur serveur) {
			
			SshUtil sshUtil = new SshUtil();
			List<KeyValuePair<int, int>>portsList = new List<KeyValuePair<int, int>>();
			portsList.Add(new KeyValuePair<int, int>(3306, 23306));
			return sshUtil.getClientWithForwardedPorts(serveur, portsList);
		}		
	}
}
