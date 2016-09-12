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
	partial class MouliForm
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
			this.exitButton = new System.Windows.Forms.Button();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.listView1 = new System.Windows.Forms.ListView();
			this.pathLabel = new System.Windows.Forms.Label();
			this.uploadButton = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.targetTreeView = new System.Windows.Forms.TreeView();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.puttyLink = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// goButton
			// 
			this.goButton.Location = new System.Drawing.Point(36, 325);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(75, 23);
			this.goButton.TabIndex = 0;
			this.goButton.Text = "goZip";
			this.goButton.UseVisualStyleBackColor = true;
			this.goButton.Click += new System.EventHandler(this.GoButtonClick);
			// 
			// exitButton
			// 
			this.exitButton.Location = new System.Drawing.Point(426, 325);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(75, 23);
			this.exitButton.TabIndex = 1;
			this.exitButton.Text = "&Exit";
			this.exitButton.UseVisualStyleBackColor = true;
			this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(70, 78);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(187, 118);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(375, 161);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// pathLabel
			// 
			this.pathLabel.Location = new System.Drawing.Point(12, 13);
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(302, 23);
			this.pathLabel.TabIndex = 4;
			this.pathLabel.Text = "target";
			// 
			// uploadButton
			// 
			this.uploadButton.Location = new System.Drawing.Point(118, 325);
			this.uploadButton.Name = "uploadButton";
			this.uploadButton.Size = new System.Drawing.Size(75, 23);
			this.uploadButton.TabIndex = 9;
			this.uploadButton.Text = "upload";
			this.uploadButton.UseVisualStyleBackColor = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(103, 296);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(459, 23);
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
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Items.AddRange(new object[] {
			"clients",
			"stock",
			"Joint/",
			"ord01/"});
			this.checkedListBox1.Location = new System.Drawing.Point(462, 12);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(100, 94);
			this.checkedListBox1.TabIndex = 12;
			// 
			// puttyLink
			// 
			this.puttyLink.Location = new System.Drawing.Point(13, 293);
			this.puttyLink.Name = "puttyLink";
			this.puttyLink.Size = new System.Drawing.Size(84, 26);
			this.puttyLink.TabIndex = 13;
			this.puttyLink.TabStop = true;
			this.puttyLink.Text = "putty";
			this.puttyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PuttyLinkLinkClicked);
			// 
			// MouliForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(589, 360);
			this.Controls.Add(this.puttyLink);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.targetTreeView);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.uploadButton);
			this.Controls.Add(this.pathLabel);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.exitButton);
			this.Controls.Add(this.goButton);
			this.Name = "MouliForm";
			this.Text = "MouliForm";
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.LinkLabel puttyLink;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TreeView targetTreeView;
		private System.Windows.Forms.Button uploadButton;
		private System.Windows.Forms.Label pathLabel;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button exitButton;
		private System.Windows.Forms.Button goButton;
	}
}
