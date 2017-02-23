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
		
		private void IconDoubleClick(object sender, EventArgs e)
		{
			//MessageBox.Show("The icon was double clicked");
			doConnection();
		}
		#endregion
		

		private void doConnection() {
			truc2();
			return;

		}
		
		private void truc2() {
			String serverAdress="server";
			String hostName="user";
			String Password="password";
			String databaseadres="127.0.0.1";
			PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(serverAdress, hostName, Password);
			connectionInfo.Timeout = TimeSpan.FromSeconds(30);
			client = new SshClient( connectionInfo);
			client.Connect();
			ForwardedPortLocal portFwld = new ForwardedPortLocal ("127.0.0.1", Convert.ToUInt32(13306), databaseadres, Convert.ToUInt32(3306));
			client.AddForwardedPort(portFwld);
			portFwld.Start();
			//String connectionstring = "Server = 127.0.0.1; Database = " + Database + "; Password = " + Password + "; UID = " + Username + "; Port = " + localport.ToString() + ";";

			// Where localport = 22 and hostport = 3306
			
		}
	}
}
