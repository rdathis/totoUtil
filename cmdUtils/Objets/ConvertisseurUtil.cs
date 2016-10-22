/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 13/07/2016
 * Heure: 18:28:39
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of ConvertisseurUtil.
	/// </summary>
	public class ConvertisseurUtil
	{
		public ConvertisseurUtil()
		{
		}
		public static List<String> convertit(string[] tablo) {
			List<String> liste = new List<string>(tablo);
//			for(int i=0;i<System.Array.FindAll().Length;i++) {
//				String s=tablo[i];
//				if (s!=null) {
//					liste.Add(s);
//				}
//			}
			return liste;
		}

		public static string[] convertitListArray(List<string> liste)
		{
			String [] tablo = new string[liste.Count];
			int i=0;
			foreach (String s in liste) {
				tablo[i]=s;
				i++;
			}
			return tablo;				
		}
	}
}
