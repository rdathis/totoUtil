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
	using Renci.SshNet;
	public class SshUtil {
		
		public SshUtil() {
			//empty
		}
		private ConnectionInfo getConnectionInfo(MeoServeur server) {
			ConnectionInfo  connectionInfo = new ConnectionInfo(
				server.getAdresse(), server.getNom(),
				new PasswordAuthenticationMethod(server.getNom(),server.getPassword()));
			return connectionInfo;
		}
		
		public void uploadArchive(MeoServeur server, string target, string archive)
		{
			ScpClient client = new ScpClient(getConnectionInfo(server));
			client.Connect();
			client.Upload(new FileInfo(archive), target + archive);
			client.Disconnect();
		}
		public  List <String> unzipArchive(MeoServeur server, string target, MouliJob job)
		{
			List <String> liste =new List<string>();
			SshClient client = new SshClient(getConnectionInfo(server));
			client.Connect();
			String newdir=target + job.getOriginalDir();
			
			//
			liste.Add(client.RunCommand("mkdir "+newdir).Result);
			
			liste.Add(client.RunCommand("cd "+newdir +" && unzip -o "+target+job.getArchiveName()).Result);
			//
			
			client.Disconnect();
			return liste;
		}
		
	}
}