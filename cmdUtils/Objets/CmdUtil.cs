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
		public CmdUtil()	{
		}

		public string dingding()
		{
			return "(cat `cygpath -W`/Media/ding.wav > /dev/dsp) ";
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
		public String buildMysqlScript(ConfigSectionSettings cfg, String databaseName, String scriptName) {
			StringBuilder builder = new StringBuilder();
			
			builder.Append(cfg.mysqlExePath);
			builder.Append(" -u ");
			builder.Append(cfg.mysqlUser);
			builder.Append(" -p");
			builder.Append(cfg.mysqlPassword);
			builder.Append(" ");
			builder.Append(databaseName);
			builder.Append(" < ");
			builder.Append(scriptName);

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

		public void listFilesToListbox(string dumpsPath, String findPattern, ListBox box, Boolean listFileOnly=true, Boolean listDirOnly=true)
		{
			if ((findPattern.Equals("")) || (findPattern==null)) {
				findPattern="*";
			}
			DirectoryInfo 		di = new DirectoryInfo(dumpsPath);
			box.Items.Clear();
			if (listDirOnly) {
				foreach(DirectoryInfo f in di.GetDirectories(findPattern)) {
					box.Items.Add(f.FullName);
				}
			}
			if (listFileOnly) {
				foreach(FileInfo f in di.GetFiles(findPattern)) {
					box.Items.Add(f.FullName);
				}
			}
		}
		
		public void launchWindowsCmd()
		{
			// For the example.
			//const string ex1 = "C:\\";
			// const string ex2 = "C:\\Dir";

			// Use ProcessStartInfo class.
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.CreateNoWindow = false;
			startInfo.UseShellExecute = false;
			startInfo.FileName = "cmd.exe";
			
			startInfo.WindowStyle = ProcessWindowStyle.Normal;
			//startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;
			startInfo.Arguments = "";

			try
			{
				// Start the process with the info we specified.
				// Call WaitForExit and then the using-statement will close.
				using (Process exeProcess = Process.Start(startInfo))
				{
					// exeProcess.WaitForExit();
				}
			}
			catch
			{
				// Log error.
			}
		}
		
		public List <String> getDatabases(ConfigSectionSettings cfg) {
			String connString = myUtil.buildconnString("", "localhost", cfg.mysqlUser, cfg.mysqlPassword);
			List <String> list = myUtil.getListResultSimple(connString, myUtil.getDatabaseList());
			
//			List <String> list = new List<String>() ;
//			foreach(object obj in listo) {
//				list.Add((String) obj.ToString());
//			}
			list=filterListe(list, listeRegDatabase(), FiltersReg.MatchOne);
			return list;
			
		}
		
		public List <String> executeCommande(String cmd, String args) {
			List <String> list = new List<String>();
			
			ProcessUtil pu = new ProcessUtil();
			Console.WriteLine(cmd +" "+args);
			// MessageBox.Show(cmd +" "+args);
			Process p = pu.startProcess(cmd, args, ProcessWindowStyle.Minimized);
/*
			try {
				//if (p.ExitCode!=0) {
					StreamReader srErr=p.StandardError;
					String [] sErr =  srErr.ReadToEnd().Split('\n');
					foreach(String ss in sErr) {
						list.Add(ss);
					}
					return list;
					
				//}
			} catch (Exception e) {
				System.Diagnostics.Debug.Print("Exception : "+e);
			}
			*/
			StreamReader srOut= p.StandardOutput;
			String [] sOut =  srOut.ReadToEnd().Split('\n');
			foreach(String ss in sOut) {
				
				list.Add(ss.Replace("\r", ""));
			}

			return list;
		}
		
		public void openWindowsExplorer(String path) {
			path=path.Replace("/", "\\");
			executeCommande("explorer", path);
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

		public string translateException(string text)
		{
			/**
		

---
cas 2 :
com.google.gwt.core.client.JavaScriptException: (TypeError) : Cannot read property 'd' of null: at
Unknown.Rxg(<anonymous>@960)
Unknown.PJk(<anonymous>@311)
Unknown.RJk(<anonymous>@1088650)
Unknown.dJg(<anonymous>@36)
Unknown.gJg(<anonymous>@379529)
Unknown.oQ(<anonymous>@258451)
Unknown.<anonymous>(<anonymous>@155)
Unknown._w(https://server/instance/application/78957C736ADB5FD05DCBA3DDACFEFF8F.cache.html@29)

			 */
			//StringBuilder builder = new StringBuilder();
			String source="";
			StringBuilder script = new StringBuilder();
			
			String server="";
			String instance="";
			String path="";
			String motLst="";
			//builder.Append("grep -w ");

			foreach (String ligne  in text.Split('\n')) {
				
				if (ligne.StartsWith("Unknown", StringComparison.Ordinal)) {
					String mot=ligne.Substring(8);
					mot= mot.Substring(0, mot.IndexOf("(", StringComparison.Ordinal));
					//builder.Append(" -e ^"+mot+"");
					motLst+=(mot+" ");
				} else if (ligne.StartsWith("sourceURL:", StringComparison.Ordinal)) {
					// CAS 1
					// sourceURL: https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html: null is not an object (evaluating 'a.d'): at
					// -> '692C88F43AF9B7D20FD4598EF78AF777.symbolMap'
					
					String mot = ligne;
					
					String[] lst = ligne.Split('/');
					server=lst[2];
					instance=lst[3];
					path=lst[4];
					
					mot = mot.Substring(mot.IndexOf(":", StringComparison.Ordinal)+1); //vire le premier ':'
					mot = mot.Substring(mot.LastIndexOf("/", StringComparison.Ordinal)+1); //garde la fin de l'url (fichier)
					//ici : calculer le path
					mot = mot.Substring(0, mot.IndexOf(":", StringComparison.Ordinal)); //vire le comment.
					mot = mot.Substring(0, mot.IndexOf(".", StringComparison.Ordinal));
					mot+=".symbolMap";
					source=mot;
				} ;
				if (ligne.Contains(".cache.html")) {
					// CAS 2
					// Unknown._w(https://server/instance/application/78957C736ADB5FD05DCBA3DDACFEFF8F.cache.html@29)
					String mot = ligne;
					String[] lst = ligne.Split('/');
					server=lst[2];
					instance=lst[3];
					path=lst[4];
					
					mot = mot.Substring(mot.IndexOf("(", StringComparison.Ordinal)+1); //vire le premier ':'
					mot = mot.Substring(mot.LastIndexOf("/", StringComparison.Ordinal)+1); //garde la fin de l'url (fichier)
					//ici : calculer le path
					// mot = mot.Substring(0, mot.IndexOf(":", StringComparison.Ordinal)); //vire le comment.
					mot = mot.Substring(0, mot.IndexOf(".", StringComparison.Ordinal));
					mot+=".symbolMap";
					source=mot;
					
				}
			}
			script.AppendLine("# Serveur : "+server +"");
			script.AppendLine("# Instance : "+instance+"");
			script.AppendLine("# App  : "+path+"");
			
			script.AppendLine("# cd tomcat-instanceX/webapps/meo_instanceX/WEB-INF/deploy/"+path+"/symbolMaps/");
			script.AppendLine("export lst='"+motLst+"' ;");
			
			script.AppendLine("export fsource="+source+";");
			script.Append("for mot in $lst ; do  (echo -n '*'$mot ' ' ; grep -w -e ^$mot $fsource) ; done;");
			
			//builder.Append(" "+source);
			
			return script.ToString();
		}

		public string getExemple(int i)
		{
			StringBuilder sb = new StringBuilder();
			if (i==1) {
				
				sb.AppendLine("com.google.gwt.core.client.JavaScriptException: (TypeError)");
				sb.AppendLine("line: 19730");
				sb.AppendLine("column: 54");
				sb.AppendLine("sourceURL: https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html: null is not an object (evaluating 'a.d'): at");
				sb.AppendLine("Unknown.f5h(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@76)");
				sb.AppendLine("Unknown.I5h(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@29)");
				sb.AppendLine("Unknown.K5h(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@621262)");
				sb.AppendLine("Unknown.hm(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@28)");
				sb.AppendLine("Unknown.Eae(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@34)");
				sb.AppendLine("Unknown.Gae(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@309143)");
				sb.AppendLine("Unknown.hm(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@28)");
				sb.AppendLine("Unknown.pm(https://server/App-1.24.0/application/692C88F43AF9B7D20FD4598EF78AF777.cache.html@12990)");
				
				return sb.ToString();
			}
			if (i==2) {
				sb.AppendLine("com.google.gwt.core.client.JavaScriptException: (TypeError) : Cannot read property 'd' of null: at");
				sb.AppendLine("Unknown.Rxg(<anonymous>@960)");
				sb.AppendLine("Unknown.PJk(<anonymous>@311)");
				sb.AppendLine("Unknown.RJk(<anonymous>@1088650)");
				sb.AppendLine("Unknown.dJg(<anonymous>@36)");
				sb.AppendLine("Unknown.gJg(<anonymous>@379529)");
				sb.AppendLine("Unknown.oQ(<anonymous>@258451)");
				sb.AppendLine("Unknown.<anonymous>(<anonymous>@155)");
				sb.AppendLine("Unknown._w(https://server/instance_name/application/78957C736ADB5FD05DCBA3DDACFEFF8F.cache.html@29)				");
				return sb.ToString();

			}
			return "";
		}

		public string buildPuttyArgs(MeoServeur server)
		{
			String retour="";
			if (String.IsNullOrEmpty(server.getPassword())) {
				retour+=" -pw "+server.getPassword();
			}
			if (!String.IsNullOrEmpty(server.getUtilisateur())) {
				retour+=" "+server.getUtilisateur()+"@"+server.getAdresse();
			}
			return (" -pw "+server.getPassword() +" "+server.getUtilisateur()+"@"+server.getAdresse());
		}

		public string buildPscpArgs(MeoServeur server, MouliJob job)
		{
			String retour="";
			if (!String.IsNullOrEmpty(server.getPassword())) {
				retour+=" -pw "+server.getPassword();
			}
			retour+=" "+job.getArchiveName()+" ";
			if (!String.IsNullOrEmpty(server.getUtilisateur())) {
				retour+=" "+server.getUtilisateur()+"@"+server.getAdresse();
			}
			retour+=":/database/transpo/";
			return (retour);
		}
		public Process executeCommandAsDetachedProcess(string command, string args)
		{
			//int ExitCode;
			ProcessStartInfo ProcessInfo;
			Process process;

			// for dos command: 			
			//ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + Command);
			ProcessInfo = new ProcessStartInfo(command, args);
			ProcessInfo.CreateNoWindow = false;
			ProcessInfo.UseShellExecute = false;
			process = Process.Start(ProcessInfo);
			//Process.WaitForExit(Timeout);
			//ExitCode = Process.ExitCode;
			//Process.Close();
			return process;
		}
	}
}
