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
		public delegate void StartWorkerCallBack(String str);
		public delegate void ProgressWorkerCallBack(int value);
		public delegate void EndWorkerCallBack(String str);
		
		private int nbOperation=-1;
		private int doneOperation=0;
		private String info="";
		private StartWorkerCallBack startWorkerCallBack=null;
		private ProgressWorkerCallBack progressWorkerCallBack=null;
		private EndWorkerCallBack endWorkerCallBack=null;
		public MouliProgressWorker()
		{
		}
		//
		public void setNbOperation(int nb) {
			this.nbOperation=nb;
		}
		public int getNbOperation() {
			return nbOperation;
		}
		//
		public void setDoneOperation(int nb) {
			this.doneOperation=nb;
		}
		public int getDoneOperation() {
			return doneOperation;
		}
		//
		public void setInfo(String str) {
			this.info=str;
		}
		public String getInfo() {
			return this.info;
		}
		//
		public void setStartWorkerCallBack(StartWorkerCallBack cb) {
			this.startWorkerCallBack=cb;
		}
		public StartWorkerCallBack getStartWorkerCallBack() {
			return this.startWorkerCallBack;
		}
		//
		public void setProgressWorkerCallBack(ProgressWorkerCallBack cb) {
			this.progressWorkerCallBack=cb;
		}
		public ProgressWorkerCallBack getProgressWorkerCallBack() {
			return this.progressWorkerCallBack;
		}
		//
		public void setEndWorkerCallBack(EndWorkerCallBack cb) {
			this.endWorkerCallBack=cb;
		}
		public EndWorkerCallBack getEndWorkerCallBack() {
			return this.endWorkerCallBack;
		}
		//
		public void doStartWorker(String str) {
			if(startWorkerCallBack!=null) {
				doneOperation=0;
				startWorkerCallBack.Invoke(str);
			}
		}
		public void doProgressWorker(int value) {
			if(progressWorkerCallBack!=null) {
				doneOperation ++;
				progressWorkerCallBack.Invoke(value);
			}
		}
		public void doEndWorker(String str) {
			if(endWorkerCallBack!=null) {
				endWorkerCallBack.Invoke(str);
			}
		}
		
	}
}
