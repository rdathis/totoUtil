/*
 * Utilisateur: Renaud
 * Date: 19/01/2017
 * Heure: 13:34:56
 * 
*/
namespace MoulUtil.Forms
{
	partial class MouliEditForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.openBtn = new System.Windows.Forms.Button();
			this.razBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.targetSvgPathBox = new System.Windows.Forms.TextBox();
			this.defaultEmailBox = new System.Windows.Forms.TextBox();
			this.defaultEmail = new System.Windows.Forms.Label();
			this.databaseAdminPwdBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.defaultPasswordBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.appPlinkBox = new System.Windows.Forms.TextBox();
			this.appPlink = new System.Windows.Forms.Label();
			this.databaseAdminUserBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.workingDirBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.databaseAdminNameBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.sql01 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.sql02 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.sql03 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.sql04 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.sql05 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(17, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "targetSvgPath";
			// 
			// openBtn
			// 
			this.openBtn.Location = new System.Drawing.Point(5, 9);
			this.openBtn.Name = "openBtn";
			this.openBtn.Size = new System.Drawing.Size(50, 23);
			this.openBtn.TabIndex = 1;
			this.openBtn.Text = "open";
			this.openBtn.UseVisualStyleBackColor = true;
			this.openBtn.Click += new System.EventHandler(this.OpenBtnClick);
			// 
			// razBtn
			// 
			this.razBtn.Location = new System.Drawing.Point(73, 9);
			this.razBtn.Name = "razBtn";
			this.razBtn.Size = new System.Drawing.Size(50, 23);
			this.razBtn.TabIndex = 2;
			this.razBtn.Text = "&raz";
			this.razBtn.UseVisualStyleBackColor = true;
			this.razBtn.Click += new System.EventHandler(this.RazBtnClick);
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(145, 9);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(50, 23);
			this.saveBtn.TabIndex = 3;
			this.saveBtn.Text = "&Sauve";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
			// 
			// targetSvgPathBox
			// 
			this.targetSvgPathBox.Location = new System.Drawing.Point(126, 49);
			this.targetSvgPathBox.Name = "targetSvgPathBox";
			this.targetSvgPathBox.Size = new System.Drawing.Size(322, 20);
			this.targetSvgPathBox.TabIndex = 4;
			// 
			// defaultEmailBox
			// 
			this.defaultEmailBox.Location = new System.Drawing.Point(582, 49);
			this.defaultEmailBox.Name = "defaultEmailBox";
			this.defaultEmailBox.Size = new System.Drawing.Size(322, 20);
			this.defaultEmailBox.TabIndex = 6;
			// 
			// defaultEmail
			// 
			this.defaultEmail.Location = new System.Drawing.Point(457, 55);
			this.defaultEmail.Name = "defaultEmail";
			this.defaultEmail.Size = new System.Drawing.Size(119, 17);
			this.defaultEmail.TabIndex = 5;
			this.defaultEmail.Text = "defaultEmail";
			// 
			// databaseAdminPwdBox
			// 
			this.databaseAdminPwdBox.Location = new System.Drawing.Point(126, 101);
			this.databaseAdminPwdBox.Name = "databaseAdminPwdBox";
			this.databaseAdminPwdBox.Size = new System.Drawing.Size(322, 20);
			this.databaseAdminPwdBox.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 17);
			this.label4.TabIndex = 9;
			this.label4.Text = "databaseAdminPwd";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(582, 127);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(322, 20);
			this.textBox3.TabIndex = 16;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(457, 133);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 17);
			this.label3.TabIndex = 15;
			this.label3.Text = "label?";
			// 
			// defaultPasswordBox
			// 
			this.defaultPasswordBox.Location = new System.Drawing.Point(126, 153);
			this.defaultPasswordBox.Name = "defaultPasswordBox";
			this.defaultPasswordBox.Size = new System.Drawing.Size(322, 20);
			this.defaultPasswordBox.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(17, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(119, 17);
			this.label5.TabIndex = 13;
			this.label5.Text = "defaultPassword";
			// 
			// appPlinkBox
			// 
			this.appPlinkBox.Location = new System.Drawing.Point(582, 75);
			this.appPlinkBox.Name = "appPlinkBox";
			this.appPlinkBox.Size = new System.Drawing.Size(322, 20);
			this.appPlinkBox.TabIndex = 12;
			// 
			// appPlink
			// 
			this.appPlink.Location = new System.Drawing.Point(457, 81);
			this.appPlink.Name = "appPlink";
			this.appPlink.Size = new System.Drawing.Size(119, 17);
			this.appPlink.TabIndex = 11;
			this.appPlink.Text = "appPlink";
			// 
			// databaseAdminUserBox
			// 
			this.databaseAdminUserBox.Location = new System.Drawing.Point(126, 75);
			this.databaseAdminUserBox.Name = "databaseAdminUserBox";
			this.databaseAdminUserBox.Size = new System.Drawing.Size(322, 20);
			this.databaseAdminUserBox.TabIndex = 22;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 81);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(119, 17);
			this.label7.TabIndex = 21;
			this.label7.Text = "databaseAdminUser";
			// 
			// workingDirBox
			// 
			this.workingDirBox.Location = new System.Drawing.Point(582, 101);
			this.workingDirBox.Name = "workingDirBox";
			this.workingDirBox.Size = new System.Drawing.Size(322, 20);
			this.workingDirBox.TabIndex = 20;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(457, 107);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 17);
			this.label8.TabIndex = 19;
			this.label8.Text = "workingDir";
			// 
			// databaseAdminNameBox
			// 
			this.databaseAdminNameBox.Location = new System.Drawing.Point(126, 127);
			this.databaseAdminNameBox.Name = "databaseAdminNameBox";
			this.databaseAdminNameBox.Size = new System.Drawing.Size(322, 20);
			this.databaseAdminNameBox.TabIndex = 18;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(17, 133);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(119, 17);
			this.label9.TabIndex = 17;
			this.label9.Text = "databaseAdminName";
			// 
			// sql01
			// 
			this.sql01.Location = new System.Drawing.Point(82, 185);
			this.sql01.Multiline = true;
			this.sql01.Name = "sql01";
			this.sql01.Size = new System.Drawing.Size(822, 90);
			this.sql01.TabIndex = 24;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(17, 188);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(59, 17);
			this.label12.TabIndex = 23;
			this.label12.Text = "sql01";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(582, 156);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(322, 20);
			this.textBox10.TabIndex = 26;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(457, 159);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(119, 17);
			this.label10.TabIndex = 25;
			this.label10.Text = "label?";
			// 
			// sql02
			// 
			this.sql02.Location = new System.Drawing.Point(82, 281);
			this.sql02.Multiline = true;
			this.sql02.Name = "sql02";
			this.sql02.Size = new System.Drawing.Size(822, 90);
			this.sql02.TabIndex = 28;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(17, 284);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(59, 17);
			this.label11.TabIndex = 27;
			this.label11.Text = "sql02";
			// 
			// sql03
			// 
			this.sql03.Location = new System.Drawing.Point(82, 377);
			this.sql03.Multiline = true;
			this.sql03.Name = "sql03";
			this.sql03.Size = new System.Drawing.Size(822, 90);
			this.sql03.TabIndex = 30;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(17, 380);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(59, 17);
			this.label13.TabIndex = 29;
			this.label13.Text = "sql03";
			// 
			// sql04
			// 
			this.sql04.Location = new System.Drawing.Point(82, 473);
			this.sql04.Multiline = true;
			this.sql04.Name = "sql04";
			this.sql04.Size = new System.Drawing.Size(822, 90);
			this.sql04.TabIndex = 32;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(17, 476);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(59, 17);
			this.label14.TabIndex = 31;
			this.label14.Text = "sql04";
			// 
			// sql05
			// 
			this.sql05.Location = new System.Drawing.Point(82, 569);
			this.sql05.Multiline = true;
			this.sql05.Name = "sql05";
			this.sql05.Size = new System.Drawing.Size(822, 90);
			this.sql05.TabIndex = 34;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(17, 572);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(59, 17);
			this.label15.TabIndex = 33;
			this.label15.Text = "sql05";
			// 
			// MouliEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 721);
			this.Controls.Add(this.sql05);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.sql04);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.sql03);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.sql02);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.sql01);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.databaseAdminUserBox);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.workingDirBox);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.databaseAdminNameBox);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.defaultPasswordBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.appPlinkBox);
			this.Controls.Add(this.appPlink);
			this.Controls.Add(this.databaseAdminPwdBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.defaultEmailBox);
			this.Controls.Add(this.defaultEmail);
			this.Controls.Add(this.targetSvgPathBox);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.razBtn);
			this.Controls.Add(this.openBtn);
			this.Controls.Add(this.label1);
			this.Name = "MouliEditForm";
			this.Text = "MouliEditForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.TextBox sql02;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox sql03;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox sql04;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox sql05;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox defaultPasswordBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox appPlinkBox;
		private System.Windows.Forms.Label appPlink;
		private System.Windows.Forms.TextBox databaseAdminUserBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox workingDirBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox databaseAdminNameBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox sql01;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox defaultEmailBox;
		private System.Windows.Forms.Label defaultEmail;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox databaseAdminPwdBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox targetSvgPathBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button openBtn;
		private System.Windows.Forms.Button razBtn;
		private System.Windows.Forms.Button saveBtn;
	}
}
