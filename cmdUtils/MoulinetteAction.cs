/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 12/10/2015
 * Heure: 17:00:53
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Windows.Forms;
using cmdUtils.Objets;

namespace cmdUtils
{
	/// <summary>
	/// Description of MoulinetteAction.
	/// </summary>
	public class MoulinetteAction
	{
		public MoulinetteAction()
		{
		}
		public void bntListSrc(System.Windows.Forms.Button btn, CmdUtil cmdUtil, String sourcePath, String filter, ListBox listbox) {
			//Button btn=(Button)sender;
			btn.Tag=btn.Text;
			btn.Text="(...)";
			btn.Enabled=false;
			
			cmdUtil.listFilesToListbox(sourcePath, filter, listbox);
			btn.Text=(String)btn.Tag;
			btn.Enabled=true;			
		}
	}
}
