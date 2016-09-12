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
using System.Xml.Serialization;
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
		static log4net.ILog ILOG = LogManager.GetLogger("mouliUtil");
		private class StatsRecap {
			public int foundFiles=0;
			public List<String> notFoundList=new List<string>();
			public int mag01FilesTotal=0;
			public  int jointDocsTotal=0;
		}
		
		
		public static void Main(string[] args)
		{
			//testXml();
			//configure le ilog -- http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/
			BasicConfigurator.Configure();
			
			Console.WriteLine("Moulinette util - ");
			Console.WriteLine(" Args ("+args.Length+")");
			for(int i=0;i<args.Length;i++) {
				Console.WriteLine(" arg["+i+"] = '"+args[i]+"'");
			}
			if (args.Length< 1) {
				printHelp();
				printEnd();
				return;
			}
			
			//
			String sourceMoulinette = args[0].Trim();
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette+="/";
			}
			
			ILOG.Info("Debut moulinette - chemin '"+sourceMoulinette+"'");
			form= new MouliForm();
			form.setServeurs(readServeurs());
			form.setInstances(readInstances());
			form.setPath(sourceMoulinette);
			form.prepare();
			form.ShowDialog();
			


		}
		private static List<MeoServeur> readServeurs() {
			XmlSerializer serializer = new XmlSerializer(typeof(List<MeoServeur>));
			FileStream fs = new FileStream(Mouliconfig.serversConfigFile, FileMode.Open);
			List <MeoServeur> liste = (List<MeoServeur>)serializer.Deserialize(fs);
			fs.Close();
			return liste;
		}
		private static List<MeoInstance> readInstances() {
			XmlSerializer serializer = new XmlSerializer(typeof(List<MeoInstance>));
			FileStream fs = new FileStream(Mouliconfig.instancesConfigFile, FileMode.Open);
			List <MeoInstance> liste = (List<MeoInstance>)serializer.Deserialize(fs);
			fs.Close();
			return liste;
		}
		
		private static void testXml() {
			//fonctionne
			Boolean ecriture = false;
			Boolean lecture=false;
			//
			if (ecriture) {
				XmlSerializer serverSerializer =      new XmlSerializer(typeof(List<MeoServeur>));
				
				XmlSerializer instancesSerializer =      new XmlSerializer(typeof(List<MeoInstance>));
				
				List<MeoInstance>instancesList = new List<MeoInstance>();
				List <MeoServeur> serversList = new List<MeoServeur>();
				TextWriter serverWriter = new StreamWriter(Mouliconfig.serversConfigFile);
				TextWriter instancesWriter = new StreamWriter(Mouliconfig.instancesConfigFile);
				MeoServeur serveur1 = new MeoServeur("meo1", "server1");
				MeoServeur serveur2 = new MeoServeur("meo2", "server2");
				MeoServeur serveur5 = new MeoServeur("meo5", "server5");
				
				MeoInstance instance1 = new MeoInstance(serveur1.getNom(), "instance1", "instance1", "meo_cli_instance1");
				MeoInstance instance3 = new MeoInstance(serveur2.getNom(), "instance3", "instance3", "meo_cli_instance3");
				
				serversList.Add(serveur1);
				serversList.Add(serveur2);
				serversList.Add(serveur5);
				
				instancesList.Add(instance1);
				instancesList.Add(instance3);
				
				instancesSerializer.Serialize(instancesWriter, instancesList);
				serverSerializer.Serialize(serverWriter, serversList);
				serverWriter.Close();
				instancesWriter.Close();
			}
			//
			if (lecture)  {
				XmlSerializer serializer = new XmlSerializer(typeof(List<MeoServeur>));
				FileStream fs = new FileStream(Mouliconfig.serversConfigFile, FileMode.Open);
				List <MeoServeur> liste = (List<MeoServeur>)serializer.Deserialize(fs);
				fs.Close();
			}

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

		public static void doTraitement(String sourceMoulinette, MouliUtilOptions options) {
			majProgression(0);
			sourceMoulinette = sourceMoulinette.Trim();
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette+="/";
			}
			
			DateTime startDateTime = DateTime.Now;
			MouliUtil mouliUtil = new MouliUtil();
			ZipUtil  zipUtil = new ZipUtil();
			String archiveName = Path.GetFullPath(sourceMoulinette);
			String dataPath=archiveName;
			
			while (archiveName.EndsWith("/")) {
				archiveName=archiveName.Substring(0, archiveName.Length -1);
			}
			while (archiveName.EndsWith("\\")) {
				archiveName=archiveName.Substring(0, archiveName.Length -1);
			}
			majProgression(5);
			String tmpname=sourceMoulinette.Replace("/", "").Replace("\\", "");
			String scriptMoulinetteFile= tmpname +".moulinette.sh";
			String scriptJobMoulinetteFile=tmpname+".job.sh";
			
			archiveName+=".zip";
			
			List <FileInfo> fichiers = new List<FileInfo>();
			String [] selectionY=null;
			String [] selectionJ=null;
			//String [] selection0 = null;
			
			StatsRecap statsRecap = new StatsRecap() ;
			Boolean toLowerCase = false;
			
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
			
			if(options==null) {
				//TODO:change me
				options = new MouliUtilOptions();
				options.setMagId(calculMagId(sourceMoulinette));
				options.setLots("CS");
				options.setInstanceName("instance0");
			}
			mouliUtil.writeMoulinetteFile("./conf/modele.moulinette", sourceMoulinette, dataPath+scriptMoulinetteFile, options);
			
			mouliUtil.writeJobFile(dataPath+scriptJobMoulinetteFile, scriptMoulinetteFile);
			selectionYfiles.Add(scriptMoulinetteFile);
			selectionYfiles.Add(scriptJobMoulinetteFile);
			// Collecte des fichiers presents
			foreach(YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				String file=yfile.ToString();
				if (toLowerCase) {
					file=file.ToLower();
				}
				if (mouliUtil.checkIfFileExists(sourceMoulinette, mouliUtil.getData(),mouliUtil.getMag01(), file, ".d")) {
					file+=".d";
					selectionYfiles.Add(file);
					Console.WriteLine(" Add : "+file);
				}
				majProgression();
			}
			if (mouliUtil.checkOrdoFixe(sourceMoulinette + mouliUtil.getData())) {
				String file=JFiles.ordo_top_fixe.ToString()+".txt";
				if(toLowerCase) {
					file=file.ToLower();
				}
				path+=mouliUtil.getJoint();
				Console.WriteLine("ordo_top_fixe :"+path+file);
				selectionJ[0] =file;
				
			}
			const String dataMag="data/mag01/";
			Console.WriteLine("Complete archive .."+dataMag);
			const String dataMagJoint=dataMag+"Joint/";
			selectionY = ConvertisseurUtil.convertitListArray(selectionYfiles);
			
			//recherche des adresses des fichiers a inclure
			for(int z=0;z<selectionY.Length;z++) {
				Console.WriteLine("z : "+z + " > '"+ selectionY[z]+"'");
			}
			
			
			//script moulinette
			// zipUtil.complete(fichiers, sourceMoulinette, selection0);
			// yfiles.d
			zipUtil.complete(fichiers, sourceMoulinette+dataMag, selectionY);
			majProgression();
			// Joint/xyz.pdf
			if (selectionJ.Length>0) {
				zipUtil.complete(fichiers, sourceMoulinette+dataMagJoint, selectionJ);
			}
			
			
			Console.WriteLine(" list<Fichiers> : "+fichiers.Count);
			Console.WriteLine(" Creation archive : "+archiveName);
			List<String> liste= new List<string>();
			
			// Ajout de notre valeur ajoutee
			liste.Add(scriptMoulinetteFile);
			liste.Add(scriptJobMoulinetteFile);
			
			
			FileInfo spath=new FileInfo(sourceMoulinette);
			foreach(FileInfo info in fichiers) {
				majProgression();
				String fpath =info.Directory.FullName.Replace(spath.FullName, "/").Replace("\\", "/")+"/";
				fpath=fpath.Substring(1, fpath.Length -2)+"/";
				liste.Add(fpath + info.Name);
				Console.WriteLine("Fichier : "+fpath +info.Name);
			}
			String originalDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(sourceMoulinette);

			// maj stats
			statsRecap.foundFiles=mouliUtil.analyseTopOrdoFixe(liste, dataMag+JFiles.ordo_top_fixe+".txt", statsRecap.notFoundList);
			if (Directory.Exists(dataMag+"Joint/")) {
				statsRecap.jointDocsTotal = Directory.GetFiles(dataMag+"Joint/").Length;
			}
			statsRecap.mag01FilesTotal = Directory.GetFiles(dataMag).Length;
			
			majProgression(50);
			//Creation archive
			zipUtil.createSimpleArchive(ZipUtil.compressionStandard, archiveName, liste);
			majProgression(99);
			
			// Fin
			Directory.SetCurrentDirectory (originalDir);
			Console.WriteLine("fin archive "+archiveName);
			printRecap(statsRecap);
			mouliUtil = null;
			
			
			TimeSpan ts = DateTime.Now - startDateTime;
			
			printChrono(ts);
			// printEnd();
			majProgression(100);
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
		static void printRecap(StatsRecap statRecap)
		{
			foreach(String s in statRecap.notFoundList) {
				Console.WriteLine("Absent : "+s);
			}
			Console.WriteLine(" PDF : trouvés : "+statRecap.foundFiles+"  -- NON TROUVES : "+statRecap.notFoundList.Count);
			Console.WriteLine(" fichiers  présents : (mag01/) : "+statRecap.mag01FilesTotal+"  (Joint/) : "+statRecap.jointDocsTotal);
		}
	}
}