/*
 * Utilisateur: Renaud
 * Date: 13/10/2017
 * Heure: 13:47:02
 * 
 */
using System;
using System.Collections.Generic;

namespace cmdUtils.Objets.business
{
	/// <summary>
	/// Description of MouliAnalyseRecap.
	/// </summary>
	public class MouliAnalyseRecap
	{
		private YFiles yfile;
		private int nb;
		private int nbt;
		//
		//tablo[0]:neg, tablo[1]:nul, tablo[2]:pos   
		private SortedDictionary<String, int[]> dico = new SortedDictionary<string, int[]>();
		public MouliAnalyseRecap(YFiles yfile, int nb, int nbt, SortedDictionary<String, int[]> dico )
		{
			this.yfile=yfile;
			this.nb=nb;
			this.nbt=nbt;
			this.dico=dico;
		}
		public YFiles getYfile() {
			return this.yfile;
		}
		public int getNb() {
			return this.nb;
		}
		public int getNbt() {
			return this.nbt;
		}
		public SortedDictionary<String, int[]> getDico() {
			return this.dico;
		}
	}
}
