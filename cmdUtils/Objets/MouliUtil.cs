﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 13/06/2016
 * Heure: 13:35:10
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Drawing;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of MouliUtil.
	/// </summary>
	public class MouliUtil
	{
		private MyUtil myUtil = new MyUtil();
		public MouliUtil()
		{
		}

		
		//txtBoxMoulDestBase.Text, txtMagId.Text, txtMagClient.Text, moulDateTextBox.Text
		public String  creaEtVerifieRepMoulinette(MeoInstance instance, RichTextBox rtb, string destBase, string magId, string magClient, string date)
		{
			
			String retour="";
			if (destBase.Length < 1) {
				rtb.AppendText("manque base");
				return retour;
			}
			if (magId.Length < 1) {
				rtb.AppendText("manque MagId");
				return retour;
			}
			if (magClient.Length < 1) {
				rtb.AppendText("manque Client");
				return retour;
			}
			if (date.Length < 1) {
				rtb.AppendText("manque Date install");
				return retour;
			}
			
			if (instance != null) {
				// String instanceCode = if(instance!=null ? instance.getCode() : "?"); ;
				String path = destBase + "MID" + magId + "-" + magClient+ "-" + date + "-" + instance.getCode() + "/";
				
				MyUtil util = new MyUtil();
				util.createFolderIfNotExists(path);
				
				retour=path;
				rtb.AppendText("CREATE " + path + "\n");
				path += "data/";
				util.createFolderIfNotExists(path);
				rtb.AppendText("CREATE " + path + "\n");
				
				path += "mag01/";
				util.createFolderIfNotExists(path);
				rtb.AppendText("CREATE " + path + "\n");
				
				path += "Joint/";
				util.createFolderIfNotExists(path);
				rtb.AppendText("CREATE " + path + "\n");
				
				util = null;
			} else {
				rtb.AppendText("manque instance.");
			}
			return retour;
		}

		public void checkOrdoFixe(String path)
		{
			String ordotxt=(JFiles.ordo_top_fixe+".txt");
			if (File.Exists(path+ordotxt)) {
				File.Copy(path+ordotxt, path+"Joint/"+ordotxt);
			}

		}
		public void checkIfYFilesExists(String path, RichTextBox rtb, string dataPath, string magPath, String extension)
		{
			foreach(YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				Boolean value= checkIfFileExists(path,  dataPath, magPath, yfile.ToString(), extension);
				String str = yfile.ToString() +"\n";
				if (value) {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Green);
				} else {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Red);
				}
			}

		}
		public void checkIfJFilesExists(String path, RichTextBox rtb, string dataPath, string magPath, String extension)
		{
			foreach(JFiles jfile in Enum.GetValues(typeof(JFiles))) {
				Boolean value= checkIfFileExists(path,  dataPath, magPath, jfile.ToString(), extension);
				String str = jfile.ToString() +"\n";
				if (value) {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Green);
				} else {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Red);
				}
			}

		}

		private Boolean checkIfFileExists(string path, string dataPath, String magPath, String fileName, String extension)
		{
			String file = (path+dataPath+magPath+fileName);
			if (extension!=null ) {
				file+=extension;
			}
			return File.Exists(file);
		}

		public void updateMoulinetteMagasin(String magId, ConfigSectionSettings cfg, TextBox texbox,  System.Windows.Forms.RichTextBox rtb) {
			
			string sql = "select * from administration.magasins where magasin_id=" + magId;
			MyUtil util = new MyUtil();

			string cstr = util.doConnString(cfg);
			var magasinList = util.getListResultAsKV(cstr, sql);
			
			rtb.AppendText("#libe:" + util.getItem(magasinList[0], "magasin_libelle") + " - url :" + util.getItem(magasinList[0], "url"));
			rtb.AppendText("\n#cli_id:" + util.getItem(magasinList[0], "client_id"));
			//Console.WriteLine("libe:"+util.getItem(magasinList[0], "magasin_libelle"));
			//Console.WriteLine("cli_id:"+util.getItem(magasinList[0], "client_id"));
			
			texbox.Text = (string)util.getItem(magasinList[0], "magasin_identifiant");
			sql = "SELECT utilisateur_id,magasin_id FROM administration.utilisateurs where utilisateur_active=true AND magasin_id=" + magId + ";";
			var userList = util.getListResultAsKV(cstr, sql);
			
			rtb.AppendText("\nmodeDevMagId=" + util.getItem(userList[0], "magasin_id"));
			rtb.AppendText("\nmodeDevUserId=" + util.getItem(userList[0], "utilisateur_id"));
			
			
		}
	}
}
