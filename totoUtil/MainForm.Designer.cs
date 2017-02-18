/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/02/2015
 * Heure: 18:22:46
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace totoUtil
{
	partial class MainForm
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
			this.pathTextBox = new System.Windows.Forms.TextBox();
			this.tipTextbox = new System.Windows.Forms.TextBox();
			this.argTextBox = new System.Windows.Forms.TextBox();
			this.infoTextBox = new System.Windows.Forms.TextBox();
			this.initButton = new System.Windows.Forms.Button();
			this.cmdLabel = new System.Windows.Forms.Label();
			this.cmdArgsLabel = new System.Windows.Forms.Label();
			this.tippedTextBox = new System.Windows.Forms.TextBox();
			this.tippedRichTextBox = new System.Windows.Forms.RichTextBox();
			this.sendKeysButton = new System.Windows.Forms.Button();
			this.launchMCButton = new System.Windows.Forms.Button();
			this.grepButton = new System.Windows.Forms.Button();
			this.btnExplore = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabelEtatMC = new System.Windows.Forms.ToolStripStatusLabel();
			this.userLabel = new System.Windows.Forms.Label();
			this.userTextBox = new System.Windows.Forms.TextBox();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// goButton
			// 
			this.goButton.BackColor = System.Drawing.Color.Green;
			this.goButton.Location = new System.Drawing.Point(697, 33);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(75, 23);
			this.goButton.TabIndex = 0;
			this.goButton.Text = "go!";
			this.goButton.UseVisualStyleBackColor = false;
			this.goButton.Visible = false;
			this.goButton.Click += new System.EventHandler(this.BtnClick);
			// 
			// pathTextBox
			// 
			this.pathTextBox.Location = new System.Drawing.Point(76, 12);
			this.pathTextBox.Name = "pathTextBox";
			this.pathTextBox.Size = new System.Drawing.Size(601, 20);
			this.pathTextBox.TabIndex = 1;
			this.pathTextBox.Visible = false;
			// 
			// tipTextbox
			// 
			this.tipTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left)));
			this.tipTextbox.Location = new System.Drawing.Point(0, 274);
			this.tipTextbox.Multiline = true;
			this.tipTextbox.Name = "tipTextbox";
			this.tipTextbox.Size = new System.Drawing.Size(475, 254);
			this.tipTextbox.TabIndex = 2;
			// 
			// argTextBox
			// 
			this.argTextBox.Location = new System.Drawing.Point(76, 35);
			this.argTextBox.Name = "argTextBox";
			this.argTextBox.Size = new System.Drawing.Size(601, 20);
			this.argTextBox.TabIndex = 3;
			this.argTextBox.Visible = false;
			// 
			// infoTextBox
			// 
			this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.infoTextBox.Location = new System.Drawing.Point(0, 82);
			this.infoTextBox.Multiline = true;
			this.infoTextBox.Name = "infoTextBox";
			this.infoTextBox.Size = new System.Drawing.Size(835, 186);
			this.infoTextBox.TabIndex = 4;
			// 
			// initButton
			// 
			this.initButton.BackColor = System.Drawing.Color.Green;
			this.initButton.Location = new System.Drawing.Point(697, 12);
			this.initButton.Name = "initButton";
			this.initButton.Size = new System.Drawing.Size(75, 23);
			this.initButton.TabIndex = 5;
			this.initButton.Text = "&init";
			this.initButton.UseVisualStyleBackColor = false;
			this.initButton.Visible = false;
			this.initButton.Click += new System.EventHandler(this.InitButtonClick);
			// 
			// cmdLabel
			// 
			this.cmdLabel.Location = new System.Drawing.Point(0, 12);
			this.cmdLabel.Name = "cmdLabel";
			this.cmdLabel.Size = new System.Drawing.Size(70, 23);
			this.cmdLabel.TabIndex = 6;
			this.cmdLabel.Text = "grep:";
			this.cmdLabel.Visible = false;
			// 
			// cmdArgsLabel
			// 
			this.cmdArgsLabel.Location = new System.Drawing.Point(0, 35);
			this.cmdArgsLabel.Name = "cmdArgsLabel";
			this.cmdArgsLabel.Size = new System.Drawing.Size(70, 23);
			this.cmdArgsLabel.TabIndex = 7;
			this.cmdArgsLabel.Text = "grep args";
			this.cmdArgsLabel.Visible = false;
			// 
			// tippedTextBox
			// 
			this.tippedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tippedTextBox.Location = new System.Drawing.Point(481, 274);
			this.tippedTextBox.Multiline = true;
			this.tippedTextBox.Name = "tippedTextBox";
			this.tippedTextBox.Size = new System.Drawing.Size(354, 254);
			this.tippedTextBox.TabIndex = 8;
			// 
			// tippedRichTextBox
			// 
			this.tippedRichTextBox.Location = new System.Drawing.Point(554, 320);
			this.tippedRichTextBox.Name = "tippedRichTextBox";
			this.tippedRichTextBox.Size = new System.Drawing.Size(243, 142);
			this.tippedRichTextBox.TabIndex = 9;
			this.tippedRichTextBox.Text = "";
			this.tippedRichTextBox.TextChanged += new System.EventHandler(this.RichTextBox1TextChanged);
			// 
			// sendKeysButton
			// 
			this.sendKeysButton.BackColor = System.Drawing.Color.Red;
			this.sendKeysButton.Location = new System.Drawing.Point(779, 11);
			this.sendKeysButton.Name = "sendKeysButton";
			this.sendKeysButton.Size = new System.Drawing.Size(56, 23);
			this.sendKeysButton.TabIndex = 10;
			this.sendKeysButton.Text = "&sendKeys";
			this.sendKeysButton.UseVisualStyleBackColor = false;
			this.sendKeysButton.Visible = false;
			this.sendKeysButton.Click += new System.EventHandler(this.Button1Click);
			// 
			// launchMCButton
			// 
			this.launchMCButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.launchMCButton.Location = new System.Drawing.Point(779, 35);
			this.launchMCButton.Name = "launchMCButton";
			this.launchMCButton.Size = new System.Drawing.Size(56, 23);
			this.launchMCButton.TabIndex = 11;
			this.launchMCButton.Text = "MC";
			this.launchMCButton.UseVisualStyleBackColor = false;
			this.launchMCButton.Click += new System.EventHandler(this.LaunchMCButtonClick);
			// 
			// grepButton
			// 
			this.grepButton.Location = new System.Drawing.Point(676, 57);
			this.grepButton.Name = "grepButton";
			this.grepButton.Size = new System.Drawing.Size(59, 19);
			this.grepButton.TabIndex = 12;
			this.grepButton.Text = "&grep";
			this.grepButton.UseVisualStyleBackColor = true;
			this.grepButton.Click += new System.EventHandler(this.GrepButtonClick);
			// 
			// btnExplore
			// 
			this.btnExplore.Location = new System.Drawing.Point(756, 57);
			this.btnExplore.Name = "btnExplore";
			this.btnExplore.Size = new System.Drawing.Size(61, 19);
			this.btnExplore.TabIndex = 13;
			this.btnExplore.Text = "...";
			this.btnExplore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnExplore.UseVisualStyleBackColor = true;
			this.btnExplore.Visible = false;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(333, 57);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 15;
			this.button2.Text = "timerButton";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabelEtatMC});
			this.statusStrip1.Location = new System.Drawing.Point(0, 506);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(835, 22);
			this.statusStrip1.TabIndex = 16;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabelEtatMC
			// 
			this.toolStripStatusLabelEtatMC.Name = "toolStripStatusLabelEtatMC";
			this.toolStripStatusLabelEtatMC.Size = new System.Drawing.Size(0, 17);
			// 
			// userLabel
			// 
			this.userLabel.Location = new System.Drawing.Point(0, 59);
			this.userLabel.Name = "userLabel";
			this.userLabel.Size = new System.Drawing.Size(76, 20);
			this.userLabel.TabIndex = 17;
			this.userLabel.Text = "MC User";
			this.userLabel.Visible = false;
			// 
			// userTextBox
			// 
			this.userTextBox.Location = new System.Drawing.Point(76, 59);
			this.userTextBox.Name = "userTextBox";
			this.userTextBox.Size = new System.Drawing.Size(234, 20);
			this.userTextBox.TabIndex = 18;
			this.userTextBox.Visible = false;
			this.userTextBox.Leave += new System.EventHandler(this.UserTextBoxLeave);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(835, 528);
			this.Controls.Add(this.userTextBox);
			this.Controls.Add(this.userLabel);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnExplore);
			this.Controls.Add(this.grepButton);
			this.Controls.Add(this.launchMCButton);
			this.Controls.Add(this.sendKeysButton);
			this.Controls.Add(this.tippedRichTextBox);
			this.Controls.Add(this.tippedTextBox);
			this.Controls.Add(this.cmdArgsLabel);
			this.Controls.Add(this.cmdLabel);
			this.Controls.Add(this.initButton);
			this.Controls.Add(this.infoTextBox);
			this.Controls.Add(this.argTextBox);
			this.Controls.Add(this.tipTextbox);
			this.Controls.Add(this.pathTextBox);
			this.Controls.Add(this.goButton);
			this.Name = "MainForm";
			this.Text = "totoUtil";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label userLabel;
		private System.Windows.Forms.TextBox userTextBox;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEtatMC;
		private System.Windows.Forms.Button grepButton;
		private System.Windows.Forms.Button launchMCButton;
		private System.Windows.Forms.Button sendKeysButton;
		private System.Windows.Forms.RichTextBox tippedRichTextBox;
		private System.Windows.Forms.TextBox tippedTextBox;
		private System.Windows.Forms.Label cmdArgsLabel;
		private System.Windows.Forms.Label cmdLabel;
		private System.Windows.Forms.Button initButton;
		private System.Windows.Forms.TextBox infoTextBox;
		private System.Windows.Forms.TextBox argTextBox;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.TextBox pathTextBox;
		private System.Windows.Forms.TextBox tipTextbox;
		private System.Windows.Forms.Button btnExplore;
		private System.Windows.Forms.Button button2;
	}
}
