using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rest
{
    public partial class FormMüşteriEkle : Form
    {
        public FormMüşteriEkle()
        {
            InitializeComponent();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtAd.Text == "" || txtSoyad.Text == "")
                {
                    MessageBox.Show("Müşteri ad ve soyad kısmı boş bırakılamaz.");
                }
                else
                {
                    bool f = isValidEmail(txtEmail.Text);
                    if (f == true)
                    {
                        ClassMüşteriler c = new ClassMüşteriler();
                        bool sonuc = c.IsClientExist(txtTelefon.Text);
                        if (!sonuc)
                        {
                            c.Musteriad = txtAd.Text;
                            c.Musterisoyad = txtSoyad.Text;
                            c.Telefon = txtTelefon.Text;
                            c.Email = txtEmail.Text;
                            c.Adres = txtAdres.Text;
                            txtMusteriNo.Text = c.AddClient(c).ToString();
                            if (txtMusteriNo.Text != "")
                            {
                                MessageBox.Show("Müşteri eklendi");
                            }
                            else
                            {
                                MessageBox.Show("Müşteri eklenemedi!");
                            }
                        }
                        else
                            MessageBox.Show("Bu isimde kayıt bulunmaktadır.");
                    }
                    else
                        MessageBox.Show("Geçersiz email adresi girdiniz");

                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz.");
            }
        }

        private void btnMusteriSec_Click(object sender, EventArgs e)
        {
            if (ClassBilgiGenel._musteriEkleme == 0)
            {
                FormRezervasyonİşlemleri frm = new FormRezervasyonİşlemleri();
                ClassBilgiGenel._musteriEkleme = 1;
                this.Close();
                frm.Show();
            }
            else if (ClassBilgiGenel._musteriEkleme == 1)
            {
                FormPaketServisi frm = new FormPaketServisi();
                ClassBilgiGenel._musteriEkleme = 0;
                this.Close();
                frm.Show();
            }
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTelefon.Text.Length > 6)
            {
                if (txtAd.Text == "" || txtSoyad.Text == "")
                {
                    MessageBox.Show("Müşteri ad ve soyad kısmı boş bırakılamaz.");
                }
                else
                {
                    bool f = isValidEmail(txtEmail.Text);
                    if (f == true)
                    {
                        ClassMüşteriler c = new ClassMüşteriler();
                        c.Musteriad = txtAd.Text;
                        c.Musterisoyad = txtSoyad.Text;
                        c.Telefon = txtTelefon.Text;
                        c.Email = txtEmail.Text;
                        c.Adres = txtAdres.Text;
                        c.Musteriid = Convert.ToInt32(txtMusteriNo.Text);
                        bool sonuc = c.UpdateClient(c);


                        if (sonuc)
                        {

                            if (txtMusteriNo.Text != "")
                            {
                                MessageBox.Show("Müşteri bilgileri güncellendi");
                            }
                            else
                            {
                                MessageBox.Show("Müşteri bilgileri güncellenemedi!");
                            }
                        }
                        else
                            MessageBox.Show("Bu isimde kayıt bulunmaktadır.");
                    }
                    else
                        MessageBox.Show("Geçersiz email adresi girdiniz.");

                }
            }
            else
            {
                MessageBox.Show("Lütfen en az 7 haneli bir telefon numarası giriniz.");
            }
        }

        private void frmMusteriEkleme_Load(object sender, EventArgs e)
        {
            if (ClassBilgiGenel._musteriId > 0)
            {
                ClassMüşteriler c = new ClassMüşteriler();
                txtMusteriNo.Text = ClassBilgiGenel._musteriId.ToString();
                c.WithID_BringClients(Convert.ToInt32(txtMusteriNo.Text), txtAd, txtSoyad, txtTelefon, txtAdres, txtEmail);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        //geri döndürme butonu
        private void button3_Click(object sender, EventArgs e)
        {

            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }

        private void btnGeridon_Click(object sender, EventArgs e)
        {

            FormMüşteriler frm = new FormMüşteriler();
            this.Close();
            frm.Show();
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

    }
}
