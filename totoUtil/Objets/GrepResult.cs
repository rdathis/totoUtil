/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 03/04/2015
 * Heure: 18:34:18
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;

namespace totoUtil.Objets
{
	/// <summary>
	/// Description of GrepResult.
	/// </summary>
	public class GrepResult
	{
		public GrepResult()
		{
		}
		private String fileName;
		private List <GrepLignes> results = new List<GrepLignes>();
		public GrepResult (String filename, List <GrepLignes> results) {
			this.fileName=filename;
			this.results=results;
		}
		public List <GrepLignes> getResults() {
			return results;
		}
		public void setResults(List<GrepLignes> value) {
			this.results=value;
		}
		public String getFilename() {
			return this.fileName;
		}
		
		
	}
}
