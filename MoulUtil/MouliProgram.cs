/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 04/07/2016
 * Heure: 12:58:37
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using cmdUtils.Objets;
using log4net;
using log4net.Config;
namespace MoulUtil
{
	class MouliProgram
	{
		// disable StringEndsWithIsCultureSpecific
		public static void Main(string[] args)
		{
			String tmpBasePath=Directory.GetCurrentDirectory();
			if(tmpBasePath.ToLower().EndsWith("\\bin") && !Directory.Exists("conf") &&  Directory.Exists("..\\conf")) {
				
				Directory.SetCurrentDirectory("..");
				tmpBasePath=Directory.GetCurrentDirectory();
				Console.WriteLine("directory changed to "+Directory.GetCurrentDirectory());
			}
			//configure le ilog -- http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/

			log4net.ILog LOGGER = LogManager.GetLogger("mouliProgram");
			ConfigUtil configUtil = new ConfigUtil(LOGGER);
			if(File.Exists(configUtil.getLoggerConfigFilePath())) {
				XmlConfigurator.Configure(new Uri(configUtil.getLoggerConfigFilePath()));
				LOGGER.Debug("config file : "+configUtil.getLoggerConfigFilePath());
			} else {
				Console.WriteLine("Erreur fichier log absent : "+configUtil.getLoggerConfigFilePath());
			}
			
			
			ConfigDto configDto = configUtil.getConfig();
			if(!configUtil.controleConfig(configDto) ) {
				LOGGER.Error("bad config file");
				throw new NotImplementedException ("unexpectable understood config file. read it, correct it");
			}
			configDto.basePath=tmpBasePath;
			
			LOGGER.Info("Moulinette util - ");
			LOGGER.Info(" Args ("+args.Length+")");
			for(int i=0;i<args.Length;i++) {
				LOGGER.Info(" arg["+i+"] = '"+args[i]+"'");
			}

			String sourceMoulinette="";
			if (args.Length> 0) {
				sourceMoulinette = args[0].Trim();

				if (((!sourceMoulinette.EndsWith(@"\\")) && (!sourceMoulinette.EndsWith("/")))) {
					sourceMoulinette+="/";
				}
			}
			
			LOGGER.Debug("opening prepa form ");
			MouliPrepaForm formPrepa = new MouliPrepaForm(configDto, LOGGER);
			formPrepa.controleRegistre();
			formPrepa.setWorkspacePath(sourceMoulinette);
			formPrepa.setTargetSvgPath(configDto.getTargetSvgPath());
			formPrepa.ShowDialog();
		}
	}
}