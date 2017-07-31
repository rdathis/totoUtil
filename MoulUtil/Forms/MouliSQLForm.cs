﻿/*
 * Utilisateur: Renaud
 * Date: 09/01/2017
 * Heure: 14:42:23
 * 
 */
using System;
using System.Windows.Forms;
using MoulUtil.Forms.utils;
using Renci.SshNet;
using cmdUtils.Objets;
using cmdUtils.Objets.business;
using log4net;
namespace MoulUtil
{
	/// <summary>
	/// Form for requests
	/// </summary>
	public partial class MouliSQLForm : Form
	{
		private String magId=null;
		private ConfigDto configDto;
		private MeoInstance instance = null;
		private MyUtil myUtil=null;
		private MeoServeur meoServeur =null;
		private int sqlPort=-1;
		private MouliUtilOptions options = null;
		private ConnectServerBackgroundWorker connectWorker = new ConnectServerBackgroundWorker();
		private SshClient sshClient=null;
		private log4net.ILog ILOG;
		
		public MouliSQLForm(log4net.ILog ILOG, String magId, MouliUtilOptions options) {
			InitializeComponent();
			this.ILOG=ILOG;
			this.magId=magId;
			this.options=options;
			//
			ConfigUtil configUtil= new ConfigUtil();
			configDto = configUtil.getConfig();
			//
			this.instance=MeoInstance.findInstanceByInstanceName(configDto.instances, options.getInstanceName());
			myUtil=new MyUtil();
			if(instance!=null) {
				meoServeur = MeoServeur.findServeurByName(configDto.serveurs, instance.serveur);
				prepareConnection();
			}
			purgeStockLabel.Visible=false;
			purgeVisitesLabel.Visible=false;
			testServeur();
			populate();
		}
		private void prepareConnection() {
			String tunnelStr = meoServeur.getTunnel();
			int leftPort = int.Parse(tunnelStr.Substring(0, tunnelStr.IndexOf(":", StringComparison.Ordinal)));
			int rightPort = int.Parse(tunnelStr.Substring(tunnelStr.IndexOf(":", StringComparison.Ordinal) + 1));
			sqlPort=leftPort;
			
			ILOG.Info("preparation connectBW");
			connectWorker.prepare(sshClient, meoServeur, leftPort, rightPort, null);
			
			MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = str => {
				ILOG.InfoFormat("Notification received for: {0}", str);
				//?? plantage: toolStripStatusLabel1.Text = name;
				try {
					//statusStrip1.Text = "connecting to " + meoServeur.nom + " by ssh (" + tunnelStr + ")...";
					detailmagasinBox.Text ="connecting to " + meoServeur.nom + " by ssh (" + tunnelStr + ")...";
				} catch (Exception ex) {
					ILOG.Error("still exception here ..." + ex.Message);
				}
			};
			//

			MouliProgressWorker.EndWorkerSshClientCallBack endWorkerCallBack = (message, tmpSshClient, textbox) => {
				if (tmpSshClient == null) {
					ILOG.Error("Exception message :" + message);
					detailmagasinBox.Text = "SSH : Exception message :" + message;
				} else {
					ILOG.Info("connected");
					sshClient = tmpSshClient;
					try {
						TotauxLabelClick(null, null);
					} catch(Exception ex) {
						ILOG.Error(ex);
					}
					try {
						detailmagasinBox.Text = "connected";
					} catch(Exception ex) {
						ILOG.Error(ex);
					}
				}
			};

			connectWorker.setStartWorkerCallBack(startWorkerCallBack);
			connectWorker.setEndWorkerSshClientCallBack(endWorkerCallBack);
			connectWorker.RunWorkerAsync();
		}
		private void testServeur() {
			Boolean visible = (meoServeur!=null);
			purgeStockLabel.Visible=visible;
			purgeVisitesLabel.Visible=visible;
			statStockLabel.Visible=visible;
			statVisitesLabel.Visible=visible;
			
			if (meoServeur==null) {
				detailmagasinBox.Text= "erreur, serveur non retrouvé";
				return;
			}
			detailmagasinBox.Text = "I:" +instance.nom + " - S :" +meoServeur.adresse + " D:"+instance.nom;
		}
		private void populate() {
			this.magasinIdBox.Text=magId;
			this.magasinIdBox.Enabled=false;
			totauxLabel.Tag=configDto.getSqlCommand(SqlCommandsType.getUtilisation);
			statStockLabel.Tag = configDto.getSqlCommand(SqlCommandsType.getExtensionStock);
			statVisitesLabel.Tag=configDto.getSqlCommand(SqlCommandsType.getExtensionClient);
			purgeStockLabel.Tag=configDto.getSqlCommand(SqlCommandsType.doPurgeStock);
			purgeVisitesLabel.Tag=configDto.getSqlCommand(SqlCommandsType.doPurgeClient);
			
			DateTime dt = DateTime.Now;
			anneeStockPurgeBox.Text = "2001";
			anneeVisitePurgeBox.Text = (dt.Year -10) +"";
			
			visiteLimiteBox.Text=options.getLimiteVisite();
			stockLimiteBox.Text = options.getLimiteStock();
			
			visiteLimiteBox.Enabled=false;
			stockLimiteBox.Enabled=false;
		}
		private void doStatStock() {
			populateGrid(statStockLabel.Tag.ToString(), anneeStockPurgeBox.Text);
			purgeStockLabel.Visible=true;
		}
		
		private void doStatVisite() {
			populateGrid(statVisitesLabel.Tag.ToString(), anneeVisitePurgeBox.Text);
			purgeVisitesLabel.Visible=true;
		}
		private void StatStockLabelClick(object sender, EventArgs e) {
			doStatStock();
		}
		
		private void StatVisitesLabelClick(object sender, EventArgs e) {
			doStatVisite();
		}
		private void PurgeStockLabelClick(object sender, EventArgs e) {
			doPurge(purgeStockLabel.Tag.ToString(), anneeStockPurgeBox.Text);
			doStatStock();
		}
		private void PurgeVisitesLabelClick(object sender, EventArgs e) {
			doPurge(purgeVisitesLabel.Tag.ToString(), anneeVisitePurgeBox.Text);
			doStatVisite();
		}
		private void populateGrid(String sql, String annee) {
			sql=prepareSQL(sql, magId, annee);
			sqlCalculeBox.Text=sql;
			String connectionString = myUtil.buildConnectionStringFromInstance(instance, configDto, sqlPort);
			dataGridView1.DataSource= myUtil.buildDataSource(connectionString, sql);
			dataGridView1.Refresh();
			
		}
		private void doPurge(String sql, String annee) {
			sql=prepareSQL(sql, magId, annee);
			resultatSQLBox.Text=sql;
			DialogResult result = MessageBox.Show("Purger les données magasins <= "+annee+" ?",   "confirme purge",    MessageBoxButtons.YesNo);
			if(result==DialogResult.Yes) {
				String connectionString = myUtil.buildConnectionStringFromInstance(instance, configDto, sqlPort);
				myUtil.getExecuteQueryResult(connectionString, sql);
			}
		}
		private String prepareSQL(String sql, String magId, String year) {
			sql=sql.Trim();
			sql=sql.Replace("@MAGID", magId);
			sql=sql.Replace("@MYEAR", year);
			return sql;
		}
		void MouliSQLFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(sshClient!=null && sshClient.IsConnected) {
				sshClient.Disconnect();
			}
		}
		void TotauxLabelClick(object sender, EventArgs e)
		{
			populateGrid(totauxLabel.Tag.ToString(), anneeVisitePurgeBox.Text);
		}
	}
}
