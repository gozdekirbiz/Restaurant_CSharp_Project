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
    public partial class FormSiparişveMüşteriKontrol : Form
    {
        public FormSiparişveMüşteriKontrol()
        {
            InitializeComponent();
        }

        private void frmSiparişKontrol_Load(object sender, EventArgs e)
        {
            ClassAdisyonİşlemleri c = new ClassAdisyonİşlemleri();
            int butonSayisi = c.NumberOfTakeAway();
            c.OpenTakeAwayOrders(lvMüşteriler);
            int alt = 1;
            int sol = 50;
            int bol = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonSayisi)));
            for( int i =1;i <=butonSayisi;i++)
            {
                Button btn = new Button();
                btn.AutoSize = false;
                btn.Size = new Size(179, 80);
                btn.FlatStyle = FlatStyle.Flat;
                btn.Name = lvMüşteriler.Items[i - 1].SubItems[0].Text;
                btn.Text= lvMüşteriler.Items[i - 1].SubItems[1].Text;
                btn.BackColor = Color.Azure;
                btn.Font = new Font("Cocogoose Pro", 9, FontStyle.Bold);
                btn.ForeColor = Color.MidnightBlue;
                btn.Location = new Point(sol, alt);
                this.Controls.Add(btn);

                sol += btn.Width + 5;
                if(i==2)
                {
                    sol = 1;
                    alt += 50;
                }
                btn.Click += new EventHandler(dinamikMetod);
                btn.MouseEnter += new EventHandler(dinamikMetod2);
            }
        }
        
        protected void dinamikMetod(object sender,EventArgs e)
        {
            ClassAdisyonİşlemleri c = new ClassAdisyonİşlemleri();
            Button dinamikButon = (sender as Button);
            FormÖdeme frm = new FormÖdeme();
            ClassBilgiGenel._ServisTurNo = 2;
            ClassBilgiGenel._AdisyonId = c.Last_TakeAwayAdditionID_ForClient(Convert.ToInt32(dinamikButon.Name)).ToString();
            frm.Show();
        }
        protected void dinamikMetod2(object sender, EventArgs e)
        {
            Button dinamikButon = (sender as Button);
            ClassAdisyonİşlemleri c = new ClassAdisyonİşlemleri();
            ClassSiparişVerme s = new ClassSiparişVerme();
            //cPaketler p = new cPaketler();
            //int adisyonid = p.musteriSonAdisyonIDGetir(Convert.ToInt32(dinamikButon.Name)) - 1;
            //s.PaketServisUpdateSil(Convert.ToInt32(dinamikButon.Name), adisyonid);
            c.ClientDetails(lvMusteriDetaylari, Convert.ToInt32(dinamikButon.Name));
            sonSiparisTarihi();
           
            lvSatisDetaylari.Items.Clear();
            lblGenelToplam.Text = s.OverallTotal(Convert.ToInt32(dinamikButon.Name)).ToString();
            ClassBilgiGenel._ServisTurNo = 2;
            ClassBilgiGenel._AdisyonId = c.Last_TakeAwayAdditionID_ForClient(Convert.ToInt32(dinamikButon.Name)).ToString() + " TL"; ;
            
        }
        void sonSiparisTarihi()
        {
            if(lvMusteriDetaylari.Items.Count>0)
            {
                int s = lvMusteriDetaylari.Items.Count;
                lblSonSiparisTarihi.Text = lvMusteriDetaylari.Items[s - 1].SubItems[3].Text;
                txtToplamTutar.Text = s + " Adet";
            }
        }
        void toplam()
        {
            int kayitsayisi = lvSatisDetaylari.Items.Count;
            decimal toplam = 0;
            for(int i=0;i <kayitsayisi;i++)
            {
                toplam += Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[2].Text)*Convert.ToDecimal(lvSatisDetaylari.Items[i].SubItems[3].Text);
            }
            lblToplamSiparis.Text = toplam.ToString() + " TL";
        }

        private void lvMusteriDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvMusteriDetaylari.SelectedItems.Count>0)
            {
               
                ClassSiparişVerme c = new ClassSiparişVerme();
                c.AdditionTakeAwayDetails(lvSatisDetaylari,Convert.ToInt32(lvMusteriDetaylari.SelectedItems[0].SubItems[4].Text));
                toplam();
            }
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
            FormMüşteriler frm = new FormMüşteriler();
            this.Close();
            frm.Show();
        }

        private void txtToplamTutar_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvSatisDetaylari_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
