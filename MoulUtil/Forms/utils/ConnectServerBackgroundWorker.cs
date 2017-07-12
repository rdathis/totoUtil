/*
 * Utilisateur: Renaud
 * Date: 05/07/2017
 * Heure: 11:10:45
 * 
*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Renci.SshNet;
using cmdUtils;
using cmdUtils.Objets;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// 
	/// </summary>
	public class ConnectServerBackgroundWorker : MouliProgressWorker
	{
		private MeoServeur server=null;
		private SshUtil sshUtil = null;
		private SshClient sshClient = null;
		private int port1=0;
		private int port2=0;
		private TextBox textbox;
		public ConnectServerBackgroundWorker()
		{
			this.WorkerSupportsCancellation = true;
			this.WorkerReportsProgress = true;
			this.DoWork +=new DoWorkEventHandler(this.connectAdminBW_DoWork);
			this.ProgressChanged += new ProgressChangedEventHandler(this.connectAdminBW_ProgressChanged);
			this.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.connectAdminBW_RunWorkerCompleted);
			this.sshUtil = new SshUtil();
			
		}
		public void prepare(SshClient sshClient, MeoServeur server, int port1, int port2, TextBox textbox) {
			this.server=server;
			this.sshClient = sshClient;
			this.port1=port1;
			this.port2=port2;
			this.textbox=textbox;
		}
		
		
		public void connectAdminBW_DoWork(object sender, DoWorkEventArgs e)
		{
			doStartWorker("Debut du travail ");
			RechercheMagasinUtil rechercheUtil = new RechercheMagasinUtil();
			sshClient = rechercheUtil.doConnection(server, port1, port2, this);
			doEndWorkerSshClientCallBack("fini", sshClient, textbox);
		}
		public void connectAdminBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			doProgressWorker(e.ProgressPercentage);
		}
		public void connectAdminBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
				
				getEndWorkerSshClientCallBack().Invoke(str, sshClient, textbox);
			}
		}
	}
}
	

