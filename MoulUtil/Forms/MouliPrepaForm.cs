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
using System.IO;
using System.Windows.Forms;
using cmdUtils.Objets;
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
		private String magasinUrl="";
		private MouliSQLForm sqlForm;
		MouliUtilOptions options = null;
		public MouliPrepaForm(ConfigDto configDto)
		{
			InitializeComponent();
			mouliPrepaUtil = new MouliPrepaUtil(this, configDto);
			this.configDto = configDto;
			this.workingDirBox.Text=configDto.getWorkingDir();
			new TreeViewUtil(configDto.instances,configDto.serveurs).populateTargets(targetTreeView);
		}
		void MouliPrepaLoad(object sender, EventArgs e)
		{
			plinkProcess= mouliPrepaUtil.startPlink(configDto);
		}
		void WorkspaceBoxTextChanged(object sender, EventArgs e)
		{
			MouliUtil mouliUtil = new MouliUtil();
			mouliUtil.safeCreateDirectory( configDto.getWorkingDir());
		}
		void PrepareBtnClick(object sender, EventArgs e)
		{
			if(options==null) return;
			if (workspaceBaseBox.Text.Length > 0 && workspaceBox.Text.Length > 0) {
				MouliActionForm form = new MouliActionForm(options, configDto, workspaceBox.Text, magasinUrl);
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
			String targetDir = Path.GetFullPath(targetSvgPathBox.Text)+"\\" + targetNameBox.Text;
			MouliUtil mouliUtil = new MouliUtil();
			mouliUtil.createArbo(targetDir);
			CmdUtil cmdUtil = new CmdUtil();
			cmdUtil.executeCommande("explorer", Path.GetFullPath(targetDir));
			//TODO:copy src files to target dir.
		}
		void RechMagIdBtnClick(object sender, EventArgs e)
		{
			rechercheMagasin();
		}

		void rechercheMagasin() {
			options=mouliPrepaUtil.rechercheMagasin(rechMagIdBox, magDescBox, propositionBox, sqlBtn);
		}

		public void CreateBtnClick(object sender, EventArgs e)
		{
			String proposition = propositionBox.Text;
			if (proposition.Length > 0) {
				MouliUtil mouliUtil = new MouliUtil();
				mouliUtil.createArbo(proposition);
				CmdUtil cmdUtil = new CmdUtil();
				
				cmdUtil.executeCommande("explorer", Path.GetFullPath(proposition));
			}
		}
		void CopyBtnClick(object sender, EventArgs e)
		{
			String str = propositionBox.Text.Trim();
			if (str.Length > 0) {
				workspaceBox.Text = str;
				targetNameBox.Text = str;
			}
		}
		void MouliPrepaFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(plinkProcess!=null) {
				plinkProcess.Close();
			}
		}
		void SqlBtnClick(object sender, EventArgs e)
		{
			MeoInstance meoInstance = MeoInstance.findInstanceByMeoURL(configDto.instances, magasinUrl); // convertitInstance(string url);
			sqlForm = new MouliSQLForm(this.rechMagIdBox.Text, meoInstance);
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
			Console.WriteLine("putty asked");
			//retrouver l'objet recu
			// trouver le serveur, et faire un putty dedans
		}
		void RechMagIdBoxEnter(object sender, EventArgs e)
		{
			//marche seulement qd vide.
			rechercheMagasin();
		}
		void RechMagIdBoxValidated(object sender, EventArgs e)
		{
			//ne marche pas
			rechercheMagasin();
		}
	}
}
