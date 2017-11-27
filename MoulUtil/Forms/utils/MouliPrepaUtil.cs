/*
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
using System.Globalization;
using System.IO;
using System.Text;
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
		private log4net.ILog  LOGGER=null;
		public MouliPrepaUtil(MouliPrepaForm mouliPrepaForm, ConfigDto configDto, log4net.ILog  LOGGER)
		{
			this.mouliPrepaForm=mouliPrepaForm;
			this.configDto=configDto;
			this.LOGGER=LOGGER;
		}

		//inutilise, conserve pour usage futur eventuel
		public System.Diagnostics.Process startPlink(ConfigDto configDto, TextBox textbox)
		{
			MeoInstance adminInstance= MeoInstance.findInstanceByInstanceName(configDto.instances, "administration");
			if(adminInstance==null) {
				return null;
			}
			MeoServeur server = MeoServeur.findServeurByName(configDto.serveurs, adminInstance.serveur);
			if(adminInstance==null) {
				return null;
			}
			String databaseTunnel = server.getTunnel();;
			String tmpTunnel = databaseTunnel.Replace(":", ":127.0.0.1:");
			String plinkArgs =" -ssh -batch -pw "+server.password + " -L " + tmpTunnel + " " +server.utilisateur+"@"+server.adresse;
			System.Diagnostics.Process plinkProcess=null;
			try {
				//demarrage du plink en arriere plan pour le tunnel SSH
				ProcessUtil putil =new ProcessUtil();
				plinkProcess= putil.startProcess(MouliConfig.plinkPath, plinkArgs, System.Diagnostics.ProcessWindowStyle.Normal);

				textbox.Visible=true;
				mouliPrepaForm.BackColor = Color.LightBlue;
			} catch(Exception exs) {
				LOGGER.Info ("erreur sur start de plink",exs);
				plinkProcess=null;
				mouliPrepaForm.BackColor = Color.Orange;
			}
			return plinkProcess;
		}
		public string normaliseNom(string str)
		{
			str=RemoveDiacritics(str);
			str=str.Replace(" ", "").Replace("'", "").Replace("\"", "").Replace("'", "");

			return str;
		}
		//degage les accents
		private String RemoveDiacritics(String text)
		{
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder();

			foreach (var c in normalizedString)
			{
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
		}
		
		private void safeWorkingDir()
		{
			String str=configDto.getWorkingDir();
			if((str!=null) && (str.Length>0)) {
				MouliUtil mouliUtil = new MouliUtil(LOGGER);
				mouliUtil.safeCreateDirectory( configDto.getWorkingDir());
			}
		}

		public void createMock(string path, string magIrris)
		{
			
			MouliUtil mouliUtil = new MouliUtil(LOGGER);
			String dataPath=mouliUtil.getData();
			mouliUtil.setMagasinIrris(magIrris);
			String magPath=mouliUtil.getMag01();
			String extension = ".d";
			
			foreach (YFILES.YFiles yfile in Enum.GetValues(typeof(YFILES.YFiles))) {
				Boolean value = mouliUtil.checkIfFileExists(path, dataPath, magPath, yfile.ToString(), extension);
				if(!value) {
					String file=path+dataPath+magPath+ yfile.ToString().ToLower() +extension;
					StreamWriter outputFile = new StreamWriter(file);
					//outputFile.WriteLine("## MOCK : "+yfile);
					outputFile.Close();
				}
			}
			
		}

		public MouliUtilOptions  rechercheMagasin( //
		                                          MeoServeur adminServer, //
		                                          TextBox rechMagIdBox, //
		                                          TextBox magDescBox, //
		                                          TextBox propositionBox,//
		                                          String workingPath, //
		                                          Button sqlBtn, //
		                                          String magIrris //
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
				createMock(workingPath+propositionBox.Text, magIrris);
				options = new MouliUtilOptions();
				options.setMagId(rechMagIdBox.Text);
				options.setInstanceName("meo_test");
				options.setWorkspacePath(workingPath);
				options.setWorkingPath(rep);
				options.setLimiteYearStock("99");
				options.setLimiteYearVisites("99");
				return options;
			}
			MyUtil myUtil = new MyUtil();
			String user = configDto.getDatabaseAdminUser();
			String pwd = configDto.getDatabaseAdminPwd();
			String sql = configDto.getSqlCommand(SqlCommandsType.getDescriptionMagasin);
			String database = configDto.getDatabaseAdminName();
			
			String tmpStr = adminServer.getTunnel();
			int port = int.Parse(tmpStr.Substring(0, tmpStr.IndexOf(":", StringComparison.Ordinal)));
			const string connectedBySSH = "connected by SSH \r\n";
			String s = connectedBySSH;
			s+="[mag_id] = '"+rechMagIdBox.Text+"' \r\n";
			String proposition = "";

			String cnxString = myUtil.buildconnString(database, "127.0.0.1", user, pwd, port);
			sql = sql + " WHERE magasins.magasin_id=" + rechMagIdBox.Text;
			List<List<KeyValuePair<String, object>>> magasinList = null;
			try {
				magasinList = myUtil.getListResultAsKeyValue(cnxString, sql);
			} catch(Exception ex) {
				LOGGER.Error(ex);
				magDescBox.Text = "erreur accès aux données :" + ex.Message + "\n" + ex.Source;
				MessageBox.Show("erreur accès aux données : "+ex.Message);
				return null;
			}
			try {
				magDescBox.Text = "";
				magDescBox.Text = s;
				List<KeyValuePair<String, Object>> ligne = magasinList[0];
				if (ligne.Count > 0) {
					proposition =  normaliseNom(ligne[0].Value.ToString());

					
					options = new MouliUtilOptions();
					
					MeoInstance magInstance=convertitInstance(ligne[2].Value.ToString());
					if(magInstance!=null) {
						proposition+="-"+magInstance.getCode();;
					}
					proposition = "MID" + rechMagIdBox.Text.Trim() + "-" + proposition + "/";
					options.setWorkingPath(proposition);
					//magasinUrl=ligne[2].Value.ToString();
					//proposition = configDto.getWorkingDir()+ proposition;
					
					options.setWorkspacePath(workingPath);
					if(magInstance!=null) {
						options.setInstanceName(magInstance.getNom());
						options.setInstancePath(magInstance.meopath);
						options.setInstanceCommande(magInstance.getMeocli());
					}
					options.setMagId(rechMagIdBox.Text);
					
					String extensionStock = ligne[5].Value.ToString();
					String extensionVisite = ligne[6].Value.ToString();
					options.setLimiteStock(ligne[3].Value.ToString());
					options.setLimiteVisite(ligne[4].Value.ToString());
					options.setLimiteYearStock("99");
					options.setLimiteYearVisites("99");
					
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
				LOGGER.Error(ex);
				magDescBox.Text = "erreur :" + ex.Message + "\n" + ex.Source;
				MessageBox.Show("Erreur : "+ex.Message);
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

		public List<String> sauvegardeMoulinette( String sourcePath, string targetPath, MouliUtilOptions options, MouliProgressWorker backgroundWorker)
		{
			List<String> retour = new List<string>();
			try {
				if(options!=null) {
					String path=targetPath;
					String fileName=new FileInfo(options.getarchiveName()).Name;
					
					LOGGER.Info("path:"+path);
					LOGGER.Info("path:"+Path.GetFullPath(path));
					LOGGER.Info("fileName:"+fileName);
					if(File.Exists(options.getarchiveName())) {
						File.Copy(options.getarchiveName(), Path.GetFullPath(path)+fileName, true);
						retour.Add(Path.GetFullPath(path)+fileName);
					}
					
					sourcePath = new DirectoryInfo(sourcePath).FullName;
					MouliUtil mouliUtil = new MouliUtil(LOGGER);
					Regex excludeRegex = new Regex("\\.(7z|rar|gz|tgz|gzip|zip)$");
					List<String> toSaveFiles= mouliUtil.findFiles(sourcePath,  true, false, null, excludeRegex);
					toSaveFiles = mouliUtil.excludeFiles(toSaveFiles, excludeRegex);
					ZipUtil zipUtil = new ZipUtil(LOGGER);
					FileInfo fi =new FileInfo(options.getarchiveName());
					
					zipUtil.createSimpleArchive(9, Path.GetFullPath(path)+ "origine-"+fi.Name, toSaveFiles, backgroundWorker);
					retour.Add(Path.GetFullPath(path)+ "origine-"+fi.Name);
					
					
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
				LOGGER.Error(exception);
				MessageBox.Show("Erreur de copie de vers "+Path.GetFullPath(targetPath)+"\n "+exception.Message);
			}
			return retour;
		}
		public void startBrowser(String url) {
			if(url!=null) {
				Process.Start("chrome", @url);
			}
		}
		
		public List<String> populateSourceBaseListBox(string source, string filter)
		{
			MouliUtil mouliUtil = new MouliUtil(LOGGER);
			return mouliUtil.findFiles(source, false, true, filter, null);
		}		
	}
}
