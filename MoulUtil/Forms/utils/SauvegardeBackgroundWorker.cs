/*
 * Utilisateur: Renaud
 * Date: 22/06/2017
 * Heure: 13:07:41
 * 
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using cmdUtils.Objets;
using MoulUtil.Forms.utils;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of SauvegardeBakgroundWorker.
	/// </summary>
	public class SauvegardeBackgroundWorker : MouliProgressWorker
	{
		private MouliPrepaUtil mouliPrepaUtil;
		private MouliUtilOptions mouliUtilOptions;
		private String sourceDir;
		private String targetDir;
		
		private TextBox  tbProgress = new TextBox();
		private StatusStrip statusStrip=null;
		private Button sauveButton=null;
		public SauvegardeBackgroundWorker (StatusStrip statusStrip, Button sauveButton, TextBox progressTextBox)
		{
			this.statusStrip=statusStrip;
			this.sauveButton=sauveButton;
			this.tbProgress=progressTextBox;
		}
		
		public void prepare(MouliPrepaUtil mouliPrepaUtil, MouliUtilOptions mouliUtilOptions, String sourceDir, String targetDir) {
			this.mouliPrepaUtil=mouliPrepaUtil;
			this.mouliUtilOptions=mouliUtilOptions;
			this.sourceDir=sourceDir;
			this.targetDir=targetDir;
		}
		
		public void sauvegardeBW_DoWork(object sender, DoWorkEventArgs e)
		{
			
			//statusStrip.Text = "Starting sauvegarde ..."; // erreur si on y touche
			sauveButton.Enabled=false;

			MouliProgressWorker worker = sender as MouliProgressWorker;
			mouliPrepaUtil.sauvegardeMoulinette(sourceDir, targetDir, mouliUtilOptions, worker);
			
		}
		public void sauvegardeBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			double prc=0;
			if(getNbOperation()!=0) {
				prc = e.ProgressPercentage / ((double)getNbOperation()) * 100;
				prc = Math.Round(prc, 3) ;
			}
			this.tbProgress.Text = (e.ProgressPercentage.ToString() +" / "+getNbOperation()+  " ("+prc+")%");
		}
		public void sauvegardeBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if ((e.Cancelled == true))
			{
				this.tbProgress.Text = "Annulé !";
			}

			else if (e.Error != null) {
				this.tbProgress.Text = ("Error: " + e.Error.Message);
			} else {
				this.tbProgress.Text = this.tbProgress.Text + " Fini";
			}
			//statusStrip.Text = this.tbProgress.Text;
			sauveButton.Enabled=true;
		}
	}
}
