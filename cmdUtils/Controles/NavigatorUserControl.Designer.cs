/*
 * Utilisateur: Renaud
 * Date: 15/02/2017
 * Heure: 15:46:35
 * 
*/
namespace cmdUtils.Controles
{
	partial class NavigatorUserControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigatorUserControl));
			this.navigButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// navigButton
			// 
			this.navigButton.BackColor = System.Drawing.SystemColors.Control;
			this.navigButton.ForeColor = System.Drawing.Color.Red;
			this.navigButton.Image = ((System.Drawing.Image)(resources.GetObject("navigButton.Image")));
			this.navigButton.Location = new System.Drawing.Point(3, 3);
			this.navigButton.Name = "navigButton";
			this.navigButton.Size = new System.Drawing.Size(75, 23);
			this.navigButton.TabIndex = 0;
			this.navigButton.Text = "go!";
			this.navigButton.UseVisualStyleBackColor = false;
			this.navigButton.Click += new System.EventHandler(this.NavigButtonClick);
			this.navigButton.MouseHover += new System.EventHandler(this.NavigButtonMouseHover);
			// 
			// NavigatorUserControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.Controls.Add(this.navigButton);
			this.Name = "NavigatorUserControl";
			this.Size = new System.Drawing.Size(82, 30);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button navigButton;
	}
}
