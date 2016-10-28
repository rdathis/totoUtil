/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 11/10/2016
 * Heure: 13:48:13
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */

namespace cmdUtils.Objets {
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Windows.Forms;
	using Renci.SshNet;
	using Renci.SshNet.Security;
	public class SshUtil {
		
		public SshUtil() {
			//empty
		}
		private ConnectionInfo getConnectionInfo(MeoServeur server) {
			ConnectionInfo  connectionInfo = new ConnectionInfo(
				server.getAdresse(), server.getUtilisateur(),
				new PasswordAuthenticationMethod(server.getUtilisateur(), server.getPassword()));
			return connectionInfo;
		}
		
		public void uploadArchive(MeoServeur server, string target, string archive)
		{
			ScpClient client = new ScpClient(getConnectionInfo(server));
			client.Connect();
			FileInfo info =new FileInfo(archive);
			client.Upload(info, target + info.Name);
			client.Disconnect();
		}
		public  List <String> unzipArchive(MeoServeur server, string target, MouliJob job)
		{
			List <String> liste =new List<string>();
			SshClient client = new SshClient(getConnectionInfo(server));
			client.Connect();
			String newdir=target + job.getMoulinettePath();
			
			//
			liste.Add(client.RunCommand("mkdir "+newdir).Result);
			
			FileInfo info =new FileInfo(job.getArchiveName());
			liste.Add(client.RunCommand("cd "+newdir +" && unzip -o "+target+info.Name).Result);
			//
			
			client.Disconnect();
			return liste;
		}
		
		public SshClient getClientWithForwardedPorts(MeoServeur serveur, List<KeyValuePair<int, int>>portsList )
		{
			ConnectionInfo  connectionInfo = getConnectionInfo(serveur);
			Console.Write(connectionInfo.CurrentServerEncryption);
			SshClient client = new SshClient(connectionInfo);
			client.Connect();
			
			//SshCommand commande= client.RunCommand("/bin/pwd");
			//print(commande.Result);
			// commande= client.RunCommand("cd /home ; pwd \n");
			// print(commande.Result);
			// commande= client.RunCommand("/bin/pwd");
			
			// print(commande.Result);
			
			foreach(KeyValuePair<int, int> forwardedPort  in portsList) {
				int local=forwardedPort.Key;
				int distant=forwardedPort.Value;
				ForwardedPort port = new ForwardedPortLocal((uint) distant, serveur.getNom(), (uint) local);
				client.AddForwardedPort(port);
			}
			
			
			return client;
		}
	}
}