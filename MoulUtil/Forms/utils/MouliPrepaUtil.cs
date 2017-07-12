﻿/*
 * Utilisateur: Renaud
 * Date: 14/02/2017
 * Heure: 13:32:04
 * 
 */
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using cmdUtils.Objets;
using System.Windows.Forms;
using cmdUtils.Objets.business;
namespace MoulUtil.Forms.utils
{
	public class MouliPrepaUtil
	{
		private MouliPrepaForm mouliPrepaForm;
		// disable once FieldCanBeMadeReadOnly.Local
		private ConfigDto configDto=null;
		public MouliPrepaUtil(MouliPrepaForm mouliPrepaForm, ConfigDto configDto)
		{
			this.mouliPrepaForm=mouliPrepaForm;
			this.configDto=configDto;
		}

		public System.Diagnostics.Process startPlink(ConfigDto configDto, TextBox textbox)
		{
			System.Diagnostics.Process plinkProcess=null;
			try {
				//demarrage du plink en arriere plan pour le tunnel SSH
				ProcessUtil putil =new ProcessUtil();
				plinkProcess= putil.startProcess(MouliConfig.plinkPath, configDto.getAppPlink(), System.Diagnostics.ProcessWindowStyle.Normal);

				textbox.Visible=true;
				mouliPrepaForm.BackColor = Color.LightBlue;
			} catch(Exception exs) {
				Console.WriteLine ("erreur sur start de plink",exs);
				plinkProcess=null;
				mouliPrepaForm.BackColor = Color.Orange;
			}
			if(configDto.getAppPlink()!=null) {
			}
			return plinkProcess;
		}
		public string normaliseNom(string str)
		{
			str=str.Replace(" ", "").Replace("'", "").Replace("\"", "");
			return str;
		}
		private void safeWorkingDir()
		{
			String str=configDto.getWorkingDir();
			if((str!=null) && (str.Length>0)) {
				MouliUtil mouliUtil = new MouliUtil();
				mouliUtil.safeCreateDirectory( configDto.getWorkingDir());
			}
		}

		private void createMock(string path)
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

		public MouliUtilOptions  rechercheMagasin( //
		                                          TextBox rechMagIdBox, //
		                                          TextBox magDescBox, //
		                                          TextBox propositionBox,//
		                                          String workingPath, //
		                                          Button sqlBtn//
		                                         ) {
			
			MouliUtilOptions options=null;
			rechMagIdBox.Text=rechMagIdBox.Text.Trim();
			if(rechMagIdBox.Text.Length < 1) {
				return options;
			}
			safeWorkingDir();
			
			//mise en commentaire de prepadir, pas pret.
			if(rechMagIdBox.Text.Equals("0")) {
				magDescBox.Text = "Fake Shop";
				String rep= "MID0000-TOTO-i0/";
				propositionBox.Text = configDto.getWorkingDir()+rep;
				propositionBox.Text =rep;
				mouliPrepaForm.CreateBtnClick(null, null);
				createMock(workingPath+propositionBox.Text);
				options = new MouliUtilOptions();
				options.setMagId(rechMagIdBox.Text);
				options.setInstanceName("meo_test");
				return options;
			}
			MyUtil myUtil = new MyUtil();
			String user = configDto.getDatabaseAdminUser();
			String pwd = configDto.getDatabaseAdminPwd();
			String sql = configDto.getSqlCommand(SqlCommandsType.getDescriptionMagasin);
			String database = configDto.getDatabaseAdminName();
			
			String tmpStr = configDto.getConfigParamValueByName(ConfigParam.ParamNamesType.databaseTunneling);
			int port = int.Parse(tmpStr.Substring(0, tmpStr.IndexOf(":", StringComparison.Ordinal)));
			const string connectedBySSH = "connected by SSH \r\n";
			String s = connectedBySSH;
			String proposition = "";

			String cnxString = myUtil.buildconnString(database, "127.0.0.1", user, pwd, port);
			sql = sql + " WHERE magasins.magasin_id=" + rechMagIdBox.Text;
			try {
				var magasinList = myUtil.getListResultAsKeyValue(cnxString, sql);
				magDescBox.Text = "";
				
				magDescBox.Text = s;
				List<KeyValuePair<String, Object>> ligne = magasinList[0];
				if (ligne.Count > 0) {
					proposition =  normaliseNom(ligne[0].Value.ToString());

					
					MeoInstance magInstance=convertitInstance(ligne[2].Value.ToString());
					if(magInstance!=null) {
						proposition+="-"+magInstance.getCode();;
					}
					//magasinUrl=ligne[2].Value.ToString();
					proposition = configDto.getWorkingDir()+ "MID" + rechMagIdBox.Text.Trim() + "-" + proposition + "/";
					
					
					options = new MouliUtilOptions();
					if(magInstance!=null) {
						options.setInstanceName(magInstance.getNom());
						options.setInstanceCommande(magInstance.getMeocli());
					}
					options.setMagId(rechMagIdBox.Text);
					
					String extensionStock = ligne[5].Value.ToString();
					String extensionVisite = ligne[6].Value.ToString();
					options.setLimiteStock(ligne[3].Value.ToString());
					options.setLimiteVisite(ligne[4].Value.ToString());
					
					if(extensionStock=="1") {
						options.setExtensionStock(MoulinettePurgeOptionTypes.CLIENT_POSSEDE_EXTENSION);
					}
					if(extensionVisite=="1") {
						options.setExtensionClient(MoulinettePurgeOptionTypes.CLIENT_POSSEDE_EXTENSION);
					}
				}
				
				for (int i = 0; i < ligne.Count; i++) {
					KeyValuePair<String, Object> item = ligne[i];
					s += "[" + item.Key + "] = '" + item.Value + "' \r\n";
				}
				magDescBox.Text = s;
				propositionBox.Text = proposition;
				sqlBtn.Enabled=true;
			} catch (Exception ex) {
				magDescBox.Text = "erreur :" + ex.Message + "\n" + ex.Source;
			}
			
			return options;
		}
		private MeoInstance convertitInstance(string url) {
			if(configDto!=null) {
				String [] tablo = url.Split('/');
				String str = tablo[tablo.Length -1];
				foreach(MeoInstance meoInstance in configDto.getInstances()) {
					if(meoInstance.getNom()==str) {
						return meoInstance;
					}
				}
			}
			return null;
		}

		public void sauvegardeMoulinette(String sourcePath, string targetPath, MouliUtilOptions options, MouliProgressWorker backgroundWorker)
		{
			try {
				if(options!=null) {
					String subPath="MEO"+DateTime.Now.Year+"/";
					String path=targetPath+"/"+subPath;
					String fileName=new FileInfo(options.getarchiveName()).Name;
					
					Console.WriteLine("path:"+path);
					Console.WriteLine("path:"+Path.GetFullPath(path));
					Console.WriteLine("fileName:"+fileName);
					if(File.Exists(options.getarchiveName())) {
						File.Copy(options.getarchiveName(), Path.GetFullPath(path)+fileName, true);
					}
					
					sourcePath = new DirectoryInfo(sourcePath).FullName;
					MouliUtil mouliUtil = new MouliUtil();
					Regex excludeRegex = new Regex("\\.(7z|rar|gz|gzip|zip)$");
					List<String> toSaveFiles= mouliUtil.findFiles(sourcePath,  true, null, excludeRegex);
					toSaveFiles = mouliUtil.excludeFiles(toSaveFiles, excludeRegex);
					ZipUtil zipUtil = new ZipUtil();
					FileInfo fi =new FileInfo(options.getarchiveName());
					
					zipUtil.createSimpleArchive(9, Path.GetFullPath(path)+ "origine-"+fi.Name, toSaveFiles, backgroundWorker);
					return;
					
					//creation zip sur cible, liste de fichiers a faire, en excluant *.zip, *.rar, *gz, *.7z
					//1 - faire la liste filtree
					//2 renseigner zip utiloptions.
//					ZipUtil zipUtil = new ZipUtil();
//					ZipUtilOptions zipUtilOptions = new ZipUtilOptions();
//					zipUtilOptions.setArchiveDir("");
//					zipUtilOptions.setArchiveName("");
//					zipUtilOptions.setSourceBaseDir("");
//					zipUtilOptions.setSourceSelection(liste);
//
//
//					zipUtil.createArchive(zipUtilOptions);
					
				}
			} catch(Exception exception) {
				MessageBox.Show("Erreur de copie de vers "+Path.GetFullPath(targetPath)+"\n "+exception.Message);
			}
		}
		public void startBrowser(String url) {
			if(url!=null) {
				Process.Start("chrome", @url);
			}
		}
	}
}
