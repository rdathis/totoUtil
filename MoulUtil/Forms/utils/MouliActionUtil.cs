﻿/*
 * Utilisateur: Renaud
 * Date: 12/07/2017
 * Heure: 12:47:45
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using cmdUtils;
using cmdUtils.Objets;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of MouliActionUtil.
	/// </summary>
	public class MouliActionUtil
	{
		private MouliActionForm form;
		private int progression=0;
		private MouliUtil mouliUtil = null;
		private ConfigDto configDto=null;
		//private const String scriptModele  + "/conf/modele.moulinette"
		
		public MouliActionUtil(MouliActionForm form, ConfigDto configDto)
		{
			this.form = form;
			this.configDto=configDto;
			mouliUtil = new MouliUtil();
		}
		
		public String getJobContent(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto) {
			prepareTraitement(sourceMoulinette, options, configDto);
			return mouliUtil.listStringToString(mouliUtil.genereJob(options.getJobFileName(), options.getScriptFileName(), options));
			
		}
		public String getScriptContent(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto) {
			prepareTraitement(sourceMoulinette, options, configDto);
			String modele = new StreamReader(configDto.basePath + "/conf/modele.moulinette").ReadToEnd();
			return mouliUtil.listStringToString(mouliUtil.genereScript(modele, options.getScriptFileName(), options));
			
		}
		public void prepareTraitement(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto) {
			sourceMoulinette = sourceMoulinette.Trim();
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette += "/";
			}
			if (options.getarchiveName() == null) {
				options.setArchiveName(mouliUtil.calculeArchiveName(sourceMoulinette));
			}
			mouliUtil.setMagasinIrris(options.getNumeroMagasinIrris());
			{
				String left = "";
				String tmpname = sourceMoulinette.Replace("\\", "/");
				while (tmpname.EndsWith("/")) {
					tmpname = tmpname.Substring(0, tmpname.Length - 1);
				}
				int i = tmpname.LastIndexOf("/");
				if (i > 0) {
					left = tmpname.Substring(0, i + 1);
					tmpname = tmpname.Substring(i).Replace("/", "");
				}
				
				String scriptMoulinetteFile = tmpname + ".moulinette.sh";
				String scriptJobMoulinetteFile = tmpname + ".job.sh";
				options.setJobFileName(scriptJobMoulinetteFile);
				options.setScriptFileName(scriptMoulinetteFile);
				
				if ((options != null) && (options.getMagId() == null)) {
					options.setMagId(calculMagId(sourceMoulinette));
				}
			}
		}
		public MouliJob doAnalyse(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto)
		{
			
			//ici il faut faire un change dir workspace/repertoire avant
			
			prepareTraitement(sourceMoulinette, options, configDto);
			//
			Directory.SetCurrentDirectory(options.getWorkspacePath());
			toJournal(sourceMoulinette, options);
			
			majProgression(0);
			DateTime startDateTime = DateTime.Now;
			String archiveName = options.getarchiveName();
			ZipUtil zipUtil = new ZipUtil();
			
			String originalDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(sourceMoulinette);
			
	
			MouliStatRecap statsRecap = new MouliStatRecap();
			List<String> liste = populateListe(false, options, statsRecap);
			mouliUtil = new MouliUtil();
			zipUtil = null;
			majProgression(50);
			MouliJob job = new MouliJob(archiveName, originalDir, liste, statsRecap, startDateTime, options, sourceMoulinette);
			return job;
		}
		
		private void majProgression() {
			majProgression(++progression);
		}
		private void majProgression(int value) {
			progression=value;
//			if(form!=null) {
//				form.updateProgression(progression);
//			}
		}

		private List<String> populateListe(Boolean filtre, MouliUtilOptions options,  MouliStatRecap statsRecap, Boolean toLowerCase = true) {
			String[] selectionY = null;
			String[] selectionJ = null;
			
			List<String> liste = new List<String>();
			selectionJ = new string[1];
			
			String path = mouliUtil.getData() + mouliUtil.getMag01();
			List <String> selectionYfiles = new List<string>();

			String basePath=options.getWorkspacePath()+options.getWorkingPath();
			// Collecte des fichiers presents
			foreach (YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				String file = yfile.ToString();
				if (toLowerCase) {
					file = file.ToLower();
				}
				if (mouliUtil.checkIfFileExists(basePath, mouliUtil.getData(), mouliUtil.getMag01(), file, ".d")) {
					statsRecap.mag01FilesTotal++;
					file += ".d";
					if(YFiles.YCLIENTS==yfile) {
						statsRecap.mag01ClientTotal++;
						
					}
					if(YFiles.YSTOCAT==yfile ||YFiles.YSTOCK==yfile) {
						statsRecap.mag01StockTotal++;
					}

					if(filtreFichiers(filtre, options, yfile)) {
						selectionYfiles.Add(mouliUtil.getData() + mouliUtil.getMag01() + file);
						Console.WriteLine(" Add : " + file);
					}
				}
				majProgression();
			}
			if (mouliUtil.checkOrdoFixe(mouliUtil.getData())) {
				String file = JFiles.ordo_top_fixe + ".txt";
				if (toLowerCase) {
					file = file.ToLower();
				}
				path += mouliUtil.getJoint();
				Console.WriteLine("ordo_top_fixe :" + path + file);
				selectionJ[0] = file;
			}
			
			String scriptMoulinetteFile= options.getScriptFileName();
			String scriptJobMoulinetteFile = options.getJobFileName();
			
			mouliUtil.writeMoulinetteFile(configDto.basePath + "/conf/modele.moulinette", "", scriptMoulinetteFile, options);
			
			mouliUtil.writeJobFile(scriptJobMoulinetteFile, scriptMoulinetteFile, options);
			
			String dataMag = (mouliUtil.getData() + mouliUtil.getMag01());
			Console.WriteLine("Complete archive .." + dataMag);
			String dataMagJoint = dataMag + "Joint/";
			selectionY = ConvertisseurUtil.convertitListArray(selectionYfiles);
			

			//script moulinette
			majProgression();
			
			//Console.WriteLine(" list<Fichiers> : " + fichiers.Count);
			//Console.WriteLine(" Creation archive : " + archiveName);

			for (int z = 0; z < selectionY.Length; z++) {
				liste.Add(selectionY[z]);
			}

			// Ajout de notre valeur ajoutee
			liste.Add(scriptMoulinetteFile);
			liste.Add(scriptJobMoulinetteFile);

			// maj stats
			statsRecap.datamag = dataMag;
			statsRecap.foundFiles = mouliUtil.analyseTopOrdoFixe(liste, dataMag + JFiles.ordo_top_fixe + ".txt", statsRecap.notFoundList);
			if (filtreFichier(filtre, options.doJoint)) {
				if (Directory.Exists(dataMag + "Joint/")) {
					
					for (int z = 0; z < selectionJ.Length; z++) {
						if (File.Exists(dataMag + mouliUtil.getJoint() + selectionJ[z])) {
							liste.Add(dataMag + mouliUtil.getJoint() + selectionJ[z]);
						}
					}
					
					statsRecap.jointDocsTotal = Directory.GetFiles(dataMag + "Joint/").Length;
				}
			}
			
			if(filtreFichier(filtre, options.doDoc01)) {
				options.setOrd01(mouliUtil.checkIsOrd01(mouliUtil.getData() + mouliUtil.getOrd01()));
				options.setDoc01(mouliUtil.checkIsDoc01(mouliUtil.getData() + mouliUtil.getDoc01()));
				statsRecap.doc01DocsTotal = options.getOrd01().Count +options.getDoc01().Count ;
			} else {
				options.setOrd01(new List<String>());
				options.setDoc01(new List<String>());
			}
			
			return liste;
		}

		private bool filtreFichiers(bool filtre, MouliUtilOptions options, YFiles yfile)
		{
			if(filtre) {
				return (((isStock(yfile) && options.doStock))|| (isClient(yfile) && options.doClient));
			}
			return true;
		}


		private Boolean isStock(YFiles yfile) {
			return (YFiles.YFORMULE==yfile || YFiles.YFOURNI==yfile || YFiles.YMARQUE==yfile || YFiles.YSTOCAT==yfile || YFiles.YSTOCK==yfile) ;
		}
		private Boolean isClient(YFiles yfile) {
			return !isStock(yfile); //shortcut.
		}
		private bool filtreFichier(bool filtre, bool isNecessary)
		{
			return ((filtre && isNecessary) || filtre==false);
		}
		
		private string calculMagId(string sourceMoulinette)
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
		
		public static void toJournal (String sourceMoulinette, MouliUtilOptions options) {
			MouliUtil mouliUtil = new MouliUtil();
			mouliUtil.safeCreateDirectory("logs/");
			
			StreamWriter outputFile = new StreamWriter(getJournalFilePath(), true);
			try {
				outputFile.NewLine = "\n";
				outputFile.WriteLine(DateTime.Now+ " prepa moulinette : "+sourceMoulinette + " "+getDetails(options));
			} catch (Exception e) {
				Console.WriteLine(e);
			} finally {
				outputFile.Close();
			}
		}
		private static String getJournalFilePath() {
			DateTime date = DateTime.Now;
			return "logs/journal-"+date.Year+".log";
		}
		private static String getDetails(MouliUtilOptions options) {
			String s="";
			s+=" MagId:"+options.getMagId();
			s+=" instance:"+options.getInstanceName();
			s+=" Lots:"+options.getLots() ;
			s+=" joint:"+options.getIsJoint();
			if(options.getOrd01()!=null) {
				s+=" ord01:"+(options.getOrd01().Count > 0);
			}
			return s;
		}
		public void doArchive(MouliJob job)
		{
			Directory.SetCurrentDirectory (job.getOriginalDir());
			Directory.SetCurrentDirectory (job.getMoulinettePath());
			
			job.setStart(DateTime.Now);
			//ici:on doit recalculer suivant les choix
//			job.getOptions().get
//			job.setListe(calculeListe());
			//MouliJob job = new MouliJob(archiveName, originalDir, liste, statsRecap, startDateTime, options, sourceMoulinette);
			
			
			ZipUtil zipUtil = new ZipUtil();
			
			//List<String> liste = job.getListe();
			MouliStatRecap statsRecap = new MouliStatRecap();
			List<String> liste = populateListe(true, job.getOptions(), statsRecap);
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
			
			zipUtil.createSimpleArchive(ZipUtil.compressionStandard, job.getArchiveName() , liste, job.getBackgroundWorker());
			//majProgression(99);
			// Fin
			Directory.SetCurrentDirectory (configDto.getProgramPath());
			Console.WriteLine("fin archive "+job.getArchiveName());
			printRecap(job.getStatRecap());
		}
		private void printRecap( MouliStatRecap statRecap)
		{
			foreach(String s in statRecap.notFoundList) {
				Console.WriteLine("Absent : "+s);
			}
			Console.WriteLine(" PDF : trouvés : "+statRecap.foundFiles+"  -- NON TROUVES : "+statRecap.notFoundList.Count);
			Console.WriteLine(" fichiers  présents : ("+statRecap.datamag+"/) : "+statRecap.mag01FilesTotal+"  (Joint/) : "+statRecap.jointDocsTotal);
		}
	}
}