/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 10/06/2016
 * Heure: 13:42:23
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class MeoServeur
	{
		[XmlAttribute]
		public String nom;
		[XmlAttribute]
		public String adresse;
		[XmlAttribute]
		public String utilisateur;
		[XmlAttribute]
		public String password;
		
		[XmlAttribute]
		public Boolean test;
		
		[XmlAttribute]
		public Boolean boboche;
		
		[XmlAttribute]
		public String tunnel;

		[XmlAttribute]
		public String transpo;

		
		public MeoServeur() {
			// empty for serialisator
		}
		public MeoServeur(String nom, String adresse)
		{
			this.nom=nom;
			this.adresse=adresse;
		}
		public String getNom() {
			return nom;
		}
		public String getAdresse() {
			return adresse;
		}
		public string getUtilisateur()
		{
			return utilisateur;
		}
		public string getPassword()
		{
			return password;
		}
		public void setUtilisateur(String value) {
			utilisateur=value;
		}
		public void setPassword(String value) {
			password=value;
		}
		public void setBoboche(Boolean value) {
			boboche=value;
		}
		public Boolean getBoboche() {
			return boboche;
		}
		public void setTunnel(String value) {
			this.tunnel=value;
		}
		public String getTunnel() {
			return this.tunnel;
		}
		public void setTranspo(String value) {
			this.transpo=value;
		}
		public String getTranspo() {
			return this.transpo;
		}
		public static MeoServeur findServeurByName(List<MeoServeur> list, string serverName)
		{
			if(list!=null)  {
				foreach(MeoServeur server in list) {
					if(serverName==server.getNom()) {
						return server;
					}
				}
			}
			return null;
		}
	}
}
