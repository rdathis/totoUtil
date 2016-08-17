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
using cmdUtils.Objets;
using log4net;
using log4net.Config;
namespace MoulUtil
{

	class Program
	{
		
		static log4net.ILog ILOG = LogManager.GetLogger("mouliUtil");
		private class StatsRecap {
			public int foundFiles=0;
			public List<String> notFoundList=new List<string>();
			public int mag01FilesTotal=0;
			public  int jointDocsTotal=0;
		}
		
		public static void Main(string[] args)
		{
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
			ILOG.Info("Debut moulinette");
			//
			String sourceMoulinette = args[0].Trim();
			
			
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette+="/";
			}
			doTraitement(sourceMoulinette);
		}
		private static void doTraitement(String sourceMoulinette) {
			DateTime startDateTime = DateTime.Now;
			MouliUtil mouliUtil = new MouliUtil();
			ZipUtil  zipUtil = new ZipUtil();
			
			String archiveName = Path.GetFullPath(sourceMoulinette);
			while (archiveName.EndsWith("/")) {
				archiveName=archiveName.Substring(0, archiveName.Length -1);
			};
			while (archiveName.EndsWith("\\")) {
				archiveName=archiveName.Substring(0, archiveName.Length -1);
			};
			archiveName+=".zip";
			
			List <FileInfo> fichiers = new List<FileInfo>();
			String [] selectionY=null;
			String [] selectionJ=null;
			
			StatsRecap statsRecap = new StatsRecap() ;
			Boolean toLowerCase = false;
			
			selectionJ = new string[1];
			
			String path = mouliUtil.getData()+mouliUtil.getMag01();
			List <String> selectionYfiles = new List<string>();
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
			
			zipUtil.complete(fichiers, sourceMoulinette+dataMag, selectionY);
			zipUtil.complete(fichiers, sourceMoulinette+dataMagJoint, selectionJ);
			
			Console.WriteLine(" list<Fichiers> : "+fichiers.Count);
			Console.WriteLine(" Creation archive : "+archiveName);
			List<String> liste= new List<string>();
			FileInfo spath=new FileInfo(sourceMoulinette);
			foreach(FileInfo info in fichiers) {
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
			
			//Creation archive
			zipUtil.createSimpleArchive(ZipUtil.compressionStandard, archiveName, liste);
			
			// Fin
			Directory.SetCurrentDirectory (originalDir);
			Console.WriteLine("fin archive "+archiveName);
			printRecap(statsRecap);
			mouliUtil = null;
			
			
			TimeSpan ts = DateTime.Now - startDateTime;
			
			Console.WriteLine("Temps écoulé : "+string.Format("{0}", ts.TotalSeconds.ToString())+" secondes" );
			Console.WriteLine("Temps écoulé : "+string.Format("{0}", ts.TotalMinutes.ToString())+" minutes" );
			//TODO:02-- inclure script de at (how to instance ?) - a generer ailleurs, ou faire un programme juste pour ca.
			// printEnd();
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