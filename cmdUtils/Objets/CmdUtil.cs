/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 23/04/2015
 * Heure: 13:52:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of CmdUtil.
	/// </summary>
	public class CmdUtil
	{


		MyUtil myUtil = new MyUtil();		
		//const string  mysqlShowDatabase_="show databases;";
		private List<Regex> listeRegDatabase () {
			List<Regex> listReg=new List<Regex>();
			listReg.Add(new Regex(@"meo"));
			listReg.Add(new Regex(@"administration"));
			return listReg;
		}
		public CmdUtil()
		{
		}
		
		public bool sourceSQL(ConfigSectionSettings cfg, string databaseName, string sourceFileName) {
			if ((databaseName==null) || (databaseName.Length<1)) {
				throw new Exception("bad params");
			}
			
			//String cmd=cfg.mysqlExePath;
			//String args=" -u "+cfg.mysqlUser +" -p"+cfg.mysqlPassword +" -Be ";
			
			sourceFileName=sourceFileName.Replace("\\", "/");
			String connString = myUtil.buildconnString("", "localhost", cfg.mysqlUser, cfg.mysqlPassword);
			int i = myUtil.getExecuteQueryResult(connString, myUtil.getSourceSQL(databaseName, sourceFileName));			
			return (i>0);
		}
		public bool dropRecreateDatabase(ConfigSectionSettings cfg, string databaseName, Boolean reCreate=true, Boolean createFileDb=false)
		{
			if ((databaseName==null) || (databaseName.Length<1)) {
				throw new Exception("bad params");
			}
			
			//String cmd=cfg.mysqlExePath;
			//String args=" -u "+cfg.mysqlUser +" -p"+cfg.mysqlPassword +" -Be ";
			
			
			String connString = myUtil.buildconnString("", "localhost", cfg.mysqlUser, cfg.mysqlPassword);
			int i = myUtil.getExecuteQueryResult(connString, myUtil.getDropSQL(databaseName, reCreate));
			if (createFileDb) {
				//cmdUtils.sourceSQL(cfg, databaseName, "X:/meo-datas/create_meo_filedb.sql");
				connString = myUtil.buildconnString(databaseName, "localhost", cfg.mysqlUser, cfg.mysqlPassword);
				//TODO:add a parameter
				myUtil.getExecuteQueryResult(connString, myUtil.readScript("X:/meo-datas/create_meo_filedb.sql"));
			}
			
			return (i>0);
		}

		public String buildImportDatabase(ConfigSectionSettings cfg, String dumpName, String databaseName, Boolean unzip=true) {
			StringBuilder builder = new StringBuilder();
			
			String v=dumpName.Replace("\\", "/");
			builder.Append("gunzip < ");
			builder.Append(v);
			builder.Append(" | ");
			
			builder.Append(cfg.mysqlExePath);
			builder.Append(" -u ");
			builder.Append(cfg.mysqlUser);
			builder.Append(" -p");
			builder.Append(cfg.mysqlPassword);
			builder.Append(" ");
			builder.Append(databaseName);
			
			return builder.ToString();
		}
		public void listToCombo(List<string> liste, ComboBox combo, Boolean clearBefore)
		{
			
			if ((liste!=null) && (combo!=null)) {
				if (clearBefore) {
					combo.Items.Clear();
				}
				
			}
			foreach(String s in liste) {
				combo.Items.Add(s);
			}
			
		}

		public void listFilesToListbox(string dumpsPath, String findPattern, ListBox box)
		{
			DirectoryInfo 		di = new DirectoryInfo(dumpsPath);
			box.Items.Clear();
			foreach(FileInfo f in di.GetFiles(findPattern)) {
				box.Items.Add(f.FullName);
			}
		}
		public List <String> getDatabases(ConfigSectionSettings cfg) {
			String connString = myUtil.buildconnString("", "localhost", cfg.mysqlUser, cfg.mysqlPassword);
			List <String> list = myUtil.getListResult(connString, myUtil.getDatabaseList());
			
			list=filterListe(list, listeRegDatabase(), FiltersReg.MatchOne);
			return list;
			
		}
		
		public List <String> executeCommand(String cmd, String args) {
			List <String> list = new List<String>();
			
			ProcessUtil pu = new ProcessUtil();
			Process p = pu.startProcess(cmd, args, ProcessWindowStyle.Minimized);
			try {
				if (p.ExitCode!=0) {
					StreamReader srErr=p.StandardError;
					String [] sErr =  srErr.ReadToEnd().Split('\n');
					foreach(String ss in sErr) {
						list.Add(ss);
					}
					return list;
					
				}
			} catch (Exception e) {
				System.Diagnostics.Debug.Print("Exception : "+e);
			}
			StreamReader srOut= p.StandardOutput;
			String [] sOut =  srOut.ReadToEnd().Split('\n');
			foreach(String ss in sOut) {
				
				list.Add(ss.Replace("\r", ""));
			}

			return list;
		}
		public List<String> filterListe(List<String> listStr, List<Regex> listReg, FiltersReg filter) {
			
			List <String> back=null;
			if ((listStr!=null) && (listReg!=null)) {
				back=new List<String>();
				foreach(String itemString in listStr) {
					Boolean keepIt=false;
					foreach(Regex itemRegex in listReg) {
						if(itemRegex.Match(itemString).Success) {
							if(filter.Equals(FiltersReg.MatchNone)) {
								keepIt=false;
								break;
							}
							keepIt=true;
							break; //no need to spec all the list.
						} else {
							if(filter.Equals(FiltersReg.MatchAll)) {
								keepIt=false;
								break;
							}
						}
					}
					if(keepIt) {
						back.Add(itemString.Replace("\n", ""));
					}
					
				}
				
			}
			return back;
		}
	}
}
