/*
 * Utilisateur: Renaud
 * Date: 23/06/2017
 * Heure: 12:56:36
 * 
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;
using cmdUtils;
//using cmdUtils.Objets;
using MoulUtil.Forms.utils;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// worker pour la creation de l'archive
	/// </summary>
	public class CreateArchiveBackgroundWorker : MouliProgressWorker
	{
		private TextBox progressTextBox=null;
		private MouliJob job=null;
		private LinkLabel link=null;
		private Button button=null;
		public CreateArchiveBackgroundWorker()
		{
		}
		public void prepare(MouliJob job, TextBox progressTextBox, Button button, LinkLabel link) {
			this.job=job;
			//this.progressTextBox=progressTextBox;
			//this.button=button;
			this.link=link;
		}
		
		public void creaArchiveBW_DoWork(object sender, DoWorkEventArgs e)
		{
			if(button!=null) {
				button.Enabled=false;
			}
			
			if (progressTextBox!=null) {
				progressTextBox.Text = "Starting archive job";
			}
			//statusStrip.Text = "Starting sauvegarde ..."; // erreur si on y touche
			//MouliProgressWorker worker = sender as MouliProgressWorker;
			MouliProgram.doArchive(job);
			//mouliPrepaUtil.sauvegardeMoulinette(sourceDir, targetDir, mouliUtilOptions, worker);
			
		}
		public void creaArchiveBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if(progressTextBox==null) return;
			//
			double prc=0;
			if(getNbOperation()!=0) {
				prc = e.ProgressPercentage / ((double)getNbOperation()) * 100;
				prc = Math.Round(prc, 3) ;
			}
			this.progressTextBox.Text = (e.ProgressPercentage.ToString() +" / "+getNbOperation()+  " ("+prc+")%");
		}
		public void creaArchiveBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(this.progressTextBox!=null) {
				if ((e.Cancelled == true))
				{
					this.progressTextBox.Text = "Annulé !";
				}

				else if (e.Error != null) {
					this.progressTextBox.Text = ("Error: " + e.Error.Message);
				} else {
					this.progressTextBox.Text = this.progressTextBox.Text + " Fini";
				}
				//statusStrip.Text = this.tbProgress.Text;
				//sauveButton.Enabled=true;
			}
			if(link!=null) {
				link.Text = "pscp ZIP" ;
			}
			if(button!=null) {
				button.Enabled=true;
			}
			
			
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
