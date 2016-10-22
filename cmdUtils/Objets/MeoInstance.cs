/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 10/06/2016
 * Heure: 13:41:29
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of Instances.
	/// </summary>
	public class MeoInstance
	{
		public MeoInstance() {
			
		}
		public MeoInstance(String serveurName, String nom, String code, String meocli)
		{
			this.serveur=serveurName;
			this.nom=nom;
			this.code=code;
			this.meocli=meocli;
		}
		[XmlAttribute]
		public String serveur;
		[XmlAttribute]
		public String nom;
		[XmlAttribute]
		public String code;
		[XmlAttribute]
		public String meocli;
		
		
		public String getServeur() {
			return serveur;
		}
		public String getNom() {
			return nom;
		}
		public String getCode() {
			return code;
		}
		public String getMeocli() {
			return meocli;
		}

		public static MeoInstance findInstanceByServerName(List<MeoInstance> instances, string serverName)
		{
			if(instances!=null) {
				foreach(MeoInstance instance in instances) {
					if (serverName==instance.getServeur() ) {
						return instance;
					}
				}
			}
			return null;
		}
	}
}
