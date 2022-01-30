using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace rest
{
    public partial class FormMasalar : Form
    {
        public FormMasalar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        ClassBilgiGenel gnl = new ClassBilgiGenel();
        private void frmMasalar_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Durum, ID from Masalar", con);
            SqlDataReader dr = null;
            if (con.State == ConnectionState.Closed)
                con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                foreach (Control item in this.Controls)
                {
                    if (item is Button)
                    {
                        if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "1")
                        {
                           

                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2") 
                        {
                            ClassMasalar ms = new ClassMasalar();
                            DateTime dt1 = Convert.ToDateTime(ms.SessionSum(2,dr["ID"].ToString()));
                            DateTime dt2 = DateTime.Now;

                            string st1 = Convert.ToDateTime(ms.SessionSum(2, dr["ID"].ToString())).ToShortTimeString();
                            string st2 = DateTime.Now.ToShortTimeString();

                            DateTime t1 = dt1.AddMinutes(DateTime.Parse(st1).TimeOfDay.TotalMinutes);
                            DateTime t2 = dt2.AddMinutes(DateTime.Parse(st2).TimeOfDay.TotalMinutes);

                            var fark = t2 - t1;
                            item.Text = String.Format("{0}{1}{2}",
                                fark.Days > 0 ? string.Format("{0} Gün ", fark.Days) : "",
                                fark.Hours > 0 ? string.Format("{0} Saat ", fark.Hours) : "",
                                fark.Minutes > 0 ? string.Format("{0} Dakika", fark.Minutes) : "").Trim() + "\n\n\nMasa" + dr["ID"].ToString();
                          
                           item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.dolu);
                           item.ForeColor = System.Drawing.Color.White;
                        }

                        else if  (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.acıkrezerve);
                            item.ForeColor = System.Drawing.Color.White;
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "4")
                        {
                            item.BackgroundImage = (System.Drawing.Image)(Properties.Resources.rezerve);
                            item.ForeColor = System.Drawing.Color.White;
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

        private void btnGeridon_Click(object sender, EventArgs e)
        {
            FormMenü frm = new FormMenü();
            this.Close();
            frm.Show();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa1.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa1.Text.Substring(uzunluk - 5,5);
            ClassBilgiGenel._ButtonName = btnMasa1.Name;
            this.Close();
            frm.ShowDialog();
           
          

        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa2.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa2.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
           frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa3.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa3.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa4.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa4.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
           frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa5.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa5.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa6.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa6.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa7.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa7.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa8.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa8.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa8.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa9_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa9.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa9.Text.Substring(uzunluk - 5, 5);
            ClassBilgiGenel._ButtonName = btnMasa9.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa10_Click(object sender, EventArgs e)
        {
            frmSipariş frm = new frmSipariş();
            int uzunluk = btnMasa10.Text.Length;

            ClassBilgiGenel._ButtonValue = btnMasa10.Text.Substring(uzunluk - 6, 6);
            ClassBilgiGenel._ButtonName = btnMasa10.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void lblRezerve_Click(object sender, EventArgs e)
        {

        }

        private void lblBoş_Click(object sender, EventArgs e)
        {

        }
    }
}

