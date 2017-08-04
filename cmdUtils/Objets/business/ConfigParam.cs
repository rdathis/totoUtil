/*
 * Utilisateur: Renaud
 * Date: 16/02/2017
 * Heure: 13:53:13
 * 
 */

using System;
using System.Xml.Serialization;
namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of Param
	/// </summary>
	public class ConfigParam {
		public enum ParamNamesType	{
			//[XmlEnum("moulinetteSource")] moulinetteSource,
			[XmlEnum("history")] history,
			
			[XmlEnum("targetSvgPath")] targetSvgPath,
			[XmlEnum("databaseAdminUser")] databaseAdminUser,
			[XmlEnum("databaseAdminPwd")] databaseAdminPwd,
			[XmlEnum("databaseAdminName")] databaseAdminName,
			[XmlEnum("defaultPassword")] defaultPassword,
			//[XmlEnum("appPlink")] appPlink,
			[XmlEnum("defaultEmail")] defaultEmail,
			[XmlEnum("workingDir")] workingDir,
			[XmlEnum("emails")] emails,
			//[XmlEnum("databasePath")] databasePath,
			//[XmlEnum("databaseTunneling")] databaseTunneling,
			//
			[XmlEnum("INCONNU")] INCONNU
		}
		
		public enum ParamTypesType {
			[XmlEnum("generic")] generic,
			[XmlEnum("chemin")] chemin,
			[XmlEnum("password")] password,
			[XmlEnum("url")] url
		}
		
		
		
		[XmlAttribute]
		public ParamNamesType nom { get; set ;}
		[XmlAttribute]
		public ParamTypesType type { get; set ;}
		[XmlText]
		public string Value { get; set; }
		
		[XmlAttribute]
		public Boolean boboche { get; set; }
		
		public ConfigParam() {
			//just for xml serialization 
		}
		public ConfigParam(ParamNamesType nom, ParamTypesType type, String value) {
			this.nom=nom;
			this.type=type;
			this.Value=value;
			this.boboche=false;
		}
	}
}