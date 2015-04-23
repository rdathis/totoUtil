/*
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button2;
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
			this.tabs = new System.Windows.Forms.TabControl();
			this.tabParam = new System.Windows.Forms.TabPage();
			this.labelFichierConfig = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
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
			this.button2 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.reloadButton = new System.Windows.Forms.Button();
			this.defConfigButton = new System.Windows.Forms.Button();
			this.tabs.SuspendLayout();
			this.tabParam.SuspendLayout();
			this.tabImport.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabParam);
			this.tabs.Controls.Add(this.tabImport);
			this.tabs.Location = new System.Drawing.Point(12, 27);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(787, 475);
			this.tabs.TabIndex = 0;
			// 
			// tabParam
			// 
			this.tabParam.Controls.Add(this.defConfigButton);
			this.tabParam.Controls.Add(this.reloadButton);
			this.tabParam.Controls.Add(this.labelFichierConfig);
			this.tabParam.Controls.Add(this.button1);
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
			this.tabParam.Size = new System.Drawing.Size(779, 449);
			this.tabParam.TabIndex = 0;
			this.tabParam.Text = "Params";
			this.tabParam.UseVisualStyleBackColor = true;
			this.tabParam.Click += new System.EventHandler(this.TabParamClick);
			// 
			// labelFichierConfig
			// 
			this.labelFichierConfig.Location = new System.Drawing.Point(54, 394);
			this.labelFichierConfig.Name = "labelFichierConfig";
			this.labelFichierConfig.Size = new System.Drawing.Size(678, 23);
			this.labelFichierConfig.TabIndex = 15;
			this.labelFichierConfig.Text = "?";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(328, 356);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(20, 137);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "user@my";
			// 
			// mysqlUserParam
			// 
			this.mysqlUserParam.Location = new System.Drawing.Point(131, 137);
			this.mysqlUserParam.Name = "mysqlUserParam";
			this.mysqlUserParam.Size = new System.Drawing.Size(642, 20);
			this.mysqlUserParam.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(20, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "pwd@my";
			// 
			// mysqlPasswordParam
			// 
			this.mysqlPasswordParam.Location = new System.Drawing.Point(131, 163);
			this.mysqlPasswordParam.Name = "mysqlPasswordParam";
			this.mysqlPasswordParam.Size = new System.Drawing.Size(642, 20);
			this.mysqlPasswordParam.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 186);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "scriptsSQL";
			// 
			// scriptCreateFiledDBParam
			// 
			this.scriptCreateFiledDBParam.Location = new System.Drawing.Point(131, 189);
			this.scriptCreateFiledDBParam.Name = "scriptCreateFiledDBParam";
			this.scriptCreateFiledDBParam.Size = new System.Drawing.Size(642, 20);
			this.scriptCreateFiledDBParam.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(20, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "scriptsSQL";
			// 
			// scriptCreateDbParam
			// 
			this.scriptCreateDbParam.Location = new System.Drawing.Point(131, 111);
			this.scriptCreateDbParam.Name = "scriptCreateDbParam";
			this.scriptCreateDbParam.Size = new System.Drawing.Size(642, 20);
			this.scriptCreateDbParam.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 85);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "datas";
			// 
			// dataParam
			// 
			this.dataParam.Location = new System.Drawing.Point(131, 85);
			this.dataParam.Name = "dataParam";
			this.dataParam.Size = new System.Drawing.Size(642, 20);
			this.dataParam.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "mysql";
			// 
			// mysqlParam
			// 
			this.mysqlParam.Location = new System.Drawing.Point(131, 59);
			this.mysqlParam.Name = "mysqlParam";
			this.mysqlParam.Size = new System.Drawing.Size(642, 20);
			this.mysqlParam.TabIndex = 2;
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
			this.tabImport.Controls.Add(this.button2);
			this.tabImport.Controls.Add(this.richTextBox1);
			this.tabImport.Controls.Add(this.textBox10);
			this.tabImport.Controls.Add(this.label10);
			this.tabImport.Controls.Add(this.textBox9);
			this.tabImport.Controls.Add(this.label9);
			this.tabImport.Controls.Add(this.textBox8);
			this.tabImport.Controls.Add(this.label8);
			this.tabImport.Controls.Add(this.listBox1);
			this.tabImport.Location = new System.Drawing.Point(4, 22);
			this.tabImport.Name = "tabImport";
			this.tabImport.Padding = new System.Windows.Forms.Padding(3);
			this.tabImport.Size = new System.Drawing.Size(779, 449);
			this.tabImport.TabIndex = 1;
			this.tabImport.Text = "tabImport";
			this.tabImport.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(31, 223);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(152, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "&lancer";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(6, 252);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(770, 181);
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
			this.textBox9.Location = new System.Drawing.Point(114, 44);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(355, 20);
			this.textBox9.TabIndex = 4;
			this.textBox9.Text = "dropt if exist ; create database;";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(7, 34);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(100, 23);
			this.label9.TabIndex = 3;
			this.label9.Text = "script avant";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(114, 9);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(355, 20);
			this.textBox8.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(7, 7);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 1;
			this.label8.Text = "database";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(6, 70);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(765, 95);
			this.listBox1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.menuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(799, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "menu";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 517);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(799, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// reloadButton
			// 
			this.reloadButton.Location = new System.Drawing.Point(424, 356);
			this.reloadButton.Name = "reloadButton";
			this.reloadButton.Size = new System.Drawing.Size(75, 23);
			this.reloadButton.TabIndex = 16;
			this.reloadButton.Text = "&reload";
			this.reloadButton.UseVisualStyleBackColor = true;
			// 
			// defConfigButton
			// 
			this.defConfigButton.Location = new System.Drawing.Point(520, 356);
			this.defConfigButton.Name = "defConfigButton";
			this.defConfigButton.Size = new System.Drawing.Size(75, 23);
			this.defConfigButton.TabIndex = 18;
			this.defConfigButton.Text = "&defConfig";
			this.defConfigButton.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 539);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "cmdUtils";
			this.tabs.ResumeLayout(false);
			this.tabParam.ResumeLayout(false);
			this.tabParam.PerformLayout();
			this.tabImport.ResumeLayout(false);
			this.tabImport.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
