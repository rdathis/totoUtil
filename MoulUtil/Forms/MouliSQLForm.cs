/*
 * Utilisateur: Renaud
 * Date: 09/01/2017
 * Heure: 14:42:23
 * 
 */
using System;
using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;
using cmdUtils.Objets;
using cmdUtils.Objets.business;
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
		private	const int sqlPort=5000;
		private System.Diagnostics.Process plinkProcess = null;
		private MouliUtilOptions options = null;
		
		public MouliSQLForm(String magId, MouliUtilOptions options) {
		                    
			InitializeComponent();
			this.magId=magId;
			this.options=options;
			
			ConfigUtil configUtil= new ConfigUtil();
			configDto = configUtil.getConfig();
			
			this.instance=MeoInstance.findInstanceByInstanceName(configDto.instances, options.getInstanceName());
			myUtil=new MyUtil();
			if(instance!=null) {
				meoServeur = MeoServeur.findServeurByName(configDto.serveurs, instance.serveur);
			}
			purgeStockLabel.Visible=false;
			purgeVisitesLabel.Visible=false;
			testServeur();
			populate();
		}
		private void testServeur() {
			if (meoServeur==null) {
				detailmagasinBox.Text= "erreur, serveur non retrouvé";
				purgeStockLabel.Visible=false;
				purgeVisitesLabel.Visible=false;
				statStockLabel.Visible=false;
				statVisitesLabel.Visible=false;
				return;
			}
			detailmagasinBox.Text = "I:" +instance.nom + " - S :" +meoServeur.adresse + " D:"+instance.nom;
			//startPlink(meoServeur);
			//plink a faire.
		}

//		void startPlink(MeoServeur meoServeur)
//		{
//			String args = " -ssh -batch -pw "+meoServeur.password+" -L "+sqlPort+":127.0.0.1:3306 "+meoServeur.getUtilisateur()+"@"+meoServeur.adresse;
//
//			ProcessUtil putil =new ProcessUtil();
//			plinkProcess = putil.startProcess(MouliConfig.plinkPath, args, System.Diagnostics.ProcessWindowStyle.Normal);
//			this.BackColor = Color.LightBlue;
//			statStockLabel.Visible=true;
//			statVisitesLabel.Visible=true;
//		}

		private void populate() {
			this.magasinIdBox.Text=magId;
			this.magasinIdBox.Enabled=false;
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
			if(plinkProcess!=null) {
				plinkProcess.Close();
			}

		}
	}
}
