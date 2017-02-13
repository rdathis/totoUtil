/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 02/09/2016
 * Heure: 16:23:52
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MoulUtil
{
	partial class MouliActionForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.goButton = new System.Windows.Forms.Button();
			this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.listView1 = new System.Windows.Forms.ListView();
			this.pathLabel = new System.Windows.Forms.Label();
			this.uploadButton = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.targetTreeView = new System.Windows.Forms.TreeView();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.puttyLink = new System.Windows.Forms.LinkLabel();
			this.pscpLink = new System.Windows.Forms.LinkLabel();
			this.exitButton = new System.Windows.Forms.Button();
			this.launchCmdLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.raccoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.echangesmeomoulinettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wmeomoulinettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.echangesutilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.echangeftpmeoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.programmesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.puttiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.path = new System.Windows.Forms.Label();
			this.magIdTextBox = new System.Windows.Forms.TextBox();
			this.pathTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.targetLabel = new System.Windows.Forms.Label();
			this.magIrrisLabel = new System.Windows.Forms.Label();
			this.irrisMagTBox = new System.Windows.Forms.TextBox();
			this.purgeClientChkBox = new System.Windows.Forms.CheckBox();
			this.purgeStockChkBox = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// goButton
			// 
			this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.goButton.Location = new System.Drawing.Point(24, 377);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(75, 23);
			this.goButton.TabIndex = 0;
			this.goButton.Text = "goZip";
			this.goButton.UseVisualStyleBackColor = true;
			this.goButton.Click += new System.EventHandler(this.GoButtonClick);
			// 
			// dateTimePicker
			// 
			this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker.Location = new System.Drawing.Point(24, 79);
			this.dateTimePicker.Name = "dateTimePicker";
			this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker.TabIndex = 2;
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(187, 118);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(384, 161);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// pathLabel
			// 
			this.pathLabel.Location = new System.Drawing.Point(12, 13);
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(282, 23);
			this.pathLabel.TabIndex = 4;
			this.pathLabel.Text = "target";
			// 
			// uploadButton
			// 
			this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.uploadButton.Location = new System.Drawing.Point(106, 377);
			this.uploadButton.Name = "uploadButton";
			this.uploadButton.Size = new System.Drawing.Size(75, 23);
			this.uploadButton.TabIndex = 9;
			this.uploadButton.Text = "upload";
			this.uploadButton.UseVisualStyleBackColor = true;
			this.uploadButton.Click += new System.EventHandler(this.UploadButtonClick);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(6, 348);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(586, 23);
			this.progressBar1.TabIndex = 10;
			// 
			// targetTreeView
			// 
			this.targetTreeView.Location = new System.Drawing.Point(13, 118);
			this.targetTreeView.Name = "targetTreeView";
			this.targetTreeView.Size = new System.Drawing.Size(168, 161);
			this.targetTreeView.TabIndex = 11;
			this.targetTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TargetTreeViewAfterSelect);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Items.AddRange(new object[] {
			"clients (C)",
			"stock (S)",
			"Joint/ (J)",
			"ord01+doc01 (D)/"});
			this.checkedListBox1.Location = new System.Drawing.Point(460, 27);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(121, 79);
			this.checkedListBox1.TabIndex = 12;
			// 
			// puttyLink
			// 
			this.puttyLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.puttyLink.Location = new System.Drawing.Point(7, 319);
			this.puttyLink.Name = "puttyLink";
			this.puttyLink.Size = new System.Drawing.Size(84, 26);
			this.puttyLink.TabIndex = 13;
			this.puttyLink.TabStop = true;
			this.puttyLink.Text = "putty";
			this.puttyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PuttyLinkLinkClicked);
			this.puttyLink.Click += new System.EventHandler(this.PuttyLinkClick);
			// 
			// pscpLink
			// 
			this.pscpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pscpLink.Location = new System.Drawing.Point(97, 319);
			this.pscpLink.Name = "pscpLink";
			this.pscpLink.Size = new System.Drawing.Size(84, 26);
			this.pscpLink.TabIndex = 14;
			this.pscpLink.TabStop = true;
			this.pscpLink.Text = "pscp";
			this.pscpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PscpLinkLinkClicked);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Location = new System.Drawing.Point(438, 377);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(75, 23);
			this.exitButton.TabIndex = 1;
			this.exitButton.Text = "&Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
			// 
			// launchCmdLabel
			// 
			this.launchCmdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.launchCmdLabel.BackColor = System.Drawing.Color.Black;
			this.launchCmdLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.launchCmdLabel.Location = new System.Drawing.Point(537, 378);
			this.launchCmdLabel.Name = "launchCmdLabel";
			this.launchCmdLabel.Size = new System.Drawing.Size(44, 25);
			this.launchCmdLabel.TabIndex = 15;
			this.launchCmdLabel.Text = "Cmd";
			this.launchCmdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.launchCmdLabel.Click += new System.EventHandler(this.CmdLabelClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.raccoursToolStripMenuItem,
			this.programmesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(599, 24);
			this.menuStrip1.TabIndex = 17;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// raccoursToolStripMenuItem
			// 
			this.raccoursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.echangesmeomoulinettesToolStripMenuItem,
			this.wmeomoulinettesToolStripMenuItem,
			this.echangesutilisateursToolStripMenuItem,
			this.echangeftpmeoToolStripMenuItem});
			this.raccoursToolStripMenuItem.Name = "raccoursToolStripMenuItem";
			this.raccoursToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
			this.raccoursToolStripMenuItem.Text = "Raccourcis";
			// 
			// echangesmeomoulinettesToolStripMenuItem
			// 
			this.echangesmeomoulinettesToolStripMenuItem.Name = "echangesmeomoulinettesToolStripMenuItem";
			this.echangesmeomoulinettesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.echangesmeomoulinettesToolStripMenuItem.Text = "echanges/meo/moulinettes";
			// 
			// wmeomoulinettesToolStripMenuItem
			// 
			this.wmeomoulinettesToolStripMenuItem.Name = "wmeomoulinettesToolStripMenuItem";
			this.wmeomoulinettesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.wmeomoulinettesToolStripMenuItem.Text = "w:/meo-moulinettes";
			// 
			// echangesutilisateursToolStripMenuItem
			// 
			this.echangesutilisateursToolStripMenuItem.Name = "echangesutilisateursToolStripMenuItem";
			this.echangesutilisateursToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.echangesutilisateursToolStripMenuItem.Text = "echanges/utilisateurs";
			// 
			// echangeftpmeoToolStripMenuItem
			// 
			this.echangeftpmeoToolStripMenuItem.Name = "echangeftpmeoToolStripMenuItem";
			this.echangeftpmeoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.echangeftpmeoToolStripMenuItem.Text = "echange/ftp/meo";
			// 
			// programmesToolStripMenuItem
			// 
			this.programmesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.puttiesToolStripMenuItem,
			this.cmdToolStripMenuItem});
			this.programmesToolStripMenuItem.Name = "programmesToolStripMenuItem";
			this.programmesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
			this.programmesToolStripMenuItem.Text = "programmes";
			// 
			// puttiesToolStripMenuItem
			// 
			this.puttiesToolStripMenuItem.Name = "puttiesToolStripMenuItem";
			this.puttiesToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.puttiesToolStripMenuItem.Text = "putties";
			// 
			// cmdToolStripMenuItem
			// 
			this.cmdToolStripMenuItem.Name = "cmdToolStripMenuItem";
			this.cmdToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.cmdToolStripMenuItem.Text = "cmd";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1,
			this.toolStripProgressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 408);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(599, 22);
			this.statusStrip1.TabIndex = 18;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// path
			// 
			this.path.Location = new System.Drawing.Point(236, 79);
			this.path.Name = "path";
			this.path.Size = new System.Drawing.Size(58, 18);
			this.path.TabIndex = 19;
			this.path.Text = "magId";
			// 
			// magIdTextBox
			// 
			this.magIdTextBox.Location = new System.Drawing.Point(300, 76);
			this.magIdTextBox.Name = "magIdTextBox";
			this.magIdTextBox.Size = new System.Drawing.Size(154, 20);
			this.magIdTextBox.TabIndex = 20;
			// 
			// pathTextBox
			// 
			this.pathTextBox.Location = new System.Drawing.Point(300, 47);
			this.pathTextBox.Name = "pathTextBox";
			this.pathTextBox.Size = new System.Drawing.Size(154, 20);
			this.pathTextBox.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(236, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 18);
			this.label2.TabIndex = 21;
			this.label2.Text = "path";
			// 
			// targetLabel
			// 
			this.targetLabel.Location = new System.Drawing.Point(236, 99);
			this.targetLabel.Name = "targetLabel";
			this.targetLabel.Size = new System.Drawing.Size(218, 16);
			this.targetLabel.TabIndex = 23;
			this.targetLabel.Text = "Destination";
			// 
			// magIrrisLabel
			// 
			this.magIrrisLabel.Location = new System.Drawing.Point(37, 46);
			this.magIrrisLabel.Name = "magIrrisLabel";
			this.magIrrisLabel.Size = new System.Drawing.Size(83, 22);
			this.magIrrisLabel.TabIndex = 24;
			this.magIrrisLabel.Text = "mag Irris";
			// 
			// irrisMagTBox
			// 
			this.irrisMagTBox.Location = new System.Drawing.Point(126, 46);
			this.irrisMagTBox.MaxLength = 2;
			this.irrisMagTBox.Name = "irrisMagTBox";
			this.irrisMagTBox.Size = new System.Drawing.Size(97, 20);
			this.irrisMagTBox.TabIndex = 25;
			// 
			// purgeClientChkBox
			// 
			this.purgeClientChkBox.Location = new System.Drawing.Point(149, 23);
			this.purgeClientChkBox.Name = "purgeClientChkBox";
			this.purgeClientChkBox.Size = new System.Drawing.Size(89, 24);
			this.purgeClientChkBox.TabIndex = 26;
			this.purgeClientChkBox.Text = "purger Client";
			this.purgeClientChkBox.UseVisualStyleBackColor = true;
			// 
			// purgeStockChkBox
			// 
			this.purgeStockChkBox.Location = new System.Drawing.Point(254, 23);
			this.purgeStockChkBox.Name = "purgeStockChkBox";
			this.purgeStockChkBox.Size = new System.Drawing.Size(89, 24);
			this.purgeStockChkBox.TabIndex = 27;
			this.purgeStockChkBox.Text = "purger Stock";
			this.purgeStockChkBox.UseVisualStyleBackColor = true;
			// 
			// MouliActionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(599, 430);
			this.Controls.Add(this.purgeStockChkBox);
			this.Controls.Add(this.purgeClientChkBox);
			this.Controls.Add(this.irrisMagTBox);
			this.Controls.Add(this.magIrrisLabel);
			this.Controls.Add(this.targetLabel);
			this.Controls.Add(this.pathTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.magIdTextBox);
			this.Controls.Add(this.path);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.launchCmdLabel);
			this.Controls.Add(this.pscpLink);
			this.Controls.Add(this.puttyLink);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.targetTreeView);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.uploadButton);
			this.Controls.Add(this.pathLabel);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.dateTimePicker);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.goButton);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MouliActionForm";
			this.Text = "MouliActionForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.CheckBox purgeStockChkBox;
		private System.Windows.Forms.CheckBox purgeClientChkBox;
		private System.Windows.Forms.TextBox irrisMagTBox;
		private System.Windows.Forms.Label magIrrisLabel;
		private System.Windows.Forms.Label targetLabel;
		private System.Windows.Forms.TextBox pathTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label path;
		private System.Windows.Forms.TextBox magIdTextBox;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem programmesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem puttiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cmdToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem echangesmeomoulinettesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wmeomoulinettesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem echangesutilisateursToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem echangeftpmeoToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem raccoursToolStripMenuItem;
		private System.Windows.Forms.LinkLabel pscpLink;

		private System.Windows.Forms.LinkLabel puttyLink;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TreeView targetTreeView;
		private System.Windows.Forms.Button uploadButton;
		private System.Windows.Forms.Label pathLabel;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.Label launchCmdLabel;
	}
}
