/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 10/04/2015
 * Time: 08:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using totoUtil.Utils;
namespace totoUtil.Objets
{
	/// <summary>
	/// Description of HyUtil.
	/// </summary>
	public class HyUtil
	{
		public HyUtil()
		{
		}
		const String NONE = "NONE";
		private const String NONETIP = "/tip " + NONE;
		
		protected static Regex tipWithPlayer = new Regex(@"( Coins from )");
		protected static Regex tipWithoutPlayer = new Regex(@" Coins Boosters queued");
		protected static Regex tipSent = new Regex(@"You tipped");

		public Regex getTipWithPlayer() {
			return tipWithPlayer;
		}
		public Regex getTipSent() {
			return tipSent;
		}
		//TODO:change as a list<String>
		public List <String> grepMatchesAndTip(String sourcePath) {
			//todo:use FSW
			System.IO.FileSystemWatcher dog = new System.IO.FileSystemWatcher();
			Greper g = new Greper();
			
			List<Regex> liste =new List<Regex>();
			//liste.Add(tipWithPlayer);
			// liste.Add(tipWithoutPlayer);
			liste.Add(tipSent);
			
			//TODO:PARAM + textbox
			
			String userProfilePath = Environment.ExpandEnvironmentVariables("%userprofile%");
			
			sourcePath=sourcePath.Replace("\\", "/");
			userProfilePath = userProfilePath.Replace("\\", "/");
			sourcePath=sourcePath.Replace("%userprofile%", userProfilePath);
			GrepOptions options=new GrepOptions();
			options.setPrintFileName(false);
			options.setPrintLineNumber(false);
			List <String> strList = g.grepFile(sourcePath, liste, options);
			return strList;
		}
		public String parseTips(List <String> strList) {
			String retour="";
			var resultDico = new Dictionary<String, String>();
			
			
			foreach(String ligne in strList) {
				
				Match matchSuccess = tipWithPlayer.Match(ligne);
				Match matchNothing =  tipWithoutPlayer.Match(ligne); // Coins Boosters queueud");
				
				//LIGNE : 20:19:49] [Client thread/INFO]: [CHAT] Blitz Survival Games - Triple Coins from NickSaurus11, Igloo, ItsTimeGaming, Flummox_, Epicnoodles and 111 more
				
				String ligne2=ligne;
				int debI= ligne.IndexOf(":[");
				if(debI>0) {
					debI+=1;
					ligne2=ligne.Substring(debI);
				}
				String when = ligne2.Substring(1, 9);
				
				int toI = ligne2.LastIndexOf(@" from ");
				int gameI = ligne2.IndexOf(@"[CHAT] ");
				String game="";
				String to=NONE;
				if (toI > 0)  {
					to = ligne2.Substring(toI + 5).Trim();
					if (to.IndexOf(",") > 0) {
						to=to.Substring(0, to.IndexOf(","));
					}
				}
				if (gameI > 0) {
					game = ligne2.Substring(gameI + 6).Trim();
					if (game.IndexOf("-") > 0) {
						game=game.Substring(0, game.IndexOf("-")-1);
					}
				}
				
				
				
				if (matchSuccess.Success || matchNothing.Success) {
					if (matchSuccess.Success) {
					} else if (matchNothing.Success) {
						to=NONE;
					}
					
					String tipLine = " /tip "+to;
//					System.Diagnostics.Debug.Print(" game : "+game + tipLine+" /");
					if (resultDico.ContainsKey(game)) {
						resultDico[game] = tipLine;
					} else {
						resultDico.Add(game, tipLine);
					}
				}
			}

			
			
			
			//pre-uniq
			List <String> resultList = new List<String>();
			foreach(String s in resultDico.Values) {
				resultList.Add(s);
			}
			foreach(String tip in resultList.Distinct().ToList()) {
				if (!tip.Contains(NONETIP)) {
					retour+=tip + "\r\n";
				}
			}
			return retour;
		}
		
		
		
		public void updateTippedRtfBox(System.Windows.Forms.RichTextBox box, List<String> liste) {

			List<TypedPlayer> playerList = new List<TypedPlayer>();
			
			var dicoTipAction = new Dictionary<String, String>();
			System.Windows.Forms.BaseCollection coll = new System.Windows.Forms.BaseCollection();
			
			foreach (String ligne in liste) {
				
				//example : [17:56:43] [Client thread/INFO]: [CHAT] You sent a tip of 100 coins to [MVP+] pluto in DSKRoom
				Match match1 =getTipSent().Match(ligne);
				if (match1.Success) {
					String when = ligne.Substring(1, 9);
					int toI = ligne.LastIndexOf(@" to ");
					int gameI = ligne.LastIndexOf(@" in ");
					if ((toI > 0) && (gameI > 0)) {
						String to = ligne.Substring(toI + 4, (gameI - toI) - 3).Trim();
						String game = ligne.Substring(gameI + 3).Trim();
						playerList.Add(new TypedPlayer(to, when, game));
					}
				}
			}
			
			//build rtf for box
			MainUtils.buildTypedRichTBox(box, playerList);
			
		}
		public String updateCoins(List<String> list) {
			return "";
		}
		
		public void updateSearchTextBox(System.Windows.Forms.TextBox box, List<String> liste) {
			List<String> tmpListe = liste.GetRange(0, liste.Count);
			tmpListe.Reverse();
			box.Text="";
			StringBuilder strBuilder=new StringBuilder();
			foreach(String str in tmpListe) {
				strBuilder.Append(str+"\r\n");
			}
			box.Text=strBuilder.ToString();
		}
	}
}
