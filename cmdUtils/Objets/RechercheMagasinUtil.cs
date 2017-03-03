/*
 * Utilisateur: Renaud
 * Date: 23/02/2017
 * Heure: 13:52:00
 * 
 */
using System;
using System.Collections.Generic;
using Renci.SshNet;
using cmdUtils.Objets;

namespace cmdUtils {

	public class RechercheMagasinUtil {
		const String mouliUtilConfigPath="w:/meo-moulinettes/";
		const String dbName="administration";
		private ConfigUtil configUtil = new ConfigUtil();
		private ConfigDto configDto=null;
		
		private SshClient doConnection(MeoServeur serveur, int localPort, int forwardPort) {
			List<KeyValuePair<int, int>>portsList = new List<KeyValuePair<int, int>>();
			
			portsList.Add(new KeyValuePair<int, int>(localPort, forwardPort));
			SshUtil sshUtil =new SshUtil();
			return sshUtil.getClientWithForwardedPorts(serveur, portsList);
			/*
			SshClient client=null;
			PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(serverAddress, login, password);
			connectionInfo.Timeout = TimeSpan.FromSeconds(30);
			client = new SshClient( connectionInfo);
			client.Connect();
			ForwardedPortLocal portFwld = new ForwardedPortLocal ("127.0.0.1", Convert.ToUInt32(localPort), "127.0.0.1", Convert.ToUInt32(forwardPort));
			client.AddForwardedPort(portFwld);
			portFwld.Start();
			 */
		}
		private ConfigDto getConfig() {
			
			configDto= configUtil.readConfigXml(mouliUtilConfigPath );
			return configDto;
		}
		public String  getAdminServeur(ref SshClient client, int newPort) {
			
			configDto=getConfig();
			String retour=null;
			if(getConfig()==null) {
				return "config nulle";
			}
			if(client == null ) {
				MeoInstance adminInstance = MeoInstance.findInstanceByInstanceName(configDto.getInstances(), dbName);
				if (adminInstance==null) {
					return "instance non trouvee";
				}
				MeoServeur adminServeur = MeoServeur.findServeurByName(configDto.getServeurs(), adminInstance.getServeur());
				if(adminServeur == null) {
					return ("server is null");
				}
				//SshClient client = doConnection(adminServeur, newPort, 3306);
				client = getAdminServeur(adminServeur);
				if(client==null) {
					return "ssh connection failed";
				}
			}
			return "";
		}
		public String getMagasinDescription(String magId, ref SshClient client, int newPort = 23306, Boolean disconnectAfter=true) {
			String retour="";
			if(client==null) {
				retour=getAdminServeur(ref client, newPort);
				if(retour.Length>0) {
					return retour;
				}
			}
			
			configDto = getConfig();
			//here : openssh conn with sss
			// sortir le tout dans une classe X  util =  new X("administration"), 12345;
			
			string sql = "select * from administration.magasins where magasin_id=" + magId;
			MyUtil util = new MyUtil();

			String user=configDto.getDatabaseAdminUser();
			String pwd = configDto.getDatabaseAdminPwd();

			string cstr = util.buildconnString(dbName, "127.0.0.1", user, pwd, newPort);
			
			System.Diagnostics.Debug.Print ("cst : "+cstr);
			
			var magasinList = util.getListResultAsKeyValue(cstr, sql);
			
			retour+=("#libe:" + util.getItem(magasinList[0], "magasin_libelle") + " - url :" + util.getItem(magasinList[0], "url"));
			retour+=("\n#cli_id:" + util.getItem(magasinList[0], "client_id"));
			//Console.WriteLine("libe:"+util.getItem(magasinList[0], "magasin_libelle"));
			//Console.WriteLine("cli_id:"+util.getItem(magasinList[0], "client_id"));
			
			sql = "SELECT utilisateur_id,magasin_id FROM administration.utilisateurs where utilisateur_active=true AND magasin_id=" + magId + ";";
			var userList = util.getListResultAsKeyValue(cstr, sql);
			
			retour+=("\nmodeDevMagId=" + util.getItem(userList[0], "magasin_id"));
			retour+=("\nmodeDevUserId=" + util.getItem(userList[0], "utilisateur_id"));
			
			sql = "SELECT group_concat(distinct options.option_module) as OLIST FROM administration.magasins_options ";
			sql+= " inner join administration.options on options.option_id=magasins_options.option_id ";
			sql+=" WHERE magasin_id="+magId+" and options.option_module is not null ;";
			var optionsList = util.getListResultAsKeyValue(cstr, sql);
			
			retour+=("\nmodeDevModuleList=" + util.getItem(optionsList[0], "OLIST"));
			
			if(disconnectAfter==true) {
				if((client !=null)  && (client.IsConnected)) {
					client.Disconnect();
				}
				client=null;
			}
			return retour;
		}
		
		//tmp stuff, to clear
		private static SshClient getAdminServeur(MeoServeur serveur) {
			
			SshUtil sshUtil = new SshUtil();
			List<KeyValuePair<int, int>>portsList = new List<KeyValuePair<int, int>>();
			portsList.Add(new KeyValuePair<int, int>(3306, 23306));
			return sshUtil.getClientWithForwardedPorts(serveur, portsList);
		}
	}
}