/*
 * Utilisateur: Renaud
 * Date: 02/11/2016
 * Heure: 17:18:09
 * 
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Renci.SshNet;


namespace TestSSH
{
	public sealed class NotificationIcon
	{
		private NotifyIcon notifyIcon;
		private ContextMenu notificationMenu;
		private SshClient client=null;
		
		#region Initialize icon and menu
		public NotificationIcon()
		{
			notifyIcon = new NotifyIcon();
			notificationMenu = new ContextMenu(InitializeMenu());
			
			notifyIcon.DoubleClick += IconDoubleClick;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationIcon));
			notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
			notifyIcon.ContextMenu = notificationMenu;
		}
		
		private MenuItem[] InitializeMenu()
		{
			MenuItem[] menu = new MenuItem[] {
				new MenuItem("About", menuAboutClick),
				new MenuItem("Exit", menuExitClick)
			};
			return menu;
		}
		#endregion
		
		#region Main - Program entry point
		/// <summary>Program entry point.</summary>
		/// <param name="args">Command Line Arguments</param>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			bool isFirstInstance;
			// Please use a unique name for the mutex to prevent conflicts with other programs
			using (Mutex mtx = new Mutex(true, "TestSSH", out isFirstInstance)) {
				if (isFirstInstance) {
					NotificationIcon notificationIcon = new NotificationIcon();
					notificationIcon.notifyIcon.Visible = true;
					Application.Run();
					notificationIcon.notifyIcon.Dispose();
				} else {
				}
			} // releases the Mutex
		}
		#endregion
		
		#region Event Handlers
		private void menuAboutClick(object sender, EventArgs e)
		{
			MessageBox.Show("About This Application");
		}
		
		private void menuExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		private void truc2() {
			
			//ssh
			String serverAdress="serveur";
			String hostName="login";
			String Password="password";
			String databaseadres="127.0.0.1";
			//db
			String dbdatabase="dbname";
			String dbpassword="dbpassword";
			String dbusername="dblogin";
			//
			
			
			int localport=3615;
			
			PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(serverAdress, hostName, Password);
			connectionInfo.Timeout = TimeSpan.FromSeconds(30);
			client = new SshClient( connectionInfo);
			client.Connect();
			ForwardedPortLocal portFwld = new ForwardedPortLocal ("127.0.0.1", Convert.ToUInt32(localport), databaseadres, Convert.ToUInt32(3306));
			client.AddForwardedPort(portFwld);
			Debug.Print("starting client");
			portFwld.Start();
			
			String connectionString = "Server = 127.0.0.1; Database = " + dbdatabase + "; Password = " + dbpassword + "; UID = " + dbusername + "; Port = " + localport.ToString() + ";";

			Debug.Print("starting db");
			MySqlConnection cnx = new MySqlConnection();
			cnx.ConnectionString = connectionString;
			cnx.Open();
			String sql = "select (3*5) AS FIFTEEN ; ";
			Debug.Print("starting sql :"+sql);
			
			MySqlCommand command = new MySqlCommand(sql, cnx);


			MySqlDataReader data = command.ExecuteReader();
			while(data.Read()) {
				
				//result.Add(convertit(data, fieldIndex));

				Debug.Print("data:("+data.GetFieldType(0)+")" + data.GetValue(0) +" "+ data.FieldCount);
			}
			cnx.Close();
			
			Debug.Print("disco client");
			client.Disconnect();
			Console.WriteLine("finish");
			
			// Where localport = 22 and hostport = 3306
			
		}
		private void IconDoubleClick(object sender, EventArgs e)
		{
			//MessageBox.Show("The icon was double clicked");
			doConnection();
		}
		

		#endregion
		
		private void doConnection() {
			try {
				truc2();
			} catch(Exception ex) {
				Console.WriteLine("Erreur surveneu : "+ex.Message);
			}
			if(client!=null && client.IsConnected) {
				client.Disconnect();
			}
			return;

		}
	}
}
