/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 10/06/2016
 * Heure: 13:42:23
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace cmdUtils
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class MeoServeur
	{
		private readonly String nom;
		public MeoServeur(String nom)
		{
			this.nom=nom;
		}
		public String getNom() {
			return nom;
		}
	}
}
