
using System;
using System.Collections;
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
    public partial class FormPaketServisi : Form
    {
        public FormPaketServisi()
        {
            InitializeComponent();
        }

        void islem(Object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btn1":
                    txtAdet.Text += (1).ToString();
                    break;
                case "btn2":
                    txtAdet.Text += (2).ToString();
                    break;
                case "btn3":
                    txtAdet.Text += (3).ToString();
                    break;
                case "btn4":
                    txtAdet.Text += (4).ToString();
                    break;
                case "btn5":
                    txtAdet.Text += (5).ToString();
                    break;
                case "btn6":
                    txtAdet.Text += (6).ToString();
                    break;
                case "btn7":
                    txtAdet.Text += (7).ToString();
                    break;
                case "btn8":
                    txtAdet.Text += (8).ToString();
                    break;
                case "btn9":
                    txtAdet.Text += (9).ToString();
                    break;
                case "btn0":
                    txtAdet.Text += (0).ToString();
                    break;
                default:
                    MessageBox.Show("Sayi gir");

                    break;
            }
        }
        private void frmPaketServisi_Load(object sender, EventArgs e)
        {
            ClassMüşteriler c = new ClassMüşteriler();
            c.ForLv_BringClients(lvMusteriler);
            btn1.Click += new EventHandler(islem);
            btn2.Click += new EventHandler(islem);
            btn3.Click += new EventHandler(islem);
            btn4.Click += new EventHandler(islem);
            btn5.Click += new EventHandler(islem);
            btn6.Click += new EventHandler(islem);
            btn7.Click += new EventHandler(islem);
            btn8.Click += new EventHandler(islem);
            btn9.Click += new EventHandler(islem);
            btn0.Click += new EventHandler(islem);
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

        private void btnYeniMusteri_Click(object sender, EventArgs e)
        {
            FormMüşteriEkle frm = new FormMüşteriEkle();
            ClassBilgiGenel._musteriEkleme = 1;

            this.Close();
            frm.Show();
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
        int AdditionId = 0;
        private void btnPaketSiparisVer_Click(object sender, EventArgs e)
        {
            ClassPaketServis p = new ClassPaketServis();
            if (rbKrediKarti.Checked || rbNakit.Checked || rbTicket.Checked)
            {
                if (lvMusteriler.SelectedItems.Count > 0)
                {


                    lblAdisyonId.Text = ClassBilgiGenel._AdisyonId;
                    ClassAdisyonİşlemleri a = new ClassAdisyonİşlemleri();
                    a.ServisTurNo = 2;
                    a.PersonelId = ClassBilgiGenel._personelId;

                    int odemeTurNo = 0;
                    p.AdditionID = a.OpenAdditionforTakeAway(a);
                    AdditionId = p.AdditionID;
                    p.ClientID = Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text);
                    if (rbNakit.Checked)
                        odemeTurNo = 1;
                    else if (rbKrediKarti.Checked)
                        odemeTurNo = 2;
                    else if (rbTicket.Checked)
                        odemeTurNo = 3;
                    else
                        MessageBox.Show("Ödeme türünü seçiniz!");
                    p.PayTypeid = odemeTurNo;
                    p.Description = txtAciklama.Text;
                    bool sonuc = p.OrderServiceOpen(p);
                    if (sonuc)
                    {
                        ClassSiparişVerme cs = new ClassSiparişVerme();
                        cs.getByOrder(lvSiparisler, AdditionId);
                        if (lvYeniEklenenler.Items.Count > 0)
                        {

                            for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                            {

                                saveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                                saveOrder.AdisyonId = p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                                saveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                                saveOrder.SaveTakeAwaySales(saveOrder);

                            }
                            ClassBilgiGenel._AdisyonId = p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text)).ToString();
                            if (silinler.Count > 0)
                            {

                                foreach (string item in silinler)
                                {
                                    saveOrder.setDeleteOrder(Convert.ToInt32(item));
                                }

                            }
                            MessageBox.Show("Paket siparişi başarıyla oluşturuldu.");
                            Temizle();
                        }
                    }
                    else
                        MessageBox.Show("Paket siparişi oluşturulamadı!");




                }
            }
            else
                MessageBox.Show("Ödeme türünü seçiniz.");

        }
        void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();
            txtAciklama.Clear();
        }
        ClassKategoriÜrün Uc = new ClassKategoriÜrün();
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }
            int sayac = 0; int sayac2 = 0;
            if (lvMenu.Items.Count > 0)
            {
                sayac = lvSiparisler.Items.Count;
                lvSiparisler.Items.Add(lvMenu.SelectedItems[0].Text);
                lvSiparisler.Items[sayac].SubItems.Add(txtAdet.Text);
                lvSiparisler.Items[sayac].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvSiparisler.Items[sayac].SubItems.Add((Convert.ToDecimal(lvMenu.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                lvSiparisler.Items[sayac].SubItems.Add("0");
                sayac2 = lvYeniEklenenler.Items.Count;
                lvSiparisler.Items[sayac].SubItems.Add(sayac2.ToString());


                lvYeniEklenenler.Items.Add(AdditionId.ToString());
                lvYeniEklenenler.Items[sayac2].SubItems.Add(lvMenu.SelectedItems[0].SubItems[2].Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(txtAdet.Text);
                lvYeniEklenenler.Items[sayac2].SubItems.Add(sayac2.ToString());


                sayac2++;

                txtAdet.Text = "";
            }
        }
        ArrayList silinler = new ArrayList();
        private void lvSiparisler_DoubleClick(object sender, EventArgs e)
        {
            if (lvSiparisler.Items.Count > 0)
            {
                if (lvSiparisler.SelectedItems[0].SubItems[4].Text != "0")
                {
                    ClassSiparişVerme saveorder = new ClassSiparişVerme();
                    saveorder.setDeleteOrder(Convert.ToInt32(lvSiparisler.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        if (lvYeniEklenenler.Items[i].SubItems[4].Text == lvSiparisler.SelectedItems[0].SubItems[5].Text)
                        {
                            lvYeniEklenenler.Items.RemoveAt(i);
                        }
                    }
                }
                lvSiparisler.Items.RemoveAt(lvSiparisler.SelectedItems[0].Index);

            }

        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            Uc.getByProductType(lvMenu, btnAnaYemek1);
        }

        private void btnİçecekler2_Click(object sender, EventArgs e)
        {
            Uc.getByProductType(lvMenu, btnİçecekler2);
        }

        private void btnTatlılar3_Click(object sender, EventArgs e)
        {
            Uc.getByProductType(lvMenu, btnTatlılar3);
        }

        private void btnSalatalar4_Click(object sender, EventArgs e)
        {
            Uc.getByProductType(lvMenu, btnSalatalar4);

        }

        private void btnÇorba5_Click(object sender, EventArgs e)
        {
            Uc.getByProductType(lvMenu, btnÇorba5);
        }

        private void btnarasıcak6_Click(object sender, EventArgs e)
        {
            Uc.getByProductType(lvMenu, btnarasıcak6);
        }

        private void btnAnaYemek1_Click_1(object sender, EventArgs e)
        {

        }
        ClassPaketServis p = new ClassPaketServis();
        ClassSiparişVerme saveOrder = new ClassSiparişVerme();
        ClassAdisyonİşlemleri a = new ClassAdisyonİşlemleri();
        FormÖdeme frm = new FormÖdeme();
        private void btnÖdeme_Click(object sender, EventArgs e)
        {
            ClassBilgiGenel._AdisyonId = p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text)).ToString();
            ClassBilgiGenel._ServisTurNo = 2;
            this.Close();
            frm.Show();
        }

        private void lvMusteriler_DoubleClick(object sender, EventArgs e)
        {
            if (p.PaketDurumGetir(p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text))) == false)
            {
                ClassSiparişVerme orders = new ClassSiparişVerme();

                orders.getByOrder(lvSiparisler, p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text)));
            }


        }

        private void lvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPaketGuncelle_Click(object sender, EventArgs e)
        {
            if (lvMusteriler.SelectedItems.Count > 0)
            {
                if (lvSiparisler.Items.Count > 0)
                {
                    ClassSiparişVerme cs = new ClassSiparişVerme();
                    cs.getByOrder(lvSiparisler, AdditionId);
                    if (lvYeniEklenenler.Items.Count > 0)
                    {

                        for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                        {

                            saveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                            saveOrder.AdisyonId = p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text));
                            saveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                            saveOrder.SaveTakeAwaySales(saveOrder);

                        }
                        ClassBilgiGenel._AdisyonId = p.BringClientLastAdditionID(Convert.ToInt32(lvMusteriler.SelectedItems[0].SubItems[0].Text)).ToString();
                        if (silinler.Count > 0)
                        {

                            foreach (string item in silinler)
                            {
                                saveOrder.setDeleteOrder(Convert.ToInt32(item));
                            }

                        }
                        MessageBox.Show("Paket sipariş güncellendi.");
                        Temizle();
                    }
                    if (silinler.Count > 0)
                    {

                        foreach (string item in silinler)
                        {
                            saveOrder.setDeleteOrder(Convert.ToInt32(item));
                        }

                    }
                    Temizle();

                }
            }
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "";
            }
            else
            {
                ClassKategoriÜrün cu = new ClassKategoriÜrün();
                cu.getByProductSearch(lvMenu, Convert.ToInt32(textBox1.Text));
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "UYARI!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void btnGeridon_Click_1(object sender, EventArgs e)
        {
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }
    }
}