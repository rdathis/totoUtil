/*
 * Created by SharpDevelop.
 * User: Renaud
 * Date: 18/02/2017
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace TestUtil
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		static log4net.ILog LOGGER = LogManager.GetLogger("testUtil");
		public MainForm()
		{
			InitializeComponent();
			BasicConfigurator.Configure();
			System.Diagnostics.Debug.Print("starting");
			LOGGER.Info("info");
			LOGGER.Debug("debug");
			LOGGER.Warn("warn");
			LOGGER.Error("error");
		}
	}
}
