﻿/*
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
using System.Net.Mime;
using System.Runtime.InteropServices;
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
		//protected String magasinUrl="";
		private MouliSQLForm sqlForm;
		private MouliUtil mouliUtil = null;
		private MouliUtilOptions options = null;
		protected CmdUtil cmdUtil = null;
		public MouliPrepaForm(ConfigDto configDto)
		{
			InitializeComponent();
			mouliPrepaUtil = new MouliPrepaUtil(this, configDto);
			this.configDto = configDto;
			this.workingDirBox.Text=configDto.getWorkingDir();
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
		void MouliPrepaLoad(object sender, EventArgs e)
		{
			plinkProcess= mouliPrepaUtil.startPlink(configDto);
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
			String targetDir = Path.GetFullPath(targetSvgPathBox.Text)+"\\" + targetNameBox.Text;
			mouliUtil.createArbo(targetDir);
			//copier le resultat.zip dans le sousrep,
			//generer un zip du rep tmp dans le sousrep. (comment le nommer ?)
			cmdUtil.executeCommande("explorer", Path.GetFullPath(targetDir));
			try {
				if(options!=null) {
					String subPath="MEO"+DateTime.Now.Year+"/";
					String path=targetSvgPathBox.Text+"/"+subPath;
					String fileName=new FileInfo(options.getarchiveName()).Name;
					
					Console.WriteLine("path:"+path);
					Console.WriteLine("path:"+Path.GetFullPath(path));
					Console.WriteLine("fileName:"+fileName);
					File.Copy(options.getarchiveName(), Path.GetFullPath(path)+fileName, true);
					
				}
			} catch(Exception exception) {
				MessageBox.Show("Erreur de copie de vers "+Path.GetFullPath(targetSvgPathBox.Text)+"\n "+exception.Message);
			}
			//TODO:copy src files to target dir.
		}
		void RechMagIdBtnClick(object sender, EventArgs e)
		{
			rechercheMagasin();
		}

		void rechercheMagasin() {
			String workingPath=workspaceBaseBox.Text+workingDirBox.Text;
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
			Console.WriteLine("putty asked");
			//retrouver l'objet recu
			// trouver le serveur, et faire un putty dedans
		}
		void RechMagIdBoxEnter(object sender, EventArgs e)
		{
			//marche seulement qd vide.
			//rechercheMagasin();
		}
		void RechMagIdBoxValidated(object sender, EventArgs e)
		{
			//ne marche pas
			//rechercheMagasin();
		}
		void RechMagIdBoxTextChanged(object sender, EventArgs e)
		{
			

		}
		void RechMagIdBoxKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue.Equals(13)) {
				try {
					rechercheMagasin();
				} catch(Exception ex) {
					//reportError(ex);
				}
			}

		}
	}
}
