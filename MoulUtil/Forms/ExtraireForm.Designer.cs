/*
 * Utilisateur: Renaud
 * Date: 09/11/2017
 * Heure: 18:11:42
 * 
*/
namespace MoulUtil.Forms
{
	partial class ExtraireForm
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
			this.escBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.goBtn = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.pathTBox = new System.Windows.Forms.TextBox();
			this.refreshBtn = new System.Windows.Forms.Button();
			this.resultListBox = new System.Windows.Forms.ListBox();
			this.logBox = new System.Windows.Forms.TextBox();
			this.razBtn = new System.Windows.Forms.Button();
			this.dispatchBtn = new System.Windows.Forms.Button();
			this.traite1Btn = new System.Windows.Forms.Button();
			this.traite2Btn = new System.Windows.Forms.Button();
			this.traite3Btn = new System.Windows.Forms.Button();
			this.titleLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// escBtn
			// 
			this.escBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.escBtn.Location = new System.Drawing.Point(676, 351);
			this.escBtn.Name = "escBtn";
			this.escBtn.Size = new System.Drawing.Size(75, 23);
			this.escBtn.TabIndex = 0;
			this.escBtn.Text = "&Fermer";
			this.escBtn.UseVisualStyleBackColor = true;
			this.escBtn.Click += new System.EventHandler(this.EscBtnClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(3, 47);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(586, 20);
			this.textBox1.TabIndex = 1;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(3, 73);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(586, 20);
			this.textBox2.TabIndex = 3;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(3, 99);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(586, 20);
			this.textBox3.TabIndex = 5;
			// 
			// goBtn
			// 
			this.goBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.goBtn.Location = new System.Drawing.Point(217, 351);
			this.goBtn.Name = "goBtn";
			this.goBtn.Size = new System.Drawing.Size(75, 23);
			this.goBtn.TabIndex = 8;
			this.goBtn.Text = "&Go unzip";
			this.goBtn.UseVisualStyleBackColor = true;
			this.goBtn.Click += new System.EventHandler(this.GoBtnClick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(595, 47);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 9;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(595, 72);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 21);
			this.comboBox2.TabIndex = 10;
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(595, 98);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(121, 21);
			this.comboBox3.TabIndex = 11;
			// 
			// pathTBox
			// 
			this.pathTBox.Location = new System.Drawing.Point(50, 171);
			this.pathTBox.Name = "pathTBox";
			this.pathTBox.Size = new System.Drawing.Size(540, 20);
			this.pathTBox.TabIndex = 12;
			// 
			// refreshBtn
			// 
			this.refreshBtn.Location = new System.Drawing.Point(609, 218);
			this.refreshBtn.Name = "refreshBtn";
			this.refreshBtn.Size = new System.Drawing.Size(75, 23);
			this.refreshBtn.TabIndex = 14;
			this.refreshBtn.Text = "refresh";
			this.refreshBtn.UseVisualStyleBackColor = true;
			this.refreshBtn.Click += new System.EventHandler(this.RefreshBtnClick);
			// 
			// resultListBox
			// 
			this.resultListBox.FormattingEnabled = true;
			this.resultListBox.Location = new System.Drawing.Point(50, 195);
			this.resultListBox.Name = "resultListBox";
			this.resultListBox.Size = new System.Drawing.Size(539, 69);
			this.resultListBox.TabIndex = 15;
			// 
			// logBox
			// 
			this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.logBox.Location = new System.Drawing.Point(3, 270);
			this.logBox.Multiline = true;
			this.logBox.Name = "logBox";
			this.logBox.Size = new System.Drawing.Size(761, 67);
			this.logBox.TabIndex = 16;
			// 
			// razBtn
			// 
			this.razBtn.Location = new System.Drawing.Point(26, 351);
			this.razBtn.Name = "razBtn";
			this.razBtn.Size = new System.Drawing.Size(75, 23);
			this.razBtn.TabIndex = 17;
			this.razBtn.Text = "&Raz";
			this.razBtn.UseVisualStyleBackColor = true;
			this.razBtn.Click += new System.EventHandler(this.razButtonClick);
			// 
			// dispatchBtn
			// 
			this.dispatchBtn.Location = new System.Drawing.Point(121, 351);
			this.dispatchBtn.Name = "dispatchBtn";
			this.dispatchBtn.Size = new System.Drawing.Size(75, 23);
			this.dispatchBtn.TabIndex = 18;
			this.dispatchBtn.Text = "&Dispatch";
			this.dispatchBtn.UseVisualStyleBackColor = true;
			this.dispatchBtn.Click += new System.EventHandler(this.dispatchButtonClick);
			// 
			// traite1Btn
			// 
			this.traite1Btn.Location = new System.Drawing.Point(722, 50);
			this.traite1Btn.Name = "traite1Btn";
			this.traite1Btn.Size = new System.Drawing.Size(23, 17);
			this.traite1Btn.TabIndex = 19;
			this.traite1Btn.Text = "1";
			this.traite1Btn.UseVisualStyleBackColor = true;
			this.traite1Btn.Click += new System.EventHandler(this.Traite1BtnClick);
			// 
			// traite2Btn
			// 
			this.traite2Btn.Location = new System.Drawing.Point(722, 72);
			this.traite2Btn.Name = "traite2Btn";
			this.traite2Btn.Size = new System.Drawing.Size(23, 21);
			this.traite2Btn.TabIndex = 20;
			this.traite2Btn.Text = "2";
			this.traite2Btn.UseVisualStyleBackColor = true;
			this.traite2Btn.Click += new System.EventHandler(this.Traite2BtnClick);
			// 
			// traite3Btn
			// 
			this.traite3Btn.Location = new System.Drawing.Point(722, 99);
			this.traite3Btn.Name = "traite3Btn";
			this.traite3Btn.Size = new System.Drawing.Size(23, 20);
			this.traite3Btn.TabIndex = 21;
			this.traite3Btn.Text = "3";
			this.traite3Btn.UseVisualStyleBackColor = true;
			this.traite3Btn.Click += new System.EventHandler(this.Traite3BtnClick);
			// 
			// titleLabel
			// 
			this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.DarkBlue;
			this.titleLabel.Location = new System.Drawing.Point(13, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(737, 39);
			this.titleLabel.TabIndex = 22;
			this.titleLabel.Text = "Extraction des archives";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ExtraireForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 378);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.traite3Btn);
			this.Controls.Add(this.traite2Btn);
			this.Controls.Add(this.traite1Btn);
			this.Controls.Add(this.dispatchBtn);
			this.Controls.Add(this.razBtn);
			this.Controls.Add(this.logBox);
			this.Controls.Add(this.resultListBox);
			this.Controls.Add(this.refreshBtn);
			this.Controls.Add(this.pathTBox);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.goBtn);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.escBtn);
			this.Name = "ExtraireForm";
			this.Text = "ExtraireForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Button traite3Btn;
		private System.Windows.Forms.Button traite2Btn;
		private System.Windows.Forms.Button traite1Btn;
		private System.Windows.Forms.Button dispatchBtn;
		private System.Windows.Forms.Button razBtn;
		private System.Windows.Forms.TextBox logBox;
		private System.Windows.Forms.ListBox resultListBox;
		private System.Windows.Forms.Button refreshBtn;
		private System.Windows.Forms.TextBox pathTBox;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button goBtn;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button escBtn;
	}
}
