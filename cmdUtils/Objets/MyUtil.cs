/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 19/05/2015
 * Heure: 13:11:51
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of MyUtil.
	/// </summary>
	public class MyUtil
	{

		public MyUtil()
		{
		}
		
		public String buildconnString(String databaseName, String serverName, String user, String pwd) {
			return buildconnString(databaseName, serverName, user, pwd, 3306);
			
		}
		
		public String buildconnString(String databaseName, String serverName, String user, String pwd, int port) {
			return string.Format("Database={0};Data Source={1};User Id={2};Password={3};Port={4}", databaseName, serverName, user, pwd, port);
			
		}
		public  MySqlConnection getConnection(String connectionString) {
			MySqlConnection cnx = new MySqlConnection();
			cnx.ConnectionString = connectionString;
			return cnx;
		}

		public object getItem(List<KeyValuePair<string, object>> list, string keyName)
		{
			foreach(KeyValuePair<string, object> paire in list) {
				if (paire.Key.Equals(keyName)) {
					return paire.Value;
				}
			}
			return ".";
		}
		public string doConnString(ConfigSectionSettings cfg)
		{
			return buildconnString("", "127.0.0.1", cfg.mysqlUser, cfg.mysqlPassword, 3306);
		}

	
		public  MySqlConnection getConnection(String databaseName, String serverName, String user, String pwd, int port) {
			String cString = buildconnString(databaseName, serverName, user, pwd, port);
			return getConnection(cString);
		}

		//lit rapidement un script sql
		public string readScript(string file)
		{
			String script=null;
			StreamReader reader =null;
			try {
				reader= new StreamReader(file);
				if (reader!=null) {
					script=reader.ReadToEnd();
				}
			} catch {
				//TODO:mind this
			} finally {
				if (reader!=null) {
					reader.Close();
				}
			}
			return script;
		}

		public List<String> getListResultSimple(string connString, string str, int fieldIndex=0)
		{
			
			List<Object> liste = getListResult(connString, str, fieldIndex);
			List <String> retour = new List<string>();
			foreach(Object data in liste) {
				retour.Add((String) data);
			}
			return retour;
		}

		//fast, but not extensible
		private object convertit(MySqlDataReader reader, int fieldIndex)
		{
			return(reader.GetValue(fieldIndex));
		}
		public List<object> getListResult(string connString, string sql, int fieldIndex=0) {
			{
				List<object> result=new List<object>();

				MySqlConnection cnx = getConnection(connString);
				cnx.Open();
				MySqlCommand command = new MySqlCommand(sql, cnx);
				
				MySqlDataReader data = command.ExecuteReader();
				while(data.Read()) {
				
					result.Add(convertit(data, fieldIndex));

					System.Diagnostics.Debug.Print("data:("+data.GetFieldType(0)+")" + data.GetValue(0) +" "+ data.FieldCount);
				}
				cnx.Close();
				return result;
			}
		}
		public List<List<KeyValuePair<String, Object>>> getListResultAsKeyValue(string connString, string sql) {
			List<List<KeyValuePair<String, Object>>> result = new List<List<KeyValuePair<string, object>>>();
			MySqlConnection cnx = getConnection(connString);
			cnx.Open();
			MySqlCommand command = new MySqlCommand(sql, cnx);
			
			MySqlDataReader data = command.ExecuteReader();
			while(data.Read()) {
				result.Add(  traduit(data));
			}
			cnx.Close();
			return result;
		}
		private List<KeyValuePair<String, Object>> traduit(MySqlDataReader data) {
			List <KeyValuePair<String, Object>> l = new List<KeyValuePair<String, Object>>();
			for(int i=0;i< data.FieldCount;i++) {
				KeyValuePair<String, Object> z = new KeyValuePair<String, Object>(data.GetName(i), data.GetValue(i));
				l.Add(z);
			}
			
			return l;
		}
		public int getExecuteQueryResult(string connString, string sql) {
			int retour=-1;
			try {
				MySqlConnection cnx = getConnection(connString);
				cnx.Open();
				MySqlCommand command = new MySqlCommand(sql, cnx);

				System.Diagnostics.Debug.Print ("sql : "+sql);
				retour = command.ExecuteNonQuery();
				cnx.Close();
				System.Diagnostics.Debug.Print(" nb affected : "+retour);
			} catch (Exception ex) {
				System.Windows.Forms.MessageBox.Show("Erreur sql ("+connString+")\nSQL:"+sql+"\n\n"+ex.Message+"\n\n"+ex.StackTrace);
			}
			return retour;
		}
		public String getSourceSQL(String databaseName, string fileName) {
			return "USE "+databaseName+" ; SOURCE "+fileName+" ;";
		}
		
		public string getDropSQL(string databaseName, Boolean reCreate)
		{
			String cmd="  DROP DATABASE IF EXISTS "+databaseName+" ; ";
			if (reCreate) {
				cmd+="  CREATE DATABASE IF NOT EXISTS "+databaseName+"; "+" ";
			}
			return (cmd);
		}
		
		public String getDatabaseList() {
			return ("SHOW DATABASES;");
		}
		
		private void voidx() {
//			System.Windows.Data.pdf
//				https://msdn.microsoft.com/en-us/library/windows/apps/dn263107.aspx
//
//			https://www.edrawsoft.com/embed-pdf-vbnet.php
//
			
		}
		public Boolean createFolderIfNotExists(String path) {
			DirectoryInfo di = Directory.CreateDirectory(path);
			return true;
		}
		public String getDate8(DateTime date) {
			return String.Format("{0:yyyyMMdd}", date);
		}
	}
}
