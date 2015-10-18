﻿/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 20/04/2015
 * Time: 20:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace cmdUtils
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage tabParam;
		private System.Windows.Forms.TabPage tabImport;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox scriptCreateDbParam;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox dataParam;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox mysqlParam;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox cygwinParam;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox mysqlUserParam;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox mysqlPasswordParam;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox scriptCreateFiledDBParam;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox dumpsListBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button mysqlImportBouton;
		private System.Windows.Forms.Label labelFichierConfig;
		private System.Windows.Forms.Button reloadButton;
		private System.Windows.Forms.Button defConfigButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabParam = new System.Windows.Forms.TabPage();
			this.lmoulDstPath = new System.Windows.Forms.Label();
			this.moulDstPathParam = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.moulScp1Param = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.moulScp2Param = new System.Windows.Forms.TextBox();
			this.lmoulSrcPath = new System.Windows.Forms.Label();
			this.moulSrcPathParam = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cygwinTermParam = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.pdfLabel = new System.Windows.Forms.Label();
			this.defConfigButton = new System.Windows.Forms.Button();
			this.reloadButton = new System.Windows.Forms.Button();
			this.labelFichierConfig = new System.Windows.Forms.Label();
			this.saveButton = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.mysqlUserParam = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.mysqlPasswordParam = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.scriptCreateFiledDBParam = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.scriptCreateDbParam = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.dataParam = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.mysqlParam = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cygwinParam = new System.Windows.Forms.TextBox();
			this.tabImport = new System.Windows.Forms.TabPage();
			this.recreateButton = new System.Windows.Forms.Button();
			this.filedbCheckbox = new System.Windows.Forms.CheckBox();
			this.meoCreateFiledb = new System.Windows.Forms.Button();
			this.dropButton = new System.Windows.Forms.Button();
			this.filterGzTextBox = new System.Windows.Forms.TextBox();
			this.filterGzBtn = new System.Windows.Forms.Button();
			this.mysqlDatabaseCombo = new System.Windows.Forms.ComboBox();
			this.getMysqlDatabaseButton = new System.Windows.Forms.Button();
			this.mysqlImportBouton = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dumpsListBox = new System.Windows.Forms.ListBox();
			this.tabSQL = new System.Windows.Forms.TabPage();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label11 = new System.Windows.Forms.Label();
			this.tabPdf = new System.Windows.Forms.TabPage();
			this.tabMoulinettes = new System.Windows.Forms.TabPage();
			this.docs = new System.Windows.Forms.Label();
			this.txtBoxMoulDocs = new System.Windows.Forms.TextBox();
			this.data = new System.Windows.Forms.Label();
			this.txtBoxMoulData = new System.Windows.Forms.TextBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.btnMoulNavigDestBase = new System.Windows.Forms.Button();
			this.btnMoulFilterSrc = new System.Windows.Forms.Button();
			this.btnZip = new System.Windows.Forms.Button();
			this.txtFinal = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.listboxMoulSrc = new System.Windows.Forms.ListBox();
			this.txtMagClient = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtMagId = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtBoxMoulDestBase = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtBoxMoulSrcFilter = new System.Windows.Forms.TextBox();
			this.txtBoxMoulSrcPath = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.dataSet1 = new System.Data.DataSet();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.cygwinToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.label20 = new System.Windows.Forms.Label();
			this.moulFichiersParam = new System.Windows.Forms.TextBox();
			this.tabs.SuspendLayout();
			this.tabParam.SuspendLayout();
			this.tabImport.SuspendLayout();
			this.tabSQL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabMoulinettes.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.tabParam);
			this.tabs.Controls.Add(this.tabImport);
			this.tabs.Controls.Add(this.tabSQL);
			this.tabs.Controls.Add(this.tabPdf);
			this.tabs.Controls.Add(this.tabMoulinettes);
			this.tabs.Location = new System.Drawing.Point(12, 27);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(822, 515);
			this.tabs.TabIndex = 0;
			this.tabs.Click += new System.EventHandler(this.tabImportClick);
			// 
			// tabParam
			// 
			this.tabParam.Controls.Add(this.label20);
			this.tabParam.Controls.Add(this.moulFichiersParam);
			this.tabParam.Controls.Add(this.lmoulDstPath);
			this.tabParam.Controls.Add(this.moulDstPathParam);
			this.tabParam.Controls.Add(this.label21);
			this.tabParam.Controls.Add(this.moulScp1Param);
			this.tabParam.Controls.Add(this.label22);
			this.tabParam.Controls.Add(this.moulScp2Param);
			this.tabParam.Controls.Add(this.lmoulSrcPath);
			this.tabParam.Controls.Add(this.moulSrcPathParam);
			this.tabParam.Controls.Add(this.label13);
			this.tabParam.Controls.Add(this.cygwinTermParam);
			this.tabParam.Controls.Add(this.label12);
			this.tabParam.Controls.Add(this.pdfLabel);
			this.tabParam.Controls.Add(this.defConfigButton);
			this.tabParam.Controls.Add(this.reloadButton);
			this.tabParam.Controls.Add(this.labelFichierConfig);
			this.tabParam.Controls.Add(this.saveButton);
			this.tabParam.Controls.Add(this.label7);
			this.tabParam.Controls.Add(this.mysqlUserParam);
			this.tabParam.Controls.Add(this.label6);
			this.tabParam.Controls.Add(this.mysqlPasswordParam);
			this.tabParam.Controls.Add(this.label5);
			this.tabParam.Controls.Add(this.scriptCreateFiledDBParam);
			this.tabParam.Controls.Add(this.label3);
			this.tabParam.Controls.Add(this.scriptCreateDbParam);
			this.tabParam.Controls.Add(this.label4);
			this.tabParam.Controls.Add(this.dataParam);
			this.tabParam.Controls.Add(this.label2);
			this.tabParam.Controls.Add(this.mysqlParam);
			this.tabParam.Controls.Add(this.label1);
			this.tabParam.Controls.Add(this.cygwinParam);
			this.tabParam.Location = new System.Drawing.Point(4, 22);
			this.tabParam.Name = "tabParam";
			this.tabParam.Padding = new System.Windows.Forms.Padding(3);
			this.tabParam.Size = new System.Drawing.Size(814, 489);
			this.tabParam.TabIndex = 0;
			this.tabParam.Text = "Params";
			this.tabParam.UseVisualStyleBackColor = true;
			this.tabParam.Click += new System.EventHandler(this.TabParamClick);
			// 
			// lmoulDstPath
			// 
			this.lmoulDstPath.Location = new System.Drawing.Point(20, 266);
			this.lmoulDstPath.Name = "lmoulDstPath";
			this.lmoulDstPath.Size = new System.Drawing.Size(100, 23);
			this.lmoulDstPath.TabIndex = 33;
			this.lmoulDstPath.Text = "moulDstPath";
			// 
			// moulDstPathParam
			// 
			this.moulDstPathParam.Location = new System.Drawing.Point(131, 266);
			this.moulDstPathParam.Name = "moulDstPathParam";
			this.moulDstPathParam.Size = new System.Drawing.Size(642, 20);
			this.moulDstPathParam.TabIndex = 27;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(20, 313);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(100, 23);
			this.label21.TabIndex = 32;
			this.label21.Text = "cp @S1";
			// 
			// moulScp1Param
			// 
			this.moulScp1Param.Location = new System.Drawing.Point(131, 316);
			this.moulScp1Param.Name = "moulScp1Param";
			this.moulScp1Param.Size = new System.Drawing.Size(642, 20);
			this.moulScp1Param.TabIndex = 28;
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(20, 339);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 31;
			this.label22.Text = "cp@S2";
			// 
			// moulScp2Param
			// 
			this.moulScp2Param.Location = new System.Drawing.Point(131, 342);
			this.moulScp2Param.Name = "moulScp2Param";
			this.moulScp2Param.Size = new System.Drawing.Size(642, 20);
			this.moulScp2Param.TabIndex = 29;
			// 
			// lmoulSrcPath
			// 
			this.lmoulSrcPath.Location = new System.Drawing.Point(20, 240);
			this.lmoulSrcPath.Name = "lmoulSrcPath";
			this.lmoulSrcPath.Size = new System.Drawing.Size(100, 23);
			this.lmoulSrcPath.TabIndex = 30;
			this.lmoulSrcPath.Text = "moulSrcPath";
			// 
			// moulSrcPathParam
			// 
			this.moulSrcPathParam.Location = new System.Drawing.Point(131, 240);
			this.moulSrcPathParam.Name = "moulSrcPathParam";
			this.moulSrcPathParam.Size = new System.Drawing.Size(642, 20);
			this.moulSrcPathParam.TabIndex = 26;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(20, 59);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 25;
			this.label13.Text = "terminalCygwin";
			// 
			// cygwinTermParam
			// 
			this.cygwinTermParam.Location = new System.Drawing.Point(131, 59);
			this.cygwinTermParam.Name = "cygwinTermParam";
			this.cygwinTermParam.Size = new System.Drawing.Size(642, 20);
			this.cygwinTermParam.TabIndex = 24;
			// 
			// label12
			// 
			this.label12.BackColor = System.Drawing.Color.Red;
			this.label12.ForeColor = System.Drawing.Color.Yellow;
			this.label12.Location = new System.Drawing.Point(340, 434);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(433, 23);
			this.label12.TabIndex = 23;
			this.label12.Text = "cat `cygpath -W`/Media/ding.wav > /dev/dsp";
			// 
			// pdfLabel
			// 
			this.pdfLabel.Location = new System.Drawing.Point(673, 411);
			this.pdfLabel.Name = "pdfLabel";
			this.pdfLabel.Size = new System.Drawing.Size(100, 23);
			this.pdfLabel.TabIndex = 22;
			this.pdfLabel.Text = "pdf";
			this.pdfLabel.Click += new System.EventHandler(this.PdfLabelClick);
			// 
			// defConfigButton
			// 
			this.defConfigButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.defConfigButton.Location = new System.Drawing.Point(516, 460);
			this.defConfigButton.Name = "defConfigButton";
			this.defConfigButton.Size = new System.Drawing.Size(75, 23);
			this.defConfigButton.TabIndex = 18;
			this.defConfigButton.Text = "&defConfig";
			this.defConfigButton.UseVisualStyleBackColor = true;
			// 
			// reloadButton
			// 
			this.reloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.reloadButton.Location = new System.Drawing.Point(420, 460);
			this.reloadButton.Name = "reloadButton";
			this.reloadButton.Size = new System.Drawing.Size(75, 23);
			this.reloadButton.TabIndex = 16;
			this.reloadButton.Text = "&reload";
			this.reloadButton.UseVisualStyleBackColor = true;
			// 
			// labelFichierConfig
			// 
			this.labelFichierConfig.Location = new System.Drawing.Point(131, 411);
			this.labelFichierConfig.Name = "labelFichierConfig";
			this.labelFichierConfig.Size = new System.Drawing.Size(482, 23);
			this.labelFichierConfig.TabIndex = 15;
			this.labelFichierConfig.Text = "?";
			// 
			// saveButton
			// 
			this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.saveButton.Location = new System.Drawing.Point(324, 460);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(75, 23);
			this.saveButton.TabIndex = 14;
			this.saveButton.Text = "&save";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(20, 162);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "user@my";
			// 
			// mysqlUserParam
			// 
			this.mysqlUserParam.Location = new System.Drawing.Point(131, 162);
			this.mysqlUserParam.Name = "mysqlUserParam";
			this.mysqlUserParam.Size = new System.Drawing.Size(642, 20);
			this.mysqlUserParam.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 185);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "pwd@my";
			// 
			// mysqlPasswordParam
			// 
			this.mysqlPasswordParam.Location = new System.Drawing.Point(131, 188);
			this.mysqlPasswordParam.Name = "mysqlPasswordParam";
			this.mysqlPasswordParam.Size = new System.Drawing.Size(642, 20);
			this.mysqlPasswordParam.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 211);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "scriptsSQL";
			// 
			// scriptCreateFiledDBParam
			// 
			this.scriptCreateFiledDBParam.Location = new System.Drawing.Point(131, 214);
			this.scriptCreateFiledDBParam.Name = "scriptCreateFiledDBParam";
			this.scriptCreateFiledDBParam.Size = new System.Drawing.Size(642, 20);
			this.scriptCreateFiledDBParam.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(20, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "scriptsSQL";
			// 
			// scriptCreateDbParam
			// 
			this.scriptCreateDbParam.Location = new System.Drawing.Point(131, 136);
			this.scriptCreateDbParam.Name = "scriptCreateDbParam";
			this.scriptCreateDbParam.Size = new System.Drawing.Size(642, 20);
			this.scriptCreateDbParam.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "datas";
			// 
			// dataParam
			// 
			this.dataParam.Location = new System.Drawing.Point(131, 110);
			this.dataParam.Name = "dataParam";
			this.dataParam.Size = new System.Drawing.Size(642, 20);
			this.dataParam.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "mysql";
			// 
			// mysqlParam
			// 
			this.mysqlParam.Location = new System.Drawing.Point(131, 84);
			this.mysqlParam.Name = "mysqlParam";
			this.mysqlParam.Size = new System.Drawing.Size(642, 20);
			this.mysqlParam.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "cygwin";
			// 
			// cygwinParam
			// 
			this.cygwinParam.Location = new System.Drawing.Point(131, 33);
			this.cygwinParam.Name = "cygwinParam";
			this.cygwinParam.Size = new System.Drawing.Size(642, 20);
			this.cygwinParam.TabIndex = 0;
			// 
			// tabImport
			// 
			this.tabImport.Controls.Add(this.recreateButton);
			this.tabImport.Controls.Add(this.filedbCheckbox);
			this.tabImport.Controls.Add(this.meoCreateFiledb);
			this.tabImport.Controls.Add(this.dropButton);
			this.tabImport.Controls.Add(this.filterGzTextBox);
			this.tabImport.Controls.Add(this.filterGzBtn);
			this.tabImport.Controls.Add(this.mysqlDatabaseCombo);
			this.tabImport.Controls.Add(this.getMysqlDatabaseButton);
			this.tabImport.Controls.Add(this.mysqlImportBouton);
			this.tabImport.Controls.Add(this.richTextBox1);
			this.tabImport.Controls.Add(this.textBox10);
			this.tabImport.Controls.Add(this.label10);
			this.tabImport.Controls.Add(this.textBox9);
			this.tabImport.Controls.Add(this.label9);
			this.tabImport.Controls.Add(this.label8);
			this.tabImport.Controls.Add(this.dumpsListBox);
			this.tabImport.Location = new System.Drawing.Point(4, 22);
			this.tabImport.Name = "tabImport";
			this.tabImport.Padding = new System.Windows.Forms.Padding(3);
			this.tabImport.Size = new System.Drawing.Size(814, 489);
			this.tabImport.TabIndex = 1;
			this.tabImport.Text = "tabImport";
			this.tabImport.UseVisualStyleBackColor = true;
			// 
			// recreateButton
			// 
			this.recreateButton.Location = new System.Drawing.Point(519, 30);
			this.recreateButton.Name = "recreateButton";
			this.recreateButton.Size = new System.Drawing.Size(56, 23);
			this.recreateButton.TabIndex = 16;
			this.recreateButton.Text = "reCreate";
			this.recreateButton.UseVisualStyleBackColor = true;
			this.recreateButton.Click += new System.EventHandler(this.RecreateButtonClick);
			// 
			// filedbCheckbox
			// 
			this.filedbCheckbox.Checked = true;
			this.filedbCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.filedbCheckbox.Location = new System.Drawing.Point(590, 33);
			this.filedbCheckbox.Name = "filedbCheckbox";
			this.filedbCheckbox.Size = new System.Drawing.Size(118, 20);
			this.filedbCheckbox.TabIndex = 15;
			this.filedbCheckbox.Text = "fileDB";
			this.filedbCheckbox.UseVisualStyleBackColor = true;
			// 
			// meoCreateFiledb
			// 
			this.meoCreateFiledb.Location = new System.Drawing.Point(218, 223);
			this.meoCreateFiledb.Name = "meoCreateFiledb";
			this.meoCreateFiledb.Size = new System.Drawing.Size(75, 23);
			this.meoCreateFiledb.TabIndex = 14;
			this.meoCreateFiledb.Text = "create &filedb";
			this.meoCreateFiledb.UseVisualStyleBackColor = true;
			this.meoCreateFiledb.Click += new System.EventHandler(this.MeoCreateFileDbClick);
			// 
			// dropButton
			// 
			this.dropButton.Location = new System.Drawing.Point(475, 29);
			this.dropButton.Name = "dropButton";
			this.dropButton.Size = new System.Drawing.Size(38, 23);
			this.dropButton.TabIndex = 13;
			this.dropButton.Text = "dropButton";
			this.dropButton.UseVisualStyleBackColor = true;
			this.dropButton.Click += new System.EventHandler(this.dropButtonClick);
			// 
			// filterGzTextBox
			// 
			this.filterGzTextBox.Location = new System.Drawing.Point(555, 2);
			this.filterGzTextBox.Name = "filterGzTextBox";
			this.filterGzTextBox.Size = new System.Drawing.Size(196, 20);
			this.filterGzTextBox.TabIndex = 12;
			// 
			// filterGzBtn
			// 
			this.filterGzBtn.Location = new System.Drawing.Point(757, 0);
			this.filterGzBtn.Name = "filterGzBtn";
			this.filterGzBtn.Size = new System.Drawing.Size(50, 23);
			this.filterGzBtn.TabIndex = 11;
			this.filterGzBtn.Text = "filtre";
			this.filterGzBtn.UseVisualStyleBackColor = true;
			this.filterGzBtn.Click += new System.EventHandler(this.FilterGzBtnClick);
			// 
			// mysqlDatabaseCombo
			// 
			this.mysqlDatabaseCombo.FormattingEnabled = true;
			this.mysqlDatabaseCombo.Location = new System.Drawing.Point(113, 4);
			this.mysqlDatabaseCombo.Name = "mysqlDatabaseCombo";
			this.mysqlDatabaseCombo.Size = new System.Drawing.Size(355, 21);
			this.mysqlDatabaseCombo.TabIndex = 10;
			// 
			// getMysqlDatabaseButton
			// 
			this.getMysqlDatabaseButton.Location = new System.Drawing.Point(474, 2);
			this.getMysqlDatabaseButton.Name = "getMysqlDatabaseButton";
			this.getMysqlDatabaseButton.Size = new System.Drawing.Size(75, 23);
			this.getMysqlDatabaseButton.TabIndex = 9;
			this.getMysqlDatabaseButton.Text = "&get db";
			this.getMysqlDatabaseButton.UseVisualStyleBackColor = true;
			this.getMysqlDatabaseButton.Click += new System.EventHandler(this.GetMysqlDatabaseButtonClick);
			// 
			// mysqlImportBouton
			// 
			this.mysqlImportBouton.Location = new System.Drawing.Point(31, 223);
			this.mysqlImportBouton.Name = "mysqlImportBouton";
			this.mysqlImportBouton.Size = new System.Drawing.Size(152, 23);
			this.mysqlImportBouton.TabIndex = 8;
			this.mysqlImportBouton.Text = "&lancer";
			this.mysqlImportBouton.UseVisualStyleBackColor = true;
			this.mysqlImportBouton.Click += new System.EventHandler(this.GoMysqlImportButtonClick);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(6, 252);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(805, 237);
			this.richTextBox1.TabIndex = 7;
			this.richTextBox1.Text = "";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(113, 178);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(355, 20);
			this.textBox10.TabIndex = 6;
			this.textBox10.Text = "file_db";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(7, 178);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 5;
			this.label10.Text = "script apres";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(113, 31);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(355, 20);
			this.textBox9.TabIndex = 4;
			this.textBox9.Text = "dropt if exist ; create database;";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(7, 30);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 3;
			this.label9.Text = "script avant";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(7, 7);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 1;
			this.label8.Text = "database";
			// 
			// dumpsListBox
			// 
			this.dumpsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dumpsListBox.FormattingEnabled = true;
			this.dumpsListBox.Location = new System.Drawing.Point(6, 70);
			this.dumpsListBox.Name = "dumpsListBox";
			this.dumpsListBox.Size = new System.Drawing.Size(805, 95);
			this.dumpsListBox.TabIndex = 0;
			this.dumpsListBox.SelectedIndexChanged += new System.EventHandler(this.DumpsListBoxSelectedIndexChanged);
			this.dumpsListBox.DoubleClick += new System.EventHandler(this.DumpsListBoxDoubleClick);
			// 
			// tabSQL
			// 
			this.tabSQL.Controls.Add(this.richTextBox2);
			this.tabSQL.Controls.Add(this.dataGrid1);
			this.tabSQL.Controls.Add(this.dataGridView1);
			this.tabSQL.Controls.Add(this.label11);
			this.tabSQL.Location = new System.Drawing.Point(4, 22);
			this.tabSQL.Name = "tabSQL";
			this.tabSQL.Size = new System.Drawing.Size(814, 489);
			this.tabSQL.TabIndex = 2;
			this.tabSQL.Text = "tabSQL";
			this.tabSQL.UseVisualStyleBackColor = true;
			// 
			// richTextBox2
			// 
			this.richTextBox2.Location = new System.Drawing.Point(3, 3);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(768, 127);
			this.richTextBox2.TabIndex = 25;
			this.richTextBox2.Text = "";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(386, 237);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(385, 209);
			this.dataGrid1.TabIndex = 24;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(22, 237);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(358, 209);
			this.dataGridView1.TabIndex = 23;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(108, 176);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 22;
			this.label11.Text = "label11";
			this.label11.Click += new System.EventHandler(this.Label11Click);
			// 
			// tabPdf
			// 
			this.tabPdf.Location = new System.Drawing.Point(4, 22);
			this.tabPdf.Name = "tabPdf";
			this.tabPdf.Size = new System.Drawing.Size(814, 489);
			this.tabPdf.TabIndex = 3;
			this.tabPdf.Text = "tabPdf";
			this.tabPdf.UseVisualStyleBackColor = true;
			// 
			// tabMoulinettes
			// 
			this.tabMoulinettes.Controls.Add(this.docs);
			this.tabMoulinettes.Controls.Add(this.txtBoxMoulDocs);
			this.tabMoulinettes.Controls.Add(this.data);
			this.tabMoulinettes.Controls.Add(this.txtBoxMoulData);
			this.tabMoulinettes.Controls.Add(this.button4);
			this.tabMoulinettes.Controls.Add(this.button3);
			this.tabMoulinettes.Controls.Add(this.btnMoulNavigDestBase);
			this.tabMoulinettes.Controls.Add(this.btnMoulFilterSrc);
			this.tabMoulinettes.Controls.Add(this.btnZip);
			this.tabMoulinettes.Controls.Add(this.txtFinal);
			this.tabMoulinettes.Controls.Add(this.label19);
			this.tabMoulinettes.Controls.Add(this.listboxMoulSrc);
			this.tabMoulinettes.Controls.Add(this.txtMagClient);
			this.tabMoulinettes.Controls.Add(this.label18);
			this.tabMoulinettes.Controls.Add(this.txtMagId);
			this.tabMoulinettes.Controls.Add(this.label17);
			this.tabMoulinettes.Controls.Add(this.txtBoxMoulDestBase);
			this.tabMoulinettes.Controls.Add(this.label16);
			this.tabMoulinettes.Controls.Add(this.txtBoxMoulSrcFilter);
			this.tabMoulinettes.Controls.Add(this.txtBoxMoulSrcPath);
			this.tabMoulinettes.Controls.Add(this.label15);
			this.tabMoulinettes.Controls.Add(this.label14);
			this.tabMoulinettes.Controls.Add(this.btnSearch);
			this.tabMoulinettes.Location = new System.Drawing.Point(4, 22);
			this.tabMoulinettes.Name = "tabMoulinettes";
			this.tabMoulinettes.Padding = new System.Windows.Forms.Padding(3);
			this.tabMoulinettes.Size = new System.Drawing.Size(814, 489);
			this.tabMoulinettes.TabIndex = 4;
			this.tabMoulinettes.Text = "Moulinettes";
			this.tabMoulinettes.UseVisualStyleBackColor = true;
			// 
			// docs
			// 
			this.docs.Location = new System.Drawing.Point(30, 245);
			this.docs.Name = "docs";
			this.docs.Size = new System.Drawing.Size(61, 20);
			this.docs.TabIndex = 22;
			this.docs.Text = "f docs";
			// 
			// txtBoxMoulDocs
			// 
			this.txtBoxMoulDocs.Location = new System.Drawing.Point(97, 245);
			this.txtBoxMoulDocs.Name = "txtBoxMoulDocs";
			this.txtBoxMoulDocs.Size = new System.Drawing.Size(470, 20);
			this.txtBoxMoulDocs.TabIndex = 21;
			// 
			// data
			// 
			this.data.Location = new System.Drawing.Point(30, 219);
			this.data.Name = "data";
			this.data.Size = new System.Drawing.Size(61, 20);
			this.data.TabIndex = 20;
			this.data.Text = "f data";
			// 
			// txtBoxMoulData
			// 
			this.txtBoxMoulData.Location = new System.Drawing.Point(97, 219);
			this.txtBoxMoulData.Name = "txtBoxMoulData";
			this.txtBoxMoulData.Size = new System.Drawing.Size(470, 20);
			this.txtBoxMoulData.TabIndex = 19;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(693, 407);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 18;
			this.button4.Text = "s2";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(693, 378);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 17;
			this.button3.Text = "s1";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// btnMoulNavigDestBase
			// 
			this.btnMoulNavigDestBase.Location = new System.Drawing.Point(430, 407);
			this.btnMoulNavigDestBase.Name = "btnMoulNavigDestBase";
			this.btnMoulNavigDestBase.Size = new System.Drawing.Size(51, 23);
			this.btnMoulNavigDestBase.TabIndex = 16;
			this.btnMoulNavigDestBase.Text = "explorer";
			this.btnMoulNavigDestBase.UseVisualStyleBackColor = true;
			this.btnMoulNavigDestBase.Click += new System.EventHandler(this.Button2Click);
			// 
			// btnMoulFilterSrc
			// 
			this.btnMoulFilterSrc.Location = new System.Drawing.Point(390, 28);
			this.btnMoulFilterSrc.Name = "btnMoulFilterSrc";
			this.btnMoulFilterSrc.Size = new System.Drawing.Size(51, 23);
			this.btnMoulFilterSrc.TabIndex = 15;
			this.btnMoulFilterSrc.Text = "explorer";
			this.btnMoulFilterSrc.UseVisualStyleBackColor = true;
			this.btnMoulFilterSrc.Click += new System.EventHandler(this.BtnMoulFilterSrcClick);
			// 
			// btnZip
			// 
			this.btnZip.Location = new System.Drawing.Point(620, 460);
			this.btnZip.Name = "btnZip";
			this.btnZip.Size = new System.Drawing.Size(75, 23);
			this.btnZip.TabIndex = 14;
			this.btnZip.Text = "zip";
			this.btnZip.UseVisualStyleBackColor = true;
			// 
			// txtFinal
			// 
			this.txtFinal.Location = new System.Drawing.Point(102, 444);
			this.txtFinal.Name = "txtFinal";
			this.txtFinal.Size = new System.Drawing.Size(310, 20);
			this.txtFinal.TabIndex = 13;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(12, 444);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(84, 23);
			this.label19.TabIndex = 12;
			this.label19.Text = "fFinal";
			// 
			// listboxMoulSrc
			// 
			this.listboxMoulSrc.FormattingEnabled = true;
			this.listboxMoulSrc.Location = new System.Drawing.Point(7, 79);
			this.listboxMoulSrc.Name = "listboxMoulSrc";
			this.listboxMoulSrc.Size = new System.Drawing.Size(807, 134);
			this.listboxMoulSrc.TabIndex = 11;
			// 
			// txtMagClient
			// 
			this.txtMagClient.Location = new System.Drawing.Point(381, 363);
			this.txtMagClient.Name = "txtMagClient";
			this.txtMagClient.Size = new System.Drawing.Size(100, 20);
			this.txtMagClient.TabIndex = 10;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(245, 361);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 23);
			this.label18.TabIndex = 9;
			this.label18.Text = "client";
			// 
			// txtMagId
			// 
			this.txtMagId.Location = new System.Drawing.Point(102, 361);
			this.txtMagId.Name = "txtMagId";
			this.txtMagId.Size = new System.Drawing.Size(100, 20);
			this.txtMagId.TabIndex = 8;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(12, 361);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 23);
			this.label17.TabIndex = 7;
			this.label17.Text = "magId";
			// 
			// txtBoxMoulDestBase
			// 
			this.txtBoxMoulDestBase.Location = new System.Drawing.Point(102, 407);
			this.txtBoxMoulDestBase.Name = "txtBoxMoulDestBase";
			this.txtBoxMoulDestBase.Size = new System.Drawing.Size(310, 20);
			this.txtBoxMoulDestBase.TabIndex = 6;
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(12, 407);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(84, 23);
			this.label16.TabIndex = 5;
			this.label16.Text = "destBase";
			// 
			// txtBoxMoulSrcFilter
			// 
			this.txtBoxMoulSrcFilter.Location = new System.Drawing.Point(97, 52);
			this.txtBoxMoulSrcFilter.Name = "txtBoxMoulSrcFilter";
			this.txtBoxMoulSrcFilter.Size = new System.Drawing.Size(220, 20);
			this.txtBoxMoulSrcFilter.TabIndex = 4;
			// 
			// txtBoxMoulSrcPath
			// 
			this.txtBoxMoulSrcPath.Location = new System.Drawing.Point(97, 28);
			this.txtBoxMoulSrcPath.Name = "txtBoxMoulSrcPath";
			this.txtBoxMoulSrcPath.Size = new System.Drawing.Size(287, 20);
			this.txtBoxMoulSrcPath.TabIndex = 3;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(7, 53);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(84, 19);
			this.label15.TabIndex = 2;
			this.label15.Text = "filtre";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(7, 26);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(100, 23);
			this.label14.TabIndex = 1;
			this.label14.Text = "source";
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(492, 53);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "filtre";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 25);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(834, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.menuToolStripMenuItem.Text = "menu";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 545);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(834, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripLabel1,
			this.cygwinToolStripButton,
			this.toolStripSeparator1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(834, 25);
			this.toolStrip1.TabIndex = 3;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
			this.toolStripLabel1.Text = "cygWin";
			// 
			// cygwinToolStripButton
			// 
			this.cygwinToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cygwinToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cygwinToolStripButton.Image")));
			this.cygwinToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cygwinToolStripButton.Name = "cygwinToolStripButton";
			this.cygwinToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.cygwinToolStripButton.Text = "cygwin";
			this.cygwinToolStripButton.Click += new System.EventHandler(this.CygwinToolStripButtonClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(20, 290);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 23);
			this.label20.TabIndex = 35;
			this.label20.Text = "moulFichiers";
			// 
			// moulFichiersParam
			// 
			this.moulFichiersParam.Location = new System.Drawing.Point(131, 290);
			this.moulFichiersParam.Name = "moulFichiersParam";
			this.moulFichiersParam.Size = new System.Drawing.Size(642, 20);
			this.moulFichiersParam.TabIndex = 34;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(834, 567);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.toolStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "cmdUtils";
			this.tabs.ResumeLayout(false);
			this.tabParam.ResumeLayout(false);
			this.tabParam.PerformLayout();
			this.tabImport.ResumeLayout(false);
			this.tabImport.PerformLayout();
			this.tabSQL.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabMoulinettes.ResumeLayout(false);
			this.tabMoulinettes.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox moulFichiersParam;
		private System.Windows.Forms.Label docs;
		private System.Windows.Forms.TextBox txtBoxMoulDocs;
		private System.Windows.Forms.Label data;
		private System.Windows.Forms.TextBox txtBoxMoulData;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnMoulNavigDestBase;
		private System.Windows.Forms.Button btnMoulFilterSrc;
		private System.Windows.Forms.Label lmoulDstPath;
		private System.Windows.Forms.TextBox moulDstPathParam;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox moulScp1Param;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox moulScp2Param;
		private System.Windows.Forms.Label lmoulSrcPath;
		private System.Windows.Forms.TextBox moulSrcPathParam;
		private System.Windows.Forms.Button btnZip;
		private System.Windows.Forms.TextBox txtFinal;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ListBox listboxMoulSrc;
		private System.Windows.Forms.TextBox txtMagClient;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox txtMagId;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtBoxMoulDestBase;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtBoxMoulSrcFilter;
		private System.Windows.Forms.TextBox txtBoxMoulSrcPath;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.TabPage tabMoulinettes;
		private System.Windows.Forms.Button recreateButton;
		private System.Windows.Forms.CheckBox filedbCheckbox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox cygwinTermParam;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton cygwinToolStripButton;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button meoCreateFiledb;
		//private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.TabPage tabPdf;
		private System.Windows.Forms.TabPage tabSQL;
		private System.Windows.Forms.Label pdfLabel;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label11;
		private System.Data.DataSet dataSet1;
		private System.Windows.Forms.Button dropButton;
		private System.Windows.Forms.TextBox filterGzTextBox;
		private System.Windows.Forms.Button filterGzBtn;
		private System.Windows.Forms.ComboBox mysqlDatabaseCombo;
		private System.Windows.Forms.Button getMysqlDatabaseButton;
	}
}
