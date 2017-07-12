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
using MoulUtil.Forms.utils;
using Renci.SshNet;
using cmdUtils;
using cmdUtils.Objets;
using cmdUtils.Objets.utils;
using log4net;
using log4net.Config;

namespace MoulUtil
{

	class MouliProgram
	{
		//private static MouliActionForm form =null;
		//private static int progression=0;
		//private static DateTime startDateTime;
		//private static String basePath;
		static log4net.ILog ILOG = LogManager.GetLogger("mouliUtil");

		private static void print(String s) {
			System.Diagnostics.Debug.Print(s);
		}

		public static void Main(string[] args)
		{
			String tmpBasePath=Directory.GetCurrentDirectory();
			if(tmpBasePath.ToLower().EndsWith("\\bin") && !Directory.Exists("conf") &&  Directory.Exists("..\\conf")) {
				
				Directory.SetCurrentDirectory("..");
				tmpBasePath=Directory.GetCurrentDirectory();
				Console.WriteLine("directory changed to "+Directory.GetCurrentDirectory());
			}
			//configure le ilog -- http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/
			BasicConfigurator.Configure();
			
			ConfigUtil configUtil = new ConfigUtil();
			ConfigDto configDto = configUtil.getConfig();
			configDto.basePath=tmpBasePath;
			
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
			formPrepa.controleRegistre();
			formPrepa.setWorkspacePath(sourceMoulinette);
			formPrepa.setTargetSvgPath(configDto.getTargetSvgPath());
			formPrepa.ShowDialog();
			
			ILOG.Info("Debut moulinette - chemin '"+sourceMoulinette+"'");
		}

		

/*
		public static MouliJob doTraitement(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto) {
			Directory.SetCurrentDirectory(configDto.basePath);
			MouliActionUtil.toJournal(sourceMoulinette, options);
			
			majProgression(0);
			sourceMoulinette = sourceMoulinette.Trim();
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette+="/";
			}
			
			
			
			DateTime startDateTime = DateTime.Now;
			MouliUtil mouliUtil = new MouliUtil();
			
			if(options.getarchiveName()==null) {
				options.setArchiveName(mouliUtil.calculeArchiveName(sourceMoulinette));
			}
			String archiveName=options.getarchiveName();
			
			
			mouliUtil.setMagasinIrris(options.getNumeroMagasinIrris());
			ZipUtil zipUtil = new ZipUtil();
			//String archiveName = Path.GetFullPath(sourceMoulinette);
			//String dataPath=archiveName;
			
			String originalDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(sourceMoulinette);
			
			majProgression(5);
			
			
			String left="";
			String tmpname=sourceMoulinette.Replace("\\", "/");
			while (tmpname.EndsWith("/")) {
				tmpname=tmpname.Substring(0, tmpname.Length -1);
			}
			int i=tmpname.LastIndexOf("/");
			if(i>0) {
				left=tmpname.Substring(0, i+1);
				tmpname=tmpname.Substring(i).Replace("/", "");
			}
			
			String scriptMoulinetteFile= tmpname +".moulinette.sh";
			String scriptJobMoulinetteFile=tmpname+".job.sh";
			//String scriptInstallFile=tmpname+"install.file";
			
			//archiveName+=".zip";
			
			
			List <FileInfo> fichiers = new List<FileInfo>();
			String [] selectionY=null;
			String [] selectionJ=null;
			
			MouliStatRecap statsRecap = new MouliStatRecap() ;
			// disable once ConvertToConstant.Local
			Boolean toLowerCase = true;
			
			selectionJ = new string[1];
			
			String path = mouliUtil.getData()+mouliUtil.getMag01();
			List <String> selectionYfiles = new List<string>();
			if((options!=null) && (options.getMagId()==null)) {
				options.setMagId(calculMagId(sourceMoulinette));
			}
			
			options.setOrd01(mouliUtil.checkIsOrd01( mouliUtil.getData() + mouliUtil.getOrd01()));
			options.setDoc01(mouliUtil.checkIsDoc01(mouliUtil.getData() + mouliUtil.getDoc01()));
			
			mouliUtil.writeMoulinetteFile(configDto.basePath+"/conf/modele.moulinette", "",scriptMoulinetteFile, options);
			
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
			Console.WriteLine("Complete archive .."+dataMag);
			String dataMagJoint=dataMag+"Joint/";
			selectionY = ConvertisseurUtil.convertitListArray(selectionYfiles);
			

			//script moulinette
			majProgression();
			
			Console.WriteLine(" list<Fichiers> : "+fichiers.Count);
			Console.WriteLine(" Creation archive : "+archiveName);
			List<String> liste= new List<string>();

			for(int z=0;z<selectionY.Length;z++) {
				liste.Add(selectionY[z]);
			}

			// Ajout de notre valeur ajoutee
			liste.Add(scriptMoulinetteFile);
			liste.Add(scriptJobMoulinetteFile);

			// maj stats
			statsRecap.datamag=dataMag;
			statsRecap.foundFiles=mouliUtil.analyseTopOrdoFixe(liste, dataMag+JFiles.ordo_top_fixe+".txt", statsRecap.notFoundList);
			if (Directory.Exists(dataMag+"Joint/")) {
				
				for(int z=0;z<selectionJ.Length;z++) {
					if(File.Exists(dataMag+mouliUtil.getJoint()+selectionJ[z])) {
						liste.Add(dataMag+mouliUtil.getJoint()+selectionJ[z]);
					}
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
	*/

		
		/*
		static void printEnd()
		{
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		*/
		/*
		private static void printHelp() {
			Console.WriteLine(" Outil compression moulinette -- ");
		}
		*/
		/*
		static void printChrono(TimeSpan ts)
		{
			Console.WriteLine("Temps écoulé : "+string.Format("{0}", Math.Round(ts.TotalSeconds, 3).ToString())+" secondes" );
			Console.WriteLine("Temps écoulé : "+string.Format("{0}", Math.Round(ts.TotalMinutes, 3).ToString())+" minutes" );
		}
		*/
	}
}