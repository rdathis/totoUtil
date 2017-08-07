/*
 * Utilisateur: Renaud
 * Date: 04/08/2017
 * Heure: 18:05:27
 * 
*/
using System;
using System.Windows.Forms;

namespace cmdUtils.Objets.utils
{
	/// <summary>
	/// Description of ToolTipUtil.
	/// </summary>
	public class ToolTipUtil
	{
		public ToolTipUtil()
		{
		}
		public void add(Control control, String str) {
			new ToolTip().SetToolTip(control, str);
		}
	}
}
