/*
 * Utilisateur: Renaud
 * Date: 22/05/2017
 * Heure: 13:48:00
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.VisualStyles;
namespace testBW
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		BackgroundWorker bw = null;
		public MainForm()
		{
			InitializeComponent();
			initBW();
		}
		void initBW() {
			bw = new BackgroundWorker();
			bw.WorkerSupportsCancellation = true;
			bw.WorkerReportsProgress = true;
			bw.DoWork +=new DoWorkEventHandler(bw_DoWork);
			bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
			bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
			
		}
		void Button1Click(object sender, EventArgs e)
		{
//			TestUBW tub = new TestUBW () ;{
//				tub.OneValue=3;
//				tub.TwoValue=4;
//			}
			

			//bw.RunWorkerAsync(tub);
		}
		
		
		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

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
					System.Threading.Thread.Sleep(500);
					worker.ReportProgress((i * 10));
				}
			}
		}
		private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
		}
		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
			
			this.label1.Text=  "fini";
			this.label1.BackColor=Color.Purple;
		}
		void StartBtnClick(object sender, EventArgs e)
		{
			this.label1.BackColor=Color.Yellow;
			this.label1.ForeColor = Color.Pink;
			
			if (bw.IsBusy != true)
			{
				bw.RunWorkerAsync();
			}
		}
		void StopBtnClick(object sender, EventArgs e)
		{
			if (bw.WorkerSupportsCancellation == true)
			{
				bw.CancelAsync();
			}
		}
		
		
	}
	
	class TestUBW {
		public int OneValue { get; set; }
		public int TwoValue { get; set; }
	}
}

