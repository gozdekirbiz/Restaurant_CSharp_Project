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
    public partial class FormRapor : Form
    {
        public FormRapor()
        {
            InitializeComponent();
        }

        private void frmKasa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.DataTable2' table. You can move, or remove it, as needed.
            this.DataTable2TableAdapter.Fill(this.DataSet3.DataTable2);
            // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DataSet3.DataTable1);

            this.rpvAylik.RefreshReport();
            this.rpvGunluk.RefreshReport();
            rpvGunluk.Visible = false;
            lblAylikRapor.Text = "AYLIK RAPOR";
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnAylikRapor_Click(object sender, EventArgs e)
        {
            lblAylikRapor.Text = "AYLIK RAPOR";
            rpvAylik.Visible = true;
            rpvGunluk.Visible = false;
        }

        private void btnZRaporu_Click(object sender, EventArgs e)
        {
            lblAylikRapor.Text = "GÜNLÜK RAPOR";
            rpvAylik.Visible = false;
            rpvGunluk.Visible = true;
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }
    }
}
