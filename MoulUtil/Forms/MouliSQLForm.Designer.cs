/*
 * Utilisateur: Renaud
 * Date: 09/01/2017
 * Heure: 14:42:23
 * 
*/
namespace MoulUtil
{
	partial class MouliSQLForm
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
			this.magasinIdBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.detailmagasinBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.anneepurgeBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.resultatSQLBox = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.sqlCalculeBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "magasin";
			// 
			// magasinIdBox
			// 
			this.magasinIdBox.Location = new System.Drawing.Point(120, 13);
			this.magasinIdBox.Name = "magasinIdBox";
			this.magasinIdBox.Size = new System.Drawing.Size(100, 20);
			this.magasinIdBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Lime;
			this.label2.Location = new System.Drawing.Point(13, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "stat Stock";
			// 
			// detailmagasinBox
			// 
			this.detailmagasinBox.Location = new System.Drawing.Point(245, 12);
			this.detailmagasinBox.Multiline = true;
			this.detailmagasinBox.Name = "detailmagasinBox";
			this.detailmagasinBox.Size = new System.Drawing.Size(474, 47);
			this.detailmagasinBox.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Année purge";
			// 
			// anneepurgeBox
			// 
			this.anneepurgeBox.Location = new System.Drawing.Point(120, 39);
			this.anneepurgeBox.Name = "anneepurgeBox";
			this.anneepurgeBox.Size = new System.Drawing.Size(100, 20);
			this.anneepurgeBox.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Lime;
			this.label4.Location = new System.Drawing.Point(120, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "stat Visites";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Fuchsia;
			this.label5.Location = new System.Drawing.Point(389, 68);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 23);
			this.label5.TabIndex = 7;
			this.label5.Text = "purge Stock";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Fuchsia;
			this.label6.Location = new System.Drawing.Point(490, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(73, 23);
			this.label6.TabIndex = 8;
			this.label6.Text = "purge Visites";
			// 
			// resultatSQLBox
			// 
			this.resultatSQLBox.Location = new System.Drawing.Point(1, 447);
			this.resultatSQLBox.Multiline = true;
			this.resultatSQLBox.Name = "resultatSQLBox";
			this.resultatSQLBox.Size = new System.Drawing.Size(873, 47);
			this.resultatSQLBox.TabIndex = 9;
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(35, 132);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(344, 96);
			this.dataGrid1.TabIndex = 10;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(22, 273);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(550, 94);
			this.dataGridView1.TabIndex = 11;
			// 
			// sqlCalculeBox
			// 
			this.sqlCalculeBox.Location = new System.Drawing.Point(1, 394);
			this.sqlCalculeBox.Multiline = true;
			this.sqlCalculeBox.Name = "sqlCalculeBox";
			this.sqlCalculeBox.Size = new System.Drawing.Size(873, 47);
			this.sqlCalculeBox.TabIndex = 12;
			// 
			// MouliSQLForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 506);
			this.Controls.Add(this.sqlCalculeBox);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.resultatSQLBox);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.anneepurgeBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.detailmagasinBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.magasinIdBox);
			this.Controls.Add(this.label1);
			this.Name = "MouliSQLForm";
			this.Text = "MouliSQLForm";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.TextBox sqlCalculeBox;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox resultatSQLBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox anneepurgeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox detailmagasinBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox magasinIdBox;
		private System.Windows.Forms.Label label1;
	}
}
