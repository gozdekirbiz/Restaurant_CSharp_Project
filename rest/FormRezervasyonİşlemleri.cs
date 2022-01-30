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
    public partial class FormRezervasyonİşlemleri : Form
    {
        public FormRezervasyonİşlemleri()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            FormMüşteriler frm = new FormMüşteriler();
            this.Close();
            frm.Show();
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            ClassMüşteriler m = new ClassMüşteriler();
            m.ForLv_BringClients(lvMusteriler);

            ClassMasalar masa = new ClassMasalar();
            masa.MasaKapasitesiVeDurumuGetir(cbMasa);

            dtTarih.MinDate = DateTime.Today;
            dtTarih.Format = DateTimePickerFormat.Time;
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler m = new ClassMüşteriler();
            m.WithName_BringClients(lvMusteriler, txtMusteriAd.Text);
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler m = new ClassMüşteriler();
            m.WithPhoneNumber_BringClients(lvMusteriler, txtTelefon.Text);
        }
       

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {
            ClassMüşteriler m = new ClassMüşteriler();
            m.WithAdress_BringClients(lvMusteriler, txtAdres.Text);
        }
        void temizle()
        {
            txtAdres.Clear();
            txtKisiSayisi.Clear();
            txtMasa.Clear();
            txtTarih.Clear();
            txtTelefon.Clear();  
        }

        private void btnRezervasyonAc_Click(object sender, EventArgs e)
        {
            ClassRezervasyon r = new ClassRezervasyon();

            if (lvMusteriler.SelectedItems.Count > 0)
            {
                bool sonuc = r.RezervasyonAcikmiKontrol(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                if (!sonuc)
                {
                    if (txtTarih.Text != "")
                    {
                        if (txtKisiSayisi.Text != "")
                        {
                            ClassMasalar masa = new ClassMasalar();
                         
                            if (masa.TableGetByState(Convert.ToInt32(txtMasaNo.Text), 1))
                            {
                                ClassAdisyonİşlemleri a = new ClassAdisyonİşlemleri();
                                a.Tarih = Convert.ToDateTime(txtTarih.Text);
                                a.ServisTurNo = 1;
                                a.MasaId = Convert.ToInt32(txtMasaNo.Text);
                                a.PersonelId = ClassBilgiGenel._personelId;

                                r.ClientId= Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                                r.TableId = Convert.ToInt32(txtMasaNo.Text);
                                r.Date= Convert.ToDateTime(txtTarih.Text);
                                r.ClientCount = Convert.ToInt32(txtKisiSayisi.Text);
                                r.Description = txtAcıklama.Text;


                                r.AdditionId = a.RezervasyonAdisyonAc(a);
                                sonuc = r.RezervasyonAc(r);
                                masa.setChangeTableState(txtMasaNo.Text, 3);

                                if (sonuc)
                                {
                                    MessageBox.Show("Rezervasyon Başarıyla Açılmıştır.");
                                    temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Rezervasyon kaydı gerçekleşemedi. Lütfen yetkiliyle iletişime geçiniz!!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Rezervasyon yapılan masa şu an dolu.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen kişi sayısı seçiniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir tarih seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Bu müşteri üzerine açık bir rezervasyon bulunmaktadır.");
                }
            }
        }

        private void dtTarih_MouseEnter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_Enter(object sender, EventArgs e)
        {
            dtTarih.Width = 200;
        }

        private void dtTarih_MouseLeave(object sender, EventArgs e)
        {
            dtTarih.Width = 23;
        }

        private void dtTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtTarih.Value.ToString();
        }

        private void cbKisiSayisi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKisiSayisi.Text = cbKisiSayisi.SelectedItem.ToString();

        }

        private void cbMasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbKisiSayisi.Enabled = true;
            txtMasa.Text = cbMasa.SelectedItem.ToString();

            ClassMasalar Kapasitesi = (ClassMasalar)cbMasa.SelectedItem;
            int kapasite = Kapasitesi.KAPASITE;
            txtMasaNo.Text = Convert.ToString(Kapasitesi.ID);

            cbKisiSayisi.Items.Clear();
            for(int i=0; i < kapasite; i++)
            {
                cbKisiSayisi.Items.Add(i + 1);
            }
        }

        private void cbMasa_MouseEnter(object sender, EventArgs e)
        {
            cbMasa.Width = 200;
        }

        private void cbMasa_MouseLeave(object sender, EventArgs e)
        {
            cbMasa.Width = 23;
        }

        private void cbKisiSayisi_MouseEnter(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 100;
        }

        private void cbKisiSayisi_MouseLeave(object sender, EventArgs e)
        {
            cbKisiSayisi.Width = 23;
        }

        private void btnSiparisKontrol_Click(object sender, EventArgs e)
        {
            FormSiparişveMüşteriKontrol frm = new FormSiparişveMüşteriKontrol();
            this.Close();
            frm.Show();
        }

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            FormMüşteriEkle frm = new FormMüşteriEkle();
            ClassBilgiGenel._musteriEkleme = 0;
            frm.btnMusteriGuncelle.Visible = false;
            frm.btnYeniMusteri.Visible = true;
            this.Close();
            frm.Show();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                FormMüşteriEkle me = new FormMüşteriEkle();
                ClassBilgiGenel._musteriEkleme = 0;
                ClassBilgiGenel._musteriId = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                me.btnMusteriGuncelle.Visible = true;
                me.btnYeniMusteri.Visible = false;
                this.Close();
                me.Show();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            FormMüşteriler frm = new FormMüşteriler();
            this.Close();
            frm.Show();
        }
    }
}
