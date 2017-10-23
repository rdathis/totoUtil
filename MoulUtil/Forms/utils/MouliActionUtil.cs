/*
 * Utilisateur: Renaud
 * Date: 12/07/2017
 * Heure: 12:47:45
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Renci.SshNet.Security;
using cmdUtils;
using cmdUtils.Objets;
using cmdUtils.Objets.business;
using cmdUtils.Objets.utils;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of MouliActionUtil.
	/// </summary>
	public class MouliActionUtil
	{
		private MouliActionForm form;
		private int progression = 0;
		private readonly MouliUtil mouliUtil = null;
		private ConfigDto configDto = null;
		private readonly log4net.ILog LOGGER = null;
		private readonly BcdUtil bcdUtil = null;
		
		public MouliActionUtil(MouliActionForm form, ConfigDto configDto, log4net.ILog  LOGGER, MouliUtil mouliUtil)
		{
			this.form = form;
			this.configDto = configDto;
			this.LOGGER = LOGGER;
			this.mouliUtil = mouliUtil;
			this.bcdUtil = new BcdUtil(LOGGER);
		}
		
		public String getJobContent(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto)
		{
			prepareTraitement(sourceMoulinette, options, configDto);
			return mouliUtil.listStringToString(mouliUtil.genereJob(options.getJobFileName(), options.getScriptFileName(), options));
			
		}
		public String getScriptContent(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto)
		{
			prepareTraitement(sourceMoulinette, options, configDto);
			String modele = new StreamReader(configDto.basePath + "/conf/modele.moulinette").ReadToEnd();
			return mouliUtil.listStringToString(mouliUtil.genereScript(modele, options.getScriptFileName(), options));
			
		}
		public void prepareTraitement(String sourceMoulinette, MouliUtilOptions options, ConfigDto configDto)
		{
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
			toJournal(sourceMoulinette, options, LOGGER);
			
			majProgression(0);
			DateTime startDateTime = DateTime.Now;
			String archiveName = options.getarchiveName();
			ZipUtil zipUtil = new ZipUtil(LOGGER);
			
			String originalDir = Directory.GetCurrentDirectory();
			Directory.SetCurrentDirectory(sourceMoulinette);
			
			String detailClient = null;
			String detailStock = null;
			String detailJoint = null;
			String detailDoc = null;
			MouliStatRecap statsRecap = new MouliStatRecap();
			List<String> liste = populateListe(false, options, statsRecap, detailClient, detailStock, detailJoint, detailDoc);
			//mouliUtil = new MouliUtil(LOGGER);
			zipUtil = null;
			majProgression(50);
			
			MouliJob job = new MouliJob(archiveName, originalDir, liste, statsRecap, startDateTime, options, sourceMoulinette);
			job.setDetailClient(detailClient);
			job.setDetailStock(detailStock);
			job.setDetailJoint(detailJoint);
			job.setDetailDoc(detailDoc);
			
			doStatAnalyses(options, job, sourceMoulinette, configDto);

			//
			return job;
		}
		
		private void majProgression()
		{
			majProgression(++progression);
		}
		private void majProgression(int value)
		{
			progression = value;
//			if(form!=null) {
//				form.updateProgression(progression);
//			}
		}

		private List<String> populateListe(Boolean filtre, MouliUtilOptions options, MouliStatRecap statsRecap, String detailClient, String detailStock, String detailJoint, String detailDoc, Boolean toLowerCase = true)
		{
			String[] selectionY = null;
			String[] selectionJ = null;
			
			List<String> liste = new List<String>();
			List<YFiles> missingList = new List<YFiles>();
			selectionJ = new string[1];
			
			String path = mouliUtil.getData() + mouliUtil.getMag01();
			List <String> selectionYfiles = new List<string>();
			mouliUtil.setMagasinIrris(options.getNumeroMagasinIrris());
			
			String basePath = options.getWorkspacePath() + options.getWorkingPath();
			// Collecte des fichiers presents
			foreach (YFiles yfile in Enum.GetValues(typeof(YFiles))) {
				missingList.Add(yfile);
				String file = yfile.ToString();
				if (toLowerCase) {
					file = file.ToLower();
				}
				if (mouliUtil.checkIfFileExists(basePath, mouliUtil.getData(), mouliUtil.getMag01(), file, ".d")) {
					missingList.Remove(yfile);
					statsRecap.mag01FilesTotal++;
					file += ".d";
					if (YFiles.YCLIENTS == yfile) {
						statsRecap.mag01ClientTotal++;
						
					}
					if (YFiles.YSTOCAT == yfile || YFiles.YSTOCK == yfile) {
						statsRecap.mag01StockTotal++;
					}

					if (filtreFichiers(filtre, options, yfile)) {
						selectionYfiles.Add(mouliUtil.getData() + mouliUtil.getMag01() + file);
						Console.WriteLine(" Add : " + file);
					}
				}
				majProgression();
			}
			foreach (YFiles yfile in missingList) {
				if (isStock(yfile)) {
					detailStock = yfile + " ";
				}
				if (isClient(yfile)) {
					detailClient = yfile + " ";
				}
			}
			if (mouliUtil.checkOrdoFixe(mouliUtil.getData())) {
				String file = JFiles.ordo_top_fixe + ".txt";
				if (toLowerCase) {
					file = file.ToLower();
				}
				path += mouliUtil.getJoint();
				LOGGER.Info("ordo_top_fixe :" + path + file);
				
				if (filtreFichiers(filtre, options, JFiles.ordo_top_fixe)) {
					selectionJ[0] = file;
				}
			}
			
			String scriptMoulinetteFile = options.getScriptFileName();
			String scriptJobMoulinetteFile = options.getJobFileName();
			
			mouliUtil.writeMoulinetteFile(configDto.basePath + "/conf/modele.moulinette", "", scriptMoulinetteFile, options);
			
			mouliUtil.writeJobFile(scriptJobMoulinetteFile, scriptMoulinetteFile, options);
			
			String dataMag = (mouliUtil.getData() + mouliUtil.getMag01());
			LOGGER.Info("Complete archive .." + dataMag);
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
			
			if (filtreFichier(filtre, options.doDoc01)) {
				options.setOrd01(mouliUtil.checkIsOrd01(mouliUtil.getData() + mouliUtil.getOrd01()));
				options.setDoc01(mouliUtil.checkIsDoc01(mouliUtil.getData() + mouliUtil.getDoc01()));
				statsRecap.doc01DocsTotal = options.getOrd01().Count + options.getDoc01().Count;
			} else {
				options.setOrd01(new List<String>());
				options.setDoc01(new List<String>());
			}
			
			return liste;
		}

		private bool filtreFichiers(bool filtre, MouliUtilOptions options, YFiles yfile)
		{
			if (filtre) {
				return (((isStock(yfile) && options.doStock)) || (isClient(yfile) && options.doClient));
			}
			return true;
		}
		private bool filtreFichiers(bool filtre, MouliUtilOptions options, JFiles jfile)
		{
			if (filtre) {
				return (options.doJoint);
			}
			return true;
		}


		private Boolean isStock(YFiles yfile)
		{
			return (YFiles.YFORMULE == yfile || YFiles.YFOURNI == yfile || YFiles.YMARQUE == yfile || YFiles.YSTOCAT == yfile || YFiles.YSTOCK == yfile);
		}
		private Boolean isClient(YFiles yfile)
		{
			return !isStock(yfile); //shortcut.
		}
		private bool filtreFichier(bool filtre, bool isNecessary)
		{
			return ((filtre && isNecessary) || filtre == false);
		}
		
		private string calculMagId(string sourceMoulinette)
		{
			String retour = "9999";
			if (sourceMoulinette.StartsWith("MID")) {
				retour = sourceMoulinette.Substring(3, sourceMoulinette.Length - 3);
				if (retour.IndexOf("-") > 0) {
					retour = retour.Substring(0, retour.IndexOf("-"));
				}
			}
			return retour;
		}
		
		public static void toJournal(String sourceMoulinette, MouliUtilOptions options, log4net.ILog  LOGGER)
		{
			MouliUtil mouliUtil = new MouliUtil(LOGGER);
			mouliUtil.safeCreateDirectory("logs/");
			
			StreamWriter outputFile = new StreamWriter(getJournalFilePath(), true);
			try {
				outputFile.NewLine = "\n";
				outputFile.WriteLine(DateTime.Now + " prepa moulinette : " + sourceMoulinette + " " + getDetails(options));
			} catch (Exception e) {
				LOGGER.Error(e);
			} finally {
				outputFile.Close();
			}
		}
		private static String getJournalFilePath()
		{
			DateTime date = DateTime.Now;
			return "logs/journal-" + date.Year + ".log";
		}
		private static String getDetails(MouliUtilOptions options)
		{
			String s = "";
			s += " MagId:" + options.getMagId();
			s += " instance:" + options.getInstanceName();
			s += " Lots:" + options.getLots();
			s += " joint:" + options.getIsJoint();
			if (options.getOrd01() != null) {
				s += " ord01:" + (options.getOrd01().Count > 0);
			}
			return s;
		}
		public void doArchive(MouliJob job)
		{
			Directory.SetCurrentDirectory(job.getOriginalDir());
			Directory.SetCurrentDirectory(job.getMoulinettePath());
			
			job.setStart(DateTime.Now);
			
			MouliStatRecap statsRecap = new MouliStatRecap();

			String detailClient = null;
			String detailStock = null;
			String detailJoint = null;
			String detailDoc = null;
			
			//Actualisation de la liste des fichier, en fonction des options.
			List<String> liste = populateListe(true, job.getOptions(), statsRecap, detailClient, detailStock, detailJoint, detailDoc);
			//
			if (job.getOptions() != null) {
				List <String> doc01 = job.getOptions().getDoc01();
				List <String> ord01 = job.getOptions().getOrd01();
				//
				if (doc01 != null) {
					for (int i = 0; i < doc01.Count; i++) {
						liste.Add(doc01[i]);
					}
				}
				//
				if (ord01 != null) {
					for (int i = 0; i < ord01.Count; i++) {
						liste.Add(ord01[i]);
					}
				}
			}
			ZipUtil zipUtil = new ZipUtil(LOGGER);
			zipUtil.createSimpleArchive(ZipUtil.compressionStandard, job.getArchiveName(), liste, job.getBackgroundWorker());
			//majProgression(99);
			// Fin
			Directory.SetCurrentDirectory(configDto.getProgramPath());
			LOGGER.Info("fin archive " + job.getArchiveName());
			printRecap(job.getStatRecap());
		}
		private void printRecap(MouliStatRecap statRecap)
		{
			foreach (String s in statRecap.notFoundList) {
				LOGGER.Warn("Absent : " + s);
			}
			LOGGER.Info(" PDF : trouvés : " + statRecap.foundFiles + "  -- NON TROUVES : " + statRecap.notFoundList.Count);
			LOGGER.Info(" fichiers  présents : (" + statRecap.datamag + "/) : " + statRecap.mag01FilesTotal + "  (Joint/) : " + statRecap.jointDocsTotal);
		}

		private MouliAnneeRecap getYearRecap(String year, List<MouliAnneeRecap> liste)
		{
			foreach (MouliAnneeRecap recap in liste) {
				if (year == recap.getYear()) {
					return recap;
				}
			}
			MouliAnneeRecap yearRecap = new MouliAnneeRecap(year);
			liste.Add(yearRecap);
			return yearRecap;
		}
		List<MouliAnneeRecap> doListeRecap(MouliAnalyseRecap opRecap, MouliAnalyseRecap leRecap, MouliAnalyseRecap stRecap)
		{
			List<MouliAnneeRecap> liste = new List<MouliAnneeRecap>();
			
			foreach (String year in opRecap.getDico().Keys) {
				MouliAnneeRecap recap = getYearRecap(year, liste);
				recap.setNbVisO(opRecap.getDico()[year][2]);
			}
			//
			foreach (String year in leRecap.getDico().Keys) {
				MouliAnneeRecap recap = getYearRecap(year, liste);
				recap.setNbVisL(leRecap.getDico()[year][2]);
			}
			//
			foreach (String year in stRecap.getDico().Keys) {
				MouliAnneeRecap recap = getYearRecap(year, liste);
				//recap.setSt(0, 0, stRecap.getDico()[year]);
				recap.setSt(stRecap.getDico()[year][0], stRecap.getDico()[year][1], stRecap.getDico()[year][2]);
			}
			
			List<MouliAnneeRecap> retourList = new List<MouliAnneeRecap>();
			foreach (MouliAnneeRecap yearRecap in liste) {
				int nVO = yearRecap.getNbVisO();
				int nVL = yearRecap.getNbVisL();
				int nVT = nVO + nVL;
				//
				int sNe = yearRecap.getNbStNeg();
				int sNu = yearRecap.getNbStNul();
				int sPo = yearRecap.getNbStPos();
				int sTo = sNe + sNu + sPo;
				if (nVT == 0 && sTo == 0) {
					//void
				} else {
					retourList.Add(yearRecap);
				}
			}
			//
			retourList.Sort(new MouliAnneeRecap.MouliAnneeRecapComparer());
			return retourList;
		}
		public string doStatAnalyses(MouliUtilOptions options, MouliJob job, string text, ConfigDto configDto)
		{
			String path = text;
			MouliAnalyseRecap opRecap = doStatAnalyse(options, job, path, YFiles.YTOPTIC);
			MouliAnalyseRecap leRecap = doStatAnalyse(options, job, path, YFiles.YTLENTI);
			MouliAnalyseRecap stRecap = doStatAnalyse(options, job, path, YFiles.YSTOCK);
			List<MouliAnneeRecap> liste = doListeRecap(opRecap, leRecap, stRecap);
			String str = "nbV : O=" + opRecap.getNb() + " T=" + leRecap.getNb() + " ==>" + (opRecap.getNb() + leRecap.getNb());
			str += "\n";
			str += "St   :" + stRecap.getNb();
			
			String recapHtmlFile = "recap-MID" + options.getMagId() + ".html";
			
			String recapHtml = buildRecapHtml(options, liste);
			
			job.getStatRecap().listeRecapAnnee = liste;
			job.getStatRecap().recapHtml = recapHtml;
			try {
				StreamWriter sw = new StreamWriter(recapHtmlFile);
				sw.Write(recapHtml);
				sw.Close();
				Console.Write(str);
			} catch (Exception ex) {
				LOGGER.Error(ex);
			}
			return str;
		}


		string buildRecapHtml(MouliUtilOptions options, List<MouliAnneeRecap> liste)
		{
			StringBuilder s = new StringBuilder();
			
			//TODO:move in a model file.
			s.Append("<html><head><title>Recap visites et stocks magasin</title>\n");
			
			s.Append("<style> \n");
			s.Append("tr:nth-child(even) {background: #CCC} \n");
			s.Append("tr:nth-child(odd) {background: #FFF} \n");

			s.Append(".separator { background: pink } \n");
			s.Append(".lyear { background: lightgrey } \n");
			s.Append(".hyear, .hvis, .hstk, .hcumul, .htotal{ width: 80px ; background: lightgrey} \n");
			s.Append(".lvis, .lstk, .ltotal, .lcumul { text-align:right } \n");
			s.Append(".lvis { background: lightblue } \n");
			s.Append(".lstk { background: lightgreen } \n");
			s.Append(".ltotal, .lcumul { font-weight: bold } \n");
			s.Append(".ttyear, .ttvis, .ttstk, .tttotal { font-weight: bold; text-align:right } \n");
			s.Append(".tttotal { font-weight: bold; text-align:center ; background: lightgrey} \n");
			s.Append(".ttvis {font: blue; text-align:right; background: lightgrey} \n");
			s.Append(".ttstk {font: green; text-align:right; background: lightgrey}\n");
			s.Append(".ttyear {background: lightgrey}\n");
			s.Append("</style>\n");
			//
			s.Append("\n</head>\n<body><h1>Recap visites et stocks magasin</h1>");
			//
			s.Append("<ul><li>Magasin Num:");
			s.Append(options.getMagId());
			s.Append("</li></ul>\n");
			
			s.Append("<table id='recap'>");
			s.Append("\n<tr>");
			s.Append(" <th class='hyear'>Annee</th>");
			s.Append(" <td class='separator' rowspan='" + liste.Count + 1 + 1 + "'>&nbsp</td>");
			s.Append(" <th class='hvis'>V. OPT</th>");
			s.Append(" <th class='hvis'>V. LEN</th>");
			s.Append(" <th class='htotal'>TOTAL</th>");
			s.Append(" <th class='hcumul'>Cumul V</th>");
			s.Append(" <td class='separator' rowspan='" + liste.Count + 1 + 1 + "'>&nbsp</td>");
			s.Append(" <th class='hstk'>Stock NEG</th>");
			s.Append(" <th class='hstk'>Stock NUL</th>");
			s.Append(" <th class='hstk'>Stock Pos</th>");
			s.Append(" <th  class='htotal'>TOTAL</th>");
			s.Append(" <th class='hcumul'>Cumul S</th>");
			s.Append(" <td class='separator' rowspan='" + liste.Count + 1 + 1 + "'>&nbsp</td>");
			s.Append("</tr>\n");
			
			int tnVO = 0;
			int tnVL = 0;
			int tnVT = 0;
			//
			int tsNe = 0;
			int tsNu = 0;
			int tsPo = 0;
			int tsTo = 0;
			foreach (MouliAnneeRecap yearRecap in liste) {
				int nVO = yearRecap.getNbVisO();
				int nVL = yearRecap.getNbVisL();
				int nVT = nVO + nVL;
				//
				int sNe = yearRecap.getNbStNeg();
				int sNu = yearRecap.getNbStNul();
				int sPo = yearRecap.getNbStPos();
				int sTo = sNe + sNu + sPo;
				//
				tnVO += nVO;
				tnVL += nVL;
				tnVT += nVT;
				//
				tsNe += sNe;
				tsNu += sNu;
				tsPo += sPo;
				tsTo += sTo;
				//
				s.Append("\n<tr>");
				s.Append(" <td class='lyear'>" + yearRecap.getYear() + "</td>");
				s.Append(" <td class='lvis'>" + nVO + "</td>");
				s.Append(" <td class='lvis'>" + nVL + "</td>");
				s.Append(" <td class='ltotal'>" + nVT + "</td>");
				s.Append(" <td class='lcumul'>" + tnVT + "</td>");
				//s.Append(" <td class='separator' rowspan='"+liste.Count+"'>&nbsp</td>");
				s.Append(" <td class='lstk'>" + sNe + "</td>");
				s.Append(" <td class='lstk'>" + sNu + "</td>");
				s.Append(" <td class='lstk'>" + sPo + "</td>");
				s.Append(" <td  class='ltotal'>" + (sTo) + "</td>");
				s.Append(" <td  class='lcumul'>" + (tsTo) + "</td>");
				s.Append("</tr>\n");
				
			}
			s.Append("\n<tr>");
			s.Append(" <td class='ttyear'>" + liste.Count + " annees</td>");
			s.Append(" <td class='ttvis'>" + tnVO + "</td>");
			s.Append(" <td class='ttvis'>" + tnVL + "</td>");
			s.Append(" <td class='tttotal' colspan='2'>" + tnVT + "</td>");
			//s.Append(" <td class='separator' rowspan='"+liste.Count+"'>&nbsp</td>");
			s.Append(" <td class='ttstk'>" + tsNe + "</td>");
			s.Append(" <td class='ttstk'>" + tsNu + "</td>");
			s.Append(" <td class='ttstk'>" + tsPo + "</td>");
			s.Append(" <td class='tttotal' colspan='2'>" + (tsTo) + "</td>");
			s.Append("</tr>\n");
			
			s.Append("</table></body></html>");
			return s.ToString();
		}
		private int getEnregLength(YFiles yfile)
		{
			if (YFiles.YTOPTIC.Equals(yfile)) {
				return 1800;
			} else if (YFiles.YTLENTI.Equals(yfile)) {
				return 1010;
			} else if (YFiles.YSTOCK.Equals(yfile)) {
				return 473;
			} else if (YFiles.YSTOCAT.Equals(yfile)) {
				return 256;
			}
			return -1;
		}
		private String getYfileYear(byte[] buffer, YFiles yfile)
		{
			
			int deb = 0;
			String year = null;
			if (YFiles.YTOPTIC.Equals(yfile) || YFiles.YTLENTI.Equals(yfile)) {
				deb = 4;
			} else if (YFiles.YSTOCK.Equals(yfile)) {
				deb = 159;
			} else if (YFiles.YSTOCAT.Equals(yfile)) {
				deb = 23;
			}
			
			if (deb > 0) {
				year = "";
				for (int i = 0; i < 4; i++) {
					//TODO:test [0-9] sinon return null
					year += Convert.ToChar(buffer[deb + i]);
				}
			}
			return year;
		}
		
		byte getYfileMarqueur(byte[] buffer, YFiles yfile)
		{
			if (YFiles.YTOPTIC.Equals(yfile) || YFiles.YTLENTI.Equals(yfile)) {
				return buffer[13];
			} else if (YFiles.YSTOCK.Equals(yfile)) {
				return buffer[17];
			} else if (YFiles.YSTOCAT.Equals(yfile)) {
				return buffer[17];
			} else {
				return 0;
			}
		}

		SortedDictionary<string, string> doStcAnalyse(MouliJob job, MouliUtilOptions options)
		{
			SortedDictionary<String, string> stcDico = new SortedDictionary<string, string>();
			YFiles yfile = YFiles.YSTOCAT;
			String fileName = job.getOriginalDir() + "/" + options.getWorkingPath() + mouliUtil.getData() + mouliUtil.getMag01() + yfile + ".d";
			int length = getEnregLength(YFiles.YSTOCAT);
			int nb = 0;
			int nbt = 0;

			if (length > 0) {
				length++; //control
				using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open))) {
					int byteRead = 0;
					do {
						
						byte[] buffer = reader.ReadBytes(length);
						byteRead = buffer.Length;
						if (byteRead != length) {
							break;
						}
						nbt++;
						//
						String numero =	Convert.ToString(buffer[2]) + Convert.ToString(buffer[3]);
						
						byte controle = buffer[length - 1];
						String year = getYfileYear(buffer, yfile);
						byte marqueur = getYfileMarqueur(buffer, yfile);
						
						if (((year != null) && controle == 10) && (numero == options.getNumeroMagasinIrris() && (marqueur == 1))) {
							String clef = getStKey(buffer);
							stcDico.Add(clef, year);
						}
						nb++;
					} while(true);
					LOGGER.Info(fileName + " " + nb + "/" + nbt);
					reader.Close();
				}
			}
			return stcDico;
		}
		private String getStKey(byte[] buffer)
		{
			String clef = "";
			const int deb = 4;
			for (int i = 0; i < 13; i++) {
				clef += Convert.ToChar(buffer[deb + i]);
			}
			return clef;
		}
		private MouliAnalyseRecap doStatAnalyse(MouliUtilOptions options, MouliJob job, string path, YFiles yfile)
		{
			mouliUtil.setMagasinIrris(options.getNumeroMagasinIrris());
			SortedDictionary<String, String> stcDico = null;
			if (YFiles.YSTOCK.Equals(yfile)) {
				stcDico = doStcAnalyse(job, options);
			}
			//
			String fileName = job.getOriginalDir() + "/" + options.getWorkingPath() + mouliUtil.getData() + mouliUtil.getMag01() + yfile + ".d";
			Boolean checkMid = !string.Equals("00", mouliUtil.getMag01(), StringComparison.Ordinal);
			int nb = 0;
			int nbt = 0;
			SortedDictionary<String, int[] > dico = new SortedDictionary<string, int[] >();
			if (File.Exists(fileName)) {
				int length = getEnregLength(yfile);
				if (length > 0) {
					length++; //control
					using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open))) {
						int byteRead = 0;
						do {
							
							byte[] buffer = reader.ReadBytes(length);
							byteRead = buffer.Length;
							if (byteRead != length) {
								break;
							}
							nbt++;
							//
							String numero =	Convert.ToString(buffer[2]) + Convert.ToString(buffer[3]);
							
							byte controle = buffer[length - 1];
							String year = null;
							if (YFiles.YSTOCK.Equals(yfile)) {
								String clef = getStKey(buffer);
								if (stcDico.ContainsKey(clef)) {
									year = stcDico[clef];
								}
							} else {
								year = getYfileYear(buffer, yfile);
							}
							
							byte marqueur = getYfileMarqueur(buffer, yfile);
							Boolean magOk=((checkMid && numero == options.getNumeroMagasinIrris())|| true) ;
							
							if (((year != null) && controle == 10) && (magOk && (marqueur == 1))) {
								int[] tablo = { 0, 0, 0 };
								if (dico.ContainsKey(year)) {
									tablo = dico[year];
								}
								if (YFiles.YSTOCK.Equals(yfile)) {
									long qte = (long)bcdUtil.getDoubleBcd(buffer, 191, 8);
									
									if (qte < 0) {
										tablo[0]++;
									} else if (qte == 0) {
										tablo[1]++;
									} else {
										tablo[2]++;
									}
								} else {
									tablo[2]++;
								}
								
								if (dico.ContainsKey(year)) {
									dico[year] = tablo;
								} else {
									dico.Add(year, tablo);
								}
								nb++;
							}
						} while(true);
						LOGGER.Info(fileName + " " + nb + "/" + nbt);
						reader.Close();
					}
				}
			}
			MouliAnalyseRecap recap = new MouliAnalyseRecap(yfile, nb, nbt, dico);
			return (recap);
		}
	}
}