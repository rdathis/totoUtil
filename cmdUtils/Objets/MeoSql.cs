/*
 * Utilisateur: Renaud
 * Date: 13/02/2017
 * Heure: 12:28:41
 * 
 */
using System;
using System.Xml;
using System.Xml.Serialization;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of MeoSql.
	/// </summary>
	public class MeoSql
	{
		[XmlAttribute]
		public String nom;
		[XmlText]
		public string Value { get; set; }

		
		
		public MeoSql() {
			// Console.WriteLine("");
		}
		public MeoSql(String nom, String value)		{
			Console.WriteLine("");
		}
	}
}
