using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class FormMenü : Form
    {
        public FormMenü()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void btn_musteriler_Click(object sender, EventArgs e)
        {
            FormMüşteriler frm = new FormMüşteriler();
            this.Close();
            frm.Show();
        }

        private void btn_masa_Click(object sender, EventArgs e)
        {
            FormMasalar frm = new FormMasalar();
            this.Close();
            frm.Show();
        }

        private void btn_rezervasyon_Click(object sender, EventArgs e)
        {
            FormRezervasyonİşlemleri frm = new FormRezervasyonİşlemleri();
            this.Close();
            frm.Show();
        }

        private void btn_paket_Click(object sender, EventArgs e)
        {
            FormPaketServisi frm = new FormPaketServisi();
            this.Close();
            frm.Show();
        }

        private void btn_kasa_Click(object sender, EventArgs e)
        {
            FormRapor frm = new FormRapor();
            this.Close();
            frm.Show();
        }

        private void btn_raporlar_Click(object sender, EventArgs e)
        {
            Formİstatistik frm = new Formİstatistik();
            this.Close();
            frm.Show();
        }

        private void btn_ayarlar_Click(object sender, EventArgs e)
        {
            FormPersoneller frm = new FormPersoneller();
            this.Close();
            frm.Show();
        }

        private void btn_mutfak_Click(object sender, EventArgs e)
        {
            FormÜrünKategori frm = new FormÜrünKategori();
            this.Close();
            frm.Show();
        }

        private void btn_kilitle_Click(object sender, EventArgs e)
        {
            FormKilitle frm = new FormKilitle();
            this.Close();
            frm.Show();
        }
        private void btn_kapa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
