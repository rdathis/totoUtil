/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/10/2016
 * Heure: 13:28:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace MoulUtil
{
	partial class MouliPrepaForm
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
		/// not be able to load this method iit was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.rechMagIdBtn = new System.Windows.Forms.Button();
			this.rechMagIdBox = new System.Windows.Forms.TextBox();
			this.sourceBaseBox = new System.Windows.Forms.TextBox();
			this.sourceFilterBox = new System.Windows.Forms.TextBox();
			this.magDescBox = new System.Windows.Forms.TextBox();
			this.sourceListBox = new System.Windows.Forms.ListBox();
			this.workspaceBaseBox = new System.Windows.Forms.TextBox();
			this.workspaceZoneBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.workingDirBox = new System.Windows.Forms.TextBox();
			this.workspaceLabel = new System.Windows.Forms.Label();
			this.createBtn = new System.Windows.Forms.Button();
			this.propositionBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.workspaceNavigatorUserControl = new cmdUtils.Controles.NavigatorUserControl();
			this.navigatorUserControl2 = new cmdUtils.Controles.NavigatorUserControl();
			this.zonePrepaNavigatorUserControl = new cmdUtils.Controles.NavigatorUserControl();
			this.prepareBtn = new System.Windows.Forms.Button();
			this.userControl11 = new cmdUtils.TotoRectangle();
			this.targetNameBox = new System.Windows.Forms.TextBox();
			this.targetSvgPathBox = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.sauvegardeProgressTextBox = new System.Windows.Forms.TextBox();
			this.svgFinalNavigatorUserControl = new cmdUtils.Controles.NavigatorUserControl();
			this.svgBaseNavigatorUserControl = new cmdUtils.Controles.NavigatorUserControl();
			this.sauvegardeBtn = new System.Windows.Forms.Button();
			this.userControl12 = new cmdUtils.TotoRectangle();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolTipLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.copyBtn = new System.Windows.Forms.Button();
			this.sqlBtn = new System.Windows.Forms.Button();
			this.configBtn = new System.Windows.Forms.Button();
			this.targetTreeView = new System.Windows.Forms.TreeView();
			this.serveursContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mysqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.puttyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.historyLabel = new System.Windows.Forms.Label();
			this.connectTimer = new System.Windows.Forms.Timer(this.components);
			this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.serveursContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// rechMagIdBtn
			// 
			this.rechMagIdBtn.Location = new System.Drawing.Point(130, 49);
			this.rechMagIdBtn.Name = "rechMagIdBtn";
			this.rechMagIdBtn.Size = new System.Drawing.Size(75, 23);
			this.rechMagIdBtn.TabIndex = 1;
			this.rechMagIdBtn.Text = "recherche";
			this.rechMagIdBtn.UseVisualStyleBackColor = true;
			this.rechMagIdBtn.Click += new System.EventHandler(this.RechMagIdBtnClick);
			// 
			// rechMagIdBox
			// 
			this.rechMagIdBox.AcceptsReturn = true;
			this.rechMagIdBox.Location = new System.Drawing.Point(12, 49);
			this.rechMagIdBox.Name = "rechMagIdBox";
			this.rechMagIdBox.Size = new System.Drawing.Size(108, 20);
			this.rechMagIdBox.TabIndex = 0;
			this.rechMagIdBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RechMagIdBoxKeyUp);
			// 
			// sourceBaseBox
			// 
			this.sourceBaseBox.Location = new System.Drawing.Point(13, 12);
			this.sourceBaseBox.Name = "sourceBaseBox";
			this.sourceBaseBox.Size = new System.Drawing.Size(292, 20);
			this.sourceBaseBox.TabIndex = 2;
			// 
			// sourceFilterBox
			// 
			this.sourceFilterBox.Location = new System.Drawing.Point(312, 12);
			this.sourceFilterBox.Name = "sourceFilterBox";
			this.sourceFilterBox.Size = new System.Drawing.Size(325, 20);
			this.sourceFilterBox.TabIndex = 3;
			// 
			// magDescBox
			// 
			this.magDescBox.Location = new System.Drawing.Point(311, 13);
			this.magDescBox.Multiline = true;
			this.magDescBox.Name = "magDescBox";
			this.magDescBox.Size = new System.Drawing.Size(325, 85);
			this.magDescBox.TabIndex = 4;
			// 
			// sourceListBox
			// 
			this.sourceListBox.Enabled = false;
			this.sourceListBox.FormattingEnabled = true;
			this.sourceListBox.Location = new System.Drawing.Point(37, 149);
			this.sourceListBox.Name = "sourceListBox";
			this.sourceListBox.Size = new System.Drawing.Size(624, 95);
			this.sourceListBox.TabIndex = 8;
			// 
			// workspaceBaseBox
			// 
			this.workspaceBaseBox.Location = new System.Drawing.Point(13, 23);
			this.workspaceBaseBox.Name = "workspaceBaseBox";
			this.workspaceBaseBox.Size = new System.Drawing.Size(292, 20);
			this.workspaceBaseBox.TabIndex = 6;
			this.workspaceBaseBox.Text = "?";
			// 
			// workspaceZoneBox
			// 
			this.workspaceZoneBox.Location = new System.Drawing.Point(311, 23);
			this.workspaceZoneBox.Name = "workspaceZoneBox";
			this.workspaceZoneBox.Size = new System.Drawing.Size(325, 20);
			this.workspaceZoneBox.TabIndex = 7;
			this.workspaceZoneBox.TextChanged += new System.EventHandler(this.WorkspaceBoxTextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.workingDirBox);
			this.groupBox1.Controls.Add(this.workspaceLabel);
			this.groupBox1.Controls.Add(this.createBtn);
			this.groupBox1.Controls.Add(this.propositionBox);
			this.groupBox1.Controls.Add(this.magDescBox);
			this.groupBox1.Controls.Add(this.rechMagIdBtn);
			this.groupBox1.Controls.Add(this.rechMagIdBox);
			this.groupBox1.Location = new System.Drawing.Point(25, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(644, 105);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "rechercheMagasin";
			// 
			// workingDirBox
			// 
			this.workingDirBox.Location = new System.Drawing.Point(103, 19);
			this.workingDirBox.Name = "workingDirBox";
			this.workingDirBox.Size = new System.Drawing.Size(179, 20);
			this.workingDirBox.TabIndex = 8;
			// 
			// workspaceLabel
			// 
			this.workspaceLabel.Location = new System.Drawing.Point(8, 19);
			this.workspaceLabel.Name = "workspaceLabel";
			this.workspaceLabel.Size = new System.Drawing.Size(89, 20);
			this.workspaceLabel.TabIndex = 7;
			this.workspaceLabel.Text = "workspace";
			// 
			// createBtn
			// 
			this.createBtn.Location = new System.Drawing.Point(253, 76);
			this.createBtn.Name = "createBtn";
			this.createBtn.Size = new System.Drawing.Size(51, 23);
			this.createBtn.TabIndex = 6;
			this.createBtn.Text = "&Create";
			this.createBtn.UseVisualStyleBackColor = true;
			this.createBtn.Click += new System.EventHandler(this.CreateBtnClick);
			// 
			// propositionBox
			// 
			this.propositionBox.Location = new System.Drawing.Point(13, 78);
			this.propositionBox.Name = "propositionBox";
			this.propositionBox.Size = new System.Drawing.Size(234, 20);
			this.propositionBox.TabIndex = 5;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.sourceBaseBox);
			this.groupBox2.Controls.Add(this.sourceFilterBox);
			this.groupBox2.Location = new System.Drawing.Point(24, 111);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(644, 142);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "source";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.workspaceNavigatorUserControl);
			this.groupBox3.Controls.Add(this.navigatorUserControl2);
			this.groupBox3.Controls.Add(this.zonePrepaNavigatorUserControl);
			this.groupBox3.Controls.Add(this.prepareBtn);
			this.groupBox3.Controls.Add(this.workspaceBaseBox);
			this.groupBox3.Controls.Add(this.workspaceZoneBox);
			this.groupBox3.Controls.Add(this.userControl11);
			this.groupBox3.Location = new System.Drawing.Point(25, 261);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(644, 43);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Zone préparation";
			// 
			// workspaceNavigatorUserControl
			// 
			this.workspaceNavigatorUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.workspaceNavigatorUserControl.Location = new System.Drawing.Point(334, 1);
			this.workspaceNavigatorUserControl.Name = "workspaceNavigatorUserControl";
			this.workspaceNavigatorUserControl.Size = new System.Drawing.Size(85, 23);
			this.workspaceNavigatorUserControl.TabIndex = 19;
			// 
			// navigatorUserControl2
			// 
			this.navigatorUserControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.navigatorUserControl2.Location = new System.Drawing.Point(177, 16);
			this.navigatorUserControl2.Name = "navigatorUserControl2";
			this.navigatorUserControl2.Size = new System.Drawing.Size(8, 8);
			this.navigatorUserControl2.TabIndex = 18;
			// 
			// zonePrepaNavigatorUserControl
			// 
			this.zonePrepaNavigatorUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.zonePrepaNavigatorUserControl.Location = new System.Drawing.Point(130, 0);
			this.zonePrepaNavigatorUserControl.Name = "zonePrepaNavigatorUserControl";
			this.zonePrepaNavigatorUserControl.Size = new System.Drawing.Size(85, 23);
			this.zonePrepaNavigatorUserControl.TabIndex = 17;
			// 
			// prepareBtn
			// 
			this.prepareBtn.Location = new System.Drawing.Point(562, 0);
			this.prepareBtn.Name = "prepareBtn";
			this.prepareBtn.Size = new System.Drawing.Size(75, 23);
			this.prepareBtn.TabIndex = 13;
			this.prepareBtn.Text = "&Prepare";
			this.prepareBtn.UseVisualStyleBackColor = true;
			this.prepareBtn.Click += new System.EventHandler(this.PrepareBtnClick);
			// 
			// userControl11
			// 
			this.userControl11.BackColor = System.Drawing.Color.Red;
			this.userControl11.Location = new System.Drawing.Point(312, 0);
			this.userControl11.Name = "userControl11";
			this.userControl11.Size = new System.Drawing.Size(332, 59);
			this.userControl11.TabIndex = 16;
			// 
			// targetNameBox
			// 
			this.targetNameBox.Location = new System.Drawing.Point(311, 23);
			this.targetNameBox.Name = "targetNameBox";
			this.targetNameBox.Size = new System.Drawing.Size(325, 20);
			this.targetNameBox.TabIndex = 12;
			// 
			// targetSvgPathBox
			// 
			this.targetSvgPathBox.Location = new System.Drawing.Point(12, 23);
			this.targetSvgPathBox.Name = "targetSvgPathBox";
			this.targetSvgPathBox.Size = new System.Drawing.Size(292, 20);
			this.targetSvgPathBox.TabIndex = 11;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.sauvegardeProgressTextBox);
			this.groupBox4.Controls.Add(this.svgFinalNavigatorUserControl);
			this.groupBox4.Controls.Add(this.svgBaseNavigatorUserControl);
			this.groupBox4.Controls.Add(this.sauvegardeBtn);
			this.groupBox4.Controls.Add(this.targetNameBox);
			this.groupBox4.Controls.Add(this.targetSvgPathBox);
			this.groupBox4.Controls.Add(this.userControl12);
			this.groupBox4.Location = new System.Drawing.Point(25, 320);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(644, 76);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Sauvegarde";
			// 
			// sauvegardeProgressTextBox
			// 
			this.sauvegardeProgressTextBox.Location = new System.Drawing.Point(13, 51);
			this.sauvegardeProgressTextBox.Multiline = true;
			this.sauvegardeProgressTextBox.Name = "sauvegardeProgressTextBox";
			this.sauvegardeProgressTextBox.ReadOnly = true;
			this.sauvegardeProgressTextBox.Size = new System.Drawing.Size(622, 24);
			this.sauvegardeProgressTextBox.TabIndex = 20;
			this.sauvegardeProgressTextBox.Text = "sauvegarde Progress";
			// 
			// svgFinalNavigatorUserControl
			// 
			this.svgFinalNavigatorUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.svgFinalNavigatorUserControl.Location = new System.Drawing.Point(334, 0);
			this.svgFinalNavigatorUserControl.Name = "svgFinalNavigatorUserControl";
			this.svgFinalNavigatorUserControl.Size = new System.Drawing.Size(85, 23);
			this.svgFinalNavigatorUserControl.TabIndex = 19;
			// 
			// svgBaseNavigatorUserControl
			// 
			this.svgBaseNavigatorUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.svgBaseNavigatorUserControl.Location = new System.Drawing.Point(130, 0);
			this.svgBaseNavigatorUserControl.Name = "svgBaseNavigatorUserControl";
			this.svgBaseNavigatorUserControl.Size = new System.Drawing.Size(85, 23);
			this.svgBaseNavigatorUserControl.TabIndex = 18;
			// 
			// sauvegardeBtn
			// 
			this.sauvegardeBtn.Location = new System.Drawing.Point(563, 0);
			this.sauvegardeBtn.Name = "sauvegardeBtn";
			this.sauvegardeBtn.Size = new System.Drawing.Size(75, 23);
			this.sauvegardeBtn.TabIndex = 14;
			this.sauvegardeBtn.Text = "&sauvegarde";
			this.sauvegardeBtn.UseVisualStyleBackColor = true;
			this.sauvegardeBtn.Click += new System.EventHandler(this.SauvegardeBtnClick);
			// 
			// userControl12
			// 
			this.userControl12.BackColor = System.Drawing.Color.Red;
			this.userControl12.Location = new System.Drawing.Point(312, 0);
			this.userControl12.Name = "userControl12";
			this.userControl12.Size = new System.Drawing.Size(332, 43);
			this.userControl12.TabIndex = 17;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolTipLabel,
			this.toolStripProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 737);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(681, 22);
			this.statusStrip1.TabIndex = 14;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolTipLabel
			// 
			this.toolTipLabel.Name = "toolTipLabel";
			this.toolTipLabel.Size = new System.Drawing.Size(29, 17);
			this.toolTipLabel.Text = "info:";
			// 
			// copyBtn
			// 
			this.copyBtn.BackColor = System.Drawing.Color.Red;
			this.copyBtn.Location = new System.Drawing.Point(8, 56);
			this.copyBtn.Name = "copyBtn";
			this.copyBtn.Size = new System.Drawing.Size(29, 17);
			this.copyBtn.TabIndex = 15;
			this.copyBtn.Text = "!";
			this.copyBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.copyBtn.UseVisualStyleBackColor = false;
			this.copyBtn.Click += new System.EventHandler(this.CopyBtnClick);
			// 
			// sqlBtn
			// 
			this.sqlBtn.Enabled = false;
			this.sqlBtn.Location = new System.Drawing.Point(24, 414);
			this.sqlBtn.Name = "sqlBtn";
			this.sqlBtn.Size = new System.Drawing.Size(75, 23);
			this.sqlBtn.TabIndex = 16;
			this.sqlBtn.Text = "&SQL";
			this.sqlBtn.UseVisualStyleBackColor = true;
			this.sqlBtn.Click += new System.EventHandler(this.SqlBtnClick);
			// 
			// configBtn
			// 
			this.configBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.configBtn.ForeColor = System.Drawing.SystemColors.ControlText;
			this.configBtn.Location = new System.Drawing.Point(24, 454);
			this.configBtn.Name = "configBtn";
			this.configBtn.Size = new System.Drawing.Size(75, 23);
			this.configBtn.TabIndex = 17;
			this.configBtn.Text = "&Config";
			this.configBtn.UseVisualStyleBackColor = false;
			this.configBtn.Click += new System.EventHandler(this.ConfigBtnClick);
			// 
			// targetTreeView
			// 
			this.targetTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.targetTreeView.ContextMenuStrip = this.serveursContextMenu;
			this.targetTreeView.Location = new System.Drawing.Point(336, 402);
			this.targetTreeView.Name = "targetTreeView";
			this.targetTreeView.Size = new System.Drawing.Size(345, 332);
			this.targetTreeView.TabIndex = 18;
			this.targetTreeView.DoubleClick += new System.EventHandler(this.TargetTreeViewDoubleClick);
			this.targetTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TargetTreeViewMouseClick);
			// 
			// serveursContextMenu
			// 
			this.serveursContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mysqlToolStripMenuItem,
			this.puttyToolStripMenuItem});
			this.serveursContextMenu.Name = "serveursContextMenu";
			this.serveursContextMenu.Size = new System.Drawing.Size(102, 48);
			this.serveursContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ServeursContextMenuOpening);
			// 
			// mysqlToolStripMenuItem
			// 
			this.mysqlToolStripMenuItem.Name = "mysqlToolStripMenuItem";
			this.mysqlToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.mysqlToolStripMenuItem.Text = "mysql";
			this.mysqlToolStripMenuItem.Click += new System.EventHandler(this.MysqlToolStripMenuItemClick);
			// 
			// puttyToolStripMenuItem
			// 
			this.puttyToolStripMenuItem.Name = "puttyToolStripMenuItem";
			this.puttyToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
			this.puttyToolStripMenuItem.Text = "putty";
			this.puttyToolStripMenuItem.Click += new System.EventHandler(this.PuttyToolStripMenuItemClick);
			// 
			// historyLabel
			// 
			this.historyLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.historyLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.historyLabel.Location = new System.Drawing.Point(128, 412);
			this.historyLabel.Name = "historyLabel";
			this.historyLabel.Size = new System.Drawing.Size(66, 25);
			this.historyLabel.TabIndex = 19;
			this.historyLabel.Text = "history";
			this.historyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.historyLabel.Click += new System.EventHandler(this.HistoryLabelClick);
			// 
			// toolStripProgressBar
			// 
			this.toolStripProgressBar.Name = "toolStripProgressBar";
			this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// MouliPrepaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 759);
			this.Controls.Add(this.historyLabel);
			this.Controls.Add(this.targetTreeView);
			this.Controls.Add(this.configBtn);
			this.Controls.Add(this.sqlBtn);
			this.Controls.Add(this.copyBtn);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.sourceListBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "MouliPrepaForm";
			this.ShowIcon = false;
			this.Text = "MouliPrepa";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MouliPrepaFormFormClosing);
			this.Load += new System.EventHandler(this.MouliPrepaLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.serveursContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
		private System.Windows.Forms.Timer connectTimer;
		private System.Windows.Forms.TextBox sauvegardeProgressTextBox;
		private System.Windows.Forms.Label historyLabel;
		private cmdUtils.Controles.NavigatorUserControl svgFinalNavigatorUserControl;
		private cmdUtils.Controles.NavigatorUserControl svgBaseNavigatorUserControl;
		private cmdUtils.Controles.NavigatorUserControl workspaceNavigatorUserControl;
		private cmdUtils.Controles.NavigatorUserControl navigatorUserControl2;

			private cmdUtils.Controles.NavigatorUserControl zonePrepaNavigatorUserControl;
			private System.Windows.Forms.ToolStripMenuItem mysqlToolStripMenuItem;
			private System.Windows.Forms.ToolStripMenuItem puttyToolStripMenuItem;
			private System.Windows.Forms.ContextMenuStrip serveursContextMenu;
			private System.Windows.Forms.TreeView targetTreeView;
			private System.Windows.Forms.Button configBtn;
			private System.Windows.Forms.Button sqlBtn;
			private System.Windows.Forms.TextBox workingDirBox;
			private System.Windows.Forms.Label workspaceLabel;
			private cmdUtils.TotoRectangle userControl12;
			private cmdUtils.TotoRectangle userControl11;
			private System.Windows.Forms.Button copyBtn;
			private System.Windows.Forms.Button createBtn;
			private System.Windows.Forms.TextBox propositionBox;
			private System.Windows.Forms.Button sauvegardeBtn;
			private System.Windows.Forms.Button prepareBtn;
			private System.Windows.Forms.StatusStrip statusStrip1;
			private System.Windows.Forms.ToolStripStatusLabel toolTipLabel;
			private System.Windows.Forms.TextBox targetNameBox;
			private System.Windows.Forms.TextBox targetSvgPathBox;
			private System.Windows.Forms.GroupBox groupBox4;
			private System.Windows.Forms.GroupBox groupBox3;
			private System.Windows.Forms.GroupBox groupBox2;
			private System.Windows.Forms.GroupBox groupBox1;
			private System.Windows.Forms.TextBox workspaceZoneBox;
			private System.Windows.Forms.TextBox workspaceBaseBox;
			private System.Windows.Forms.ListBox sourceListBox;
			private System.Windows.Forms.Button rechMagIdBtn;
			private System.Windows.Forms.TextBox rechMagIdBox;
			private System.Windows.Forms.TextBox sourceBaseBox;
			private System.Windows.Forms.TextBox sourceFilterBox;
			private System.Windows.Forms.TextBox magDescBox;
		}
	}
