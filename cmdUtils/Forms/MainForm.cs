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
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
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
		
		List <MeoInstance> instanceList = new List<MeoInstance>();
		
		List <AssoControleParam> configListeControles = new List<AssoControleParam>();
		
		CmdUtil cmdUtils = new CmdUtil();
		MouliUtil mouliUtil = new MouliUtil();
		MoulinetteAction moulinetteAction = new MoulinetteAction();
		ConfigSectionSettings cfg =	ConfigSectionSettings.GetSection(ConfigurationUserLevel.PerUserRoamingAndLocal);

		private Renci.SshNet.SshClient adminServeurSshClient = null;
		public MainForm()
		{
			InitializeComponent();

			initConfig();
			populate();
		}

		void initInstance()
		{
			instanceList.Clear();
			MeoServeur s1 = new MeoServeur("S-1",  "1.1.1.1");
			MeoServeur s2 = new MeoServeur("S-2", "1.1.1.2");
			MeoServeur s4 = new MeoServeur("S-4", "1.1.1.4");
			MeoServeur s5 = new MeoServeur("S-5", "1.1.1.5");
			
			//instanceList.Add(new MeoInstance(s1.getNom(), "m3035", "i01", "meocli_meo3035", "url"));
			//instanceList.Add(new MeoInstance(s1.getNom(), "od", "iOD", "meocli_od", "url"));
			//instanceList.Add(new MeoInstance(s2.getNom(), "2", "i02", "meocli_i2", "url"));
			//instanceList.Add(new MeoInstance(s2.getNom(), "3", "i03", "meocli_i3", "url"));
		}

		void initInstanceListBox(ListBox listBox)
		{
			foreach (MeoInstance i in instanceList) {
				listBox.Items.Add(i.getCode());
			}
		}


		
		void initConfig()
		{
			//configListeControles.Add(new AssoControleParam(cygwinParam,cfg.cygwinPath, cfg.cy));
			//TODO:voir configListeControles, une collection ????
			//et faire le tableau d'init. puis revoir grace a ca populate(), et updateConfig()
			
			configListeControles.Add(new AssoControleParam(cfg, "cygwinPath", cygwinParam));
			initInstance();
			initInstanceListBox(instancesListBox);
			
			MyUtil util = new MyUtil();
			moulDateTextBox.Text = util.getDate8(DateTime.Now);
			util = null;
			//todo:write a config file, with server, instance name, meocliname ...
		}
		void SaveButtonClick(object sender, EventArgs e)
		{

			updateConfig();
			
			//cfg.ExampleAttribute="youpi";
			cfg.Save();
			Configuration cfgConf = cfg.getConfiguration();
			statusStrip1.Text = "Saved in : " + cfgConf.FilePath;
			labelFichierConfig.Text = "Saved in : " + cfgConf.FilePath;
			populate();
		}
		void TabCodeBtnClick(object sender, EventArgs e) {
			String source=tabCodeSource.Text;
			String avant = tabCodeAvant.Text;
			String apres = tabCodeApres.Text;
			
			String result = tabCodeComplete(source, avant, apres);
			tabCodeResult.Text=result;
		}
		private String tabCodeComplete(String source, String avant, String apres) {
			String [] tablo= source.Split('\n');
			String retour="";
			for(int i =0 ; i<tablo.Length;i++) {
				retour+=avant +tablo[i].Trim()+apres+"\r\n";
			}
			return retour;
		}
		void TabParamClick(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
			populate();
		}
		void populate()
		{
			cygwinParam.Text = cfg.cygwinPath;
			
//			foreach(AssoControleParam param in configListeControles) {
//				param.getTextBox().Text = param.getValue();
//			}
//			cfg.getConfiguration().GetSection(param.getSection());
			
			cygwinTermParam.Text = cfg.cygwinTerm;
			mysqlParam.Text = cfg.mysqlExePath;
			dataParam.Text = cfg.dumpsPath;
			mysqlUserParam.Text = cfg.mysqlUser;
			mysqlPasswordParam.Text = cfg.mysqlPassword;
			scriptCreateDbParam.Text = cfg.scriptCreate;
			scriptCreateFiledDBParam.Text = cfg.scriptFileDb;
			
			moulSrcPathParam.Text = cfg.moulSrcPath;
			moulDstPathParam.Text = cfg.moulDstPath;
			moulScp1Param.Text = cfg.moulUploadS1;
			moulScp2Param.Text = cfg.moulUploadS2;
			moulFichiersParam.Text = cfg.moulFichiers;
			
			if (filterGzTextBox.Text.Length == 0) {
				
				DateTime now = DateTime.Now;
				filterGzTextBox.Text = "meo*anq*" + now.ToString("yyyyMMdd") + "*.sql.gz";
			}
			sshConnectionStatusLabel.Text="not connected";
			populateMoulinettes();
			populateSshServer();
			
		}
		void populateSshServer () {
			
			AsyncCallback callBack = new AsyncCallback(prepareAdminServeur);
			
			sshConnectionStatusLabel.Text = "connection to admin ...";
			callBack.Invoke(null);
			//callBack.e
			
		}
		private void prepareAdminServeur(IAsyncResult result) {
			RechercheMagasinUtil rechercheUtil = new RechercheMagasinUtil();
			String etat= rechercheUtil.getAdminServeur(ref adminServeurSshClient, 2999);
			if(etat=="") {
				sshConnectionStatusLabel.Text = "Connected to admin";
			} else {
				sshConnectionStatusLabel.Text = "connection error : "+etat;
			}
		}

		void populateMoulinettes()
		{
			txtBoxMoulSrcPath.Text = cfg.moulSrcPath;
			txtBoxMoulDestBase.Text = cfg.moulDstPath;
			
			txtBoxMoulSrcFilter.Text = "*client*";
			
			//txtBoxMoulSrcPath.Text=cfg.moulSrcPath;
			//txtMoulDestBase.Text=cfg.moulDstPath;
			
		}

		void updateConfig()
		{
//			foreach(AssoControleParam param in configListeControles) {
//				param.setValue(param.getTextBox().Text);
//			}
			
			
			cfg.cygwinPath = cygwinParam.Text;
			cfg.cygwinTerm = cygwinTermParam.Text;
			
			cfg.mysqlExePath = mysqlParam.Text;
			
			cfg.dumpsPath = dataParam.Text;
			cfg.mysqlUser = mysqlUserParam.Text;
			cfg.mysqlPassword = mysqlPasswordParam.Text;
			
			cfg.scriptCreate = scriptCreateDbParam.Text;
			cfg.scriptFileDb = scriptCreateFiledDBParam.Text;
			
			cfg.moulSrcPath = moulSrcPathParam.Text;
			cfg.moulDstPath = moulDstPathParam.Text;
			cfg.moulUploadS1 = moulScp1Param.Text;
			cfg.moulUploadS2 = moulScp2Param.Text;
			
			cfg.moulFichiers = moulFichiersParam.Text;


			
		}

		void reportError(Exception e)
		{
			statusStrip1.Text = "Erreur : " + e.Message;
			statusStrip1.BackColor = Color.Yellow;
			sqlRechRichTextBox.Clear();
			sqlRechRichTextBox.AppendText(e.Message+"\n"+e.StackTrace);
			sqlRechRichTextBox.ForeColor=Color.Red;
			
		}

		void GetMysqlDatabaseButtonClick(object sender, EventArgs e)
		{
			
			try {
				List <String> liste = cmdUtils.getDatabases(cfg);
				cmdUtils.listToCombo(liste, mysqlDatabaseCombo, true);
			} catch (Exception ex) {
				reportError(ex);
			}
			//util.getDatabases(mysqlDatabaseCombo);
		}
		void GoMysqlImportButtonClick(object sender, EventArgs ev)
		{
			System.Diagnostics.Debug.Print("in import SQL");
			mysqlImportBouton.Enabled = false;
			try {
				cmdUtils.sourceSQL(cfg, getDatabaseName(), getDumpName());
			} catch (Exception ex) {
				MessageBox.Show("Erreur import : " + ex.Message);
			}
			mysqlImportBouton.Enabled = true;
			//getExecuteQueryResult
			
			//List <String> liste=cmdUtils.getDatabases(cfg);
			//cmdUtils.listToCombo(liste, mysqlDatabaseCombo, true);
			//util.getDatabases(mysqlDatabaseCombo);
		}
		void tabImportClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.Print("clickd");
			GetMysqlDatabaseButtonClick(sender, e);
		}
		void FilterGzBtnClick(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.Tag = btn.Text;
			btn.Text = "(...)";
			btn.Enabled = false;
			
			cmdUtils.listFilesToListbox(cfg.dumpsPath, filterGzTextBox.Text, dumpsListBox);
			btn.Text = (String)btn.Tag;
			btn.Enabled = true;
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
			richTextBox1.Text = cmdUtils.buildImportDatabase(cfg, dump, getDatabaseName());
			richTextBox1.Text += " ; " + cmdUtils.dingding();
			richTextBox1.Text += " ; " + cmdUtils.buildMysqlScript(cfg, getDatabaseName(), cfg.scriptFileDb);
		}
		private string getDatabaseName()
		{
			return mysqlDatabaseCombo.Text;
		}
		private String getDumpName()
		{
			String retour = "";
			if (dumpsListBox.SelectedIndex >= 0) {
				retour = dumpsListBox.SelectedItem.ToString().Replace("\\", "/");
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
			mysqlImportBouton.Enabled = false;
			cmdUtils.sourceSQL(cfg, getDatabaseName(), "X:/meo-datas/create_meo_filedb.sql");
			mysqlImportBouton.Enabled = true;

		}
		void CygwinToolStripButtonClick(object sender, EventArgs e)
		{
			String cmd = cygwinParam.Text + "mintty.exe ";
			//title marche pas
			String args = cygwinTermParam.Text + "-size 240,48 -";
			System.Diagnostics.Debug.Print("cmd: " + cmd);
			System.Diagnostics.Debug.Print("arg: " + args);
			ProcessUtil pu = new ProcessUtil();
			ProcessWindowStyle windowStyle = ProcessWindowStyle.Normal;
			
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
			moulinetteAction.bntListSrc((Button)sender, cmdUtils, txtBoxMoulSrcPath.Text, txtBoxMoulSrcFilter.Text, listboxMoulSrc);
		}
		void Button2Click(object sender, EventArgs e)
		{
			cmdUtils.openWindowsExplorer(txtBoxMoulDestBase.Text);
			
		}
		void BntMoulZipItClick(object sender, EventArgs e)
		{
			
			txtFinal.Text = "testZip.zip";
			ZipUtil zipUtil = new ZipUtil();
			//
			ZipUtilOptions zop = new ZipUtilOptions();
			zop.setArchiveDir(cfg.moulDstPath);
			zop.setArchiveName(txtFinal.Text);
			String source = listboxMoulSrc.Text;
			zop.setSourceBaseDir(source);
			//zop.setSourceBaseDir();
//			- delegate : c'est pas ca qui fo
//				- fileinfo de la sélection a remplir
//				- suite de la methode a remplir
			//ZipUtilOptions.renommeFichierZip renomme  = v =>Console.WriteLine(v);
			//zop.setRenommeFonction(renomme);
			//renomme.Invoke();
			
			//zop.g
			zop.setSourceSelection(cfg.moulFichiers.Split(' '));
			try {
				zipUtil.createArchive(zop);
			} catch (Exception ex) {
				MessageBox.Show("Erreur : " + ex.Message);
			}
			
			//
//			try {
//				zipUtil.createArchive(txtFinal.Text, cfg.moulDstPath ,cfg.moulFichiers.Split(' '), "data/mag01", "c:/temp/");
//			} catch(Exception ex) {
//				MessageBox.Show("Erreur : "+ex.Message);
//			}
			
		}
		void TabImportClick(object sender, EventArgs e)
		{
			
		}
		void ImportMagIdKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue.Equals(13)) {
				try {
					updateMagasinsInfo(((TextBox)sender).Text, sqlRechRichTextBox);
				} catch(Exception ex) {
					reportError(ex);
				}
			}
		}
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			
		}

		void updateMagasinsInfo(string magId, RichTextBox rtb)
		{
			

			if (magId.Length > 0) {
				rtb.Clear();
				RechercheMagasinUtil rechercheUtil = new RechercheMagasinUtil();
				
				rtb.AppendText(rechercheUtil.getMagasinDescription(magId, ref adminServeurSshClient, 23306, false));
			}
		}
		Boolean checkFormat(TextBox box)
		{
			String texte = box.Text;
			Boolean changed = false;
			List<String> newList = new List<string>();
			foreach (String ligne  in texte.Split('\n')) {
				String newStr = ligne;
				
				newStr = newStr.Replace('\r', ' ');
				newStr = newStr.Replace('\t', ' ');
				newStr = newStr.Trim();
				newList.Add(newStr);
				if (!ligne.Equals(newStr)) {
					changed = false;
				}
			}
			if (changed) {
				String newStr = "";
				foreach (String ligne in newList) {
					newStr += ligne + "\n";
				}
				box.Text = newStr;
			}
			return changed;
		}

		void TabMeoTxtExceptionBruteTextChanged(object sender, EventArgs e)
		{
			try {
				if (!checkFormat(tabMeoTxtExceptionBrute)) {
					tabMeoTxtExceptionLisible.Text = cmdUtils.translateException(tabMeoTxtExceptionBrute.Text);
				}
			} catch (Exception ex) {
				Console.WriteLine("Erreur : " + ex.ToString());
				// osenf
			}
		}
		
		MeoInstance getInstance(String code)
		{
			foreach (MeoInstance instance in instanceList) {
				if (instance.getCode().Equals(code)) {
					return instance;
				}
			}
			return null;
		}
		
		private void logInRtb(String message) {
			RichTextBox rtb = moulRichTexBox;
			rtb.AppendText(message);
		}
		void MoulCreaRepBtnClick(object sender, EventArgs e)
		{
			String instanceCode = (string)this.instancesListBox.SelectedItem;
			MeoInstance instance = getInstance(instanceCode);
			RichTextBox rtb = moulRichTexBox;
			rtb.Clear();
			
			Action<String> callback = logInRtb;
			//String path=mouliUtil.creaEtVerifieRepMoulinette(instance, callback, txtBoxMoulDestBase.Text, txtMagId.Text, txtMagClient.Text, moulDateTextBox.Text, "01");
			//tboxMoulRepFinal.Text = path;
			//mouliUtil.checkOrdoFixe(path );
		}
		void TabMeoTest1Click(object sender, EventArgs e)
		{
			tabMeoTxtExceptionBrute.Text = cmdUtils.getExemple(1);

		}
		void TabMeoTest2Click(object sender, EventArgs e)
		{
			tabMeoTxtExceptionBrute.Text = cmdUtils.getExemple(2);
		}
		
		void MoulinetteMagIdKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyValue.Equals(13)) {
				string magId = ((TextBox)sender).Text;
				
				ConfigDto configDto= new ConfigUtil().getConfig();
				
				RichTextBox rtb = moulRichTexBox;
				rtb.Clear();
				if (magId.Length > 0) {
					try {
						mouliUtil.updateMoulinetteMagasin(configDto, magId,cfg,  txtMagClient, rtb);
//					string sql = "select * from administration.magasins where magasin_id=" + magId;
//					MyUtil util = new MyUtil();
//					try {
//						string cstr = util.doConnString(cfg);
//						var magasinList = util.getListResultAsKV(cstr, sql);
//
//						rtb.AppendText("#libe:" + util.getItem(magasinList[0], "magasin_libelle") + " - url :" + util.getItem(magasinList[0], "url"));
//						rtb.AppendText("\n#cli_id:" + util.getItem(magasinList[0], "client_id"));
//						//Console.WriteLine("libe:"+util.getItem(magasinList[0], "magasin_libelle"));
//						//Console.WriteLine("cli_id:"+util.getItem(magasinList[0], "client_id"));
//
//						txtMagClient.Text = (string)util.getItem(magasinList[0], "magasin_identifiant");
//						sql = "SELECT utilisateur_id,magasin_id FROM administration.utilisateurs where utilisateur_active=true AND magasin_id=" + magId + ";";
//						var userList = util.getListResultAsKV(cstr, sql);
//
//						rtb.AppendText("\nmodeDevMagId=" + util.getItem(userList[0], "magasin_id"));
//						rtb.AppendText("\nmodeDevUserId=" + util.getItem(userList[0], "utilisateur_id"));
						
					} catch (Exception ex) {
						reportError(ex);
					}
				}
			}
		}
		void BtnCheckYClick(object sender, EventArgs e)
		{
			if(tboxMoulRepFinal.Text.Length>0) {
				try  {
					moulYFRtb.Clear();
					mouliUtil.checkIfYFilesExists(tboxMoulRepFinal.Text, moulYFRtb, "data/", "mag01/", ".D");
				} catch(Exception ex) {
					reportError(ex);
				}

				
//				for(YFiles yfile : YFiles) {
//				checkIfFileExists(moulYFRtb, "data", "mag01", yfile);
//				}
			}
		}
		void BtnCheckJClick(object sender, EventArgs e)
		{
			if(tboxMoulRepFinal.Text.Length>0) {
				try  {
					moulYFRtb.Clear();
					mouliUtil.checkIfJFilesExists(tboxMoulRepFinal.Text, moulYFRtb, "data/", "mag01/Joint/", ".txt");
				} catch(Exception ex) {
					reportError(ex);
				}

			}
		}
		void EditConfigClick(object sender, EventArgs e)
		{
			ProcessUtil util = new ProcessUtil();
			ConfigUtil configUtil = new ConfigUtil();
			String configFilePath=configUtil.getConfigFilePath();
			util.startProcess("vi", configFilePath, ProcessWindowStyle.Normal);
		}

		void ToolStripButton1Click(object sender, EventArgs e)
		{
			//title marche pas
			String cmdl = "c:\\Windows\\SysWOW64\\cmd.exe";
			String args = "";
			System.Diagnostics.Debug.Print("cmd: " + cmdl);
			System.Diagnostics.Debug.Print("arg: " + args);
			Process cmd = new Process();
			cmd.StartInfo.FileName = "cmd.exe";
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = false;
			cmd.StartInfo.UseShellExecute = false;
			
			cmd.Start();
			

			cmd.StandardInput.WriteLine("echo Oscar");
			cmd.StandardInput.Flush();
			cmd.StandardInput.Close();
			cmd.WaitForExit();
			Console.WriteLine(cmd.StandardOutput.ReadToEnd());

			
			
			Console.WriteLine("p");
		}
		void ImportMagIdTextChanged(object sender, EventArgs e)
		{
		}
		void mouliUtilToolStripButtonClick(object sender, EventArgs e)
		{
			const string path="w:/meo-moulinettes/";
			const string cmd="bin/mouliutil.bat";
			ProcessUtil util = new ProcessUtil();
			Process process = new Process();
			process.StartInfo.FileName = path+cmd;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.CreateNoWindow = false;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = path;
			process.Start();
			
			//util.startProcess(path+cmd, "", ProcessWindowStyle.Normal);
		}
		void RichTextBox2TextChanged(object sender, EventArgs e)
		{
			String sql = richTextBox2.Text;
			MeoSavUtil meosavUtil = new MeoSavUtil();
			sqlRechRichTextBox.Text = meosavUtil.convertiSql(sql);
		}
		void TabsSelected(object sender, TabControlEventArgs e)
		{
			//MessageBox.Show(" selected ");
		}
		void TabSQLEnter(object sender, EventArgs e)
		{
			Console.WriteLine("entering tab SQL");
		}
		void TabSQLLeave(object sender, EventArgs e)
		{
			Console.WriteLine("leaving tab SQL");
		}
		void StatusStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
