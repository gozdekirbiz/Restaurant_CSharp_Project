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
    public partial class FormGiriş : Form
    {
        private ClassPersoneller comboBox2_SelectedItem;

        public FormGiriş()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassBilgiGenel gnl = new ClassBilgiGenel();
            ClassPersoneller p = new ClassPersoneller();
            bool result = p.EmployeeEntryControl(txtSifre.Text,ClassBilgiGenel._personelId);
            if (result)
            {
                ClassPersonelHareketleri ch = new ClassPersonelHareketleri();
                ch.PersonelId = ClassBilgiGenel._personelId;
                ch.Islem = "Giriş Yapıldı";
                ch.Tarih = DateTime.Now;
                ch.PersonelActionSave(ch);
                this.Hide();
                FormMenü menu = new FormMenü();
                menu.Show();
            }
            else
                MessageBox.Show("Şifreniz Yanlış", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?","UYARI!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassPersoneller p = new ClassPersoneller();
            p.BringEmployeeInfo(cbKullanici);

               
        }

        private void cbKullanici_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassPersoneller p = (ClassPersoneller)cbKullanici.SelectedItem;
            ClassBilgiGenel._personelId = p.PersonelId;
            ClassBilgiGenel._gorevId = p.PersonelGorevId;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
