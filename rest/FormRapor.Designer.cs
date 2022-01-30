namespace rest
{
    partial class FormRapor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRapor));
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet3 = new rest.DataSet3();
            this.DataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvAylik = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnAylikRapor = new System.Windows.Forms.Button();
            this.btnZRaporu = new System.Windows.Forms.Button();
            this.lblAylikRapor = new System.Windows.Forms.Label();
            this.rpvGunluk = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new rest.DataSet3TableAdapters.DataTable1TableAdapter();
            this.DataTable2TableAdapter = new rest.DataSet3TableAdapters.DataTable2TableAdapter();
            this.btnGeridon = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DataSet3;
            // 
            // DataSet3
            // 
            this.DataSet3.DataSetName = "DataSet2";
            this.DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable2BindingSource
            // 
            this.DataTable2BindingSource.DataMember = "DataTable2";
            this.DataTable2BindingSource.DataSource = this.DataSet3;
            // 
            // rpvAylik
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.rpvAylik.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvAylik.LocalReport.ReportEmbeddedResource = "rest.Report1.rdlc";
            this.rpvAylik.Location = new System.Drawing.Point(223, 42);
            this.rpvAylik.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rpvAylik.Name = "rpvAylik";
            this.rpvAylik.ServerReport.BearerToken = null;
            this.rpvAylik.Size = new System.Drawing.Size(727, 396);
            this.rpvAylik.TabIndex = 0;
            this.rpvAylik.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // btnAylikRapor
            // 
            this.btnAylikRapor.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAylikRapor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAylikRapor.FlatAppearance.BorderSize = 0;
            this.btnAylikRapor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAylikRapor.Font = new System.Drawing.Font("Cocogoose Pro", 12F, System.Drawing.FontStyle.Italic);
            this.btnAylikRapor.ForeColor = System.Drawing.Color.White;
            this.btnAylikRapor.Location = new System.Drawing.Point(71, 121);
            this.btnAylikRapor.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnAylikRapor.Name = "btnAylikRapor";
            this.btnAylikRapor.Size = new System.Drawing.Size(139, 105);
            this.btnAylikRapor.TabIndex = 2;
            this.btnAylikRapor.Text = "Aylık Rapor";
            this.btnAylikRapor.UseVisualStyleBackColor = false;
            this.btnAylikRapor.Click += new System.EventHandler(this.btnAylikRapor_Click);
            // 
            // btnZRaporu
            // 
            this.btnZRaporu.BackColor = System.Drawing.Color.SkyBlue;
            this.btnZRaporu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZRaporu.FlatAppearance.BorderSize = 0;
            this.btnZRaporu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZRaporu.Font = new System.Drawing.Font("Cocogoose Pro", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZRaporu.ForeColor = System.Drawing.Color.White;
            this.btnZRaporu.Location = new System.Drawing.Point(71, 239);
            this.btnZRaporu.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnZRaporu.Name = "btnZRaporu";
            this.btnZRaporu.Size = new System.Drawing.Size(139, 105);
            this.btnZRaporu.TabIndex = 3;
            this.btnZRaporu.Text = "Günlük Rapor";
            this.btnZRaporu.UseVisualStyleBackColor = false;
            this.btnZRaporu.Click += new System.EventHandler(this.btnZRaporu_Click);
            // 
            // lblAylikRapor
            // 
            this.lblAylikRapor.AutoSize = true;
            this.lblAylikRapor.BackColor = System.Drawing.Color.Transparent;
            this.lblAylikRapor.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAylikRapor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAylikRapor.Location = new System.Drawing.Point(517, 24);
            this.lblAylikRapor.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblAylikRapor.Name = "lblAylikRapor";
            this.lblAylikRapor.Size = new System.Drawing.Size(83, 13);
            this.lblAylikRapor.TabIndex = 4;
            this.lblAylikRapor.Text = "AYLIK RAPOR";
            // 
            // rpvGunluk
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.DataTable2BindingSource;
            this.rpvGunluk.LocalReport.DataSources.Add(reportDataSource2);
            this.rpvGunluk.LocalReport.ReportEmbeddedResource = "rest.Report2.rdlc";
            this.rpvGunluk.Location = new System.Drawing.Point(223, 50);
            this.rpvGunluk.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rpvGunluk.Name = "rpvGunluk";
            this.rpvGunluk.ServerReport.BearerToken = null;
            this.rpvGunluk.Size = new System.Drawing.Size(727, 388);
            this.rpvGunluk.TabIndex = 5;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // DataTable2TableAdapter
            // 
            this.DataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // btnGeridon
            // 
            this.btnGeridon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeridon.BackgroundImage")));
            this.btnGeridon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeridon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeridon.FlatAppearance.BorderSize = 0;
            this.btnGeridon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeridon.Location = new System.Drawing.Point(48, 684);
            this.btnGeridon.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnGeridon.Name = "btnGeridon";
            this.btnGeridon.Size = new System.Drawing.Size(58, 61);
            this.btnGeridon.TabIndex = 10;
            this.btnGeridon.UseVisualStyleBackColor = true;
            this.btnGeridon.Click += new System.EventHandler(this.btnGeridon_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCikis.BackgroundImage")));
            this.btnCikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCikis.FlatAppearance.BorderSize = 0;
            this.btnCikis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCikis.Location = new System.Drawing.Point(121, 684);
            this.btnCikis.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(58, 61);
            this.btnCikis.TabIndex = 9;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // FormRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.btnGeridon);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.rpvGunluk);
            this.Controls.Add(this.lblAylikRapor);
            this.Controls.Add(this.btnZRaporu);
            this.Controls.Add(this.btnAylikRapor);
            this.Controls.Add(this.rpvAylik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "FormRapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKasa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvAylik;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DataSet3 DataSet3;
        private DataSet3TableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Button btnAylikRapor;
        private System.Windows.Forms.Button btnZRaporu;
        private System.Windows.Forms.Label lblAylikRapor;
        private Microsoft.Reporting.WinForms.ReportViewer rpvGunluk;
        private System.Windows.Forms.BindingSource DataTable2BindingSource;
        private DataSet3TableAdapters.DataTable2TableAdapter DataTable2TableAdapter;
        private System.Windows.Forms.Button btnGeridon;
        private System.Windows.Forms.Button btnCikis;
    }
}