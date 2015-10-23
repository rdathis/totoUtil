/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 22/10/2015
 * Heure: 18:19:40
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace cmdUtils.Objets
{
	/// <summary>
	/// utilitaire d'acces aux fichiers a zipper.
	/// </summary>
	public class ZipUtilOptions
	{
		//target
		private string archiveName;
		private string archiveDir;
		//source
		private string sourceBaseDir;
		private string[] sourceSelection;
		//private string datamag;
		public ZipUtilOptions()
		{
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
			
			return false;
		}
		public Boolean controleSourceBaseDir() {
			return false;
		}
		public Boolean controleSourceSelection() {
			return false;
		}
		
	}
}
