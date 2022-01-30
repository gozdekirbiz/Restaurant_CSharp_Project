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
    public partial class FormÜrünKategori : Form
    {
        public FormÜrünKategori()
        {
            InitializeComponent();
        }

        private void frmMutfak_Load(object sender, EventArgs e)
        {
            ClassKategoriÜrün AnaKategori = new ClassKategoriÜrün();
            AnaKategori.BringProductTypes(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;

            label6.Visible = false;
            txtArama.Visible = false;
            ClassÜrünler c = new ClassÜrünler();
            c.ListProducts(lvGidaListesi);
        }
        private void Temizle ()
        {
            txtGidaAdi.Clear();
            txtGidaFiyati.Clear();
            txtGidaFiyati.Text = string.Format("{0:##0.00}", 0);
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gida Adi Fiyati ve Kategori seçilmemiştir", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClassÜrünler c = new ClassÜrünler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Aciklama = "Ürün Eklendi";
                    c.Urunturno = urunturNo;
                    int sonuc = c.AddProduct(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Eklemiştir");
                        cbKategoriler_SelectedIndexChanged(sender, e);
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriAd.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori ismi giriniz", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    ClassKategoriÜrün gida = new ClassKategoriÜrün();
                    gida.TurAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                   int sonuc =  gida.AddNewCategory(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Eklemiştir");
                        yenile();
                        Temizle();
                    }

                }
            }

        }
        int urunturNo = 0;
        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassÜrünler u = new ClassÜrünler();
            if (cbKategoriler.SelectedItem.ToString() =="Tüm Kategoriler")

            {
                u.ListProducts(lvGidaListesi);
            }
            else
            {
                ClassKategoriÜrün cesit = (ClassKategoriÜrün)cbKategoriler.SelectedItem;
                urunturNo = cesit.UrunTurNo;
                u.WithID_ListProducts(lvGidaListesi, urunturNo);
            }
        }

        private void btnDegistir_Click(object sender, EventArgs e)
        {

            if (rbAltKategori.Checked)
            {
                if (txtGidaAdi.Text.Trim() == "" || txtGidaFiyati.Text.Trim() == "" || cbKategoriler.SelectedItem.ToString() == "Tüm Kategoriler")
                {
                    MessageBox.Show("Gida Adi Fiyati ve Kategori seçilmemiştir", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClassÜrünler c = new ClassÜrünler();
                    c.Fiyat = Convert.ToDecimal(txtGidaFiyati.Text);
                    c.Urunad = txtGidaAdi.Text;
                    c.Urunid = Convert.ToInt32(txtUrunId.Text);
                    c.Urunturno = urunturNo;
                    c.Aciklama = "Ürün Guncenlendi";
                    
                    int sonuc = c.UpdateProducts(c);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Ürün Guncenlemiştir");
                        yenile();
                        Temizle();
                    }
                }
            }
            else
            {
                if (txtKategoriId.Text.Trim() == "")
                {
                    MessageBox.Show("Lütfen bir kategori seçiniz", "Dikkat, Bilgiler Eksik", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    ClassKategoriÜrün gida = new ClassKategoriÜrün();
                    gida.TurAd = txtKategoriAd.Text;
                    gida.Aciklama = txtAciklama.Text;
                    gida.UrunTurNo = Convert.ToInt32(txtKategoriId.Text);
                    int sonuc = gida.UpdateCategory(gida);
                    if (sonuc != 0)
                    {
                        MessageBox.Show("Kategori Guncellenmiştir");
                        gida.BringProductTypes(lvKategoriler);
                        Temizle();
                    }

                }
            }

        }

        private void lvGıdaListesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGidaListesi.SelectedItems.Count > 0)
            {
                txtGidaAdi.Text = lvGidaListesi.SelectedItems[0].SubItems[3].Text;
                txtGidaFiyati.Text = lvGidaListesi.SelectedItems[0].SubItems[4].Text;
                txtUrunId.Text = lvGidaListesi.SelectedItems[0].SubItems[0].Text;
                // cbKategoriler.SelectedIndex = Convert.ToInt32(txtUrunId.Text);

            }
           
        }

        private void lvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvKategoriler.SelectedItems.Count > 0)
            {
               
                txtKategoriId.Text = lvKategoriler.SelectedItems[0].SubItems[0].Text;
                txtKategoriAd.Text = lvKategoriler.SelectedItems[0].SubItems[1].Text;
                txtAciklama.Text = lvKategoriler.SelectedItems[0].SubItems[2].Text;
                // cbKategoriler.SelectedIndex = Convert.ToInt32(txtUrunId.Text);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            if (rbAltKategori.Checked)
            {
                if (lvGidaListesi.SelectedItems.Count > 0)
                {
                    if (MessageBox.Show("Ürünü silmekte emin misiniz?", "Dikkat, Bilgiler silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        ClassÜrünler c = new ClassÜrünler();
                        c.Urunid = Convert.ToInt32(txtUrunId.Text);
                        int sonuc = c.DeleteProducts(c, 1);
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silinmiştir");
                            cbKategoriler_SelectedIndexChanged(sender, e);
                            yenile();
                            Temizle();

                        }
                    }
                }
                else
                {

                    MessageBox.Show("Ürünü silmek için bir ürün seçiniz.", "Dikkat, Ürün seçmediniz", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                if (lvKategoriler.SelectedItems.Count > 0)
                {

                    if (MessageBox.Show("Ürünü silmekte emin misiniz?", "Dikkat, Bilgiler silinecek", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

                    {
                        ClassKategoriÜrün uc = new ClassKategoriÜrün();
                        int sonuc = uc.DeleteCategory(Convert.ToInt32(txtKategoriId.Text));
                        if (sonuc != 0)
                        {
                            MessageBox.Show("Ürün Silinmiştir");
                            ClassÜrünler c = new ClassÜrünler();
                            c.Urunid = Convert.ToInt32(txtKategoriId.Text);
                            c.DeleteProducts(c, 0);
                            yenile();
                            Temizle();
                        }
                    }
                }

            }
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
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            label6.Visible = true;
            txtArama.Visible = true;
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            if (rbAltKategori.Checked)
            {
                ClassÜrünler u = new ClassÜrünler();
                u.ForProductName_ListProducts(lvGidaListesi, txtArama.Text);
            }
            else
            {
                ClassKategoriÜrün uc = new ClassKategoriÜrün();
                uc.BringProductTypes(lvKategoriler, txtArama.Text);
            }
        }

        private void rbAltKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = true;
            panelAnaKategori.Visible = false;
            lvKategoriler.Visible = false;
            lvGidaListesi.Visible = true;
            yenile();
        }

        private void rbAnaKategori_CheckedChanged(object sender, EventArgs e)
        {
            panelUrun.Visible = false;
            panelAnaKategori.Visible = true;
            lvKategoriler.Visible = true;
            lvGidaListesi.Visible = false;
            yenile();
        }

        private void yenile()
        {
            ClassKategoriÜrün uc = new ClassKategoriÜrün();
            uc.BringProductTypes(cbKategoriler);
            cbKategoriler.Items.Insert(0, "Tüm Kategoriler");
            cbKategoriler.SelectedIndex = 0;
            uc.BringProductTypes(lvKategoriler);
            ClassÜrünler c = new ClassÜrünler();
            c.ListProducts(lvGidaListesi);


        }
    }
        }
    
    

