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
			this.statStockLabel = new System.Windows.Forms.Label();
			this.detailmagasinBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.anneeStockPurgeBox = new System.Windows.Forms.TextBox();
			this.statVisitesLabel = new System.Windows.Forms.Label();
			this.purgeStockLabel = new System.Windows.Forms.Label();
			this.purgeVisitesLabel = new System.Windows.Forms.Label();
			this.resultatSQLBox = new System.Windows.Forms.TextBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.sqlCalculeBox = new System.Windows.Forms.TextBox();
			this.anneeVisitePurgeBox = new System.Windows.Forms.TextBox();
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
			// statStockLabel
			// 
			this.statStockLabel.BackColor = System.Drawing.Color.Lime;
			this.statStockLabel.Location = new System.Drawing.Point(12, 78);
			this.statStockLabel.Name = "statStockLabel";
			this.statStockLabel.Size = new System.Drawing.Size(73, 23);
			this.statStockLabel.TabIndex = 2;
			this.statStockLabel.Text = "stat Stock";
			this.statStockLabel.Click += new System.EventHandler(this.StatStockLabelClick);
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
			// anneeStockPurgeBox
			// 
			this.anneeStockPurgeBox.Location = new System.Drawing.Point(12, 55);
			this.anneeStockPurgeBox.Name = "anneeStockPurgeBox";
			this.anneeStockPurgeBox.Size = new System.Drawing.Size(74, 20);
			this.anneeStockPurgeBox.TabIndex = 5;
			// 
			// statVisitesLabel
			// 
			this.statVisitesLabel.BackColor = System.Drawing.Color.Lime;
			this.statVisitesLabel.Location = new System.Drawing.Point(120, 78);
			this.statVisitesLabel.Name = "statVisitesLabel";
			this.statVisitesLabel.Size = new System.Drawing.Size(73, 23);
			this.statVisitesLabel.TabIndex = 6;
			this.statVisitesLabel.Text = "stat Visites";
			this.statVisitesLabel.Click += new System.EventHandler(this.StatVisitesLabelClick);
			// 
			// purgeStockLabel
			// 
			this.purgeStockLabel.BackColor = System.Drawing.Color.Fuchsia;
			this.purgeStockLabel.Location = new System.Drawing.Point(12, 106);
			this.purgeStockLabel.Name = "purgeStockLabel";
			this.purgeStockLabel.Size = new System.Drawing.Size(73, 23);
			this.purgeStockLabel.TabIndex = 7;
			this.purgeStockLabel.Text = "purge Stock";
			this.purgeStockLabel.Click += new System.EventHandler(this.PurgeStockLabelClick);
			// 
			// purgeVisitesLabel
			// 
			this.purgeVisitesLabel.BackColor = System.Drawing.Color.Fuchsia;
			this.purgeVisitesLabel.Location = new System.Drawing.Point(120, 106);
			this.purgeVisitesLabel.Name = "purgeVisitesLabel";
			this.purgeVisitesLabel.Size = new System.Drawing.Size(73, 23);
			this.purgeVisitesLabel.TabIndex = 8;
			this.purgeVisitesLabel.Text = "purge Visites";
			this.purgeVisitesLabel.Click += new System.EventHandler(this.PurgeVisitesLabelClick);
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
			// anneeVisitePurgeBox
			// 
			this.anneeVisitePurgeBox.Location = new System.Drawing.Point(120, 55);
			this.anneeVisitePurgeBox.Name = "anneeVisitePurgeBox";
			this.anneeVisitePurgeBox.Size = new System.Drawing.Size(73, 20);
			this.anneeVisitePurgeBox.TabIndex = 13;
			// 
			// MouliSQLForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 506);
			this.Controls.Add(this.anneeVisitePurgeBox);
			this.Controls.Add(this.sqlCalculeBox);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.resultatSQLBox);
			this.Controls.Add(this.purgeVisitesLabel);
			this.Controls.Add(this.purgeStockLabel);
			this.Controls.Add(this.statVisitesLabel);
			this.Controls.Add(this.anneeStockPurgeBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.detailmagasinBox);
			this.Controls.Add(this.statStockLabel);
			this.Controls.Add(this.magasinIdBox);
			this.Controls.Add(this.label1);
			this.Name = "MouliSQLForm";
			this.Text = "MouliSQLForm";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.TextBox anneeVisitePurgeBox;
		private System.Windows.Forms.TextBox sqlCalculeBox;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox resultatSQLBox;
		private System.Windows.Forms.Label purgeVisitesLabel;
		private System.Windows.Forms.Label purgeStockLabel;
		private System.Windows.Forms.Label statVisitesLabel;
		private System.Windows.Forms.TextBox anneeStockPurgeBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox detailmagasinBox;
		private System.Windows.Forms.Label statStockLabel;
		private System.Windows.Forms.TextBox magasinIdBox;
		private System.Windows.Forms.Label label1;
	}
}
