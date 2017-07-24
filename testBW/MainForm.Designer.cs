/*
 * Utilisateur: Renaud
 * Date: 22/05/2017
 * Heure: 13:48:00
 * 
*/
namespace testBW
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.startBtn = new System.Windows.Forms.Button();
			this.stopBtn = new System.Windows.Forms.Button();
			this.tbProgress = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(33, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(176, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// startBtn
			// 
			this.startBtn.Location = new System.Drawing.Point(15, 166);
			this.startBtn.Name = "startBtn";
			this.startBtn.Size = new System.Drawing.Size(50, 28);
			this.startBtn.TabIndex = 2;
			this.startBtn.Text = "start";
			this.startBtn.UseVisualStyleBackColor = true;
			this.startBtn.Click += new System.EventHandler(this.StartBtnClick);
			// 
			// stopBtn
			// 
			this.stopBtn.Location = new System.Drawing.Point(111, 166);
			this.stopBtn.Name = "stopBtn";
			this.stopBtn.Size = new System.Drawing.Size(50, 28);
			this.stopBtn.TabIndex = 3;
			this.stopBtn.Text = "stop";
			this.stopBtn.UseVisualStyleBackColor = true;
			this.stopBtn.Click += new System.EventHandler(this.StopBtnClick);
			// 
			// tbProgress
			// 
			this.tbProgress.Location = new System.Drawing.Point(96, 125);
			this.tbProgress.Name = "tbProgress";
			this.tbProgress.Size = new System.Drawing.Size(100, 23);
			this.tbProgress.TabIndex = 4;
			this.tbProgress.Text = "label2";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.tbProgress);
			this.Controls.Add(this.stopBtn);
			this.Controls.Add(this.startBtn);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "testBW";
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label tbProgress;
		private System.Windows.Forms.Button stopBtn;
		private System.Windows.Forms.Button startBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}
