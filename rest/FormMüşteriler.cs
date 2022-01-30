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
    public partial class FormMüşteriler : Form
    {
        public FormMüşteriler()
        {
            InitializeComponent();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            FormMüşteriEkle frm = new FormMüşteriEkle();
            ClassBilgiGenel._musteriEkleme = 1;

            this.Close();
            frm.Show();
        }

        private void frmMusteriler_Load(object sender, EventArgs e)
        {
            ClassMüşteriler c = new ClassMüşteriler();
            c.ForLv_BringClients(lvMusteriler);
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {

        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                FormMüşteriEkle frm = new FormMüşteriEkle();
                ClassBilgiGenel._musteriEkleme = 1;
                ClassBilgiGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);

                this.Close();
                frm.Show();

            }
        }


        private void btnGeridon_Click(object sender, EventArgs e)
        {
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler c = new ClassMüşteriler();
            c.WithName_BringClients(lvMusteriler, txtAd.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler c = new ClassMüşteriler();
            c.WithSurname_BringClients(lvMusteriler, txtSoyad.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler c = new ClassMüşteriler();
            c.WithPhoneNumber_BringClients(lvMusteriler, txtTelefon.Text);
        }

        private void btnAdisyonBul_Click(object sender, EventArgs e)
        {
            if (txtAdisyonId.Text != "")
            {
                ClassBilgiGenel._AdisyonId = txtAdisyonId.Text;
                ClassPaketServis c = new ClassPaketServis();
                bool sonuc = c.getCheckOpenAdditionID(Convert.ToInt32(txtAdisyonId.Text));
                if (sonuc)
                {
                    FormÖdeme frm = new FormÖdeme();
                    ClassBilgiGenel._ServisTurNo = 2;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show(txtAdisyonId.Text + "no'lu bir adisyon bulunamadı");
                }
            }
            else
            {
                MessageBox.Show("Aramak istediğiniz adisyonu yazınız");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSiparişveMüşteriKontrol frm = new FormSiparişveMüşteriKontrol();
            this.Close();
            frm.Show();
        }

        private void lblAd_Click(object sender, EventArgs e)
        {

        }
        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler c = new ClassMüşteriler();
            c.WithAdress_BringClients(lvMusteriler, txtAdres.Text);
        }

        private void btnMüsteriSil_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClassMüşteriler c = new ClassMüşteriler();
                    bool sonuc = c.DeleteClient(Convert.ToInt32(lvMusteriler.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("Müşteri başarıyla silindi");
                        c.ForLv_BringClients(lvMusteriler);
                    }
                    else
                    {
                        MessageBox.Show("Müşteri silinirken bir hata oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri seçiniz");
                }
            }
        }
    }
}
