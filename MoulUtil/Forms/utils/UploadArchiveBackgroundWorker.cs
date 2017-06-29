/*
 * Utilisateur: Renaud
 * Date: 29/06/2017
 * Heure: 13:02:54
 * 
 */
using System;
using System.ComponentModel;
using cmdUtils.Objets;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of UploadArchiveBackgroundWorker.
	/// </summary>
	public class UploadArchiveBackgroundWorker : MouliProgressWorker
	{
		private MeoServeur server=null;
		private string target=null;
		private string archive=null;
		private SshUtil sshUtil = null;
		public UploadArchiveBackgroundWorker()
		{
			this.WorkerSupportsCancellation = true;
			this.WorkerReportsProgress = true;
			this.DoWork +=new DoWorkEventHandler(this.uploadArchiveBW_DoWork);
			this.ProgressChanged += new ProgressChangedEventHandler(this.uploadArchiveBW_ProgressChanged);
			this.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.uploadArchiveBW_RunWorkerCompleted);
			this.sshUtil = new SshUtil();
			
		}
		public void prepare(MeoServeur server, string target, string archive) {
			this.server=server;
			this.target=target;
			this.archive=archive;
		}
		
		public void uploadArchiveBW_DoWork(object sender, DoWorkEventArgs e)
		{
			doStartWorker("Debut du travail ");
			sshUtil.uploadArchive(server, target, archive, this);
		}
		public void uploadArchiveBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			doProgressWorker(e.ProgressPercentage);
		}
		public void uploadArchiveBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
		/*
		public static CreateArchiveBackgroundWorker createWorker() {
			CreateArchiveBackgroundWorker worker = new CreateArchiveBackgroundWorker();
			worker.WorkerSupportsCancellation = true;
			worker.WorkerReportsProgress = true;
			worker.DoWork +=new DoWorkEventHandler(worker.creaArchiveBW_DoWork);
			worker.ProgressChanged += new ProgressChangedEventHandler(worker.creaArchiveBW_ProgressChanged);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker.creaArchiveBW_RunWorkerCompleted);
			return worker;
		}
		 */
		
	}
}
