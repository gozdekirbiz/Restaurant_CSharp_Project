namespace rest
{
    partial class FormSiparişveMüşteriKontrol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSiparişveMüşteriKontrol));
            this.lvMusteriDetaylari = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSatisDetaylari = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtToplamTutar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lvMüşteriler = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblToplamSiparis = new System.Windows.Forms.Label();
            this.lblGenelToplam = new System.Windows.Forms.Label();
            this.lblSonSiparisTarihi = new System.Windows.Forms.Label();
            this.btnGeridon = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMusteriDetaylari
            // 
            this.lvMusteriDetaylari.BackColor = System.Drawing.Color.Azure;
            this.lvMusteriDetaylari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvMusteriDetaylari.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMusteriDetaylari.FullRowSelect = true;
            this.lvMusteriDetaylari.GridLines = true;
            this.lvMusteriDetaylari.HideSelection = false;
            this.lvMusteriDetaylari.Location = new System.Drawing.Point(358, 137);
            this.lvMusteriDetaylari.Margin = new System.Windows.Forms.Padding(1);
            this.lvMusteriDetaylari.Name = "lvMusteriDetaylari";
            this.lvMusteriDetaylari.Size = new System.Drawing.Size(314, 160);
            this.lvMusteriDetaylari.TabIndex = 0;
            this.lvMusteriDetaylari.UseCompatibleStateImageBehavior = false;
            this.lvMusteriDetaylari.View = System.Windows.Forms.View.Details;
            this.lvMusteriDetaylari.SelectedIndexChanged += new System.EventHandler(this.lvMusteriDetaylari_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MüşteriID";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Müşteri Adı";
            this.columnHeader2.Width = 199;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Müşteri Soyadı";
            this.columnHeader3.Width = 249;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tarih";
            this.columnHeader4.Width = 229;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "AdisyonID";
            this.columnHeader5.Width = 0;
            // 
            // lvSatisDetaylari
            // 
            this.lvSatisDetaylari.BackColor = System.Drawing.Color.Azure;
            this.lvSatisDetaylari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvSatisDetaylari.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSatisDetaylari.FullRowSelect = true;
            this.lvSatisDetaylari.GridLines = true;
            this.lvSatisDetaylari.HideSelection = false;
            this.lvSatisDetaylari.Location = new System.Drawing.Point(676, 137);
            this.lvSatisDetaylari.Margin = new System.Windows.Forms.Padding(1);
            this.lvSatisDetaylari.Name = "lvSatisDetaylari";
            this.lvSatisDetaylari.Size = new System.Drawing.Size(215, 183);
            this.lvSatisDetaylari.TabIndex = 1;
            this.lvSatisDetaylari.UseCompatibleStateImageBehavior = false;
            this.lvSatisDetaylari.View = System.Windows.Forms.View.Details;
            this.lvSatisDetaylari.SelectedIndexChanged += new System.EventHandler(this.lvSatisDetaylari_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "SatışID";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ürün Adı";
            this.columnHeader7.Width = 149;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Adet";
            this.columnHeader8.Width = 133;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Fiyat";
            this.columnHeader9.Width = 138;
            // 
            // txtToplamTutar
            // 
            this.txtToplamTutar.Font = new System.Drawing.Font("Cocogoose Pro", 9.9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToplamTutar.Location = new System.Drawing.Point(493, 301);
            this.txtToplamTutar.Margin = new System.Windows.Forms.Padding(1);
            this.txtToplamTutar.Name = "txtToplamTutar";
            this.txtToplamTutar.ReadOnly = true;
            this.txtToplamTutar.Size = new System.Drawing.Size(180, 22);
            this.txtToplamTutar.TabIndex = 2;
            this.txtToplamTutar.TextChanged += new System.EventHandler(this.txtToplamTutar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(356, 304);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Toplam Sipariş Adeti:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(537, 385);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "En Son Sipariş:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Azure;
            this.label3.Location = new System.Drawing.Point(537, 359);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genel Toplam:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(537, 334);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Toplam:";
            // 
            // lvMüşteriler
            // 
            this.lvMüşteriler.BackColor = System.Drawing.Color.Azure;
            this.lvMüşteriler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvMüşteriler.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMüşteriler.FullRowSelect = true;
            this.lvMüşteriler.GridLines = true;
            this.lvMüşteriler.HideSelection = false;
            this.lvMüşteriler.Location = new System.Drawing.Point(48, 22);
            this.lvMüşteriler.Margin = new System.Windows.Forms.Padding(1);
            this.lvMüşteriler.Name = "lvMüşteriler";
            this.lvMüşteriler.Size = new System.Drawing.Size(28, 27);
            this.lvMüşteriler.TabIndex = 7;
            this.lvMüşteriler.UseCompatibleStateImageBehavior = false;
            this.lvMüşteriler.View = System.Windows.Forms.View.Details;
            this.lvMüşteriler.Visible = false;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "MüşteriID";
            this.columnHeader10.Width = 180;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Müşteri";
            this.columnHeader11.Width = 223;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "AdisyonID";
            // 
            // lblToplamSiparis
            // 
            this.lblToplamSiparis.AutoSize = true;
            this.lblToplamSiparis.BackColor = System.Drawing.Color.Transparent;
            this.lblToplamSiparis.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToplamSiparis.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblToplamSiparis.Location = new System.Drawing.Point(680, 334);
            this.lblToplamSiparis.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblToplamSiparis.Name = "lblToplamSiparis";
            this.lblToplamSiparis.Size = new System.Drawing.Size(35, 13);
            this.lblToplamSiparis.TabIndex = 8;
            this.lblToplamSiparis.Text = "____";
            // 
            // lblGenelToplam
            // 
            this.lblGenelToplam.AutoSize = true;
            this.lblGenelToplam.BackColor = System.Drawing.Color.Transparent;
            this.lblGenelToplam.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenelToplam.ForeColor = System.Drawing.Color.Azure;
            this.lblGenelToplam.Location = new System.Drawing.Point(680, 359);
            this.lblGenelToplam.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblGenelToplam.Name = "lblGenelToplam";
            this.lblGenelToplam.Size = new System.Drawing.Size(35, 13);
            this.lblGenelToplam.TabIndex = 9;
            this.lblGenelToplam.Text = "____";
            // 
            // lblSonSiparisTarihi
            // 
            this.lblSonSiparisTarihi.AutoSize = true;
            this.lblSonSiparisTarihi.BackColor = System.Drawing.Color.Transparent;
            this.lblSonSiparisTarihi.Font = new System.Drawing.Font("Cocogoose Pro", 8.099999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSonSiparisTarihi.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSonSiparisTarihi.Location = new System.Drawing.Point(680, 385);
            this.lblSonSiparisTarihi.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblSonSiparisTarihi.Name = "lblSonSiparisTarihi";
            this.lblSonSiparisTarihi.Size = new System.Drawing.Size(35, 13);
            this.lblSonSiparisTarihi.TabIndex = 10;
            this.lblSonSiparisTarihi.Text = "____";
            // 
            // btnGeridon
            // 
            this.btnGeridon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGeridon.BackgroundImage")));
            this.btnGeridon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeridon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeridon.FlatAppearance.BorderSize = 0;
            this.btnGeridon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeridon.Location = new System.Drawing.Point(47, 690);
            this.btnGeridon.Margin = new System.Windows.Forms.Padding(1);
            this.btnGeridon.Name = "btnGeridon";
            this.btnGeridon.Size = new System.Drawing.Size(63, 63);
            this.btnGeridon.TabIndex = 12;
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
            this.btnCikis.Location = new System.Drawing.Point(126, 690);
            this.btnCikis.Margin = new System.Windows.Forms.Padding(1);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(63, 63);
            this.btnCikis.TabIndex = 11;
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // FormSiparişveMüşteriKontrol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.btnGeridon);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.lblSonSiparisTarihi);
            this.Controls.Add(this.lblGenelToplam);
            this.Controls.Add(this.lblToplamSiparis);
            this.Controls.Add(this.lvMüşteriler);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToplamTutar);
            this.Controls.Add(this.lvSatisDetaylari);
            this.Controls.Add(this.lvMusteriDetaylari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FormSiparişveMüşteriKontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSiparişKontrol";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSiparişKontrol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMusteriDetaylari;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvSatisDetaylari;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox txtToplamTutar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvMüşteriler;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label lblToplamSiparis;
        private System.Windows.Forms.Label lblGenelToplam;
        private System.Windows.Forms.Label lblSonSiparisTarihi;
        private System.Windows.Forms.Button btnGeridon;
        private System.Windows.Forms.Button btnCikis;
    }
}