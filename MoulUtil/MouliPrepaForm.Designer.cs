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
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.rechMagIdBtn = new System.Windows.Forms.Button();
			this.rechMagIdBox = new System.Windows.Forms.TextBox();
			this.sourceBaseBox = new System.Windows.Forms.TextBox();
			this.sourceFilterBox = new System.Windows.Forms.TextBox();
			this.magDescBox = new System.Windows.Forms.TextBox();
			this.sourceListBox = new System.Windows.Forms.ListBox();
			this.workspaceBaseBox = new System.Windows.Forms.TextBox();
			this.workspaceBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.prepareBtn = new System.Windows.Forms.Button();
			this.targetNameBox = new System.Windows.Forms.TextBox();
			this.targetSvgPathBox = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.sauvegardeBtn = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolTipLable = new System.Windows.Forms.ToolStripStatusLabel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rechMagIdBtn
			// 
			this.rechMagIdBtn.Location = new System.Drawing.Point(130, 25);
			this.rechMagIdBtn.Name = "rechMagIdBtn";
			this.rechMagIdBtn.Size = new System.Drawing.Size(75, 23);
			this.rechMagIdBtn.TabIndex = 0;
			this.rechMagIdBtn.Text = "recherche";
			this.rechMagIdBtn.UseVisualStyleBackColor = true;
			// 
			// rechMagIdBox
			// 
			this.rechMagIdBox.Location = new System.Drawing.Point(38, 27);
			this.rechMagIdBox.Name = "rechMagIdBox";
			this.rechMagIdBox.Size = new System.Drawing.Size(102, 20);
			this.rechMagIdBox.TabIndex = 1;
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
			this.magDescBox.Size = new System.Drawing.Size(325, 66);
			this.magDescBox.TabIndex = 4;
			// 
			// sourceListBox
			// 
			this.sourceListBox.FormattingEnabled = true;
			this.sourceListBox.Location = new System.Drawing.Point(38, 129);
			this.sourceListBox.Name = "sourceListBox";
			this.sourceListBox.Size = new System.Drawing.Size(624, 95);
			this.sourceListBox.TabIndex = 5;
			// 
			// workspaceBaseBox
			// 
			this.workspaceBaseBox.Location = new System.Drawing.Point(13, 23);
			this.workspaceBaseBox.Name = "workspaceBaseBox";
			this.workspaceBaseBox.Size = new System.Drawing.Size(292, 20);
			this.workspaceBaseBox.TabIndex = 6;
			this.workspaceBaseBox.Text = "W:/meo-moulinettes/";
			// 
			// workspaceBox
			// 
			this.workspaceBox.Location = new System.Drawing.Point(311, 23);
			this.workspaceBox.Name = "workspaceBox";
			this.workspaceBox.Size = new System.Drawing.Size(325, 20);
			this.workspaceBox.TabIndex = 7;
			this.workspaceBox.TextChanged += new System.EventHandler(this.WorkspaceBoxTextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.magDescBox);
			this.groupBox1.Controls.Add(this.rechMagIdBtn);
			this.groupBox1.Location = new System.Drawing.Point(25, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(644, 85);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "rechercheMagasin";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.sourceBaseBox);
			this.groupBox2.Controls.Add(this.sourceFilterBox);
			this.groupBox2.Location = new System.Drawing.Point(25, 91);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(644, 142);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "source";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.prepareBtn);
			this.groupBox3.Controls.Add(this.workspaceBaseBox);
			this.groupBox3.Controls.Add(this.workspaceBox);
			this.groupBox3.Location = new System.Drawing.Point(25, 261);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(644, 43);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Zone préparation";
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
			this.groupBox4.Controls.Add(this.sauvegardeBtn);
			this.groupBox4.Controls.Add(this.targetNameBox);
			this.groupBox4.Controls.Add(this.targetSvgPathBox);
			this.groupBox4.Location = new System.Drawing.Point(25, 320);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(644, 43);
			this.groupBox4.TabIndex = 13;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Sauvegarde";
			// 
			// sauvegardeBtn
			// 
			this.sauvegardeBtn.Location = new System.Drawing.Point(563, 0);
			this.sauvegardeBtn.Name = "sauvegardeBtn";
			this.sauvegardeBtn.Size = new System.Drawing.Size(75, 23);
			this.sauvegardeBtn.TabIndex = 14;
			this.sauvegardeBtn.Text = "&sauvegarde";
			this.sauvegardeBtn.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolTipLable});
			this.statusStrip1.Location = new System.Drawing.Point(0, 562);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(681, 22);
			this.statusStrip1.TabIndex = 14;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolTipLable
			// 
			this.toolTipLable.Name = "toolTipLable";
			this.toolTipLable.Size = new System.Drawing.Size(29, 17);
			this.toolTipLable.Text = "info:";
			// 
			// MouliPrepaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(681, 584);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.sourceListBox);
			this.Controls.Add(this.rechMagIdBox);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Name = "MouliPrepaForm";
			this.Text = "MouliPrepa";
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Button sauvegardeBtn;
		private System.Windows.Forms.Button prepareBtn;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolTipLable;
		private System.Windows.Forms.TextBox targetNameBox;
		private System.Windows.Forms.TextBox targetSvgPathBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox workspaceBox;
		private System.Windows.Forms.TextBox workspaceBaseBox;
		private System.Windows.Forms.ListBox sourceListBox;
		private System.Windows.Forms.Button rechMagIdBtn;
		private System.Windows.Forms.TextBox rechMagIdBox;
		private System.Windows.Forms.TextBox sourceBaseBox;
		private System.Windows.Forms.TextBox sourceFilterBox;
		private System.Windows.Forms.TextBox magDescBox;
	}
}
