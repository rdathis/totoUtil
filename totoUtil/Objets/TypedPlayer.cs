/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 02/04/2015
 * Heure: 16:33:18
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace totoUtil
{
	/// <summary>
	/// Description of TypedPlayer.
	/// </summary>
	public class TypedPlayer
	{
		private String player="";
		private String when="";
		private String game="";
		
		public TypedPlayer(String player, String when, String game)
		{
			this.player=player;
			this.when=when;
			this.game=game;
		}
		public String getPlayer() {
			return player;
		}
		
		public String getWhen() {
			return when;
		}
		
		public String getGame() {
			return game;
		}
		
	}
}
