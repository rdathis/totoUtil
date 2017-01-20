/*
 * Utilisateur: Renaud
 * Date: 09/01/2017
 * Heure: 14:42:23
 * 
*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoulUtil
{
	/// <summary>
	/// Form for requests
	/// </summary>
	public partial class MouliSQLForm : Form
	{
		private String magId=null;
		public MouliSQLForm(String magId)
		{
			InitializeComponent();
			this.magId=magId;
			this.magasinIdBox.Text=magId;
			this.magasinIdBox.Enabled=false;
		}
	}
}
