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
			this.btn = new System.Windows.Forms.Button();
			this.pathTxtBox = new System.Windows.Forms.TextBox();
			this.tipTxtbox = new System.Windows.Forms.TextBox();
			this.argTxtBox = new System.Windows.Forms.TextBox();
			this.infoTxtBox = new System.Windows.Forms.TextBox();
			this.initButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tippedTextBox = new System.Windows.Forms.TextBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn
			// 
			this.btn.Location = new System.Drawing.Point(697, 33);
			this.btn.Name = "btn";
			this.btn.Size = new System.Drawing.Size(75, 23);
			this.btn.TabIndex = 0;
			this.btn.Text = "&go!";
			this.btn.UseVisualStyleBackColor = true;
			this.btn.Click += new System.EventHandler(this.BtnClick);
			// 
			// pathTxtBox
			// 
			this.pathTxtBox.Location = new System.Drawing.Point(76, 12);
			this.pathTxtBox.Name = "pathTxtBox";
			this.pathTxtBox.Size = new System.Drawing.Size(601, 20);
			this.pathTxtBox.TabIndex = 1;
			// 
			// tipTxtbox
			// 
			this.tipTxtbox.Location = new System.Drawing.Point(0, 274);
			this.tipTxtbox.Multiline = true;
			this.tipTxtbox.Name = "tipTxtbox";
			this.tipTxtbox.Size = new System.Drawing.Size(475, 254);
			this.tipTxtbox.TabIndex = 2;
			// 
			// argTxtBox
			// 
			this.argTxtBox.Location = new System.Drawing.Point(76, 35);
			this.argTxtBox.Name = "argTxtBox";
			this.argTxtBox.Size = new System.Drawing.Size(601, 20);
			this.argTxtBox.TabIndex = 3;
			// 
			// infoTxtBox
			// 
			this.infoTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.infoTxtBox.Location = new System.Drawing.Point(0, 82);
			this.infoTxtBox.Multiline = true;
			this.infoTxtBox.Name = "infoTxtBox";
			this.infoTxtBox.Size = new System.Drawing.Size(835, 186);
			this.infoTxtBox.TabIndex = 4;
			// 
			// initButton
			// 
			this.initButton.Location = new System.Drawing.Point(697, 12);
			this.initButton.Name = "initButton";
			this.initButton.Size = new System.Drawing.Size(75, 23);
			this.initButton.TabIndex = 5;
			this.initButton.Text = "&init";
			this.initButton.UseVisualStyleBackColor = true;
			this.initButton.Click += new System.EventHandler(this.InitButtonClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 23);
			this.label1.TabIndex = 6;
			this.label1.Text = "grep:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "grep args";
			// 
			// tippedTextBox
			// 
			this.tippedTextBox.Location = new System.Drawing.Point(481, 274);
			this.tippedTextBox.Multiline = true;
			this.tippedTextBox.Name = "tippedTextBox";
			this.tippedTextBox.Size = new System.Drawing.Size(354, 254);
			this.tippedTextBox.TabIndex = 8;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(544, 99);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(243, 142);
			this.richTextBox1.TabIndex = 9;
			this.richTextBox1.Text = "";
			this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(779, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(44, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(835, 528);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.tippedTextBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.initButton);
			this.Controls.Add(this.infoTxtBox);
			this.Controls.Add(this.argTxtBox);
			this.Controls.Add(this.tipTxtbox);
			this.Controls.Add(this.pathTxtBox);
			this.Controls.Add(this.btn);
			this.Name = "MainForm";
			this.Text = "totoUtil";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox tippedTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button initButton;
		private System.Windows.Forms.TextBox infoTxtBox;
		private System.Windows.Forms.TextBox argTxtBox;
		private System.Windows.Forms.Button btn;
		private System.Windows.Forms.TextBox pathTxtBox;
		private System.Windows.Forms.TextBox tipTxtbox;
	}
}
