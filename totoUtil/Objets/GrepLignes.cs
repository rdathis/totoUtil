/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 03/04/2015
 * Heure: 18:33:17
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace totoUtil.Objets
{
	/// <summary>
	/// Description of GrepLignes.
	/// </summary>
	public class GrepLignes
	{
		public GrepLignes()
		{
		}
		
		
		private long ligneNumber=-1;
		private String ligneContent;
		private long positionMatched;
		private int indexMatcher;
		public void setLigneNumber(long val) {
			this.ligneNumber=val;
		}
		public void setLigneContent(String val) {
			this.ligneContent=val;
		}
		public void setPositionMatched(long val) {
			this.positionMatched=val;
		}
		public void setIndexMatcher(int val) {
			this.indexMatcher=val;
		}
		public long getLigneNumber() {
			return this.ligneNumber;
		}
		public String getLigneContent() {
			return this.ligneContent;
		}
		public long getPositionMatched() {
			return this.positionMatched;
		}
		public int getIndexMatcher() {
			return this.indexMatcher;
		}
	}
}

