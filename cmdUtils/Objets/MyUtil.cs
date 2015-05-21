﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 19/05/2015
 * Heure: 13:11:51
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
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
			return string.Format("Database={0};Data Source={1};User Id={2};Password={3}", databaseName, serverName, user, pwd);
			
		}
		public  MySqlConnection getConnection(String connectionString) {
			MySqlConnection cnx = new MySqlConnection();
			cnx.ConnectionString = connectionString;
			return cnx;
		}
		public  MySqlConnection getConnection(String databaseName, String serverName, String user, String pwd) {
			String cString = buildconnString(databaseName, serverName, user, pwd);
			return getConnection(cString);
		}

		public List<string> getListResult(string connString, string sql)
		{
			List<string> result = new List<string>();
			MySqlConnection cnx = getConnection(connString);
			cnx.Open();
			MySqlCommand command = new MySqlCommand(sql, cnx);
			
			MySqlDataReader data = command.ExecuteReader();
			while(data.Read()) {
				//TODO:problem
				result.Add( (String) data.GetValue(0));
				System.Diagnostics.Debug.Print("data:("+data.GetFieldType(0)+")" + data.GetValue(0) +" "+ data.FieldCount);
			}
			cnx.Close();
			return result;
		}
		public int getExecuteQueryResult(string connString, string sql) {
			
			MySqlConnection cnx = getConnection(connString);
			cnx.Open();
			MySqlCommand command = new MySqlCommand(sql, cnx);
			
			System.Diagnostics.Debug.Print ("sql : "+sql);
			int retour = command.ExecuteNonQuery();
			cnx.Close();
			System.Diagnostics.Debug.Print(" nb affected : "+retour);
			return retour;
		}
		
		
		public string getDropSQL(string databaseName)
		{
			return ("  DROP DATABASE IF EXISTS "+databaseName+" ;CREATE DATABASE IF NOT EXISTS "+databaseName+"; "+" ");
		}
		
		public String getDatabaseList() {
			return ("SHOW DATABASES;");
		}
	}
}
