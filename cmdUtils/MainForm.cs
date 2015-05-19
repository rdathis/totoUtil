/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 20/04/2015
 * Time: 20:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using cmdUtils.Objets;
using MySql.Data;
namespace cmdUtils
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		CmdUtil cmdUtils = new CmdUtil();
		ConfigSectionSettings cfg=	ConfigSectionSettings.GetSection(ConfigurationUserLevel.PerUserRoamingAndLocal);
		public MainForm()
		{
			InitializeComponent();

			populate();
		}
		void SaveButtonClick(object sender, EventArgs e)
		{

			updateConfig();
			
			//cfg.ExampleAttribute="youpi";
			cfg.Save();
			Configuration cfgConf=cfg.getConfiguration();
			statusStrip1.Text="Saved in : "+cfgConf.FilePath;
			labelFichierConfig.Text="Saved in : "+cfgConf.FilePath;
			populate();
		}
		void TabParamClick(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			populate();
		}
		void populate() {
			cygwinParam.Text = cfg.cygwinPath;
			mysqlParam.Text = cfg.mysqlExePath;
			dataParam.Text=cfg.dumpsPath;
			mysqlUserParam.Text = cfg.mysqlUser;
			mysqlPasswordParam.Text=cfg.mysqlPassword;
			scriptCreateDbParam.Text=cfg.scriptCreate;
			scriptCreateFiledDBParam.Text=cfg.scriptFileDb;
			
			
			if (filterGzTextBox.Text.Length==0) {
				
				DateTime now= DateTime.Now;
				filterGzTextBox.Text="meo*"+now.ToString("yyyyMMdd")+"*.sql.gz";
			}
		}
		void updateConfig() {
			cfg.cygwinPath= cygwinParam.Text;
			cfg.mysqlExePath=mysqlParam.Text;
			
			cfg.dumpsPath=dataParam.Text;
			cfg.mysqlUser=mysqlUserParam.Text;
			cfg.mysqlPassword=mysqlPasswordParam.Text;
			
			cfg.scriptCreate=scriptCreateDbParam.Text;
			cfg.scriptFileDb=scriptCreateFiledDBParam.Text;
		}
		void GetMysqlDatabaseButtonClick(object sender, EventArgs e)
		{
			List <String> liste=cmdUtils.getDatabases(cfg);
			cmdUtils.listToCombo(liste, mysqlDatabaseCombo, true);
			//util.getDatabases(mysqlDatabaseCombo);
		}
		void FilterGzBtnClick(object sender, EventArgs e)
		{
			Button btn=(Button)sender;
			btn.Tag=btn.Text;
			btn.Text="(...)";
			btn.Enabled=false;
			
			cmdUtils.listFilesToListbox(cfg.dumpsPath, filterGzTextBox.Text, dumpsListBox);
		}
		void dropButtonClick(object sender, EventArgs e)
		{
			cmdUtils.dropRecreateDatabase(cfg, getDatabaseName());
		}
		void DumpsListBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}
		void DumpsListBoxDoubleClick(object sender, EventArgs e)
		{
			String dump = getDumpName();
			//TODO:move this code
			richTextBox1.Text=cmdUtils.buildImportDatabase(cfg, dump, getDatabaseName());
			//richTextBox1.Text="gunzip <" +" "+v+" | "+cfg.mysqlExePath+"mysql.exe"+" -u "+cfg.mysqlUser+" -p"+cfg.mysqlPassword+ " "+mysqlDatabaseCombo.Text;
		}
		private string getDatabaseName() {
			return mysqlDatabaseCombo.Text;
		}
		private String getDumpName() {
			return dumpsListBox.SelectedItem.ToString().Replace("\\", "/");
		}
		
		//http://morpheus.developpez.com/mysqldotnet/
		//http://dev.mysql.com/get/Downloads/Connector-Net/mysql-connector-net-6.9.6-noinstall.zip
		void Label11Click(object sender, EventArgs e)
		{
			//test1();
		}
		void PdfLabelClick(object sender, EventArgs e)
		{
			//PDFDocument doc =new ;
			//PDFViewer view;
			
		}
	}
	
}
