/*
 * Utilisateur: Renaud
 * Date: 15/02/2017
 * Heure: 15:46:35
 * 
 */
using System;
using System.Windows.Forms;
using cmdUtils.Objets;
using System.IO;

namespace cmdUtils.Controles
{
	/// <summary>
	/// bouton explorer windows.
	/// </summary>
	public partial class NavigatorUserControl : UserControl
	{
		private TextBox box1=null;
		private TextBox box2=null;
		public NavigatorUserControl()
		{
			InitializeComponent();
			
		}
		public String getPath() {
			String path="";
			if(box1!=null) {
				path=Path.GetFullPath(box1.Text.Trim());
				if(!path.EndsWith("\\")) {
					path+="\\";
				}
			}
			if(box2!=null) {
				if (Directory.Exists(path+box2.Text.Trim())) {
					path+=box2.Text.Trim();
				}
			}
			return path.Replace("/", "\\");;
		}
		public void setBox(TextBox box) {
			this.box1=box;
		}
		public void setBoxes(TextBox box1, TextBox box2) {
			this.box1=box1;
			this.box2=box2;
		}
		void NavigButtonClick(object sender, EventArgs e)
		{
			String path=getPath();
			if(path!="") {

				CmdUtil cmdUtil = new CmdUtil();
				cmdUtil.executeCommande("explorer", path);
			}
		}
		void NavigButtonMouseHover(object sender, EventArgs e)
		{
			ToolTip t = new ToolTip();
			t.SetToolTip(navigButton, getPath());
		}
	}
}
