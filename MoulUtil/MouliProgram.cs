/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 04/07/2016
 * Heure: 12:58:37
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;

using System.IO;
using Renci.SshNet;
using cmdUtils;
using cmdUtils.Objets;
using log4net;
using log4net.Config;

namespace MoulUtil
{

	class MouliProgram
	{
		private static MouliForm form =null;
		private static int progression=0;
		private static DateTime startDateTime;
		static log4net.ILog ILOG = LogManager.GetLogger("mouliUtil");
		
		private static SshClient testSSh() {
			String server="null";
			string user="null";
			string password="null";
			
			ConnectionInfo  connectionInfo = new ConnectionInfo(server, user, new PasswordAuthenticationMethod(user, password));
			Console.Write(connectionInfo.CurrentServerEncryption);
			SshClient client = new SshClient(connectionInfo);
			client.Connect();
			
			//SshCommand commande= client.RunCommand("/bin/pwd");
			//print(commande.Result);
			// commande= client.RunCommand("cd /home ; pwd \n");
			// print(commande.Result);
			// commande= client.RunCommand("/bin/pwd");
			
			// print(commande.Result);
			ForwardedPort port = new ForwardedPortLocal(23306, "serveur1", 3306);
			//port.s
			
				client.AddForwardedPort(port);
				
			
				return client;
			
		}
		private static void print(String s) {
			System.Diagnostics.Debug.Print(s);
			
		}
		public static void Main(string[] args)
		{
			//configure le ilog -- http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/
			BasicConfigurator.Configure();
			
			ConfigUtil configUtil = new ConfigUtil();
			ConfigDto configDto = configUtil.getConfig();
			List <MeoServeur> serveurs = configDto.getServeurs();
			
			// TODO:find serveur, tunnel SSH pour mysql
			//SshClient sshClient = testSSh(meoServeur);
			
			Console.WriteLine("Moulinette util - ");
			Console.WriteLine(" Args ("+args.Length+")");
			for(int i=0;i<args.Length;i++) {
				Console.WriteLine(" arg["+i+"] = '"+args[i]+"'");
			}

			String sourceMoulinette="";
			if (args.Length> 0) {
				sourceMoulinette = args[0].Trim();
				if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
					sourceMoulinette+="/";
				}
			}
			MouliPrepaForm formPrepa = new MouliPrepaForm(configDto);
			formPrepa.setWorkspacePath(sourceMoulinette);
			formPrepa.setTargetSvgPath(configDto.getTargetSvgPath());
			formPrepa.ShowDialog();
			
			
//			if (sshClient !=null) {
//			 sshClient.Disconnect();	
//			}
			ILOG.Info("Debut moulinette - chemin '"+sourceMoulinette+"'");
		}

		

		static void majProgression() {
			majProgression(++progression);
		}
		private static void majProgression(int value) {
			progression=value;
			if(form!=null) {
				
				form.updateProgression(progression);
			}
		}

		static string calculMagId(string sourceMoulinette)
		{
			String retour="9999";
			if (sourceMoulinette.StartsWith("MID")) {
				retour=sourceMoulinette. Substring(3, sourceMoulinette.Length - 3);
				if (retour.IndexOf("-") > 0 ) {
					retour=retour.Substring(0, retour.IndexOf("-"));
				}
			}
			return retour;
		}

		public static MouliJob doTraitement(String sourceMoulinette, MouliUtilOptions options) {
			majProgression(0);
			sourceMoulinette = sourceMoulinette.Trim();
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette+="/";
			}
			
			startDateTime = DateTime.Now;
			MouliUtil mouliUtil = new MouliUtil();
			ZipUtil zipUtil = new ZipUtil();
			String archiveName = Path.GetFullPath(sourceMoulinette);
			String dataPath=archiveName;
			
			while (archiveName.EndsWith("/")) {
				archiveName=archiveName.Substring(0, archiveName.Length -1);
			}
			while (archiveName.EndsWith("\\")) {
				archiveName=archiveName.Substring(0, archiveName.Length -1);
			}
			
			String originalDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(sourceMoulinette);
			
			majProgression(5);
			String tmpname=sourceMoulinette.Replace("/", "").Replace("\\", "");
			String scriptMoulinetteFile= tmpname +".moulinette.sh";
			String scriptJobMoulinetteFile=tmpname+".job.sh";
			
			archiveName+=".zip";
			
			List <FileInfo> fichiers = new List<FileInfo>();
			String [] selectionY=null;
			String [] selectionJ=null;
			//String [] selection0 = null;
			
			MouliStatRecap statsRecap = new MouliStatRecap() ;
			Boolean toLowerCase = true;
			
			selectionJ = new string[1];
			
			/*
			a faire pour finir le dev :
				- (FAIT) sortir le xxx.job
				- calculer si doc01 : donc isoler le code d'analyse dans une methode a part
				- calculer si Joint : donc isoler le code d'analyse dans une methode a part
				- (FAIT)- calculer magId
				- lister les serveurs et instance
				- demander pour C et pour S
				- interroger la base admin prod pour les infos. (kiamo?)
				- upload ?
			 */
			
			
			

			String path = mouliUtil.getData()+mouliUtil.getMag01();
			List <String> selectionYfiles = new List<string>();
			if((options!=null) && (options.getMagId()==null)) {
				options.setMagId(calculMagId(sourceMoulinette));
			}
			/*
			if(options==null) {
				//TODO:change me
				options = new MouliUtilOptions();
				options.setMagId(calculMagId(sourceMoulinette));
				options.setLots("CS");
				options.setInstanceName("instance0");
			}
			 */
			
			options.setOrd01(mouliUtil.checkIsOrd01( mouliUtil.getData() + mouliUtil.getOrd01()));
			options.setDoc01(mouliUtil.checkIsDoc01(mouliUtil.getData() + mouliUtil.getDoc01()));
			
			mouliUtil.writeMoulinetteFile("../conf/modele.moulinette", "",scriptMoulinetteFile, options);
			
			mouliUtil.writeJobFile(scriptJobMoulinetteFile, scriptMoulinetteFile, options);

			// Collecte des fichiers presents
			foreach(YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				String file=yfile.ToString();
				if (toLowerCase) {
					file=file.ToLower();
				}
				if (mouliUtil.checkIfFileExists("", mouliUtil.getData(),mouliUtil.getMag01(), file, ".d")) {
					file+=".d";
					selectionYfiles.Add(mouliUtil.getData()+mouliUtil.getMag01()+file);
					Console.WriteLine(" Add : "+file);
				}
				majProgression();
			}
			if (mouliUtil.checkOrdoFixe(mouliUtil.getData())) {
				String file=JFiles.ordo_top_fixe.ToString()+".txt";
				if(toLowerCase) {
					file=file.ToLower();
				}
				path+=mouliUtil.getJoint();
				Console.WriteLine("ordo_top_fixe :"+path+file);
				selectionJ[0] =file;
				
			}
			
			String dataMag=(mouliUtil.getData()+mouliUtil.getMag01());
			//ICI:bug:si mag01 n'existe pas.
			/* si data absent
			 * si data/mag01 absent (que ord01)
			 * */
			
			Console.WriteLine("Complete archive .."+dataMag);
			String dataMagJoint=dataMag+"Joint/";
			selectionY = ConvertisseurUtil.convertitListArray(selectionYfiles);
			

			
			//TODO:analyser data/ord01/[123456789)*.pdf
			// => statsRecap.ord01DocsTotal
			//TODO:distinguer ycli et ystock
			
			
			//script moulinette
			// zipUtil.complete(fichiers, sourceMoulinette, selection0);
			// yfiles.d
			// zipUtil.complete(fichiers, dataMag, selectionY);
			majProgression();
			// Joint/xyz.pdf
			
			
			Console.WriteLine(" list<Fichiers> : "+fichiers.Count);
			Console.WriteLine(" Creation archive : "+archiveName);
			List<String> liste= new List<string>();

			for(int z=0;z<selectionY.Length;z++) {
				liste.Add(selectionY[z]);
				// Console.WriteLine("z : "+z + " > '"+ selectionY[z]+"'");
			}

			
			
			// Ajout de notre valeur ajoutee
			liste.Add(scriptMoulinetteFile);
			liste.Add(scriptJobMoulinetteFile);
			
			/*
			FileInfo spath=new FileInfo(sourceMoulinette);
			foreach(FileInfo info in fichiers) {
				majProgression();
				String fpath =info.Directory.FullName.Replace(spath.FullName, "/").Replace("\\", "/")+"/";
				fpath=fpath.Substring(1, fpath.Length -2)+"/";
				liste.Add(fpath + info.Name);
				Console.WriteLine("Fichier : "+fpath +info.Name);
			}
			 */

			// maj stats
			statsRecap.foundFiles=mouliUtil.analyseTopOrdoFixe(liste, dataMag+JFiles.ordo_top_fixe+".txt", statsRecap.notFoundList);
			if (Directory.Exists(dataMag+"Joint/")) {
				
				for(int z=0;z<selectionJ.Length;z++) {
					liste.Add(dataMag+mouliUtil.getJoint()+selectionJ[z]);
				}
				
				statsRecap.jointDocsTotal = Directory.GetFiles(dataMag+"Joint/").Length;
			}
			statsRecap.mag01FilesTotal = Directory.GetFiles(dataMag).Length;
			
			mouliUtil=null;
			zipUtil=null;
			majProgression(50);
			MouliJob job = new MouliJob(archiveName, originalDir, liste, statsRecap, startDateTime, options, sourceMoulinette);
			return job;
			
		}

		public static void doArchive(MouliJob job)
		{
			ZipUtil zipUtil = new ZipUtil();
			
			List<String> liste = job.getListe();
			if (job.getOptions()!=null) {
				List <String> doc01 = job.getOptions().getDoc01();
				List <String> ord01 = job.getOptions().getOrd01();
				//
				if (doc01!=null) {
					for( int i=0;i< doc01.Count ; i++) {
						liste.Add(doc01[i]);
					}
				}
				//
				if (ord01!=null) {
					for( int i=0;i< ord01.Count ; i++) {
						liste.Add(ord01[i]);
					}
				}
			}
			
			zipUtil.createSimpleArchive(ZipUtil.compressionStandard, job.getArchiveName() , liste);
			majProgression(99);
			// Fin
			Directory.SetCurrentDirectory (job.getOriginalDir());
			Console.WriteLine("fin archive "+job.getArchiveName());
			printRecap(job.getStatRecap());
		}
		//Exemple : W:\meo-moulinettes>M:\github\totoUtil\MoulUtil\bin\Debug\MoulUtil.exe MID1973-DUPOND-20160621-1973-i3
		static void printEnd()
		{
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}

		private static void printHelp() {
			Console.WriteLine(" Outil compression moulinette -- ");
		}

		static void printChrono(TimeSpan ts)
		{
			Console.WriteLine("Temps écoulé : "+string.Format("{0}", Math.Round(ts.TotalSeconds, 3).ToString())+" secondes" );
			Console.WriteLine("Temps écoulé : "+string.Format("{0}", Math.Round(ts.TotalMinutes, 3).ToString())+" minutes" );
		}
		static void printRecap( MouliStatRecap statRecap)
		{
			foreach(String s in statRecap.notFoundList) {
				Console.WriteLine("Absent : "+s);
			}
			Console.WriteLine(" PDF : trouvés : "+statRecap.foundFiles+"  -- NON TROUVES : "+statRecap.notFoundList.Count);
			Console.WriteLine(" fichiers  présents : (mag01/) : "+statRecap.mag01FilesTotal+"  (Joint/) : "+statRecap.jointDocsTotal);
		}
	}
}