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
    public partial class FormPersoneller : Form
    {
        public FormPersoneller()
        {
            InitializeComponent();
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {
            ClassPersoneller cp = new ClassPersoneller();
            ClassPersonelGörevleri cpg = new ClassPersonelGörevleri();
            string gorev = cpg.EmployeeDutyDescription(ClassBilgiGenel._gorevId);
            if (gorev == "Müdür")
            {
                cp.BringEmployeeInfo(cbPersonel);
                cpg.BringEmployeeDuty(cbGorevi);
                cp.ForLVBringEmployeeInfo(lvPersoneller);
                btnYeni.Enabled = true;
                btnSil.Enabled = false;
                btnBilgiDegistir.Enabled = false;
                btnEkle.Enabled = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = true;
                txtSifre.ReadOnly = true;
                txtSifreTekrar.ReadOnly = true;
                lblBilgi.Text = "Mevki=Müdür / Yetki:Sınırsız / Kullanıcı:" + cp.BringEmployeeName(ClassBilgiGenel._personelId);
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = true;
                groupBox4.Visible = false;
                lblBilgi.Text = "Mevki=Personel / Yetki:Sınırlı / Kullanıcı:" + cp.BringEmployeeName(ClassBilgiGenel._personelId);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //yeni butonu 
        {
            btnYeni.Enabled = false;
            btnSil.Enabled = false;
            btnBilgiDegistir.Enabled = false;
            btnEkle.Enabled = true;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lvPersoneller_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(lvPersoneller.SelectedItems.Count>0)
            {
                btnBilgiDegistir.Enabled = true;
                btnSil.Enabled = true;
                txtPersonellId.Text = lvPersoneller.SelectedItems[0].SubItems[0].Text;
                //txtGorevId2.Text = lvPersoneller.SelectedItems[0].SubItems[1].Text;
                cbGorevi.SelectedIndex = Convert.ToInt32(lvPersoneller.SelectedItems[0].SubItems[1].Text)-1;
                txtAd.Text = lvPersoneller.SelectedItems[0].SubItems[3].Text;
                txtSoyad.Text = lvPersoneller.SelectedItems[0].SubItems[4].Text;
            }
            else
            {
                btnBilgiDegistir.Enabled = false;
                btnSil.Enabled = false;
            }
           
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtYeniSifre.Text.Trim() != "" || txtYenidenSifre.Text.Trim() != "")
            {
                if (txtYeniSifre.Text == txtYenidenSifre.Text)
                {
                    if (txtPersonelId.Text != "")
                    {
                        ClassPersoneller c = new ClassPersoneller();
                        bool sonuc = c.EmployeePasswordChange(Convert.ToInt32(txtPersonelId.Text), txtYenidenSifre.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre başarıyla değiştirildi.");
                        }
                    }
                    else
                        MessageBox.Show("Personel seçiniz!");
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil!");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız!");
            }
        }

        private void txtYenidenSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbGorevi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassPersonelGörevleri c = (ClassPersonelGörevleri)cbGorevi.SelectedItem;
            txtGorevId2.Text = Convert.ToString(c.PersonelGorevId);
        }

        private void cbPersonel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassPersoneller c = (ClassPersoneller)cbPersonel.SelectedItem;
            txtPersonelId.Text = Convert.ToString(c.PersonelId);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ClassPersoneller c = new ClassPersoneller();
                    bool sonuc = c.DeleteEmployee(Convert.ToInt32(lvPersoneller.SelectedItems[0].Text));
                    if (sonuc)
                    {
                        MessageBox.Show("Kayıt başarıyla silindi");
                        c.ForLVBringEmployeeInfo(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt silinirken bir hata oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Kayıt seçiniz");
                }
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtAd.Text.Trim() != "" & txtSoyad.Text.Trim() != "" & txtSifre.Text.Trim() != "" & txtSifreTekrar.Text.Trim() != "" & txtGorevId2.Text.Trim() != "")
            {
                if (txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim() && (txtSifreTekrar.Text.Length > 2 || txtSifre.Text.Length > 2))
                {
                    ClassPersoneller c = new ClassPersoneller();
                    c.PersonelAd = txtAd.Text.Trim();
                    c.PersonelSoyad = txtSoyad.Text.Trim();
                    c.PersonelParola = txtSifre.Text;
                    c.PersonelGorevId = Convert.ToInt32(txtGorevId2.Text);
                    bool sonuc = c.AddEmployee(c);
                    if (sonuc)
                    {
                        MessageBox.Show("Personel başarıyla eklendi.");
                        c.ForLVBringEmployeeInfo(lvPersoneller);
                    }
                    else
                    {
                        MessageBox.Show("Ekleme sırasında hata oluştu");
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler uyuşmuyor");
                }
            }
            else
            {
                MessageBox.Show("Bu alanı boş bırakmayıınız");
            }

        }

        private void btnBilgiDegistir_Click(object sender, EventArgs e)
        {
            if (lvPersoneller.SelectedItems.Count > 0)
            {
                txtSifre.ReadOnly = false;
                txtSifreTekrar.ReadOnly = false;

                if (txtAd.Text.Trim() != "" || txtSoyad.Text.Trim() != "" || txtSifre.Text.Trim() != "" || txtSifreTekrar.Text.Trim() != "" || txtGorevId2.Text.Trim() != "")
                {
                    if (txtSifreTekrar.Text.Trim() == txtSifre.Text.Trim() && (txtSifreTekrar.Text.Length > 2 || txtSifre.Text.Length > 2))
                    {
                        ClassPersoneller c = new ClassPersoneller();
                        c.PersonelAd = txtAd.Text.Trim();
                        c.PersonelSoyad = txtSoyad.Text.Trim();
                        c.PersonelParola = txtSifre.Text;
                        c.PersonelGorevId = Convert.ToInt32(txtGorevId2.Text);
                        bool sonuc =c.UpdateEmployee(c,Convert.ToInt32(txtPersonellId.Text));
                        if (sonuc)
                        {
                            MessageBox.Show("Personel başarıyla güncellendi.");
                            c.ForLVBringEmployeeInfo(lvPersoneller);//liste yenileniyor
                           
                        }
                        else
                        {
                            MessageBox.Show("Güncelleme sırasında hata oluştu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreyi girin");
                    }
                }
                else
                {
                    MessageBox.Show("Bu alanı boş bırakmayıınız");
                }
            }
            else
            {
                MessageBox.Show("Personeli seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() != "" || textBox4.Text.Trim() != "")
            {
                if (textBox2.Text == textBox4.Text)
                {
                    if (ClassBilgiGenel._personelId.ToString() != "")
                    {
                        ClassPersoneller c = new ClassPersoneller();
                        bool sonuc = c.EmployeePasswordChange(ClassBilgiGenel._personelId, textBox2.Text);
                        if (sonuc)
                        {
                            MessageBox.Show("Şifre başarıyla değiştirildi.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil!");
                }
            }
            else
            {
                MessageBox.Show("Şifre alanını boş bırakmayınız!");
            }
        }

        private void txtPersonellId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnYeni.Enabled = false;
            btnSil.Enabled = false;
            btnBilgiDegistir.Enabled = false;
            btnEkle.Enabled = true;
            txtSifre.ReadOnly = false;
            txtSifreTekrar.ReadOnly = false;
        }
    }
}
