/*
 * Utilisateur: Renaud
 * Date: 24/02/2017
 * Heure: 13:33:10
 * 
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Mime;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;
using cmdUtils.Objets;
using log4net;

namespace TestSQLOverSSH
{
	class TestSQLOverSSH
	{
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			log4net.ILog LOGGER =LogManager.GetLogger("TestSQLOverSSH");
			MouliUtil util=new MouliUtil(LOGGER);
			List <String> strs= util.findFiles("W:/meo-moulinettes/workspace/MID2317-SARLOPTIK95-i-4/",true, false, null, null);
			//strs.Clear();
			strs.Add("tralala.zip");
			strs.Add("tralala.7z");
			strs.Add("tralala.pouet");
				foreach(String str in strs) {
				FileInfo fileInfo = new FileInfo(str);
				String filterRegex="\\.(7z|rar|gz|gzip|zip)$";
				if( !Regex.IsMatch(fileInfo.Name,filterRegex,  RegexOptions.IgnoreCase)) {
					Console.WriteLine(fileInfo.FullName);
				}
				
			}
			return;
			/*
			TestSQLOverSSH testSQLOverSSH= new TestSQLOverSSH();
			testSQLOverSSH.test01();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
			*/
		}
		public void test01() {
			
			String sshserver="ssherver";
			String sshuser="sshUser";
			String sshpassword="secretpassword";
			String myuser="root";
			String mypassword="makemyday";
			String dbname="honeybox";
			int originalPort=3306;
			int forwardPort=13306;
			
			log4net.ILog LOGGER =LogManager.GetLogger("TestSQLOverSSH");
			
			SshUtil sshutil =new SshUtil();
			MeoServeur serveur =new MeoServeur();
			serveur.adresse=sshserver;
			serveur.utilisateur=sshuser;
			serveur.password=sshpassword;
			List<KeyValuePair<int, int>>portsList = new List<KeyValuePair<int, int>>();
			KeyValuePair<int, int> kvp =   new KeyValuePair<int, int>(originalPort, forwardPort);
			portsList.Add(kvp);
			
			var xclient= sshutil.getClientWithForwardedPorts(serveur, portsList, LOGGER);
			
			String sql="SELECT * FROM magasins limit 1;";
			using (MySqlConnection con = getConn("127.0.0.1", forwardPort, myuser, mypassword, dbname)) {
				using (MySqlCommand com = new MySqlCommand(sql, con)) {
					com.CommandType = CommandType.Text;
					DataSet ds = new DataSet();
					MySqlDataAdapter da = new MySqlDataAdapter(com);
					da.Fill(ds);
					foreach (DataRow drow in ds.Tables[0].Rows) {
						Console.WriteLine("From MySql: " + drow[1].ToString());
					}
				}
			}
			xclient.Disconnect();
			return;
			/*
			//work fine
			using (var client = new SshClient(sshserver, sshuser, sshpassword)) { // establishing ssh connection to server where MySql is hosted
				client.Connect();
				if (client.IsConnected) {
					var portForwarded = new ForwardedPortLocal("127.0.0.1", (uint) forwardPort, "127.0.0.1", (uint) originalPort);
					client.AddForwardedPort(portForwarded);
					portForwarded.Start();
					using (MySqlConnection con = getConn("127.0.0.1", forwardPort, myuser, mypassword, dbname)) {
						using (MySqlCommand com = new MySqlCommand(sql, con)) {
							com.CommandType = CommandType.Text;
							DataSet ds = new DataSet();
							MySqlDataAdapter da = new MySqlDataAdapter(com);
							da.Fill(ds);
							foreach (DataRow drow in ds.Tables[0].Rows) {
								Console.WriteLine("From MySql: " + drow[1].ToString());
							}
						}
					}
					client.Disconnect();
				} else {
					Console.WriteLine("Client cannot be reached...");
				}
			}
			*/
		}
		public MySqlConnection getConn(String serveur, int port, String user, String passw, String dbName) {
			MyUtil util = new MyUtil();
			return util.getConnection(util.buildconnString(dbName, serveur, user, passw, port));
		}
	}
}