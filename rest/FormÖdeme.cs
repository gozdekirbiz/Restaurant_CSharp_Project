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
    public partial class FormÖdeme : Form
    {
        public FormÖdeme()
        {
            InitializeComponent();
        }
        ClassSiparişVerme cs = new ClassSiparişVerme();
        int odemeTuru = 0;
        private void frmBill_Load(object sender, EventArgs e)
        {
            if(ClassBilgiGenel._ServisTurNo==1)
            {
                lblAdisyonId.Text = ClassBilgiGenel._AdisyonId;
                txtİndirimTutarı.TextChanged += new EventHandler(txtİndirimTutarı_TextChanged);

                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if(lvUrunler.Items.Count>0)
                {
                    decimal toplam = 0;
                    for(int i=0;i< lvUrunler.Items.Count;i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                    }
                    lblToplamTutar.Text = string.Format("{0:0.00}", toplam); //noktadan sonra 2 sayı gösterir
                    lblOdenecek.Text= string.Format("{0:0.00}", toplam);
                }
                
                txtİndirimTutarı.Clear();
            }
            else if(ClassBilgiGenel._ServisTurNo == 2)
            {
                lblAdisyonId.Text = ClassBilgiGenel._AdisyonId;
                ClassPaketServis pc = new ClassPaketServis();
                odemeTuru = pc.BringPayCheckType(Convert.ToInt32(lblAdisyonId.Text));
                txtİndirimTutarı.TextChanged += new EventHandler(txtİndirimTutarı_TextChanged);
                if(odemeTuru==1)
                {
                    rbNakit.Checked = true;
                }
                else if (odemeTuru == 2)
                {
                    rbKrediKarti.Checked = true;
                }
                else if (odemeTuru ==3)
                {
                    rbTicket.Checked = true;
                }


                cs.getByOrder(lvUrunler, Convert.ToInt32(lblAdisyonId.Text));
                if (lvUrunler.Items.Count > 0)
                {
                    decimal toplam = 0;
                    for (int i = 0; i < lvUrunler.Items.Count; i++)
                    {
                        toplam += Convert.ToDecimal(lvUrunler.Items[i].SubItems[3].Text);
                       
                    }
                    lblToplamTutar.Text = string.Format("{0:0.00}", toplam); //noktadan sonra 2 sayı gösterir
                    lblOdenecek.Text = string.Format("{0:0.00}", toplam);
                    decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
                    lblKdv.Text = string.Format("{0:0.00}", kdv);
                }

                txtİndirimTutarı.Clear();
            }

        }

        private void lblIndirim_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtİndirimTutarı_TextChanged(object sender, EventArgs e)
        {
            try 
            {
                if (Convert.ToDecimal(txtİndirimTutarı.Text) < Convert.ToDecimal(lblToplamTutar.Text))
                {
                    try
                    {
                        lbleksi.Visible = true;
                        lblIndirim.Text = string.Format("{0:0.00}", Convert.ToDecimal(txtİndirimTutarı.Text));
                    }
                    catch (Exception)
                    {
                        lblIndirim.Text = string.Format("{0:0.00}", 0);
                    }
                }
                else
                    MessageBox.Show("İndirim tutarı toplam tutardan fazla olamaz!");
            }
            catch(Exception)
            {
                lblIndirim.Text = string.Format("{0:0.00}", 0);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chkİndirim_CheckedChanged(object sender, EventArgs e)
        {
            if(chkİndirim.Checked)
            {
                gbIndirim.Visible = true;
                txtİndirimTutarı.Clear();
            }
            else
            {
                gbIndirim.Visible = false;
                txtİndirimTutarı.Clear();
            }
        }

        private void lblIndirim_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblIndirim.Text) > 0)
            {
                decimal odenecek = 0;
                lblOdenecek.Text = lblToplamTutar.Text;
                odenecek = Convert.ToDecimal(lblOdenecek.Text)-Convert.ToDecimal(lblIndirim.Text);
                lblOdenecek.Text = string.Format("{0:0.00}", odenecek);
            }
            decimal kdv = Convert.ToDecimal(lblOdenecek.Text) * 18 / 100;
            lblKdv.Text = string.Format("{0:0.00}", kdv);
        }
        ClassMasalar masalar = new ClassMasalar();
        ClassRezervasyon rezerve = new ClassRezervasyon();
        private void btnHesabıKapat_Click(object sender, EventArgs e)
        {
            if(ClassBilgiGenel._ServisTurNo==1)
            {
                int masaid = masalar.TableGetByNumber(ClassBilgiGenel._ButtonName);
                int musteriId = 0;
                if(masalar.TableGetByState(masaid,4)==true)
                {
                    musteriId = rezerve.getByClientIdFromRezervasyon(masaid);
                }
                else
                {
                    musteriId = 1;
                }
                int odemeTurId = 0;
                if(rbNakit.Checked)
                {
                    odemeTurId = 1;
                }
                if(rbKrediKarti.Checked)
                {
                    odemeTurId = 2;
                }
                if(rbTicket.Checked)
                {
                    odemeTurId = 3;
                }
                ClassÖdeme odeme = new ClassÖdeme();
                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTurId;
                odeme.MusteriId = musteriId;
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKdv.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);

                bool result = odeme.billClose(odeme);
                if(result)
                {
                    MessageBox.Show("Hesap kapatılmıştır.");
                    masalar.setChangeTableState(Convert.ToString(masaid), 1);
                    ClassRezervasyon c=new ClassRezervasyon();
                    c.reservationClose(Convert.ToInt32(lblAdisyonId.Text));
                    ClassAdisyonİşlemleri a = new ClassAdisyonİşlemleri();
                    a.additionClose(Convert.ToInt32(lblAdisyonId.Text), 1);
                    this.Close();
                    FormMasalar frm = new FormMasalar();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap kapatılamadı.");
                }
            }
            else if(ClassBilgiGenel._ServisTurNo == 2) //Paket Sipariş
            {
                ClassÖdeme odeme = new ClassÖdeme();
                odeme.AdisyonID = Convert.ToInt32(lblAdisyonId.Text);
                odeme.OdemeTurId = odemeTuru;
                ClassPaketServis p = new ClassPaketServis();
                odeme.MusteriId = p.MusteriIDgetirPaket(Convert.ToInt32(lblAdisyonId.Text));
                odeme.AraToplam = Convert.ToDecimal(lblOdenecek.Text);
                odeme.Indirim = Convert.ToDecimal(lblIndirim.Text);
                odeme.Kdvtutari = Convert.ToDecimal(lblKdv.Text);
                odeme.GenelToplam = Convert.ToDecimal(lblToplamTutar.Text);
                bool result = odeme.billClose(odeme);
                if (result)
                {
                    MessageBox.Show("Hesap kapatılmıştır.");
                    
                    
                    p.OrderServiceClose(Convert.ToInt32(lblAdisyonId.Text));
                    ClassAdisyonİşlemleri a = new ClassAdisyonİşlemleri();
                    a.additionClose(Convert.ToInt32(lblAdisyonId.Text), 1);
                    FormMenü frm = new FormMenü();
                    this.Close();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Hesap kapatılamadı.");
                }
            }
        }

        private void btnHesapOzeti_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        Font Baslik = new Font("Cocogoose Pro", 12, FontStyle.Italic);
        Font altBaslik = new Font("Cocogoose Pro", 10, FontStyle.Italic);
        Font icerik = new Font("Cocogoose Pro", 8, FontStyle.Italic);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("ÇAPA RESTAURANT", Baslik, sb, 350, 100, st);
            e.Graphics.DrawString("________________", altBaslik, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı         Adet              Fiyat", altBaslik, sb, 270, 250, st);
            e.Graphics.DrawString("___________________________________", altBaslik, sb, 270, 280, st);
            for(int i =0;i<lvUrunler.Items.Count;i++)
            {
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[0].Text, icerik, sb, 270, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[1].Text, icerik, sb, 405, 300 + i * 30, st);
                e.Graphics.DrawString(lvUrunler.Items[i].SubItems[3].Text, icerik, sb, 490, 300 + i * 30, st);
            }
            e.Graphics.DrawString("___________________________________", altBaslik, sb, 270, 300 + 30 * lvUrunler.Items.Count, st);
            e.Graphics.DrawString("Toplam Tutar:__________"+lblToplamTutar.Text+" TL", altBaslik, sb, 270, 300 + 30 * (lvUrunler.Items.Count+1), st);
            e.Graphics.DrawString("KDV Tutarı:____________"+lblKdv.Text+ "TL", altBaslik, sb, 270, 300 + 30 * (lvUrunler.Items.Count+2), st);
            e.Graphics.DrawString("İndirim Tutarı:________" + lblIndirim.Text + "TL", altBaslik, sb, 270, 300 + 30 * (lvUrunler.Items.Count + 3), st);
            e.Graphics.DrawString("Ödenilen Tutar:________" + lblOdenecek.Text + "TL", altBaslik, sb, 270, 300 + 30 * (lvUrunler.Items.Count + 4), st);


        }

        private void lblAdisyonId_Click(object sender, EventArgs e)
        {

        }

        private void lvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
