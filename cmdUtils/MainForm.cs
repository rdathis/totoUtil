﻿
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
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using cmdUtils.Objets;
using MySql.Data;

namespace cmdUtils
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	public partial class MainForm : Form
	{
		
		
		List <AssoControleParam> configListeControles = new List<AssoControleParam>();
		
		CmdUtil cmdUtils = new CmdUtil();
		MoulinetteAction moulinetteAction = new MoulinetteAction();
		ConfigSectionSettings cfg=	ConfigSectionSettings.GetSection(ConfigurationUserLevel.PerUserRoamingAndLocal);
		public MainForm()
		{
			InitializeComponent();

			initConfig();
			populate();
		}

		void initConfig()
		{
			//configListeControles.Add(new AssoControleParam(cygwinParam,cfg.cygwinPath, cfg.cy));
			//TODO:voir configListeControles, une collection ????
			//et faire le tableau d'init. puis revoir grace a ca populate(), et updateConfig()
			
			configListeControles.Add(new AssoControleParam(cfg, "cygwinPath", cygwinParam));
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
			
//			foreach(AssoControleParam param in configListeControles) {
//				param.getTextBox().Text = param.getValue();
//			}
//			cfg.getConfiguration().GetSection(param.getSection());
			
			cygwinTermParam.Text=cfg.cygwinTerm;
			mysqlParam.Text = cfg.mysqlExePath;
			dataParam.Text=cfg.dumpsPath;
			mysqlUserParam.Text = cfg.mysqlUser;
			mysqlPasswordParam.Text=cfg.mysqlPassword;
			scriptCreateDbParam.Text=cfg.scriptCreate;
			scriptCreateFiledDBParam.Text=cfg.scriptFileDb;
			
			moulSrcPathParam.Text=cfg.moulSrcPath;
			moulDstPathParam.Text=cfg.moulDstPath;
			moulScp1Param.Text=cfg.moulUploadS1;
			moulScp2Param.Text=cfg.moulUploadS2;
			moulFichiersParam.Text=cfg.moulFichiers;
			
			if (filterGzTextBox.Text.Length==0) {
				
				DateTime now= DateTime.Now;
				filterGzTextBox.Text="meo*anq*"+now.ToString("yyyyMMdd")+"*.sql.gz";
			}
			populateMoulinettes();
			
		}

		void populateMoulinettes()
		{
			txtBoxMoulSrcPath.Text=cfg.moulSrcPath;
			txtBoxMoulDestBase.Text=cfg.moulDstPath;
			
			txtBoxMoulSrcFilter.Text="*client*";
			
			//txtBoxMoulSrcPath.Text=cfg.moulSrcPath;
			//txtMoulDestBase.Text=cfg.moulDstPath;
			
		}

		void updateConfig() {
//			foreach(AssoControleParam param in configListeControles) {
//				param.setValue(param.getTextBox().Text);
//			}
			
			
			cfg.cygwinPath= cygwinParam.Text;
			cfg.cygwinTerm=cygwinTermParam.Text;
			
			cfg.mysqlExePath=mysqlParam.Text;
			
			cfg.dumpsPath=dataParam.Text;
			cfg.mysqlUser=mysqlUserParam.Text;
			cfg.mysqlPassword=mysqlPasswordParam.Text;
			
			cfg.scriptCreate=scriptCreateDbParam.Text;
			cfg.scriptFileDb=scriptCreateFiledDBParam.Text;
			
			cfg.moulSrcPath=moulSrcPathParam.Text;
			cfg.moulDstPath=moulDstPathParam.Text;
			cfg.moulUploadS1=moulScp1Param.Text;
			cfg.moulUploadS2=moulScp2Param.Text;
			
			cfg.moulFichiers=moulFichiersParam.Text;


			
		}
		void GetMysqlDatabaseButtonClick(object sender, EventArgs e)
		{
			
			List <String> liste=cmdUtils.getDatabases(cfg);
			cmdUtils.listToCombo(liste, mysqlDatabaseCombo, true);
			//util.getDatabases(mysqlDatabaseCombo);
		}
		void GoMysqlImportButtonClick(object sender, EventArgs ev)
		{
			System.Diagnostics.Debug.Print("in import SQL");
			mysqlImportBouton.Enabled=false;
			try {
				cmdUtils.sourceSQL(cfg, getDatabaseName(), getDumpName());
			} catch (Exception ex) {
				MessageBox.Show("Erreur import : "+ex.Message);
			}
			mysqlImportBouton.Enabled=true;
			//getExecuteQueryResult
			
			//List <String> liste=cmdUtils.getDatabases(cfg);
			//cmdUtils.listToCombo(liste, mysqlDatabaseCombo, true);
			//util.getDatabases(mysqlDatabaseCombo);
		}
		void tabImportClick(object sender, EventArgs e) {
			System.Diagnostics.Debug.Print("clickd");
			GetMysqlDatabaseButtonClick(sender, e);
		}
		void FilterGzBtnClick(object sender, EventArgs e)
		{
			Button btn=(Button)sender;
			btn.Tag=btn.Text;
			btn.Text="(...)";
			btn.Enabled=false;
			
			cmdUtils.listFilesToListbox(cfg.dumpsPath, filterGzTextBox.Text, dumpsListBox);
			btn.Text=(String)btn.Tag;
			btn.Enabled=true;
		}
		void dropButtonClick(object sender, EventArgs e)
		{
			if (cmdUtils.dropRecreateDatabase(cfg, getDatabaseName(), false)) {
				GetMysqlDatabaseButtonClick(null, null);
			}
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
			richTextBox1.Text+=" ; "+cmdUtils.dingding();
			richTextBox1.Text+= " ; "+cmdUtils.buildMysqlScript(cfg, getDatabaseName(), cfg.scriptFileDb);
			//richTextBox1.Text="gunzip <" +" "+v+" | "+cfg.mysqlExePath+"mysql.exe"+" -u "+cfg.mysqlUser+" -p"+cfg.mysqlPassword+ " "+mysqlDatabaseCombo.Text;
		}
		private string getDatabaseName() {
			return mysqlDatabaseCombo.Text;
		}
		private String getDumpName() {
			String retour="";
			if (dumpsListBox.SelectedIndex>=0) {
				retour=dumpsListBox.SelectedItem.ToString().Replace("\\", "/");
			}
			return retour;
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
		void MeoCreateFileDbClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.Print("in import SQL");
			mysqlImportBouton.Enabled=false;
			cmdUtils.sourceSQL(cfg, getDatabaseName(), "X:/meo-datas/create_meo_filedb.sql");
			mysqlImportBouton.Enabled=true;

		}
		void CygwinToolStripButtonClick(object sender, EventArgs e)
		{
			String cmd=cygwinParam.Text+"mintty.exe ";
			//title marche pas
			String args=cygwinTermParam.Text+"-size 240,48 -";
			System.Diagnostics.Debug.Print("cmd: "+cmd);
			System.Diagnostics.Debug.Print("arg: "+args);
			ProcessUtil pu = new ProcessUtil();
			ProcessWindowStyle windowStyle=ProcessWindowStyle.Normal;
			
			Process p = pu.startProcess(cmd, args, windowStyle);
			
			
		}
		void RecreateButtonClick(object sender, EventArgs e)
		{
			if (cmdUtils.dropRecreateDatabase(cfg, getDatabaseName(), true, filedbCheckbox.Checked)) {
				GetMysqlDatabaseButtonClick(null, null);
			}
		}
		void BtnMoulFilterSrcClick(object sender, EventArgs e)
		{
			cmdUtils.openWindowsExplorer(txtBoxMoulSrcPath.Text);
		}
		void BtnSearchClick(object sender, EventArgs e)
		{
			moulinetteAction.bntListSrc((Button) sender, cmdUtils,txtBoxMoulSrcPath.Text, txtBoxMoulSrcFilter.Text, listboxMoulSrc);
		}
		void Button2Click(object sender, EventArgs e)
		{
			cmdUtils.openWindowsExplorer(txtBoxMoulDestBase.Text);
			
		}
		void BntMoulZipItClick(object sender, EventArgs e)
		{
			txtFinal.Text="testZip.zip";
			ZipUtil zipUtil = new ZipUtil();
			//
			ZipUtilOptions zop = new ZipUtilOptions();
			zop.setArchiveDir("c:/temp/viscri01/mag01/");
			zop.setArchiveName(txtFinal.Text);
			//zop.setSourceBaseDir();
//			- delegate : c'est pas ca qui fo
//				- fileinfo de la sélection a remplir
//				- suite de la methode a remplir
			//ZipUtilOptions.renommeFichierZip renomme  = v =>Console.WriteLine(v);
			//zop.setRenommeFonction(renomme);
			//renomme.Invoke();
			
			//zop.g
			zop.setSourceSelection(cfg.moulFichiers.Split(' '));
			zipUtil.createArchive(zop);
			
			//
			zipUtil.createArchive(txtFinal.Text, "c:/temp/viscri01/mag01/" ,cfg.moulFichiers.Split(' '), "data/mag01", "c:/temp/");
			
		}
		void TabImportClick(object sender, EventArgs e)
		{
			
		}
		void ImportMagIdKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue.Equals(13)) {
				string magId=((TextBox) sender).Text;
				
				RichTextBox rtb = sqlRechRichTextBox;
				rtb.Clear();
				if (magId.Length>0) {
					string sql="select * from administration.magasins where magasin_id="+magId;
					MyUtil util = new MyUtil();
					string cstr = util.doConnString(cfg);
					var magasinList =  util.getListResultAsKV(cstr, sql);
					
					rtb.AppendText("#libe:"+util.getItem(magasinList[0], "magasin_libelle")+ " - url :"+util.getItem(magasinList[0], "url"));
					rtb.AppendText("\n#cli_id:"+util.getItem(magasinList[0], "client_id"));
					//Console.WriteLine("libe:"+util.getItem(magasinList[0], "magasin_libelle"));
					//Console.WriteLine("cli_id:"+util.getItem(magasinList[0], "client_id"));
					                                         
					sql="SELECT utilisateur_id,magasin_id FROM administration.utilisateurs where utilisateur_active=true AND magasin_id="+magId+";";
					var userList =  util.getListResultAsKV(cstr, sql);
					
					rtb.AppendText("\nmodeDevMagId="+util.getItem(userList[0], "magasin_id"));
					rtb.AppendText("\nmodeDevUserId="+util.getItem(userList[0], "utilisateur_id"));
				}
			}
		}
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}
		
		/*
---------------------------
mintty
---------------------------
Usage: mintty [OPTION]... [ PROGRAM [ARG]... | - ]

Start a new terminal session running the specified program or the user's shell.
If a dash is given instead of a program, invoke the shell as a login shell.

Options:
  -c, --config FILE     Load specified config file
  -e, --exec            Treat remaining arguments as the command to execute
  -h, --hold never|start|error|always  Keep window open after command finishes
  -i, --icon FILE[,IX]  Load window icon from file, optionally with index
  -l, --log FILE|-      Log output to file or stdout
  -o, --option OPT=VAL  Override config file option with given value
  -p, --position X,Y    Open window at specified coordinates
  -s, --size COLS,ROWS  Set screen size in characters
  -t, --title TITLE     Set window title (default: the invoked command)
  -u, --utmp            Create a utmp entry
  -w, --window normal|min|max|full|hide  Set initial window state
      --class CLASS     Set window class name (default: mintty)
  -H, --help            Display help and exit
  -V, --version         Print version information and exit

---------------------------
OK
---------------------------
		 */
		
	}
	
}
