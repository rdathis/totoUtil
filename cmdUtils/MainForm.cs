/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 20/04/2015
 * Time: 20:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace cmdUtils
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
		ConfigSectionSettings cfg=	ConfigSectionSettings.GetSection(ConfigurationUserLevel.PerUserRoamingAndLocal);
		cfg.ExampleAttribute="youpi";
		cfg.Save();
		Configuration cfgConf=cfg.getConfiguration();
		statusStrip1.Text="Saved in : "+cfgConf.FilePath;
		labelFichierConfig.Text="Saved in : "+cfgConf.FilePath;
			//ConfigurationManager.
			//settings.
	//Properties.Settings.Default.Save();
		}
	}
}
