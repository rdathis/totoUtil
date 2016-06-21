/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 21/06/2016
 * Heure: 13:30:58
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Configuration;

namespace cmdUtils.Objets
{
	/// <summary>
	/// access to our concig file.
	/// </summary>
	public class ConfigUtil
	{
		public ConfigUtil()
		{
		}
		public String getConfigFilePath() {
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			String path=config.FilePath;
			path=path.Substring(0, path.Length - 19);
			path+= ConfigSectionSettings.getFullConfigFileName();
			return path;
		}
	}
}
