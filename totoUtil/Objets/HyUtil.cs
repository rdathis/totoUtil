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
using System.Text.RegularExpressions;
using System.Linq;
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
		public String grepAndTip(String sourcePath) {

			String retour="";
			System.IO.FileSystemWatcher dog = new System.IO.FileSystemWatcher();
			Greper g = new Greper();
			
			List<Regex> liste =new List<Regex>();
			liste.Add (new Regex("You send a tip of"));
			liste.Add (new Regex("Coins"));
			
			//TODO:PARAM + textbox
			
			String userProfilePath = Environment.ExpandEnvironmentVariables("%userprofile%");
			
			sourcePath=sourcePath.Replace("\\", "/");
			userProfilePath = userProfilePath.Replace("\\", "/");
			sourcePath=sourcePath.Replace("%userprofile%", userProfilePath);
			List <String> strList = g.grepFile(sourcePath, liste);
			var resultDico = new Dictionary<String, String>();
			foreach(String ligne in strList) {
				//System.Diagnostics.Debug.Print("<ligne> :"+str);
				
				Match match = Regex.Match(ligne, @"( Coins from |Coins Boosters queued)");
				
				Match matchSuccess = Regex.Match(ligne, @"( Coins from )");
				Match matchNothing = Regex.Match(ligne, @"(Coins Boosters queueud)");
				
				//LIGNE : 20:19:49] [Client thread/INFO]: [CHAT] Blitz Survival Games - Triple Coins from NickSaurus11, Igloo, ItsTimeGaming, Flummox_, Epicnoodles and 111 more
				
				String ligne2=ligne;
				int debI= ligne.IndexOf(":[");
				if(debI>0) {
					debI+=1;
					ligne2=ligne.Substring(debI);
				}
				String when = ligne2.Substring(1, 9);
				System.Diagnostics.Debug.Print(" LIGNE : "+ligne2);
				
				int toI = ligne2.LastIndexOf(@" from ");
				int gameI = ligne2.IndexOf(@"[CHAT] ");
				String game="";
				String to=NONE;
				if ((toI > 0) && (gameI > 0)) {
					
					game = ligne2.Substring(gameI + 6).Trim();
					if (game.IndexOf("-") > 0) {
						game=game.Substring(0, game.IndexOf("-")-1);
					}
					to = ligne2.Substring(toI + 5).Trim();
					if (to.IndexOf(",") > 0) {
						to=to.Substring(0, to.IndexOf(","));
					}
//					System.Diagnostics.Debug.Print("DBG:"+when+"/"+to+" - "+game);
				}
				
				
				if (matchSuccess.Success) {
					
					
				} else if (matchNothing.Success) {
					to=NONE;
				}
				
				String tipLine = " /tip "+to;
				if (resultDico.ContainsKey(game)) {
					resultDico[game] = tipLine;
				} else {
					resultDico.Add(game, tipLine);
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
		
		
		
		public void updateTippedRtfBox(System.Windows.Forms.RichTextBox box) {
			//TODO
		}
	}

}
