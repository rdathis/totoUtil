/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 22/10/2015
 * Heure: 18:19:40
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.ComponentModel;
using System.IO;

namespace cmdUtils.Objets
{
	/// <summary>
	/// utilitaire d'acces aux fichiers a zipper.
	/// </summary>
	public class ZipUtilOptions
	{
		public enum TauxCompression {
			nulle=0, petit=1, moyen=5, maxi=9
		};
		
		public delegate String renommeFichierZip(String fichierNom);
			
		
		//target
		private string archiveName;
		private string archiveDir;
		//source
		private string sourceBaseDir;
		private string[] sourceSelection;
		private TauxCompression tauxCompression=TauxCompression.moyen;
		private BackgroundWorker backgroundWorker;
		
		private renommeFichierZip fonction=null;
		//private string datamag;
		public ZipUtilOptions()
		{
		}
		public void setRenommeFonction(renommeFichierZip fonction) {
			this.fonction=fonction;
		}
		public renommeFichierZip getRenommeFonction() {
			return this.fonction;
		}
		public String invokeRenommeFonction(String arg) {
			if (this.fonction!=null) {
				return this.fonction.Invoke(arg);
			} else {
				return arg;
			}
		}
		public void setArchiveName(string value) {
			archiveName=value;
		}
		public void setArchiveDir(string value) {
			archiveDir=value;
		}
		public void setSourceBaseDir(string value) {
			sourceBaseDir=value;
		}
		public void setSourceSelection(string[] value) {
			sourceSelection=value;
		}
//
		public string getArchiveName() {
			return archiveName;
		}
		public string getArchiveDir() {
			return archiveDir;
		}
		public string getSourceBaseDir() {
			return sourceBaseDir;
		}
		public string[] getSourceSelection() {
			return sourceSelection;
		}
		//TODO:
		public Boolean controleArchiveName() {
			return false;
		}
		public Boolean controleArchiveDir() {
			return (File.Exists(archiveDir));
			
		}
		public Boolean controleSourceBaseDir() {
			return false;
		}
		public Boolean controleSourceSelection() {
			return false;
		}
		
		public TauxCompression getTauxCompression() {
			return tauxCompression;
		}
		public void setTauxCompression(TauxCompression taux) {
			tauxCompression=taux;
		}
		public BackgroundWorker getBackgroundWorker() {
			return this.backgroundWorker;
		}
		public void setBackgroundWorker(BackgroundWorker backgroundWorker) {
			this.backgroundWorker=backgroundWorker;
		}
	}
}
