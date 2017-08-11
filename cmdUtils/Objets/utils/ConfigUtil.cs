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
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using log4net;
using cmdUtils.Objets.business;

namespace cmdUtils.Objets
{
	/// <summary>
	/// access to our config file.
	/// </summary>
	public class ConfigUtil
	{
		private readonly log4net.ILog  LOGGER;
		
		public ConfigUtil()
		{
		}

		public ConfigUtil(log4net.ILog  LOGGER)
		{
			this.LOGGER=LOGGER;
		}
		public ConfigDto readConfigXml(String path="")
		{
			
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			
			FileStream fileStream = new FileStream(path+MouliConfig.commonConfigFile, FileMode.Open);
			ConfigDto dto = (ConfigDto)serializer.Deserialize(fileStream);
			fileStream.Close();
			//
			dto.setProgramPath(Directory.GetCurrentDirectory());
			//
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

		public bool controleConfig(ConfigDto configDto)
		{
			if(configDto==null) {
				LOGGER.Error("null config");
				return false;
			}
			
			if(configDto.configParams==null) {
				LOGGER.Error("null params");
				return false;
			}
			if(configDto.getServeurs()==null || configDto.getServeurs().Count <1 ) {
				LOGGER.Error("null servers");
				return false;
			}
			if(configDto.getInstances()==null || configDto.getInstances().Count <1 ) {
				LOGGER.Error("null instances");
				return false;
			}
			if(configDto.getSqlCommands()==null || configDto.getSqlCommands().Count <1 ) {
				LOGGER.Error("null commands");
				return false;
			}
			foreach(ConfigParam.ParamNamesType type in Enum.GetValues(typeof(ConfigParam.ParamNamesType))) {
				if(ConfigParam.ParamNamesType.INCONNU!=type && configDto.getConfigParamByName(type)==null) {
					LOGGER.Error("null param  "+type.ToString());
					//return false;
				}
			}
			foreach(SqlCommandsType type in Enum.GetValues(typeof(SqlCommandsType))) {
				if(configDto.getSqlCommand(type)==null) {
					LOGGER.Error("null sqlCommand  "+type.ToString());
					//return false;
				}
			}
			return true;
		}
	}
}