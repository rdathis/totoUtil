/*
 * Utilisateur: Renaud
 * Date: 22/05/2017
 * Heure: 13:48:00
 * 
*/
using System;
using System.Windows.Forms;

namespace testBW
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
