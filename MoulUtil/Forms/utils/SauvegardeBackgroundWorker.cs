﻿/*
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
		
		public void prepare(MouliPrepaUtil mouliPrepaUtil, MouliUtilOptions mouliUtilOptions, String sourceDir, String targetDir) {
			this.mouliPrepaUtil=mouliPrepaUtil;
			this.mouliUtilOptions=mouliUtilOptions;
			this.sourceDir=sourceDir;
			this.targetDir=targetDir;
		}
		
		public void sauvegardeBW_DoWork(object sender, DoWorkEventArgs e)
		{
			MouliProgressWorker worker = sender as MouliProgressWorker;
			doStartWorker("debut");
			mouliPrepaUtil.sauvegardeMoulinette(sourceDir, targetDir, mouliUtilOptions, worker);
			
		}
		public void sauvegardeBW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			doProgressWorker(e.ProgressPercentage);
		}
		public void sauvegardeBW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			doEndWorker("fin");
		}
	}
}
