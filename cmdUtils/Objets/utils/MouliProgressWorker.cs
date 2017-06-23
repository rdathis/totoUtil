/*
 * Utilisateur: Renaud
 * Date: 22/06/2017
 * Heure: 13:37:47
 * 
*/
using System;
using System.ComponentModel;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of MouliProgressWorker.
	/// </summary>
	public class MouliProgressWorker  : BackgroundWorker
	{
		private int nbOperation=-1;
		private String info="";
		public MouliProgressWorker()
		{
		}
		public void setNbOperation(int nb) {
			this.nbOperation=nb;
		}
		public int getNbOperation() {
			return nbOperation;
		}
		public void setInfo(String str) {
			this.info=str;
		}
		public String getInfo() {
			return this.info;
		}
	}
}
