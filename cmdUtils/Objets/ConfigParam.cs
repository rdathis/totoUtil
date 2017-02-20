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
			[XmlEnum("moulinetteSource")]
			moulinetteSource,
			[XmlEnum("INCONNU")]
			INCONNU
		}
		public enum ParamTypesType {
			[XmlEnum("generic")]
			generic,
			[XmlEnum("chemin")]
			chemin
		}
		
		[XmlAttribute]
		public ParamNamesType nom { get; set ;}
		[XmlAttribute]
		public ParamTypesType type { get; set ;}
		[XmlText]
		public string Value { get; set; }
		public ConfigParam(ParamNamesType nom, ParamTypesType type, String value) {
			this.nom=nom;
			this.type=type;
			this.Value=value;
		}
	}
}