/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/02/2015
 * Heure: 18:22:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using totoUtil.Objets;
using totoUtil.Utils;
using System.Linq;

namespace totoUtil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		HyUtil hyUtil = new HyUtil();

		//TimerExample timer = null;
		public MainForm()
		{
			InitializeComponent();
			
			
			init();
			System.Threading.TimerCallback callback = goCheck;
			
			//System.Threading.Timer timm = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
			
			
		}
		void init()
		{
			pathTextBox.Text = "m:/cygwin64/bin/grep.exe";
			
			pathTextBox.Text = "grep.exe";
			if (!System.IO.File.Exists(pathTextBox.Text)) {
				pathTextBox.Text = "m:/cygwin64/bin/grep.exe";
			}
			pathTextBox.Text = "m:/cygwin64/bin/grep.exe";
			
			//<<<<<<< HEAD
//			argTextBox.Text = "-Fi --color=always coins %userprofile%/AppData/Roaming/.minecraft/logs/*log";
//			argTextBox.Text = "-Fh -e \" Coins from \" -e \"tip \" %userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
			//=======
			pathTextBox.Text = "grep.exe";
			argTextBox.Text = "-Fi --color=always coins %userprofile%/AppData/Roaming/.minecraft/logs/*log";
			argTextBox.Text = "-Fh -e \" Coins from \" -e \"tip \" %userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
			
			argTextBox.Text = "-Fh -w -e Coins -e \"You sent a tip of\" %userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
			
			//>>>>>>> d32a18bb6aad370f5551c6c92daf26bf37ca2b6f
			
			argTextBox.Text = "-Fh -w -e Coins -e \"You sent a tip of\" %userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
		}
		void BtnClick(object sender, EventArgs e)
		{
			goCheck(sender);
		}
		void goCheck(object sender)
		{
//			pathTextBox.Text = "m:/cygwin64/bin/grep.exe";

			var info = new ProcessStartInfo();
			info.FileName = pathTextBox.Text;
			info.Arguments = argTextBox.Text;
			//Process.Start(info);
			
			String us = Environment.ExpandEnvironmentVariables("%userprofile%");
			us = us.Replace("\\", "/");
			info.Arguments = info.Arguments.Replace("%userprofile%", us);
			
			info.RedirectStandardError = true;
			info.RedirectStandardOutput = true;
			info.UseShellExecute = false;
			
			var p = new Process();
			p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			p.StartInfo = info;
			

			//Execution
			p.Start();
			
			//recup. des flux
			String s1 = p.StandardOutput.ReadToEnd();
			String s2 = p.StandardError.ReadToEnd();
			if ((s2 != null) && (s2.Length > 0)) {
				MessageBox.Show("Error grep : " + s2);
			}
			
			//presentation du resultat brut sur le 1er bloc.
			//infoTxtBox.Text = s1;
			string[] lines = Regex.Split(s1, "\n");
			String newString = "";
			foreach (String ligne in lines) {
				newString += ligne + "\r\n";
			}
			infoTextBox.Text = newString;
			
			//appel du moteur de calcul pour les vrais traitements
			doTip(s1);
		}
		

		void doTip(String s)
		{
			string[] lines = Regex.Split(s, "\n");
			String retour = "";
			String reelTipCalcul = "";
			tippedRichTextBox.Clear();
			String emptyRtf=tippedRichTextBox.Rtf;
			tippedRichTextBox.Location=tippedTextBox.Location;
			tippedRichTextBox.Size= tippedTextBox.Size;
			tippedTextBox.Visible=false;
			tippedTextBox.Text = "";
			const String NONE = "NONE";
			
			List<String> rtfTippedList = new List<string>();
			List<TypedPlayer> playerList = new List<TypedPlayer>();
			
			var dicoTipAction = new Dictionary<String, String>();
			BaseCollection coll = new BaseCollection();
			
			foreach (String ligne in lines) {
				//presque, mais marche pas. : permet de choper le resultat entre parenthese

				//http://www.dotnetperls.com/regex-match
				//lignes avec deja un utilisateur (donc pas bon si l'utilisateur a fini son tour)
				
				//				Match match1 = Regex.Match(ligne, @" Coins from ([A-Za-z0-9\-_]+) ");
				
				
				/*
				 * // This is the input string.
	string input = "/content/alternate-1.aspx";

	// Here we lowercase our input first.
	input = input.ToLower();
	Match match = Regex.Match(input, @"content/([A-Za-z0-9\-]+)\.aspx$");
	if (match.Success)
	{
	    return match.Groups[1].Value; -> 'alternate'
	}
				 */
				
				//example : [17:56:43] [Client thread/INFO]: [CHAT] You sent a tip of 100 coins to [MVP+] pluto in DSKRoom
				Match match1 = Regex.Match(ligne, @" You sent a tip of ");
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
				//Extraction a la main des utilisateurs. a passer en regexp quand ... chef de la regexp
				Match match = Regex.Match(ligne, @"( Coins from |Coins Boosters queued)");
				
				if (match.Success) {
					String who = NONE;
					Match match2 = Regex.Match(ligne, @" Coins from");
					
					if (match2.Success) {
						String[] whoho = Regex.Split(ligne, @" Coins from ");
						who = whoho[1];
						
						//crado:si fini par virgule ou espace, on vire.
						if (who.Contains(",")) {
							who = who.Substring(0, who.IndexOf(","));
							
						}
						if (who.Contains(" ")) {
							who = who.Substring(0, who.IndexOf(" "));
						}
					} else {
					}
					//plus interessant : recherche du pole qui a emis la ligne en question.
					Match matchGame = Regex.Match(ligne, @" \[CHAT\] ([^-]+)");
					if (matchGame.Success) {
						String clef = matchGame.Groups[1].Value;
						if (dicoTipAction.ContainsKey(clef)) {
							dicoTipAction[clef] = who;
						} else {
							dicoTipAction.Add(clef, who);
						}
					}
					
					
					//on passe par le dictionnaire pour avoir les clefs uniques (et garder les derniers poles actifs)
					//retour += "/tip " + who + " \r\n";
				}
			}
			
			//construction de la richTextBox
			MainUtils.buildTypedRichTBox(tippedRichTextBox, playerList);
			
			
			//descente du dictionaire, et calculs
			retour = "";
			foreach (string clef in dicoTipAction.Keys) {
				String who = "null";
				who = dicoTipAction[clef];
				if (!who.Equals(NONE)) {
					//dicoTipAction.Values .TryGetValue(clef, who);
					
					retour += " /tip " + who + " " + "\r\n";
					reelTipCalcul += " s:" + clef + " = " + dicoTipAction[clef] + "\r\n";
				}
			}
			retour += "cpt:" + dicoTipAction.Count;
			tipTextbox.Text = retour + "\r\n" + reelTipCalcul;
			
			
		}
		

		void InitButtonClick(object sender, EventArgs e)
		{
			init();
			/*
			richTextBox1.BackColor =Color.Blue;
			richTextBox1.AppendText("blue");
			richTextBox1.ForeColor =Color.Blue;
			richTextBox1.BackColor=Color.Yellow;
			richTextBox1.AppendText("jaune");
			
			
			richTextBox1.Find("e", RichTextBoxFinds.MatchCase);

			// richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
			richTextBox1.SelectionColor = Color.Red;
			//richTextBox1.Find("u", RichTextBoxFinds.MatchCase);
			richTextBox1.Select(6, 30);
			richTextBox1.SelectionColor = Color.Pink;
			 */
			//MessageBox.Show(richTextBox1.Rtf);

			
		}
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			//throw new NotImplementedException();
		}
		void Button1Click(object sender, EventArgs e)
		{
			
			
			//appaCtivate
			Process mcProcess=null;
			Process[] processes = Process.GetProcessesByName("Minecraft 1.");
			processes=Process.GetProcesses();
			foreach(Process pr in processes) {
				
				if (pr.MainWindowTitle.StartsWith("Minecraft 1")) {
					System.Diagnostics.Debug.Print (" process : 	"+pr.ProcessName + " / " +pr.MainWindowTitle);
					mcProcess=pr;
				}
			}
			//<<<<<<< HEAD
//			if (mcProcess!=null) {
//				System.Diagnostics.Debug.Print ("activating");
//				SetForegroundWindow(mcProcess.MainWindowHandle);
//
//				System.Threading.Thread.Sleep(500);
//				SendKeys.SendWait("{ESC}");
//				System.Diagnostics.Debug.Print ("ESC!");
//				//System.Threading.Thread.Sleep(2000);
//				SendKeys.SendWait("t (^V) ~");
//				System.Threading.Thread.Sleep(100);
//
//				/*
//				System.Diagnostics.Debug.Print ("boos");
//				SendKeys.SendWait("/booster queue ");
//				System.Threading.Thread.Sleep(1000);
//				System.Diagnostics.Debug.Print ("Enter");
//				SendKeys.SendWait("~ {ENTER}");
//				 */
//				//sendTemperate("/booster queue ~  ", 100);
//
//				SendKeys.SendWait("x");
//				System.Threading.Thread.Sleep(100);
//				SendKeys.SendWait("{ENTER}");
//				System.Diagnostics.Debug.Print ("end");
//				//SendKeys.SendWait("");
			//=======
			if (mcProcess==null) return;
			
			SetForegroundWindow(mcProcess.MainWindowHandle);
			SendKeys.SendWait("{ESC}");
			System.Threading.Thread.Sleep(100);
			
			SendKeys.SendWait("t ");
			System.Threading.Thread.Sleep(100);
			SendKeys.Send("/booster queue  ");
			System.Threading.Thread.Sleep(100);
			SendKeys.SendWait("{ENTER}");
			//SendKeys.SendWait("");
			
			//'			goCheck(sender);
			System.Threading.Thread.Sleep(100);
			
			//prepareGrepList();
			System.Threading.Thread.Sleep(2000);
			
			//TODO:param
			const int waitMs=200;
			//string[] lines = Regex.Split(s, "\n");
			String[] str =  Regex.Split(tipTextbox.Text, "\n");
			foreach(String truc in str) {
				if (truc.Trim().StartsWith("/")) {
					System.Diagnostics.Debug.Print("TIIIP:"+truc.Trim());
					SendKeys.SendWait("t");
					System.Threading.Thread.Sleep(waitMs);
					SendKeys.SendWait(truc+" {ENTER}");
					System.Threading.Thread.Sleep(waitMs);
				}
			}
			System.Threading.Thread.Sleep(waitMs);
			
		}
		private void sendTemperate(String str, int waiter) {
			for(int i=0;i<str.Length;i++) {
				System.Diagnostics.Debug.Print ("i:"+i+" str:'"+str.Substring(i, 1)+"'");
				SendKeys.SendWait(str.Substring(i, 1));
				System.Threading.Thread.Sleep(waiter);
			}
		}
		void LaunchMCButtonClick(object sender, EventArgs e)
		{
			//TODO:param
			String cmd=@"C:/Program Files (x86)/Minecraft/MinecraftLauncher.exe";
			
			var info = new ProcessStartInfo();
			info.FileName = cmd;
			info.Arguments = "";
			//Process.Start(info);
			
			String us = Environment.ExpandEnvironmentVariables("%userprofile%");
			us = us.Replace("\\", "/");
			info.Arguments = info.Arguments.Replace("%userprofile%", us);
			
			info.RedirectStandardError = true;
			info.RedirectStandardOutput = true;
			info.UseShellExecute = false;
			
			var p = new Process();
			p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			p.StartInfo = info;

			//Execution
			p.Start();

		}
		void GrepButtonClick(object sender, EventArgs e)
		{

			prepareGrepList();
		}
		void prepareGrepList() {
			//TODO:param
			String sourcePath="%userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
			tipTextbox.Text= hyUtil.grepAndTip(sourcePath);

		}
		void checkTipLine(String ligne, List<String> resultList) {
			const String NONE = "NONE";
			Match match = Regex.Match(ligne, @"( Coins from |Coins Boosters queued)");
			
			if (match.Success) {

				String who = NONE;
				Match match2 = Regex.Match(ligne, @" Coins from");
				
				if (match2.Success) {
					String[] whoho = Regex.Split(ligne, @" Coins from ");
					who = whoho[1];
					
					//crado:si fini par virgule ou espace, on vire.
					if (who.Contains(",")) {
						who = who.Substring(0, who.IndexOf(","));
						
					}
					if (who.Contains(" ")) {
						who = who.Substring(0, who.IndexOf(" "));
					}
					resultList.Add(" /tip "+who);
				} else {
				}
				
				//here 
			}
			

		}
		

	}
}
//http://webman.developpez.com/articles/dotnet/filesystemwatcher/vbnet/