/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 03/08/2017
 * Time: 20:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace cmdUtils.Objets.business
{
	/// <summary>
	/// Description of StatMoulReader.
	/// </summary>
	public class StatMoulReader
	{
		private static class  marquers {
			public static readonly string
			MARQUEUR_VISITE= "A",
			MARQUEUR_STOCK="B",
			MARQUEUR_STOCKNEG="C",
			MARQUEUR_STOCKNUL="D",
			MARQUEUR_STOCKPOS="E";
		}
		public const String defaultFileName="stat_moul.txt";
		public StatMoulReader(String fileName=defaultFileName)
		{
		}
		
		private void readFile(String file) {
			if (File.Exists(file)) {
				String[] lignes = new MyUtil().readScript(file).Split('\n');
				for (int numLigne = 1; numLigne < lignes.GetLength(0); numLigne++) {
					String ligne = lignes[numLigne].Replace('\r', ' ').Trim();
					String[] colonnes = ligne.Split('/');
					if (colonnes.GetLength(0) > 1) {
//			qty = tab[0];
//			year = tab[1]

						

					}
				}
			}
		}
	}
}

