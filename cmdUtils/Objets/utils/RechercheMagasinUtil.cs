/*
 * Utilisateur: Renaud
 * Date: 23/02/2017
 * Heure: 13:52:00
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using Renci.SshNet;
using MoulUtil.Forms.utils;
using cmdUtils.Objets;

namespace cmdUtils {
	

	public class RechercheMagasinUtil {
		//const String mouliUtilConfigPath="w:/meo-moulinettes/";
		const String dbName="administration";
		private ConfigUtil configUtil = new ConfigUtil();
		private ConfigDto configDto=null;
		private log4net.ILog LOGGER;
		
		public RechercheMagasinUtil (log4net.ILog LOGGER) {
			this.LOGGER=LOGGER;
		}
		public SshClient doConnection(MeoServeur serveur, int localPort, int forwardPort, MouliProgressWorker worker) {
			List<KeyValuePair<int, int>>portsList = new List<KeyValuePair<int, int>>();
			
			portsList.Add(new KeyValuePair<int, int>(localPort, forwardPort));
			SshUtil sshUtil =new SshUtil();
			SshClient sshClient = sshUtil.getClientWithForwardedPorts(serveur, portsList, LOGGER);
			if(worker!=null) {
				worker.ReportProgress(1, 1);
				
			}
			return sshClient;
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
		
				
			configDto= configUtil.readConfigXml("." );
			configDto.setProgramPath(Directory.GetCurrentDirectory());
			return configDto;
		}
		public String  getAdminServeur(ref SshClient client, int hiddenPort, int visiblePort) {
			
			configDto=getConfig();
			//String retour=null;
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
				client = getAdminServeur(adminServeur, hiddenPort, visiblePort, LOGGER);
				if(client==null) {
					return "ssh connection failed";
				}
			}
			return "";
		}
		public String getMagasinDescription(String magId, ref SshClient client, int hiddenPort, int visiblePort, Boolean disconnectAfter=true) {
			String retour="";
			if(client==null) {
				retour=getAdminServeur(ref client, hiddenPort, visiblePort);
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

			string cstr = util.buildconnString(dbName, "127.0.0.1", user, pwd, visiblePort);
			
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
		private static SshClient getAdminServeur(MeoServeur serveur, int hiddenPort, int visiblePort, log4net.ILog LOGGER) {
			
			SshUtil sshUtil = new SshUtil();
			List<KeyValuePair<int, int>>portsList = new List<KeyValuePair<int, int>>();
			portsList.Add(new KeyValuePair<int, int>(hiddenPort, visiblePort));
			return sshUtil.getClientWithForwardedPorts(serveur, portsList, LOGGER);
		}
	}
}