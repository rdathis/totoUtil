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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.dataSet1 = new System.Data.DataSet();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.cygwinToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tabs.SuspendLayout();
			this.tabParam.SuspendLayout();
			this.tabImport.SuspendLayout();
			this.tabSQL.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
			this.tabs.Location = new System.Drawing.Point(12, 27);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(822, 515);
			this.tabs.TabIndex = 0;
			this.tabs.Click += new System.EventHandler(this.tabImportClick);
			// 
			// tabParam
			// 
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
			this.label12.Location = new System.Drawing.Point(62, 331);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(433, 23);
			this.label12.TabIndex = 23;
			this.label12.Text = "cat `cygpath -W`/Media/ding.wav > /dev/dsp";
			// 
			// pdfLabel
			// 
			this.pdfLabel.Location = new System.Drawing.Point(54, 263);
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
			this.labelFichierConfig.Location = new System.Drawing.Point(54, 394);
			this.labelFichierConfig.Name = "labelFichierConfig";
			this.labelFichierConfig.Size = new System.Drawing.Size(678, 23);
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
			this.filterGzTextBox.Location = new System.Drawing.Point(519, 37);
			this.filterGzTextBox.Name = "filterGzTextBox";
			this.filterGzTextBox.Size = new System.Drawing.Size(196, 20);
			this.filterGzTextBox.TabIndex = 12;
			// 
			// filterGzBtn
			// 
			this.filterGzBtn.Location = new System.Drawing.Point(721, 34);
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
			this.dumpsListBox.FormattingEnabled = true;
			this.dumpsListBox.Location = new System.Drawing.Point(6, 70);
			this.dumpsListBox.Name = "dumpsListBox";
			this.dumpsListBox.Size = new System.Drawing.Size(765, 95);
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
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
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
