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
			this.pathLabel = new System.Windows.Forms.Label();
			this.uploadButton = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
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
			this.magIrrisLabel = new System.Windows.Forms.Label();
			this.irrisMagTBox = new System.Windows.Forms.TextBox();
			this.purgeClientChkBox = new System.Windows.Forms.CheckBox();
			this.purgeStockChkBox = new System.Windows.Forms.CheckBox();
			this.progressTextBox = new System.Windows.Forms.TextBox();
			this.installBtn = new System.Windows.Forms.Button();
			this.optionCCheckBox = new System.Windows.Forms.CheckBox();
			this.optionSCheckBox = new System.Windows.Forms.CheckBox();
			this.optionJCheckBox = new System.Windows.Forms.CheckBox();
			this.optionS1CheckBox = new System.Windows.Forms.CheckBox();
			this.optionC1CheckBox = new System.Windows.Forms.CheckBox();
			this.optionDCheckBox = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.emailTextbox = new System.Windows.Forms.TextBox();
			this.visuJobLabel = new System.Windows.Forms.Label();
			this.visuScriptLabel = new System.Windows.Forms.Label();
			this.visuRichTexBox = new System.Windows.Forms.RichTextBox();
			this.cibleLabel = new System.Windows.Forms.Label();
			this.analyseLabel = new System.Windows.Forms.Label();
			this.propositionMailsListBox = new System.Windows.Forms.ListBox();
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
			this.progressBar1.Size = new System.Drawing.Size(713, 23);
			this.progressBar1.TabIndex = 10;
			// 
			// puttyLink
			// 
			this.puttyLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.puttyLink.Location = new System.Drawing.Point(16, 297);
			this.puttyLink.Name = "puttyLink";
			this.puttyLink.Size = new System.Drawing.Size(84, 20);
			this.puttyLink.TabIndex = 13;
			this.puttyLink.TabStop = true;
			this.puttyLink.Text = "putty";
			this.puttyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PuttyLinkLinkClicked);
			this.puttyLink.Click += new System.EventHandler(this.PuttyLinkClick);
			// 
			// pscpLink
			// 
			this.pscpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.pscpLink.Location = new System.Drawing.Point(106, 297);
			this.pscpLink.Name = "pscpLink";
			this.pscpLink.Size = new System.Drawing.Size(84, 20);
			this.pscpLink.TabIndex = 14;
			this.pscpLink.TabStop = true;
			this.pscpLink.Text = "pscp";
			this.pscpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PscpLinkLinkClicked);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.Location = new System.Drawing.Point(565, 377);
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
			this.launchCmdLabel.Location = new System.Drawing.Point(664, 378);
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
			this.menuStrip1.Size = new System.Drawing.Size(726, 24);
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
			this.wmeomoulinettesToolStripMenuItem.Text = "?";
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
			this.statusStrip1.Size = new System.Drawing.Size(726, 22);
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
			// progressTextBox
			// 
			this.progressTextBox.Location = new System.Drawing.Point(6, 322);
			this.progressTextBox.Name = "progressTextBox";
			this.progressTextBox.Size = new System.Drawing.Size(586, 20);
			this.progressTextBox.TabIndex = 28;
			// 
			// installBtn
			// 
			this.installBtn.Location = new System.Drawing.Point(187, 377);
			this.installBtn.Name = "installBtn";
			this.installBtn.Size = new System.Drawing.Size(92, 23);
			this.installBtn.TabIndex = 29;
			this.installBtn.Text = "&Install Job";
			this.installBtn.UseVisualStyleBackColor = true;
			this.installBtn.Click += new System.EventHandler(this.InstallBtnClick);
			// 
			// optionCCheckBox
			// 
			this.optionCCheckBox.Location = new System.Drawing.Point(24, 132);
			this.optionCCheckBox.Name = "optionCCheckBox";
			this.optionCCheckBox.Size = new System.Drawing.Size(131, 17);
			this.optionCCheckBox.TabIndex = 30;
			this.optionCCheckBox.Text = "C - Clients";
			this.optionCCheckBox.UseVisualStyleBackColor = true;
			this.optionCCheckBox.CheckedChanged += new System.EventHandler(this.OptionCCheckBoxCheckedChanged);
			// 
			// optionSCheckBox
			// 
			this.optionSCheckBox.Location = new System.Drawing.Point(24, 150);
			this.optionSCheckBox.Name = "optionSCheckBox";
			this.optionSCheckBox.Size = new System.Drawing.Size(131, 17);
			this.optionSCheckBox.TabIndex = 31;
			this.optionSCheckBox.Text = "S - Stock";
			this.optionSCheckBox.UseVisualStyleBackColor = true;
			this.optionSCheckBox.CheckedChanged += new System.EventHandler(this.OptionSCheckBoxCheckedChanged);
			// 
			// optionJCheckBox
			// 
			this.optionJCheckBox.Location = new System.Drawing.Point(24, 170);
			this.optionJCheckBox.Name = "optionJCheckBox";
			this.optionJCheckBox.Size = new System.Drawing.Size(131, 17);
			this.optionJCheckBox.TabIndex = 32;
			this.optionJCheckBox.Text = "J - Joints";
			this.optionJCheckBox.UseVisualStyleBackColor = true;
			this.optionJCheckBox.CheckedChanged += new System.EventHandler(this.OptionJCheckBoxCheckedChanged);
			// 
			// optionS1CheckBox
			// 
			this.optionS1CheckBox.ForeColor = System.Drawing.Color.Red;
			this.optionS1CheckBox.Location = new System.Drawing.Point(24, 236);
			this.optionS1CheckBox.Name = "optionS1CheckBox";
			this.optionS1CheckBox.Size = new System.Drawing.Size(148, 25);
			this.optionS1CheckBox.TabIndex = 35;
			this.optionS1CheckBox.Text = "S1 - annulation M. Stock";
			this.optionS1CheckBox.UseVisualStyleBackColor = true;
			this.optionS1CheckBox.CheckedChanged += new System.EventHandler(this.OptionS1CheckBoxCheckedChanged);
			// 
			// optionC1CheckBox
			// 
			this.optionC1CheckBox.ForeColor = System.Drawing.Color.Red;
			this.optionC1CheckBox.Location = new System.Drawing.Point(24, 216);
			this.optionC1CheckBox.Name = "optionC1CheckBox";
			this.optionC1CheckBox.Size = new System.Drawing.Size(162, 24);
			this.optionC1CheckBox.TabIndex = 34;
			this.optionC1CheckBox.Text = "C1 - annulation M. Clients";
			this.optionC1CheckBox.UseVisualStyleBackColor = true;
			this.optionC1CheckBox.CheckedChanged += new System.EventHandler(this.OptionCC1heckBoxCheckedChanged);
			// 
			// optionDCheckBox
			// 
			this.optionDCheckBox.Location = new System.Drawing.Point(25, 193);
			this.optionDCheckBox.Name = "optionDCheckBox";
			this.optionDCheckBox.Size = new System.Drawing.Size(131, 17);
			this.optionDCheckBox.TabIndex = 33;
			this.optionDCheckBox.Text = "D - Docs irris";
			this.optionDCheckBox.UseVisualStyleBackColor = true;
			this.optionDCheckBox.CheckedChanged += new System.EventHandler(this.OptionDCheckBoxCheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(171, 295);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 21);
			this.label1.TabIndex = 36;
			this.label1.Text = "email";
			// 
			// emailTextbox
			// 
			this.emailTextbox.Location = new System.Drawing.Point(200, 295);
			this.emailTextbox.Name = "emailTextbox";
			this.emailTextbox.Size = new System.Drawing.Size(392, 20);
			this.emailTextbox.TabIndex = 37;
			// 
			// visuJobLabel
			// 
			this.visuJobLabel.Location = new System.Drawing.Point(614, 276);
			this.visuJobLabel.Name = "visuJobLabel";
			this.visuJobLabel.Size = new System.Drawing.Size(104, 21);
			this.visuJobLabel.TabIndex = 38;
			this.visuJobLabel.Text = "visu Job";
			this.visuJobLabel.Click += new System.EventHandler(this.VisuJobLabelClick);
			// 
			// visuScriptLabel
			// 
			this.visuScriptLabel.Location = new System.Drawing.Point(614, 295);
			this.visuScriptLabel.Name = "visuScriptLabel";
			this.visuScriptLabel.Size = new System.Drawing.Size(104, 21);
			this.visuScriptLabel.TabIndex = 39;
			this.visuScriptLabel.Text = "visu Script";
			this.visuScriptLabel.Click += new System.EventHandler(this.VisuScriptLabelClick);
			// 
			// visuRichTexBox
			// 
			this.visuRichTexBox.Location = new System.Drawing.Point(608, 177);
			this.visuRichTexBox.Name = "visuRichTexBox";
			this.visuRichTexBox.Size = new System.Drawing.Size(100, 96);
			this.visuRichTexBox.TabIndex = 40;
			this.visuRichTexBox.Text = "";
			this.visuRichTexBox.Visible = false;
			// 
			// cibleLabel
			// 
			this.cibleLabel.Location = new System.Drawing.Point(195, 102);
			this.cibleLabel.Name = "cibleLabel";
			this.cibleLabel.Size = new System.Drawing.Size(259, 22);
			this.cibleLabel.TabIndex = 41;
			// 
			// analyseLabel
			// 
			this.analyseLabel.BackColor = System.Drawing.Color.SeaShell;
			this.analyseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.analyseLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.analyseLabel.Location = new System.Drawing.Point(20, 104);
			this.analyseLabel.Name = "analyseLabel";
			this.analyseLabel.Size = new System.Drawing.Size(151, 28);
			this.analyseLabel.TabIndex = 42;
			this.analyseLabel.Text = "Analyse";
			this.analyseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.analyseLabel.Click += new System.EventHandler(this.AnalyseLabelClick);
			// 
			// propositionMailsListBox
			// 
			this.propositionMailsListBox.FormattingEnabled = true;
			this.propositionMailsListBox.Location = new System.Drawing.Point(200, 246);
			this.propositionMailsListBox.Name = "propositionMailsListBox";
			this.propositionMailsListBox.Size = new System.Drawing.Size(391, 43);
			this.propositionMailsListBox.TabIndex = 43;
			this.propositionMailsListBox.DoubleClick += new System.EventHandler(this.PropositionMailsListBoxDoubleClick);
			// 
			// MouliActionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(726, 430);
			this.Controls.Add(this.propositionMailsListBox);
			this.Controls.Add(this.analyseLabel);
			this.Controls.Add(this.cibleLabel);
			this.Controls.Add(this.visuRichTexBox);
			this.Controls.Add(this.visuScriptLabel);
			this.Controls.Add(this.visuJobLabel);
			this.Controls.Add(this.emailTextbox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.optionS1CheckBox);
			this.Controls.Add(this.optionC1CheckBox);
			this.Controls.Add(this.optionDCheckBox);
			this.Controls.Add(this.optionJCheckBox);
			this.Controls.Add(this.optionSCheckBox);
			this.Controls.Add(this.optionCCheckBox);
			this.Controls.Add(this.installBtn);
			this.Controls.Add(this.progressTextBox);
			this.Controls.Add(this.purgeStockChkBox);
			this.Controls.Add(this.purgeClientChkBox);
			this.Controls.Add(this.irrisMagTBox);
			this.Controls.Add(this.magIrrisLabel);
			this.Controls.Add(this.pathTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.magIdTextBox);
			this.Controls.Add(this.path);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.launchCmdLabel);
			this.Controls.Add(this.pscpLink);
			this.Controls.Add(this.puttyLink);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.uploadButton);
			this.Controls.Add(this.pathLabel);
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
		private System.Windows.Forms.ListBox propositionMailsListBox;
		private System.Windows.Forms.Label analyseLabel;

		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.TextBox irrisMagTBox;
		private System.Windows.Forms.CheckBox purgeClientChkBox;
		private System.Windows.Forms.CheckBox purgeStockChkBox;
		private System.Windows.Forms.CheckBox optionSCheckBox;
		private System.Windows.Forms.CheckBox optionS1CheckBox;
		private System.Windows.Forms.Button installBtn;
		private System.Windows.Forms.ToolStripMenuItem programmesToolStripMenuItem;
		private System.Windows.Forms.Label cibleLabel;
		private System.Windows.Forms.ToolStripMenuItem puttiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem echangesmeomoulinettesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cmdToolStripMenuItem;
		private System.Windows.Forms.TextBox emailTextbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TextBox magIdTextBox;
		private System.Windows.Forms.ToolStripMenuItem wmeomoulinettesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem echangesutilisateursToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem echangeftpmeoToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem raccoursToolStripMenuItem;
		private System.Windows.Forms.LinkLabel pscpLink;
		private System.Windows.Forms.Label path;
		private System.Windows.Forms.Label magIrrisLabel;
		private System.Windows.Forms.TextBox progressTextBox;
		private System.Windows.Forms.CheckBox optionC1CheckBox;
		private System.Windows.Forms.CheckBox optionDCheckBox;

		private System.Windows.Forms.LinkLabel puttyLink;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button uploadButton;
		private System.Windows.Forms.Label pathLabel;
		private System.Windows.Forms.DateTimePicker dateTimePicker;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.Label launchCmdLabel;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.TextBox pathTextBox;
		private System.Windows.Forms.CheckBox optionCCheckBox;
		private System.Windows.Forms.CheckBox optionJCheckBox;
		private System.Windows.Forms.RichTextBox visuRichTexBox;
		private System.Windows.Forms.Label label1;
		
		private System.Windows.Forms.Label visuJobLabel;
		private System.Windows.Forms.Label visuScriptLabel;
	}
}

