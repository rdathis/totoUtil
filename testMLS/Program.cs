/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 02/10/2015
 * Heure: 17:50:35
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
 
namespace testMLS
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Starting My EasyLocalService ...");
			
			string path = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
			try {
				easyCmd(@path+"\\MyEasyLocalService.bat", null, ProcessWindowStyle.Hidden);
			} catch (Exception e) {
				Console.Write(e.Message);
				Console.ReadKey(true);
			}
			Console.WriteLine("on quitte");
			Environment.Exit(0);
			return;
		}
		private static void easyCmd(String cmd, String args, ProcessWindowStyle windowStyle) {
			var info = new ProcessStartInfo();
			info.FileName = cmd;
			info.Arguments = args;
			//Process.Start(info);
			
			String us = Environment.ExpandEnvironmentVariables("%userprofile%");
			us = us.Replace("\\", "/");
			info.Arguments = info.Arguments.Replace("%userprofile%", us);
			
			info.RedirectStandardError = true;
			info.RedirectStandardOutput = true;
			info.UseShellExecute = false;
			
			var p = new Process();
			p.StartInfo.WindowStyle = windowStyle;
			p.StartInfo = info;
			

			//Execution
			Console.WriteLine("lance le process");
			p.Start();
			Console.WriteLine("process lance ..");
			return;
		//	return p;
		}
	}
}