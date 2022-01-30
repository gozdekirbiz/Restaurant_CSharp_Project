using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace rest
{
    public partial class Formİstatistik : Form
    {
        public Formİstatistik()
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

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }

        private void btnAnaYemek1_Click(object sender, EventArgs e)
        {
            İstatistik("Ana Yemek Grafiği",1,Color.SteelBlue);
        }

        private void btnİçecekler2_Click(object sender, EventArgs e)
        {
            İstatistik("İçecek Grafiği", 2 , Color.LightSkyBlue);
        }

        private void btnTatlılar3_Click(object sender, EventArgs e)
        {
            İstatistik("Tatlı Grafiği", 3, Color.DarkCyan);
        }

        private void btnSalatalar4_Click(object sender, EventArgs e)
        {
            İstatistik("Salata Grafiği", 4, Color.MediumAquamarine);
        }

        private void btnÇorba5_Click(object sender, EventArgs e)
        {
            İstatistik("Çorba Grafiği", 5, Color.SlateGray);
        }

        private void btnarasıcak6_Click(object sender, EventArgs e)
        {
            İstatistik("Ara Sıcak Grafiği", 6, Color.PowderBlue);
        }
        private void İstatistik(string gfName,int KatId,Color renk)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = renk;
            ClassÜrünler u = new ClassÜrünler();
            lvİstatistik.Items.Clear();
            u.WithType_ForStatics_ListProducts(lvİstatistik, dtBaslangic, dtBitis, KatId);
            gbİstatistik.Text = gfName;
            if (lvİstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvİstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvİstatistik.Items[i].SubItems[0].Text, lvİstatistik.Items[i].SubItems[1].Text);
                }

            }
            else
                MessageBox.Show("Gösterilecek istatistik yok,başka bir zaman dilimi seçebilirsiniz.");
        }

        private void btnZRaporu_Click(object sender, EventArgs e)
        {
            chRapor.Palette = ChartColorPalette.None;
            chRapor.Series[0].EmptyPointStyle.Color = Color.Transparent;
            chRapor.Series[0].Color = Color.SlateBlue;
            ClassÜrünler u = new ClassÜrünler();
            lvİstatistik.Items.Clear();
            u.WithStatistic_ListAllProducts(lvİstatistik, dtBaslangic, dtBitis);
            gbİstatistik.Text = "Tüm Ürünlerin Grafiği";
            if (lvİstatistik.Items.Count > 0)
            {
                chRapor.Series["Satislar"].Points.Clear();
                for (int i = 0; i < lvİstatistik.Items.Count; i++)
                {
                    chRapor.Series["Satislar"].Points.AddXY(lvİstatistik.Items[i].SubItems[0].Text, lvİstatistik.Items[i].SubItems[1].Text);
                }
            }
            else
                MessageBox.Show("Gösterilecek istatistik yok,başka bir zaman dilimi seçebilirsiniz.");
        }

        private void Formİstatistik_Load(object sender, EventArgs e)
        {

        }
    }
}
