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
using MoulUtil.Forms.utils;
using cmdUtils.Objets;
namespace cmdUtils
{

	public class MouliJob
	{
		private String archiveName;
		private List<String> liste;
		private String originalDir;
		private MouliStatRecap statRecap;
		private DateTime startDateTime;
		private MouliUtilOptions options;
		private String moulinettePath;
		private MouliProgressWorker backgroundWorker;
		private String detailClient=null;
		private String detailStock=null;
		private String detailJoint=null;
		private String detailDoc=null;

		public MouliJob(String archiveName,
		                String originalDir,
		                List<String> liste,
		                MouliStatRecap statRecap,
		                DateTime start,
		                MouliUtilOptions options,
		                String moulinettePath
		               )
		{
			this.archiveName = archiveName;
			this.liste = liste;
			this.originalDir = originalDir;
			this.statRecap = statRecap;
			this.startDateTime = start;
			this.options = options;
			this.moulinettePath = moulinettePath;
		}
		public String getArchiveName()
		{
			return archiveName;
		}
		public String getOriginalDir()
		{
			return originalDir;
		}
		public List<String> getListe()
		{
			return liste;
		}
		public void setListe(List<String> liste)
		{
			this.liste = liste;
		}
		public void setStart(DateTime value)
		{
			this.startDateTime = value;
		}
		public DateTime getStart()
		{
			return startDateTime;
		}
		public MouliStatRecap getStatRecap()
		{
			return statRecap;
		}
		public MouliUtilOptions getOptions()
		{
			return options;
		}
		public void setOptions(MouliUtilOptions options)
		{
			this.options=options;
		}

		public String getMoulinettePath()
		{
			return moulinettePath;
		}
		public void setBackgroundWorker(MouliProgressWorker backgroundWorker)
		{
			this.backgroundWorker = backgroundWorker;
		}
		public MouliProgressWorker getBackgroundWorker()
		{
			return this.backgroundWorker;
		}
		
		public void setDetailClient (String value) {
			detailClient=value;
		}
		public String getDetailClient () {
			return detailClient;
		}
		public void setDetailStock (String value) {
			detailStock=value;
		}
		public String getDetailStock () {
			return detailStock;
		}
		public void setDetailJoint (String value) {
			detailJoint=value;
		}
		public String getDetailJoint () {
			return detailJoint;
		}
		public void setDetailDoc (String value) {
			detailDoc=value;
		}
		public String getDetailDoc () {
			return detailDoc;
		}
	}
}