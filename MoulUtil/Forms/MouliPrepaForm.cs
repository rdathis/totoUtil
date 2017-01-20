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
using System.IO;
using System.Windows.Forms;
using cmdUtils.Objets;
using MoulUtil.Forms;

namespace MoulUtil
{
	/// <summary>
	/// 
	/// Form de preparation de moulinette
	/// </summary>
	public partial class MouliPrepaForm : Form
	{
		private System.Diagnostics.Process plink;
		private ConfigDto configDto;
		private String magasinUrl="";
		
		//private String instanceNom=null;
		public MouliPrepaForm(ConfigDto configDto)
		{
			InitializeComponent();
			this.configDto = configDto;
			this.workingDirBox.Text=configDto.getWorkingDir();
			new TreeViewUtil(configDto.instances,configDto.serveurs).populateTargets(targetTreeView);
		}
		void MouliPrepaLoad(object sender, EventArgs e)
		{
			try {
				//demarrage du plink en arriere plan pour le tunnel SSH
				ProcessUtil putil =new ProcessUtil();
				plink= putil.startProcess(MouliConfig.plinkPath, configDto.appPlink, System.Diagnostics.ProcessWindowStyle.Normal);
				this.BackColor = Color.LightBlue;
			} catch(Exception exs) {
				Console.WriteLine ("erreur sur start de plink",exs);
				plink=null;
				this.BackColor = Color.Orange;
			}
			if(configDto.appPlink!=null) {
			}
		}
		void WorkspaceBoxTextChanged(object sender, EventArgs e)
		{
			
			MouliUtil mouliUtil = new MouliUtil();
			mouliUtil.safeCreateDirectory( configDto.getWorkingDir());

		}
		void PrepareBtnClick(object sender, EventArgs e)
		{
			if (workspaceBaseBox.Text.Length > 0 && workspaceBox.Text.Length > 0) {
				String magId=rechMagIdBox.Text;
				MouliForm form = new MouliForm(configDto.getServeurs(), configDto.getInstances(), configDto, magId, workspaceBox.Text, magasinUrl);
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

		string convertitInstance(string url)
		{
			if(configDto!=null) {
				String [] tablo = url.Split('/');
				String str = tablo[tablo.Length -1];
				foreach(MeoInstance meoInstance in configDto.getInstances()) {
					if(meoInstance.getNom()==str) {
						return meoInstance.getCode();
					}
				}
			}
			return "?";
		}
		void createMock(string path)
		{
			
			MouliUtil mouliUtil = new MouliUtil();
			String dataPath=mouliUtil.getData();
			String magPath=mouliUtil.getMag01();
			String extension = "d";
			
			foreach (YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				Boolean value = mouliUtil.checkIfFileExists(path, dataPath, magPath, yfile.ToString(), extension);
				if(!value) {
					String file=path+dataPath+magPath+ yfile.ToString().ToLower() +"."+extension;
					StreamWriter outputFile = new StreamWriter(file);
					outputFile.WriteLine("## MOCK : "+yfile);
					outputFile.Close();
				}
			}
			
		}

		void safeWorkingDir()
		{
			String str=configDto.getWorkingDir();
			if((str!=null) && (str.Length>0)) {
				MouliUtil mouliUtil = new MouliUtil();
				mouliUtil.safeCreateDirectory( configDto.getWorkingDir());
			}
		}

		void rechercheMagasin()
		{
			safeWorkingDir();
			
			//mise en commentaire de prepadir, pas pret.
			if(rechMagIdBox.Text.Equals("0")) {
				magDescBox.Text = "Fake Shop";
				String rep= "MID0000-TOTO-i0/";
				propositionBox.Text = configDto.workingDir+rep;
				magasinUrl="";
				CreateBtnClick(null, null);
				createMock(rep);
				return;
			}
			MyUtil myUtil = new MyUtil();
			String user = configDto.getDatabaseAdminUser();
			String pwd = configDto.getDatabaseAdminPwd();
			String sql = configDto.getSQL01();
			String database = configDto.getDatabaseAdminName();
			
			const int port = 3615;
			const string connectedBySSH = "connected by SSH \r\n";
			String s = connectedBySSH;
			String proposition = "";

			String cnxString = myUtil.buildconnString(database, "127.0.0.1", user, pwd, port);
			sql = sql + " WHERE magasin_id=" + rechMagIdBox.Text;
			try {
				var magasinList = myUtil.getListResultAsKeyValue(cnxString, sql);
				magDescBox.Text = "";
				
				magDescBox.Text = s;
				List<KeyValuePair<String, Object>> ligne = magasinList[0];
				if (ligne.Count > 0) {
					proposition = ligne[0].Value.ToString().Replace(" ", "");

					proposition+="-"+convertitInstance(ligne[2].Value.ToString());
					magasinUrl=ligne[2].Value.ToString();
					proposition = configDto.getWorkingDir()+ "MID" + rechMagIdBox.Text.Trim() + "-" + proposition + "/";
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
		}
		void RechMagIdBoxTextChanged(object sender, EventArgs e)
		{
			
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
			if(plink!=null) {
				plink.Close();
			}
		}
		void SqlBtnClick(object sender, EventArgs e)
		{
			MeoInstance meoInstance = MeoInstance.findInstanceByMeoURL(configDto.instances, magasinUrl); // convertitInstance(string url);
			MouliSQLForm form = new MouliSQLForm(this.rechMagIdBox.Text, meoInstance);
			form.ShowDialog();
		}
		void ConfigBtnClick(object sender, EventArgs e)
		{
			
			MouliEditForm form = new MouliEditForm(configDto);
			form.ShowDialog();
		}
	}
}
