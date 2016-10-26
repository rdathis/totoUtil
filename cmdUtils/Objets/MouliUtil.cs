/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 13/06/2016
 * Heure: 13:35:10
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
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

		private void doCallback(Action<String> callback, String message) {
			if (callback!=null) {
				callback(message);
			}
		}
		//txtBoxMoulDestBase.Text, txtMagId.Text, txtMagClient.Text, moulDateTextBox.Text
		public String  creaEtVerifieRepMoulinette(MeoInstance instance, Action<String> callback, string destBase, string magId, string magClient, string date)
		{
			
			String retour="";
			if (destBase.Length < 1) {
				doCallback(callback, "manque base");
				return retour;
			}
			if (magId.Length < 1) {
				doCallback(callback, "manque MagId");
				return retour;
			}
			if (magClient.Length < 1) {
				doCallback(callback, "manque Client");
				return retour;
			}
			if (date.Length < 1) {
				doCallback(callback, "manque Date install");
				return retour;
			}
			
			if (instance != null) {
				// String instanceCode = if(instance!=null ? instance.getCode() : "?"); ;
				String path = destBase + "MID" + magId + "-" + magClient+ "-" + date + "-" + instance.getCode() + "/";
				
				MyUtil util = new MyUtil();
				util.createFolderIfNotExists(path);
				
				retour=path;
				doCallback(callback, "CREATE " + path + "\n");
				path += getData();
				util.createFolderIfNotExists(path);
				doCallback(callback, "CREATE " + path + "\n");
				
				path += getMag01();
				util.createFolderIfNotExists(path);
				doCallback(callback, "CREATE " + path + "\n");
				
				path += getJoint();
				util.createFolderIfNotExists(path);
				doCallback(callback, "CREATE " + path + "\n");
				
				util = null;
			} else {
				callback("manque instance.");
			}
			return retour;
		}
		private String formatPath(String path) {
			if (!path.EndsWith("/")) {
				path+="/";
			}
			return path;
		}
		public String getData() {
			return formatPath("data/");
		}
		public String getMag01() {
			return formatPath("mag01/");
		}
		public String getOrd01() {
			return formatPath("ord01/");
		}
		public String getDoc01() {
			return formatPath("doc01/");
		}
		public String getJoint() {
			return formatPath("Joint/");
		}
		public Boolean checkOrdoFixe(String path)
		{
			String ordotxt=(JFiles.ordo_top_fixe+".txt");
			String s = path + getMag01() +ordotxt;
			Boolean done=false;
			if (File.Exists(path + getMag01() +ordotxt)) {
				if(!File.Exists(path+getMag01()+getJoint())) {
					MyUtil util = new MyUtil();
					util.createFolderIfNotExists(path+getMag01()+getJoint());
					Console.WriteLine("Creation de "+path+getMag01()+getJoint()+" ");
				}
				if (File.Exists(path + getMag01() +getJoint() + ordotxt)) {
					File.Delete(path + getMag01() +getJoint() + ordotxt);
				}
				File.Copy(path+getMag01()+ordotxt, path+getMag01()+getJoint()+ordotxt);
				done=true;
			}
			return done;
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

		public Boolean checkIfFileExists(string path, string dataPath, String magPath, String fileName, String extension)
		{
			String file = (path+dataPath+magPath+fileName);
			
			if (extension!=null ) {
				file+=extension;
			}
			Console.WriteLine(" file : "+file + " ? "+File.Exists(file));
			return File.Exists(file);
		}

		public void updateMoulinetteMagasin(String magId, ConfigSectionSettings cfg, TextBox texbox,  System.Windows.Forms.RichTextBox rtb) {
			
			string sql = "select * from administration.magasins where magasin_id=" + magId;
			MyUtil util = new MyUtil();

			string cstr = util.doConnString(cfg);
			var magasinList = util.getListResultAsKeyValue(cstr, sql);
			
			rtb.AppendText("#libe:" + util.getItem(magasinList[0], "magasin_libelle") + " - url :" + util.getItem(magasinList[0], "url"));
			rtb.AppendText("\n#cli_id:" + util.getItem(magasinList[0], "client_id"));
			//Console.WriteLine("libe:"+util.getItem(magasinList[0], "magasin_libelle"));
			//Console.WriteLine("cli_id:"+util.getItem(magasinList[0], "client_id"));
			
			texbox.Text = (string)util.getItem(magasinList[0], "magasin_libelle");
			sql = "SELECT utilisateur_id,magasin_id FROM administration.utilisateurs where utilisateur_active=true AND magasin_id=" + magId + ";";
			var userList = util.getListResultAsKeyValue(cstr, sql);
			
			rtb.AppendText("\nmodeDevMagId=" + util.getItem(userList[0], "magasin_id"));
			rtb.AppendText("\nmodeDevUserId=" + util.getItem(userList[0], "utilisateur_id"));
		}

		List<String>  parseMoulinetteScript(String source, MouliUtilOptions options) {
			String[] tmp=source.Split('\n');
			List<String> retour = new List<string>();
			
			Console.WriteLine(" source : "+source);
			Console.WriteLine ( "size :" +tmp.Length);
			
			for(int i =0;i<tmp.Length;i++) {
				Console.WriteLine(" i :"+i);
				String ligne = tmp[i];
				ligne=ligne.Replace("<%magId%>", options.getMagId());
				ligne=ligne.Replace("<%ARG%>", options.getLots());
				ligne=ligne.Replace("<%instanceName%>", options.getInstanceName());
				ligne=ligne.Replace("<%instanceCommande%>", options.getInstanceCommande());
				String joint="N";
				if (options.getIsJoint()) {
					joint="O";
				}
				ligne=ligne.Replace("<%joint%>", joint);
				ligne=ligne.Replace("<%dateCrea%>", new DateTime().Date.ToString());
				ligne=ligne.Replace("\n", "");
				ligne=ligne.Replace("\r", "");
				
				retour.Add(ligne);
			}
			return retour;
		}

		public int analyseTopOrdoFixe(List<string> liste, string file, List<string> notFoundList)
		{
			int foundFiles=0;
			String path="data/mag01/Joint/";
			if (Directory.Exists(path) && (File.Exists(file))) {
				MyUtil myUtil = new MyUtil();
				String[] lignes= myUtil.readScript(file).Split('\n');
				//commencer ligne 2, cause titre.
				for(int numLigne=1;numLigne<lignes.GetLength(0);numLigne++) {
					String ligne=lignes[numLigne].Replace('\r', ' ').Trim();
					String [] colonnes = ligne.Split(';');
					if (colonnes.GetLength(0) > 5) {
//			clientNumeroGroupement = tab[0];
//			creationDate = tab[1]
//			fichier1 = tab[2];
//			fichier2 = tab[3];
//			fichier3 = tab[4];
//			fichier4 = tab[5];
//			fichier5 = tab[6];

						
						for(int c=2;c<7;c++) {
							String colonne = colonnes[c].Trim();
							if (colonne.Length> 1) {
								if (File.Exists(path+colonne))   {
									if (!liste.Contains(path+colonne)) {
										liste.Add(path+colonne);
										foundFiles++;
									}
								} else {
									if (!notFoundList.Contains(path+colonne)) {
										notFoundList.Add(path+colonne);
									}
								}
							}
						}
					}
				}
			}
			return foundFiles;
		}
		private List<String> genereScript(String scriptSource, String scriptCible, MouliUtilOptions options)
		{
			return(parseMoulinetteScript(scriptSource, options));
		}
		public void writeMoulinetteFile(String modeleFile, String path, string moulinetteFile, MouliUtilOptions options)
		{
			String modele = new StreamReader(modeleFile).ReadToEnd();
			List<String> moul = genereScript(modele, moulinetteFile, options);
			StreamWriter outputFile = new StreamWriter(moulinetteFile);
			outputFile.NewLine="\n";
			foreach(String line in moul) {
				outputFile.WriteLine(line);
			}
			outputFile.Close();
		}
		public void writeJobFile(string scriptJobFile, string scriptMoulinetteFile, MouliUtilOptions options)
		{
			StreamWriter outputFile = new StreamWriter(scriptJobFile);
			outputFile.NewLine="\n";
			//
			outputFile.WriteLine("## job file automatique, pour planifier la maj");
			
			// outputFile.WriteLine("MPATH=`dirname $0` ");
			// outputFile.WriteLine("cd $MPATH && MPATH=$PWD");
			outputFile.WriteLine("export MAILTO=athis.r@cristallin.com && echo /bin/sh "+scriptMoulinetteFile+ " | at "+formatDateJob(options.getDateJob())+ " " );
			//
			outputFile.Close();
		}

		public DateTime calculeNextPlannedJob()
		{
			DateTime tmpDate = DateTime.Now;
			tmpDate=tmpDate.AddDays(1);

			while(tmpDate.DayOfWeek==DayOfWeek.Saturday || tmpDate.DayOfWeek==DayOfWeek.Sunday) {
				tmpDate=tmpDate.AddDays(1);
			}
			DateTime jobPlanned = new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, 08, 0, 0);
			return jobPlanned;
		}

		string formatDateJob(DateTime date)
		{
			
			//Et si je veux exécuter la commande le 15 novembre à 14 h 17 ?
			// $ at 14:17 11/15/10
			// La date est au format américain, les numéros du jour et du mois sont donc inversés : 11/15/10. 11 correspond au mois (novembre) et 15 au numéro du jour !
			
			//!pas les secondes, sinon 'Garbled time'
			return String.Format("{0:HH:mm M/d/yyyy }", date);

		}
		public List<String> giveFiles(String path) {
			Regex regex=null;
			return giveFiles(path, regex, regex);
		}
		public List<String> giveFiles(String path, String selection, String exclusion) {
			Regex selectionRegex = null;
			Regex exclusionRegex = null;
			if (selection!=null) {
				selectionRegex = new Regex(selection);
			}
			if (exclusion!=null) {
				exclusionRegex = new Regex(exclusion);
			}
			
			return giveFiles (path, selectionRegex, exclusionRegex);
		}
		public List<String> giveFiles(String path, Regex selectionPattern) {
			return giveFiles(path, selectionPattern, null);
		}
		public List<String> giveFiles(String path, Regex selectionPattern, Regex exclusionPattern) {
			List <String > liste =null;
			
			if(Directory.Exists(path)) {
				liste = new List<string>();
				String[] files = Directory.GetFiles(path);
				if (files.Length > 0) {
					for(int i=0;i<files.Length;i++) {
						//String file = files[i];
						FileInfo file = new FileInfo(files[i]);
						
						String fileName=file.Name;
						if ((exclusionPattern==null) || (!exclusionPattern.Match(fileName).Success)) {
							if ((selectionPattern==null) || (selectionPattern.Match(fileName).Success)) {

								liste.Add(files[i]);
							}
						}
					}
					
				}
			}
			return liste;
		}

		public List<String> checkIsOrd01(string path)
		{
			return giveFiles(path, "[\\.][pP][dD][fF]$", "^[dD]");
		}
		public  List<String> checkIsDoc01(string path)
		{
			return giveFiles(path, "[\\.]", null);
		}
	}
}