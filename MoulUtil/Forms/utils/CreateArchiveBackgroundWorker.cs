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
		private MouliJob job=null;
		public CreateArchiveBackgroundWorker()
		{
		}
		public void prepare(MouliJob job) {
			this.job=job;
		}
		
		public void creaArchiveBW_DoWork(object sender, DoWorkEventArgs e)
		{
			doStartWorker("Debut du travail "  + job.getArchiveName());
			MouliProgram.doArchive(job);
			
		}
		public void creaArchiveBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
//			if(false) {
//				double prc=0;
//				if(getNbOperation()!=0) {
//					prc = e.ProgressPercentage / ((double)getNbOperation()) * 100;
//					prc = Math.Round(prc, 3) ;
//				}
//				//this.progressTextBox.Text = (e.ProgressPercentage.ToString() +" / "+getNbOperation()+  " ("+prc+")%");
//			}
			doProgressWorker(e.ProgressPercentage);
		}
		public void creaArchiveBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(getEndWorkerCallBack()!=null) {
				String str="";
				if ((e.Cancelled == true))
				{
					str = "Annulé !";
				}

				else if (e.Error != null) {
					str = ("Error: " + e.Error.Message);
				} else {
					str =  " Fini";
				}
				
				getEndWorkerCallBack().Invoke(str);
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
