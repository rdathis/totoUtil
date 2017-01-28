/*
 * Utilisateur: Renaud
 * Date: 09/01/2017
 * Heure: 14:42:23
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using cmdUtils.Objets;
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
		MeoServeur meoServeur =null;

		public MouliSQLForm(String magId, MeoInstance instance)		{
			InitializeComponent();
			this.magId=magId;
			this.instance=instance;
			ConfigUtil configUtil= new ConfigUtil();
			configDto = configUtil.getConfig();
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
		}
		private void populate() {
			this.magasinIdBox.Text=magId;
			this.magasinIdBox.Enabled=false;
			statStockLabel.Tag = configDto.sql02;
			statVisitesLabel.Tag=configDto.sql04;
			purgeStockLabel.Tag=configDto.sql03;
			purgeVisitesLabel.Tag=configDto.sql05;
			
			DateTime dt = DateTime.Now;
			anneeStockPurgeBox.Text = "2001";
			anneeVisitePurgeBox.Text = (dt.Year -10) +"";
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
		}
		private void doPurge(String sql, String annee) {
			sql=prepareSQL(sql, magId, annee);
			resultatSQLBox.Text=sql;
		}
		private String prepareSQL(String sql, String magId, String year) {
			sql=sql.Trim();
			sql=sql.Replace("@MAGID", magId);
			sql=sql.Replace("@MYEAR", year);
			return sql;
		}
	}
}
