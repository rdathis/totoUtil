/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 04/07/2016
 * Heure: 12:58:37
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;

using System.IO;
using MoulUtil.Forms.utils;
using Renci.SshNet;
using cmdUtils;
using cmdUtils.Objets;
using cmdUtils.Objets.utils;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace MoulUtil
{

	class MouliProgram
	{
		// disable once FieldCanBeMadeReadOnly.Local
		static log4net.ILog ILOG = LogManager.GetLogger("mouliUtil");

		private static void print(String s) {
			System.Diagnostics.Debug.Print(s);
		}

		public static void Main(string[] args)
		{
			String tmpBasePath=Directory.GetCurrentDirectory();
			if(tmpBasePath.ToLower().EndsWith("\\bin") && !Directory.Exists("conf") &&  Directory.Exists("..\\conf")) {
				
				Directory.SetCurrentDirectory("..");
				tmpBasePath=Directory.GetCurrentDirectory();
				Console.WriteLine("directory changed to "+Directory.GetCurrentDirectory());
			}
			//configure le ilog -- http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/
			BasicConfigurator.Configure();
			
			ConfigUtil configUtil = new ConfigUtil();
			ConfigDto configDto = configUtil.getConfig();
			configDto.basePath=tmpBasePath;
			
			Console.WriteLine("Moulinette util - ");
			Console.WriteLine(" Args ("+args.Length+")");
			for(int i=0;i<args.Length;i++) {
				Console.WriteLine(" arg["+i+"] = '"+args[i]+"'");
			}

			String sourceMoulinette="";
			if (args.Length> 0) {
				sourceMoulinette = args[0].Trim();
				if (((!sourceMoulinette.EndsWith("\\")) && (!sourceMoulinette.EndsWith("/")))) {
					sourceMoulinette+="/";
				}
			}
			MouliPrepaForm formPrepa = new MouliPrepaForm(configDto, ILOG);
			formPrepa.controleRegistre();
			formPrepa.setWorkspacePath(sourceMoulinette);
			formPrepa.setTargetSvgPath(configDto.getTargetSvgPath());
			formPrepa.ShowDialog();
			
			ILOG.Info("Debut moulinette - chemin '"+sourceMoulinette+"'");
		}
	}
}