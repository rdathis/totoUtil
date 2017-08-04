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
using System.Collections.Generic;

namespace cmdUtils.Objets.business
{
	/// <summary>
	/// Description of StatMoulReader.
	/// </summary>
	public class StatMoulReader
	{
		private static class  marquers
		{
			public static readonly string
				MARQUEUR_VISITE = "NB VISITES",
				MARQUEUR_STOCK = "NB ARTICLES",
				MARQUEUR_STOCKNEG = "C",
				MARQUEUR_STOCKNUL = "D",
				MARQUEUR_STOCKPOS = "E";
		}
		public const String defaultFileName = "stat_mou.txt";
		public StatMoulReader(String fileName = defaultFileName)
		{
		}
		
		private void readFile(String file)
		{
			List<StatMoulRecap> liste = new List<StatMoulRecap>();
			if (File.Exists(file)) {
				String[] lignes = new MyUtil().readScript(file).Split('\n');
				int mode = 0;
				for (int numLigne = 1; numLigne < lignes.GetLength(0); numLigne++) {
					String ligne = lignes[numLigne].Replace('\r', ' ').Trim();
					if (ligne.IndexOf("/") > 0) {
						String[] colonnes = ligne.Split('/');
						if (colonnes.GetLength(0) > 1) {
							String col0 = colonnes[0].Trim();
							int col1 = int.Parse(colonnes[1].Trim());
							if (marquers.MARQUEUR_VISITE == col0) {
								mode = 1;
							} else if (marquers.MARQUEUR_STOCK == col0) {
								mode = 2;
							} else if (marquers.MARQUEUR_STOCKNEG == col0) {
								mode = 3;
							} else if (marquers.MARQUEUR_STOCKNUL == col0) {
								mode = 4;
							} else if (marquers.MARQUEUR_STOCKPOS == col0) {
								mode = 5;
							} else if (mode > 0) {
								StatMoulRecap recap = findRecap(liste, col0);
								if(mode==1) {
									recap.setVisiteQty(col1);
								} else if(mode==2) {
									recap.setStockQty(col1);
								} else if(mode==3) {
									recap.setStockNegQty(col1);
								} else if(mode==4) {
									recap.setStockZeroQty(col1);
								} else if(mode==5) {
									recap.setStockPosQty(col1);
								}
							}	
//			qty = tab[0];
//			year = tab[1]
						}
						

					}
				}
			}
		}

		StatMoulRecap findRecap(List<StatMoulRecap> liste, string year)
		{
			foreach(StatMoulRecap recap in liste) {
				if(recap.getYear()==year) {
					return recap;
				}
			}
			return new StatMoulRecap(year);
		}
	}
}

