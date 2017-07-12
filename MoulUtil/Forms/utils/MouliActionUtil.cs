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
		private static int progression=0;
		
		public MouliActionUtil(MouliActionForm form)
		{
			this.form = form;
		}
		public MouliJob doTraitement(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto)
		{
			Directory.SetCurrentDirectory(configDto.basePath);
			toJournal(sourceMoulinette, options);
			
			majProgression(0);
			sourceMoulinette = sourceMoulinette.Trim();
			if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
				sourceMoulinette += "/";
			}
			
			
			
			DateTime startDateTime = DateTime.Now;
			MouliUtil mouliUtil = new MouliUtil();
			
			if (options.getarchiveName() == null) {
				options.setArchiveName(mouliUtil.calculeArchiveName(sourceMoulinette));
			}
			String archiveName = options.getarchiveName();
			
			
			mouliUtil.setMagasinIrris(options.getNumeroMagasinIrris());
			ZipUtil zipUtil = new ZipUtil();
			//String archiveName = Path.GetFullPath(sourceMoulinette);
			//String dataPath=archiveName;
			
			String originalDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(sourceMoulinette);
			
			majProgression(5);
			
			
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
			//String scriptInstallFile=tmpname+"install.file";
			
			//archiveName+=".zip";
			
			
			List <FileInfo> fichiers = new List<FileInfo>();
			String[] selectionY = null;
			String[] selectionJ = null;
			
			MouliStatRecap statsRecap = new MouliStatRecap();
			// disable once ConvertToConstant.Local
			Boolean toLowerCase = true;
			
			selectionJ = new string[1];
			
			String path = mouliUtil.getData() + mouliUtil.getMag01();
			List <String> selectionYfiles = new List<string>();
			if ((options != null) && (options.getMagId() == null)) {
				options.setMagId(calculMagId(sourceMoulinette));
			}
			
			options.setOrd01(mouliUtil.checkIsOrd01(mouliUtil.getData() + mouliUtil.getOrd01()));
			options.setDoc01(mouliUtil.checkIsDoc01(mouliUtil.getData() + mouliUtil.getDoc01()));
			
			mouliUtil.writeMoulinetteFile(configDto.basePath + "/conf/modele.moulinette", "", scriptMoulinetteFile, options);
			
			mouliUtil.writeJobFile(scriptJobMoulinetteFile, scriptMoulinetteFile, options);

			// Collecte des fichiers presents
			foreach (YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				String file = yfile.ToString();
				if (toLowerCase) {
					file = file.ToLower();
				}
				if (mouliUtil.checkIfFileExists("", mouliUtil.getData(), mouliUtil.getMag01(), file, ".d")) {
					file += ".d";
					selectionYfiles.Add(mouliUtil.getData() + mouliUtil.getMag01() + file);
					Console.WriteLine(" Add : " + file);
				}
				majProgression();
			}
			if (mouliUtil.checkOrdoFixe(mouliUtil.getData())) {
				String file = JFiles.ordo_top_fixe.ToString() + ".txt";
				if (toLowerCase) {
					file = file.ToLower();
				}
				path += mouliUtil.getJoint();
				Console.WriteLine("ordo_top_fixe :" + path + file);
				selectionJ[0] = file;
				
			}
			
			String dataMag = (mouliUtil.getData() + mouliUtil.getMag01());
			Console.WriteLine("Complete archive .." + dataMag);
			String dataMagJoint = dataMag + "Joint/";
			selectionY = ConvertisseurUtil.convertitListArray(selectionYfiles);
			

			//script moulinette
			majProgression();
			
			Console.WriteLine(" list<Fichiers> : " + fichiers.Count);
			Console.WriteLine(" Creation archive : " + archiveName);
			List<String> liste = new List<string>();

			for (int z = 0; z < selectionY.Length; z++) {
				liste.Add(selectionY[z]);
			}

			// Ajout de notre valeur ajoutee
			liste.Add(scriptMoulinetteFile);
			liste.Add(scriptJobMoulinetteFile);

			// maj stats
			statsRecap.datamag = dataMag;
			statsRecap.foundFiles = mouliUtil.analyseTopOrdoFixe(liste, dataMag + JFiles.ordo_top_fixe + ".txt", statsRecap.notFoundList);
			if (Directory.Exists(dataMag + "Joint/")) {
				
				for (int z = 0; z < selectionJ.Length; z++) {
					if (File.Exists(dataMag + mouliUtil.getJoint() + selectionJ[z])) {
						liste.Add(dataMag + mouliUtil.getJoint() + selectionJ[z]);
					}
				}
				
				statsRecap.jointDocsTotal = Directory.GetFiles(dataMag + "Joint/").Length;
			}
			statsRecap.mag01FilesTotal = Directory.GetFiles(dataMag).Length;
			
			mouliUtil = null;
			zipUtil = null;
			majProgression(50);
			MouliJob job = new MouliJob(archiveName, originalDir, liste, statsRecap, startDateTime, options, sourceMoulinette);
			return job;
		}
		
		void majProgression() {
			majProgression(++progression);
		}
		private void majProgression(int value) {
			progression=value;
			if(form!=null) {
				form.updateProgression(progression);
			}
		}

		string calculMagId(string sourceMoulinette)
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
			
			zipUtil.createSimpleArchive(ZipUtil.compressionStandard, job.getArchiveName() , liste, job.getBackgroundWorker());
			//majProgression(99);
			// Fin
			Directory.SetCurrentDirectory (job.getOriginalDir());
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