/*
 * Utilisateur: Renaud
 * Date: 23/06/2017
 * Heure: 12:56:36
 * 
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
//using cmdUtils.Objets;
using MoulUtil.Forms.utils;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of CreateArchiveBackgroundWorker.
	/// </summary>
	public class CreateArchiveBackgroundWorker : MouliProgressWorker
	{
		private TextBox tbProgress=null;
		public CreateArchiveBackgroundWorker()
		{
		}
		public void prepare() {
			
		}
		
		public void creaArchiveBW_DoWork(object sender, DoWorkEventArgs e)
		{
			
			//statusStrip.Text = "Starting sauvegarde ..."; // erreur si on y touche
			//sauveButton.Enabled=false;

			MouliProgressWorker worker = sender as MouliProgressWorker;
			//mouliPrepaUtil.sauvegardeMoulinette(sourceDir, targetDir, mouliUtilOptions, worker);
			
		}
		public void creaArchiveBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			double prc=0;
			if(getNbOperation()!=0) {
				prc = e.ProgressPercentage / ((double)getNbOperation()) * 100;
				prc = Math.Round(prc, 3) ;
			}
			this.tbProgress.Text = (e.ProgressPercentage.ToString() +" / "+getNbOperation()+  " ("+prc+")%");
		}
		public void creaArchiveBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
			//sauveButton.Enabled=true;
		}

		public static CreateArchiveBackgroundWorker createWorker() {
			CreateArchiveBackgroundWorker worker = new CreateArchiveBackgroundWorker();
			worker.WorkerSupportsCancellation = true;
			worker.WorkerReportsProgress = true;
			worker.DoWork +=new DoWorkEventHandler(worker.creaArchiveBW_DoWork);
			worker.ProgressChanged += new ProgressChangedEventHandler(worker.creaArchiveBW_ProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker.creaArchiveBW_RunWorkerCompleted);
			return worker;			
		}
	}
}
