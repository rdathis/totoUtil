/*
 * Utilisateur: Renaud
 * Date: 13/10/2017
 * Heure: 13:57:05
 * 
 */
using System;
using System.Collections.Generic;

namespace cmdUtils.Objets.business
{
	/// <summary>
	/// Description of MouliAnneeRecap.
	/// </summary>
	public class MouliAnneeRecap
	{
		private string year;
		private int nbVisO;
		private int nbVisL;
		private int nbStNeg;
		private int nbStNul;
		private int nbStPos;
		public MouliAnneeRecap(String year)
		{
			this.year = year;
		}
		public string getYear()
		{
			return this.year;
		}
		public int getNbVisO()
		{
			return this.nbVisO;
		}
		public int getNbVisL()
		{
			return this.nbVisL;
		}
		public void setNbVisO(int value)
		{
			this.nbVisO = value;
		}
		public void setNbVisL(int value)
		{
			this.nbVisL = value;
		}
		public void setSt(int stNeg, int stNul, int stPos)
		{
			this.nbStNeg = stNeg;
			this.nbStNul = stNul;
			this.nbStPos = stPos;
		}
		public int getNbStNeg()
		{
			return this.nbStNeg;
		}
		public int getNbStNul()
		{
			return this.nbStNul;
		}
		public int getNbStPos()
		{
			return this.nbStPos;
		}
		
	
		public class MouliAnneeRecapComparer: IComparer<MouliAnneeRecap>
		{
			public int Compare(MouliAnneeRecap a, MouliAnneeRecap z)
			{
				return string.Compare(a.getYear(), z.getYear(), StringComparison.Ordinal);
			}

		}
	}
}
