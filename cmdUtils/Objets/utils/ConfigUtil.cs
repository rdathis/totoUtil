/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 21/06/2016
 * Heure: 13:30:58
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace cmdUtils.Objets
{
	/// <summary>
	/// access to our config file.
	/// </summary>
	public class ConfigUtil
	{
		
		public ConfigUtil()
		{
		}
		
		public ConfigDto readConfigXml(String path="")
		{
			
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			
			FileStream fileStream = new FileStream(path+MouliConfig.commonConfigFile, FileMode.Open);
			ConfigDto dto = (ConfigDto)serializer.Deserialize(fileStream);
			fileStream.Close();
			return dto;
		}
		private void writeXml(ConfigDto dto)
		{
			FileStream fs;
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			fs = new FileStream(MouliConfig.commonConfigFile, FileMode.Create);//pas de openorcreate sinon crasse a la fin
			serializer.Serialize(fs, dto);
			fs.Close();
			
		}
		
		public String getConfigFilePath() {
			//rem:faux
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			String path = config.FilePath;
			path = path.Substring(0, path.Length - 19);
			path += ConfigSectionSettings.getFullConfigFileName();
			return path;
		}

		public void saveOldConfig()
		{
			String config=MouliConfig.commonConfigFile;
			//File file = FileInfo new File(config);
			FileInfo file =new FileInfo(config);
			DateTime date = DateTime.Now;
			long ts= date.Ticks;
			
			const String savePath="/save/";
			String newFileName = file.Directory+savePath +file.Name + "-"+ts+""+file.Extension;
			if(!Directory.Exists(file.Directory+savePath)) {
				Directory.CreateDirectory(file.Directory+savePath);
			}
			File.Copy(config, newFileName);
		}
		public String getLoggerConfigFilePath() {
			String str=""+MouliConfig.commonLoggingConfigFile;
			
			str = Directory.GetCurrentDirectory() + @"/"+MouliConfig.commonLoggingConfigFile;
			return (str);
		}
		public ConfigDto getConfig()
		{
			Console.WriteLine("config:" + getConfigFilePath());
			
			// testWriteXml(dto);
			ConfigDto dto = readConfigXml();
			
			return dto;
		}
		public void saveConfig(ConfigDto configDto) {
			Console.WriteLine("saving config:" + getConfigFilePath());
			writeXml(configDto);
		}

	}
}