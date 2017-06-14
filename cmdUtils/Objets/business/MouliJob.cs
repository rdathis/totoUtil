/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 13/09/2016
 * Heure: 13:30:30
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;


using System.ComponentModel;
using cmdUtils.Objets;
namespace cmdUtils {

	public class MouliJob {
		private String archiveName;
		private List<String> liste;
		private String originalDir;
		private MouliStatRecap  statRecap;
		private DateTime startDateTime;
		private MouliUtilOptions options;
		private String moulinettePath;
		private BackgroundWorker backgroundWorker;
		public MouliJob(String archiveName, 
		                String originalDir, 
		                List<String> liste, 
		                MouliStatRecap statRecap, 
		                DateTime start, 
		                MouliUtilOptions options,
		                String moulinettePath
		               ) {
			this.archiveName=archiveName;
			this.liste=liste;
			this.originalDir=originalDir;
			this.statRecap=statRecap;
			this.startDateTime=start;
			this.options=options;
			this.moulinettePath=moulinettePath;
		}
		public String getArchiveName() {
			return archiveName;
		}
		public String getOriginalDir() {
			return originalDir;
		}
		public List<String> getListe() {
			return liste;
		}
		public DateTime getStart() {
			return startDateTime;
		}
		public MouliStatRecap getStatRecap() {
			return statRecap;
		}
		public MouliUtilOptions getOptions() {
			return options;
		}
		public String getMoulinettePath() {
			return moulinettePath;
		}
		public void setBackgroundWorker(BackgroundWorker backgroundWorker) {
			this.backgroundWorker=backgroundWorker;
		}
		public BackgroundWorker getBackgroundWorker() {
			return this.backgroundWorker;
		}
/*		
				- liste
				- originalDir
				- statsRecap
				- startDateTime
				*/
	}
	
}