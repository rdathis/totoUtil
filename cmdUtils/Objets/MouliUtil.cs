/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 13/06/2016
 * Heure: 13:35:10
 * 
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
		private String m01="01";

		private void doCallback(Action<String> callback, String message)
		{
			if (callback != null) {
				callback(message);
			}
		}

		public void setMagasinIrris(string str)
		{
			m01=str;
		}


		private String formatPath(String path)
		{
			if (!path.EndsWith("/")) {
				path += "/";
			}
			return path;
		}
		public String getData()
		{
			return formatPath("data/");
		}
		public String getMag01()
		{
			return formatPath("mag"+m01+"/");
		}
		public String getOrd01()
		{
			return formatPath("ord"+m01+"/");
		}
		public String getDoc01()
		{
			return formatPath("doc"+m01+"/");
		}
		public String getJoint()
		{
			return formatPath("Joint/");
		}
		public Boolean checkOrdoFixe(String path)
		{
			String ordotxt = (JFiles.ordo_top_fixe + ".txt");
			String s = path + getMag01() + ordotxt;
			Boolean done = false;
			if (File.Exists(path + getMag01() + ordotxt)) {
				if (!File.Exists(path + getMag01() + getJoint())) {
					MyUtil util = new MyUtil();
					util.createFolderIfNotExists(path + getMag01() + getJoint());
					Console.WriteLine("Creation de " + path + getMag01() + getJoint() + " ");
				}
				if (File.Exists(path + getMag01() + getJoint() + ordotxt)) {
					File.Delete(path + getMag01() + getJoint() + ordotxt);
				}
				File.Copy(path + getMag01() + ordotxt, path + getMag01() + getJoint() + ordotxt);
				done = true;
			}
			return done;
		}
		public void checkIfYFilesExists(String path, RichTextBox rtb, string dataPath, string magPath, String extension)
		{
			foreach (YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				Boolean value = checkIfFileExists(path, dataPath, magPath, yfile.ToString(), extension);
				String str = yfile.ToString() + "\n";
				if (value) {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Green);
				} else {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Red);
				}
			}

		}
		public void checkIfJFilesExists(String path, RichTextBox rtb, string dataPath, string magPath, String extension)
		{
			foreach (JFiles jfile in Enum.GetValues(typeof(JFiles))) {
				Boolean value = checkIfFileExists(path, dataPath, magPath, jfile.ToString(), extension);
				String str = jfile.ToString() + "\n";
				if (value) {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Green);
				} else {
					RichTextBoxUtilcs.colorit(rtb, str, Color.Red);
				}
			}

		}

		public Boolean checkIfFileExists(string path, string dataPath, String magPath, String fileName, String extension)
		{
			String file = (path + dataPath + magPath + fileName);
			
			if (extension != null) {
				file += extension;
			}
			Console.WriteLine(" file : " + file + " ? " + File.Exists(file));
			return File.Exists(file);
		}

		public void updateMoulinetteMagasin(ConfigDto configDto, String magId, ConfigSectionSettings cfg, TextBox texbox, System.Windows.Forms.RichTextBox rtb)
		{
			
			string sql = "select * from administration.magasins where magasin_id=" + magId;
			MyUtil util = new MyUtil();
			// MeoInstance instance=configDto.getInstances().
			//ici:
			// (1) ssh connection, port
			// (2) find instance by name 'administration,'
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

		List<String>  parseMoulinetteScript(String source, MouliUtilOptions options)
		{
			//  trad = (MouliUtilOptionsTraductor) options;
			String[] tmp = source.Split('\n');
			List<String> retour = new List<string>();
			
			Console.WriteLine(" source : " + source);
			Console.WriteLine("size :" + tmp.Length);
			
			for (int i = 0; i < tmp.Length; i++) {
				Console.WriteLine(" i :" + i);
				String ligne = tmp[i];
				if(!options.isCommentaire(ligne)) {
					ligne = ligne.Replace("\n", "");
					ligne = ligne.Replace("\r", "");
					ligne = MouliUtilOptionsTraductor.traduitScript(options, ligne);
					retour.Add(ligne);
				}
			}
			return retour;
		}

		public int analyseTopOrdoFixe(List<string> liste, string file, List<string> notFoundList)
		{
			int foundFiles = 0;
			String path = "data/mag"+m01+"/Joint/";
			if (Directory.Exists(path) && (File.Exists(file))) {
				MyUtil myUtil = new MyUtil();
				String[] lignes = myUtil.readScript(file).Split('\n');
				//commencer ligne 2, cause titre.
				for (int numLigne = 1; numLigne < lignes.GetLength(0); numLigne++) {
					String ligne = lignes[numLigne].Replace('\r', ' ').Trim();
					String[] colonnes = ligne.Split(';');
					if (colonnes.GetLength(0) > 5) {
//			clientNumeroGroupement = tab[0];
//			creationDate = tab[1]
//			fichier1 = tab[2];
//			fichier2 = tab[3];
//			fichier3 = tab[4];
//			fichier4 = tab[5];
//			fichier5 = tab[6];

						
						for (int c = 2; c < 7; c++) {
							String colonne = colonnes[c].Trim();
							if (colonne.Length > 1) {
								if (File.Exists(path + colonne)) {
									if (!liste.Contains(path + colonne)) {
										liste.Add(path + colonne);
										foundFiles++;
									}
								} else {
									if (!notFoundList.Contains(path + colonne)) {
										notFoundList.Add(path + colonne);
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
			outputFile.NewLine = "\n";
			foreach (String line in moul) {
				outputFile.WriteLine(line);
			}
			outputFile.Close();
		}
		public void writeJobFile(string scriptJobFile, string scriptMoulinetteFile, MouliUtilOptions options)
		{
			StreamWriter outputFile = new StreamWriter(scriptJobFile);
			outputFile.NewLine = "\n";
			//
			outputFile.WriteLine("## job file automatique, pour planifier la maj");
			
			// outputFile.WriteLine("MPATH=`dirname $0` ");
			// outputFile.WriteLine("cd $MPATH && MPATH=$PWD");
			outputFile.WriteLine("echo /bin/sh " + scriptMoulinetteFile + " -mail | at " + formatDateJob(options.getDateJob()) + " ");
			//
			String mail=options.getDefaultEmail();
			outputFile.WriteLine("mail -s \"planification moulinette + "+scriptMoulinetteFile+" \" "+mail+" < $0 ");
			outputFile.Close();
		}

		public DateTime calculeNextPlannedJob()
		{
			DateTime tmpDate = DateTime.Now;
			tmpDate = tmpDate.AddDays(1);

			while (tmpDate.DayOfWeek == DayOfWeek.Saturday || tmpDate.DayOfWeek == DayOfWeek.Sunday) {
				tmpDate = tmpDate.AddDays(1);
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
		public List<String> giveFiles(String path)
		{
			Regex regex = null;
			return giveFiles(path, regex, regex);
		}
		public List<String> giveFiles(String path, String selection, String exclusion)
		{
			Regex selectionRegex = null;
			Regex exclusionRegex = null;
			if (selection != null) {
				selectionRegex = new Regex(selection);
			}
			if (exclusion != null) {
				exclusionRegex = new Regex(exclusion);
			}
			
			return giveFiles(path, selectionRegex, exclusionRegex);
		}
		public List<String> giveFiles(String path, Regex selectionPattern)
		{
			return giveFiles(path, selectionPattern, null);
		}
		public List<String> giveFiles(String path, Regex selectionPattern, Regex exclusionPattern)
		{
			List <String > liste = null;
			
			if (Directory.Exists(path)) {
				liste = new List<string>();
				String[] files = Directory.GetFiles(path);
				if (files.Length > 0) {
					for (int i = 0; i < files.Length; i++) {
						//String file = files[i];
						FileInfo file = new FileInfo(files[i]);
						
						String fileName = file.Name;
						if ((exclusionPattern == null) || (!exclusionPattern.Match(fileName).Success)) {
							if ((selectionPattern == null) || (selectionPattern.Match(fileName).Success)) {

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
		
		public void createArbo(String path)
		{
			if(!path.EndsWith("/")) {
				path+="/";
			}
			safeCreateDirectory(path + "/");
			safeCreateDirectory(path + getData());
			safeCreateDirectory(path + getData() + getDoc01());
			safeCreateDirectory(path + getData() + getMag01());
			safeCreateDirectory(path + getData() + getMag01() + getJoint());
		}
		public bool safeCreateDirectory(String path)
		{
			Boolean r = false;
			if (!Directory.Exists(path)) {
				Directory.CreateDirectory(path);
				r = true;
			}
			return r;
		}
		
		public void writeInstallMoulinetteFile(String commande, String path)
		{
			
			StreamWriter outputFile = new StreamWriter(path);
			outputFile.NewLine = "\n";
			
			outputFile.WriteLine(commande);
			outputFile.Close();
		}
		
		public string getUnzipCmd(MeoServeur server, string target, MouliJob job)
		{
			
			FileInfo info =new FileInfo(job.getArchiveName());
			String tmp=info.Name;
			tmp=tmp.Substring(0, tmp.Length -4);
			String newdir=target + tmp;
			String cmd="mkdir "+newdir;
			
			
			cmd+=" && cd " +newdir +" && unzip -o "+target+info.Name;
			// cd /database/transpo/bidule && mkdir pouet && cd pouet && unzip ../pouet.zip
			return cmd;

			

		}
	}
}