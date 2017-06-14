/*
 * Utilisateur: Renaud
 * Date: 26/05/2017
 * Heure: 16:18:44
 * 
 */
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MoulUtil.Forms.utils
{
	/// <summary>
	/// Description of MouliPrepaBackgroundWorkerUtil.
	/// </summary>
	public class MouliPrepaBackgroundWorkerUtil
	{
		public MouliPrepaBackgroundWorkerUtil()
		{
		}
		
		private TextBox  tbProgress = new TextBox();
		
		public void sauvegardeBW_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;
			if(worker!=null) {

				for (int i = 1; (i <= 10); i++)
				{
					if ((worker.CancellationPending == true))
					{
						e.Cancel = true;
						break;
					}
					else
					{
						// Perform a time consuming operation and report progress.
						//System.Threading.Thread.Sleep(500);
						worker.ReportProgress((i * 10));
					}
				}
			}
		}
		public void sauvegardeBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
		}
		public void sauvegardeBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if ((e.Cancelled == true))
			{
				this.tbProgress.Text = "Canceled!";
			}

			else if (!(e.Error == null))
			{
				this.tbProgress.Text = ("Error: " + e.Error.Message);
			}

			else
			{
				this.tbProgress.Text = "Done!";
			}
			
			//this.label1.Text=  "fini";
			//this.label1.BackColor=Color.Purple;
		}
	}
}
