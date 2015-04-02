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

namespace totoUtil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		TimerExample timer = null;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			
			init();
			System.Threading.TimerCallback callback = goCheck;
			
			//System.Threading.Timer timm = new System.Threading.Timer(callback, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
			
			
		}
		void init()
		{
			pathTxtBox.Text = "m:/cygwin64/bin/grep.exe";
			
			pathTxtBox.Text = "grep.exe";
			if (!System.IO.File.Exists(pathTxtBox.Text)) {
				pathTxtBox.Text = "m:/cygwin64/bin/grep.exe";
			}
			
			argTxtBox.Text = "-Fi --color=always coins %userprofile%/AppData/Roaming/.minecraft/logs/*log";
			argTxtBox.Text = "-Fh -e \" Coins from \" -e \"tip \" %userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
			
			argTxtBox.Text = "-Fh -w -e Coins -e \"You sent a tip of\" %userprofile%/AppData/Roaming/.minecraft/logs/lat*log";
			
			
		}
		void BtnClick(object sender, EventArgs e)
		{
			goCheck(sender);
			tipTxtbox.AppendText(" je viens de faire, il est " + DateTime.Today.ToString());
		}
		void goCheck(object sender)
		{
			var info = new ProcessStartInfo();
			info.FileName = pathTxtBox.Text;
			info.Arguments = argTxtBox.Text;
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
			infoTxtBox.Text = newString;
			
			//appel du moteur de calcul pour les vrais traitements
			doTip(s1);
		}
		
		void colorit(RichTextBox rtb, String str, Color color) {
			int lg=rtb.Text.Length;
			rtb.AppendText(str);
			rtb.Select(lg, str.Length);
			rtb.SelectionColor =color;
			
		}

		void doTip(String s)
		{
			string[] lines = Regex.Split(s, "\n");
			String retour = "";
			String reelTipCalcul = "";
			richTextBox1.Clear();
			String emptyRtf=richTextBox1.Rtf;
			richTextBox1.Location=tippedTextBox.Location;
			richTextBox1.Size= tippedTextBox.Size;
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
				
				//[17:56:43] [Client thread/INFO]: [CHAT] You sent a tip of 100 coins to [MVP+] PietDeeke in Mega Walls
				Match match1 = Regex.Match(ligne, @" You sent a tip of ");
				if (match1.Success) {
					String when = ligne.Substring(1, 9);
					int toI = ligne.LastIndexOf(@" to ");
					int gameI = ligne.LastIndexOf(@" in ");
					if ((toI > 0) && (gameI > 0)) {
						String to = ligne.Substring(toI + 4, (gameI - toI) - 3).Trim();
						String game = ligne.Substring(gameI + 3).Trim();
						//tippedTextBox.Text = (tippedTextBox.Text + when + " " + to + " " + game + "\r\n");
						
						//tippedTextBox.Text = (when + " " + to + " " + game + "\r\n");
						
						
						
						//					richTextBox1.SelectionColor = Color.Red;
						//richTextBox1.Find("u", RichTextBoxFinds.MatchCase);
						//richTextBox1.Select(6, 30);
						//richTextBox1.SelectionColor = Color.Pink;
						
						playerList.Add(new TypedPlayer(to, when, game));
						if (false) {
						richTextBox1.Clear();
						colorit(richTextBox1, "["+when +" to ", Color.Blue);
						//richTextBox1.BackColor =Color.Blue;
						
						
						
						//richTextBox1.AppendText("["+when +" to ");
						//richTextBox1.BackColor=Color.Red;
						colorit(richTextBox1, to, Color.Red);
						//richTextBox1.AppendText(to);
						//richTextBox1.BackColor=Color.OrangeRed;
						colorit(richTextBox1, " "+game+"\r\n", Color.OrangeRed);
						//richTextBox1.AppendText(game+"\r\n");
						
						rtfTippedList.Add(richTextBox1.Rtf);
						}
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
			
			richTextBox1.Clear();
			
			List <TypedPlayer> finalList ;
			if (playerList.Count>10) {
				finalList= playerList.GetRange(playerList.Count -10, 10);
			} else {
				finalList=playerList;
			}
			for(int idx =0;idx<finalList.Count;idx++) {
				TypedPlayer player = finalList[idx];
				
				colorit(richTextBox1, "["+player.getWhen() +" to ", Color.Blue);
						//richTextBox1.BackColor =Color.Blue;
						
						
						
						//richTextBox1.AppendText("["+when +" to ");
						//richTextBox1.BackColor=Color.Red;
						colorit(richTextBox1, player.getPlayer(), Color.Red);
						//richTextBox1.AppendText(to);
						//richTextBox1.BackColor=Color.OrangeRed;
						colorit(richTextBox1, " "+player.getGame()+"\r\n", Color.OrangeRed);
				//String tip=finalList[idx];
				//richTextBox1.Rtf+=tip.Substring(emptyRtf.Length);
			}
			//tippedTextBox.Text=tippedTextBox.Name;
//			foreach(String s2 in rtfTippedList) {
//				richTextBox1.Rtf=s2;
//			}
			
			//tipTxtbox.Text = retour;
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
			tipTxtbox.Text = retour + "\r\n" + reelTipCalcul;
			
			
			//tippedTextBox.Text=" xyz";
			//MessageBox.Show(richTextBox1.Rtf);
			//richTextBox1.Text=" et rien";
			
		}
		void InitButtonClick(object sender, EventArgs e)
		{
			init();
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
			MessageBox.Show(richTextBox1.Rtf);

			
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
			if (mcProcess!=null) {
				System.Diagnostics.Debug.Print ("activating");
				SetForegroundWindow(mcProcess.MainWindowHandle);
				
				System.Threading.Thread.Sleep(500);
				SendKeys.SendWait("{ESC}");
				System.Diagnostics.Debug.Print ("ESC!");
				//System.Threading.Thread.Sleep(2000);
				SendKeys.SendWait("t (^V) ~");
				System.Threading.Thread.Sleep(100);
				
				/*
				System.Diagnostics.Debug.Print ("boos");
				SendKeys.SendWait("/booster queue ");
				System.Threading.Thread.Sleep(1000);
				System.Diagnostics.Debug.Print ("Enter");
				SendKeys.SendWait("~ {ENTER}");
				*/
				//sendTemperate("/booster queue ~  ", 100);
				
				SendKeys.SendWait("x");
				System.Threading.Thread.Sleep(100);
				SendKeys.SendWait("{ENTER}");
				System.Diagnostics.Debug.Print ("end");
				//SendKeys.SendWait("");
				
			}
			
			
			
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
	}
}
