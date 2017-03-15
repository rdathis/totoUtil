/*
 * Utilisateur: Renaud
 * Date: 03/14/2017
 * Heure: 13:29
 * 
*/
using System;
using System.Windows.Forms;

namespace EcUtil
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
	}
}
