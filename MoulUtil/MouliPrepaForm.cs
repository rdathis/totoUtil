/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/10/2016
 * Heure: 13:28:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
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
				MouliForm form = new MouliForm(configDto.getServeurs(), configDto.getInstances(), workspaceBox.Text);
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
	}
}
