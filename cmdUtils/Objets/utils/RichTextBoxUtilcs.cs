/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 17/06/2016
 * Heure: 13:53:20
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of RichTextBoxUtilcs.
	/// </summary>
	public class RichTextBoxUtil
	{
		public RichTextBoxUtil()
		{
		}
		public void dcolorit(System.Windows.Forms.RichTextBox rtb, String str, System.Drawing.Color color) {
			RichTextBoxUtil.colorit(rtb, str, color);
		}
		public static void colorit(System.Windows.Forms.RichTextBox rtb, String str, System.Drawing.Color color)
		{
			int lg = rtb.Text.Length;
			rtb.AppendText(str);
			rtb.Select(lg, str.Length);
			rtb.SelectionColor = color;
		}
	}
}
