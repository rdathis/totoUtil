/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 04/07/2016
 * Heure: 12:58:37
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Renci.SshNet.Messages;
using cmdUtils.Objets;
using log4net;
using log4net.Config;
namespace MoulUtil
{
	class MouliProgram
	{
		// disable StringEndsWithIsCultureSpecific
		[STAThread] //critical : sinon impossible d'utiliser le webbrowser
		public static void Main(string[] args)
		{
			//configure le ilog -- http://lutecefalco.developpez.com/tutoriels/dotnet/log4net/introduction/

			String versionInfo = null;
			String assemblyFullName="";
			DateTime buildDateTime = DateTime.Now;
			{
				Assembly assem = Assembly.GetExecutingAssembly();
				AssemblyName assemName = assem.GetName();
				assemblyFullName=assem.FullName();
				Version version = assemName.Version;
				//Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString());
				versionInfo = string.Format("{0}, Version {1}", assemName.Name, version.ToString());
				buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
					TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
					TimeSpan.TicksPerSecond * 2 * version.Revision)); // seconds since midnight, (multiply by 2 to get original)
				versionInfo += " du " + buildDateTime.ToString();
			}
			log4net.ILog LOGGER = LogManager.GetLogger("mouliProgram");
			ConfigUtil configUtil = new ConfigUtil(LOGGER);
			
			if (configUtil.isExistsLoggerConfigFile()) {
				XmlConfigurator.Configure(new Uri(configUtil.getLoggerConfigFilePath()));
				LOGGER.Debug("config file : " + configUtil.getLoggerConfigFilePath());
			} else {
				Console.WriteLine("Erreur fichier log absent : " + configUtil.getLoggerConfigFilePath());
			}
			
			
			String tmpBasePath = Directory.GetCurrentDirectory();
			if (tmpBasePath.ToLower().EndsWith("\\bin") && !Directory.Exists("conf") && Directory.Exists("..\\conf")) {
				Directory.SetCurrentDirectory("..");
				tmpBasePath = Directory.GetCurrentDirectory();
				Console.WriteLine("directory changed to " + Directory.GetCurrentDirectory());
			}
			
			if (!configUtil.isExistsPersoConfigFile() && configUtil.isExistsConfigFile()) {
				Boolean moveConfigFile = true;
				if (Debugger.IsAttached) {
					moveConfigFile = false;
				}
				
				if (moveConfigFile) {
					MessageBox.Show("Copie de :\n . " + configUtil.getConfigFilePath() + " -> \n . " + configUtil.getPersoConfigFilePath() );
					try {
						File.Move(configUtil.getConfigFilePath(), configUtil.getPersoConfigFilePath());
					} catch (Exception exc) {
						LOGGER.Error(exc.Message);
					}
				}
			}
			
			
			ConfigDto configDto = configUtil.getConfig();
			if (!configUtil.controleConfig(configDto)) {
				LOGGER.Error("bad config file");
				throw new NotImplementedException("unexpectable understood config file. read it, correct it");
			}
			if (!string.IsNullOrEmpty(configDto.basePath)) {
				if (Directory.Exists(configDto.basePath)) {
					DirectoryInfo di = new DirectoryInfo(configDto.basePath);
					Directory.SetCurrentDirectory(configDto.basePath);
					tmpBasePath = di.FullName; // configDto.basePath;
				}
			}
			
			configDto.basePath = tmpBasePath;
			configDto.assemblyName=assemblyFullName;
			configDto.buildDateTime=buildDateTime;
			configDto.versionInfo=versionInfo;
			
			LOGGER.Info("Moulinette util - ");
			LOGGER.Info(" Args (" + args.Length + ")");
			for (int i = 0; i < args.Length; i++) {
				LOGGER.Info(" arg[" + i + "] = '" + args[i] + "'");
			}

			String sourceMoulinette = "";
			if (args.Length > 0) {
				sourceMoulinette = args[0].Trim();

				if (((!sourceMoulinette.EndsWith(@"\\")) && (!sourceMoulinette.EndsWith("/")))) {
					sourceMoulinette += "/";
				}
			}
			
			LOGGER.Debug("opening prepa form ");
			MouliPrepaForm formPrepa = new MouliPrepaForm(configDto, LOGGER, versionInfo);
			formPrepa.controleRegistre();
			formPrepa.setWorkspacePath(sourceMoulinette);
			formPrepa.setTargetSvgPath(configDto.getTargetSvgPath());
			formPrepa.ShowDialog();
		}
	}
}