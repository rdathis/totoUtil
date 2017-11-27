/*
 * Utilisateur: Renaud
 * Date: 03/14/2017
 * Heure: 13:29
 * 
*/
namespace EcUtil
{
	partial class ECUtilMainForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cmdTextBox = new System.Windows.Forms.TextBox();
			this.progressLabel = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.copyDevePropChBox = new System.Windows.Forms.CheckBox();
			this.copyREclipChBox = new System.Windows.Forms.CheckBox();
			this.stayAliveCheckBox = new System.Windows.Forms.CheckBox();
			this.workspacesBaseLabel = new System.Windows.Forms.Label();
			this.ecPathLabel = new System.Windows.Forms.Label();
			this.wkspacesLView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.newNameBox = new System.Windows.Forms.TextBox();
			this.copyBtn = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cmdTextBox);
			this.groupBox1.Controls.Add(this.progressLabel);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.stayAliveCheckBox);
			this.groupBox1.Controls.Add(this.workspacesBaseLabel);
			this.groupBox1.Controls.Add(this.ecPathLabel);
			this.groupBox1.Controls.Add(this.wkspacesLView);
			this.groupBox1.Controls.Add(this.newNameBox);
			this.groupBox1.Controls.Add(this.copyBtn);
			this.groupBox1.Location = new System.Drawing.Point(0, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(687, 387);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "...";
			// 
			// cmdTextBox
			// 
			this.cmdTextBox.Location = new System.Drawing.Point(24, 356);
			this.cmdTextBox.Name = "cmdTextBox";
			this.cmdTextBox.Size = new System.Drawing.Size(651, 20);
			this.cmdTextBox.TabIndex = 11;
			// 
			// progressLabel
			// 
			this.progressLabel.Location = new System.Drawing.Point(19, 357);
			this.progressLabel.Name = "progressLabel";
			this.progressLabel.Size = new System.Drawing.Size(667, 29);
			this.progressLabel.TabIndex = 10;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.copyDevePropChBox);
			this.groupBox2.Controls.Add(this.copyREclipChBox);
			this.groupBox2.Location = new System.Drawing.Point(354, 140);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(302, 111);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "options";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(6, 50);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(209, 24);
			this.checkBox2.TabIndex = 10;
			this.checkBox2.Text = "?";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// copyDevePropChBox
			// 
			this.copyDevePropChBox.Location = new System.Drawing.Point(6, 80);
			this.copyDevePropChBox.Name = "copyDevePropChBox";
			this.copyDevePropChBox.Size = new System.Drawing.Size(209, 24);
			this.copyDevePropChBox.TabIndex = 11;
			this.copyDevePropChBox.Text = "copy developper.properties";
			this.copyDevePropChBox.UseVisualStyleBackColor = true;
			// 
			// copyREclipChBox
			// 
			this.copyREclipChBox.Location = new System.Drawing.Point(6, 20);
			this.copyREclipChBox.Name = "copyREclipChBox";
			this.copyREclipChBox.Size = new System.Drawing.Size(209, 24);
			this.copyREclipChBox.TabIndex = 9;
			this.copyREclipChBox.Text = "tomove";
			this.copyREclipChBox.UseVisualStyleBackColor = true;
			// 
			// stayAliveCheckBox
			// 
			this.stayAliveCheckBox.Checked = true;
			this.stayAliveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.stayAliveCheckBox.Location = new System.Drawing.Point(468, 303);
			this.stayAliveCheckBox.Name = "stayAliveCheckBox";
			this.stayAliveCheckBox.Size = new System.Drawing.Size(189, 37);
			this.stayAliveCheckBox.TabIndex = 5;
			this.stayAliveCheckBox.Text = "rester visible";
			this.stayAliveCheckBox.UseVisualStyleBackColor = true;
			// 
			// workspacesBaseLabel
			// 
			this.workspacesBaseLabel.Location = new System.Drawing.Point(382, 18);
			this.workspacesBaseLabel.Name = "workspacesBaseLabel";
			this.workspacesBaseLabel.Size = new System.Drawing.Size(254, 24);
			this.workspacesBaseLabel.TabIndex = 4;
			this.workspacesBaseLabel.Text = "workspacesBase";
			// 
			// ecPathLabel
			// 
			this.ecPathLabel.Location = new System.Drawing.Point(382, 42);
			this.ecPathLabel.Name = "ecPathLabel";
			this.ecPathLabel.Size = new System.Drawing.Size(254, 23);
			this.ecPathLabel.TabIndex = 3;
			this.ecPathLabel.Text = "eclipse Path";
			// 
			// wkspacesLView
			// 
			this.wkspacesLView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1});
			this.wkspacesLView.GridLines = true;
			this.wkspacesLView.Location = new System.Drawing.Point(24, 30);
			this.wkspacesLView.MultiSelect = false;
			this.wkspacesLView.Name = "wkspacesLView";
			this.wkspacesLView.Size = new System.Drawing.Size(313, 324);
			this.wkspacesLView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.wkspacesLView.TabIndex = 2;
			this.wkspacesLView.UseCompatibleStateImageBehavior = false;
			this.wkspacesLView.View = System.Windows.Forms.View.List;
			this.wkspacesLView.SelectedIndexChanged += new System.EventHandler(this.WkspacesLViewSelectedIndexChanged);
			this.wkspacesLView.Click += new System.EventHandler(this.WkspacesLViewClick);
			this.wkspacesLView.DoubleClick += new System.EventHandler(this.WkspacesLViewDoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "elem";
			this.columnHeader1.Width = 400;
			// 
			// newNameBox
			// 
			this.newNameBox.Location = new System.Drawing.Point(355, 114);
			this.newNameBox.Name = "newNameBox";
			this.newNameBox.Size = new System.Drawing.Size(302, 20);
			this.newNameBox.TabIndex = 1;
			// 
			// copyBtn
			// 
			this.copyBtn.Location = new System.Drawing.Point(355, 78);
			this.copyBtn.Name = "copyBtn";
			this.copyBtn.Size = new System.Drawing.Size(302, 23);
			this.copyBtn.TabIndex = 0;
			this.copyBtn.Text = "copy as :";
			this.copyBtn.UseVisualStyleBackColor = true;
			this.copyBtn.Click += new System.EventHandler(this.CopyBtnClick);
			// 
			// ECUtilMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(687, 391);
			this.Controls.Add(this.groupBox1);
			this.Name = "ECUtilMainForm";
			this.Text = "EcUtil";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.TextBox cmdTextBox;
		private System.Windows.Forms.Label progressLabel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox copyDevePropChBox;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox copyREclipChBox;
		private System.Windows.Forms.CheckBox stayAliveCheckBox;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Label workspacesBaseLabel;
		private System.Windows.Forms.Label ecPathLabel;
		private System.Windows.Forms.ListView wkspacesLView;
		private System.Windows.Forms.TextBox newNameBox;
		private System.Windows.Forms.Button copyBtn;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
