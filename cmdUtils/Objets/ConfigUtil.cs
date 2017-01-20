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
using System.IO;
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
		
		private ConfigDto readConfigXml()
		{
			
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			FileStream fileStream = new FileStream(MouliConfig.commonConfigFile, FileMode.Open);
			ConfigDto dto = (ConfigDto)serializer.Deserialize(fileStream);
			fileStream.Close();
			return dto;
		}
		private void writeXml(ConfigDto dto)
		{
			FileStream fs;
			XmlSerializer serializer = new XmlSerializer(typeof(ConfigDto));
			fs = new FileStream(MouliConfig.commonConfigFile, FileMode.OpenOrCreate);
			serializer.Serialize(fs, dto);
			fs.Close();
			
		}
		public String getConfigFilePath()
		{
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
			String newFileName = file.Directory+"/"+file.Name + "-"+ts+""+file.Extension;
			
			File.Copy(config, newFileName);
		}

		/*
		private void open(String file)
		{
			fs = new FileStream(file, FileMode.Open);
		}
		private void close()
		{
			fs.Close();
			fs = null;
		}
		*/
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
		/*
		private String targetSvgPath(FileStream fs)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(String));
			return (String)serializer.Deserialize(fs);
		}

		// disable once ParameterHidesMember
		public List<MeoInstance>instances(FileStream fs)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<MeoInstance>));
			return  (List<MeoInstance>)serializer.Deserialize(fs);
		}
		public List<MeoInstance> readInstances()
		{
			open(MouliConfig.instancesConfigFile);
			//open("conf/common.xml");
			List<MeoInstance> liste = instances(fs);
			close();
			return liste;
		}
		public List<MeoServeur> readServeurs()
		{
			open(MouliConfig.serversConfigFile);
			//open("conf/common.xml");
			List <MeoServeur> liste = serveurs(fs);
			close();
			return liste;
		}
		// disable once ParameterHidesMember
		private  List<MeoServeur> serveurs(FileStream fs)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<MeoServeur>));
			return (List<MeoServeur>)serializer.Deserialize(fs);
		}
		*/
	}
}
