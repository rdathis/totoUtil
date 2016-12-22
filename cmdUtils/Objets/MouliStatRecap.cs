/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 13/09/2016
 * Heure: 13:34:27
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using cmdUtils.Objets;
namespace cmdUtils.Objets {
	
	public class MouliStatRecap {
		public int foundFiles=0;
		public List<String> notFoundList=new List<string>();
		public int mag01FilesTotal=0;
		public int jointDocsTotal=0;
		public int ord01DocsTotal;
		public int doc01DocsTotal;
		public string datamag;
		public MouliStatRecap() {
			
		}
	}
}