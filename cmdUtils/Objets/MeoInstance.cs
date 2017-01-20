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
		public MeoInstance(String serveurName, String nom, String code, String meocli, String meourl)
		{
			this.serveur=serveurName;
			this.nom=nom;
			this.code=code;
			this.meocli=meocli;
			this.meourl=meourl;
		}
		[XmlAttribute]
		public String serveur;
		[XmlAttribute]
		public String nom;
		[XmlAttribute]
		public String code;
		[XmlAttribute]
		public String meocli;
		[XmlAttribute]
		public String meourl;
		
		
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
		public String getMeourl() {
			return meourl;
		}
		
		public static MeoInstance findInstanceByInstanceName(List<MeoInstance> instances, string instanceName)
		{
			if(instances!=null) {
				foreach(MeoInstance instance in instances) {
					if (instanceName==instance.getNom() ) {
						return instance;
					}
				}
			}
			return null;
		}
		public static MeoInstance findInstanceByMeoURL(List<MeoInstance> instances, string meourl)
		{
			if(instances!=null) {
				foreach(MeoInstance instance in instances) {
					if (meourl==instance.getMeourl() ) {
						return instance;
					}
				}
			}
			return null;
		}
		
	}
}
