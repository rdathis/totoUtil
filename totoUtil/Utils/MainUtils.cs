/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 02/04/2015
 * Heure: 17:18:58
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using  System.Drawing;
using  System.IO;
namespace totoUtil.Utils
{
	/// <summary>
	/// Description of MainUtils.
	/// </summary>
	public static class MainUtils
	{
//		public MainUtils()
//		{
//		}
		
		public static void buildTypedRichTBox(RichTextBox box, List<TypedPlayer> liste, int limite=10, bool showRecap=true) {
			box.Clear();
			Color colorDebut=Color.Gray;
			
			List <TypedPlayer> finalList ;
			if ((limite>0) && (liste.Count>limite)) {
				finalList= liste.GetRange(liste.Count -limite, limite);
			} else {
				finalList=liste;
			}
			for(int idx =0;idx<finalList.Count;idx++) {
				TypedPlayer player = finalList[idx];
				colorit(box, "["+player.getWhen() +" to ", colorDebut);
				colorit(box, player.getPlayer(), Color.Red);
				colorit(box, " - "+player.getGame()+"\r\n", Color.IndianRed);
			}
			if (showRecap) {
				box.AppendText(" je viens de faire, il est " + DateTime.Today.ToShortDateString() + "-"+DateTime.Now.ToShortTimeString()+" limite = "+limite + " / "+liste.Count);
			}
		}
		
		public static void colorit(RichTextBox rtb, String str, Color color) {
			int lg=rtb.Text.Length;
			rtb.AppendText(str);
			rtb.Select(lg, str.Length);
			rtb.SelectionColor =color;
		}
		
		
		
		public static String readFux(String fileName) {
			StreamReader sr = new  StreamReader(fileName) ;
			String flux = sr.ReadToEnd();
			sr.Close();
			return flux;
		}
		
		public static List<String> getFiles(string searchPath, String searchFilter) {
			String realPath = System.IO.Path.GetDirectoryName(searchPath);
			String joker = System.IO.Path.GetFileName(searchPath);
			DirectoryInfo info = new DirectoryInfo(realPath);

			List<String> list = new List<String>();
			if (info.Exists) {
				foreach(var f in info.GetFiles(joker)){
					list.Add(f.FullName);
				}
			}
			return list;
		}
	}
}
