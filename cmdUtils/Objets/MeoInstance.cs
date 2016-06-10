/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 10/06/2016
 * Heure: 13:41:29
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace cmdUtils
{
	/// <summary>
	/// Description of Instances.
	/// </summary>
	public class MeoInstance
	{
		public MeoInstance(MeoServeur serveur, String nom, String code, String meocli)
		{
			this.serveur=serveur;
			this.nom=nom;
			this.code=code;
			this.meocli=meocli;
		}
		private MeoServeur serveur;
		private String nom;
		private String code;
		private String meocli;
		private MeoServeur getServeur() {
			return serveur;
		}
		private String getNom() {
			return nom;
		}
		private String getCode() {
			return code;
		}
		private String getMeocli() {
			return meocli;
		}
	}
}
