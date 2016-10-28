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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
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
			this.configDto = configDto;
			
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
			if (workspaceBaseBox.Text.Length > 0 && workspaceBox.Text.Length > 0) {
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
			workspaceBox.Text = sourceMoulinette;
		}
		void SauvegardeBtnClick(object sender, EventArgs e)
		{
			//TODO:
		}
		void RechMagIdBtnClick(object sender, EventArgs e)
		{
			rechercheMagasin();
		}
		void rechercheMagasin()
		{
			List <MeoServeur> serveurs = configDto.getServeurs();
			
			MeoServeur adminServeur = MeoServeur.findServeurByName(serveurs, "meo1");
			SshClient sshClient = null;
			//sshClient = getAdminServeur(adminServeur);
			MyUtil myUtil = new MyUtil();
			String user = configDto.getDatabaseAdminUser();
			String pwd = configDto.getDatabaseAdminPwd();
			String sql = configDto.getSQL01();
			String database = configDto.getDatabaseAdminName();
			int port = 23306;
			String s = "connected by SSH \r\n";
			String proposition = "";
			// HACK:crado code
			if (sshClient == null) {
				s = "local database \r\n";
				pwd = configDto.getDefaultPassword();
				;
				port = 3306;
			}
			String cnxString = myUtil.buildconnString(database, "127.0.0.1", user, pwd, port);
			sql = sql + " WHERE magasin_id=" + rechMagIdBox.Text;
			try {
				var magasinList = myUtil.getListResultAsKeyValue(cnxString, sql);
				magDescBox.Text = "";
				
				magDescBox.Text = s;
				List<KeyValuePair<String, Object>> ligne = magasinList[0];
				if (ligne.Count > 0) {
					proposition = ligne[0].Value.ToString().Replace(" ", "");
					proposition = "MID" + rechMagIdBox.Text.Trim() + "-" + proposition + "/";
				}
				
				for (int i = 0; i < ligne.Count; i++) {
					KeyValuePair<String, Object> item = ligne[i];
					s += "[" + item.Key + "] = '" + item.Value + "' \r\n";
				}
				magDescBox.Text = s;
				propositionBox.Text = proposition;
			} catch (Exception ex) {
				magDescBox.Text = "erreur :" + ex.Message + "\n" + ex.Source;
			}
			
			if (sshClient != null) {
				sshClient.Disconnect();
			}
		}
		private static SshClient getAdminServeur(MeoServeur serveur)
		{
			SshUtil sshUtil = new SshUtil();
			List<KeyValuePair<int, int>> portsList = new List<KeyValuePair<int, int>>();
			portsList.Add(new KeyValuePair<int, int>(23306, 3306));
			return sshUtil.getClientWithForwardedPorts(serveur, portsList);
		}
		void RechMagIdBoxTextChanged(object sender, EventArgs e)
		{
			rechercheMagasin();
		}
		void CreateBtnClick(object sender, EventArgs e)
		{
			String proposition = propositionBox.Text;
			if (proposition.Length > 0) {
				MouliUtil mouliUtil = new MouliUtil();
				mouliUtil.createArbo(proposition);
				CmdUtil cmdUtil = new CmdUtil();
				
				
				
				cmdUtil.executeCommande("explorer", Path.GetFullPath(proposition));
			}
		}
	}
}
