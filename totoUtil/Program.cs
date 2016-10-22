/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/02/2015
 * Heure: 18:22:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace totoUtil
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
