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
    public partial class frmSipariş : Form
    {
        public frmSipariş()
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
        //Hesap islemi
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
        int TableId = 0; int AdditionId = 0;
        private void frmSipariş_Load(object sender, EventArgs e)
        {

            lblMasaNo.Text = ClassBilgiGenel._ButtonValue;
            ClassMasalar ms = new ClassMasalar();
            TableId = ms.TableGetByNumber(ClassBilgiGenel._ButtonName);
            if (ms.TableGetByState(TableId, 2) == true || ms.TableGetByState(TableId, 4) == true)
            {
                ClassAdisyonİşlemleri Ad = new ClassAdisyonİşlemleri();
                AdditionId = Ad.getByAddition(TableId);

                ClassSiparişVerme orders = new ClassSiparişVerme();
                orders.getByOrder(lvSiparisler, AdditionId);

            }

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

        private void bt2_Click(object sender, EventArgs e)
        {

        }
        ClassKategoriÜrün Uc = new ClassKategoriÜrün();
       


        int sayac = 0; int sayac2 = 0;
        private void lvMenu_DoubleClick(object sender, EventArgs e)
        {
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            }

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
                lvYeniEklenenler.Items[sayac2].SubItems.Add(TableId.ToString());
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

        private void btnÖdeme_Click(object sender, EventArgs e)
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

        private void btnSiparis_Click(object sender, EventArgs e)
        {
            /*  1- masa boş
                         2- masa dolu
                         3- masa rezerve
                         4- dolu rezerve*/


            ClassMasalar masa = new ClassMasalar();
            FormMasalar ms = new FormMasalar();
            ClassAdisyonİşlemleri newAddition = new ClassAdisyonİşlemleri();
            ClassSiparişVerme saveOrder = new ClassSiparişVerme();
            bool sonuc = false;

            if (masa.TableGetByState(TableId, 1) == true)
            {
                newAddition.ServisTurNo = 1;
                newAddition.PersonelId = ClassBilgiGenel._personelId;
                newAddition.MasaId = TableId;
                newAddition.Tarih = DateTime.Now;
                newAddition.ServisTurNo = 1;
                sonuc = newAddition.setByAdditionNew(newAddition);
                masa.setChangeTableState(ClassBilgiGenel._ButtonName, 2);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaId = TableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonId = newAddition.getByAddition(TableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }

                    this.Close();
                    ms.Show();



                }
            }
            else if (masa.TableGetByState(TableId, 2) == true || masa.TableGetByState(TableId, 4) == true)
            {
                if (lvYeniEklenenler.Items.Count > 0)
                {
                    for (int i = 0; i < lvYeniEklenenler.Items.Count; i++)
                    {
                        saveOrder.MasaId = TableId;
                        saveOrder.UrunId = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[1].Text);
                        saveOrder.AdisyonId = newAddition.getByAddition(TableId);
                        saveOrder.Adet = Convert.ToInt32(lvYeniEklenenler.Items[i].SubItems[2].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }
                    ClassBilgiGenel._AdisyonId = Convert.ToString(newAddition.getByAddition(TableId));

                }
                if (silinler.Count > 0)
                {

                    foreach (string item in silinler)
                    {
                        saveOrder.setDeleteOrder(Convert.ToInt32(item));
                    }

                }

                this.Close();
                ms.Show();
            }
            else if (masa.TableGetByState(TableId, 3) == true)
            {
                masa.setChangeTableState(ClassBilgiGenel._ButtonName, 4);

                if (lvSiparisler.Items.Count > 0)
                {
                    for (int i = 0; i < lvSiparisler.Items.Count; i++)
                    {
                        saveOrder.MasaId = TableId;
                        saveOrder.UrunId = Convert.ToInt32(lvSiparisler.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonId = newAddition.getByAddition(TableId);
                        saveOrder.Adet = Convert.ToInt32(lvSiparisler.Items[i].SubItems[1].Text);
                        saveOrder.setSaveOrder(saveOrder);
                    }

                    this.Close();
                    ms.Show();



                }
            }
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.Text = "";
            }
            else
            {
                ClassKategoriÜrün cu = new ClassKategoriÜrün();
                cu.getByProductSearch(lvMenu, Convert.ToInt32(textBox1.Text));
            }
            
        }

        private void btnÖdeme_Click_1(object sender, EventArgs e)
        {
            ClassBilgiGenel._ServisTurNo = 1;
            ClassBilgiGenel._AdisyonId = AdditionId.ToString();
            FormÖdeme frm = new FormÖdeme();
            this.Close();
            frm.Show();

        }

        private void lvYeniEklenenler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvSiparisler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblMasaNo_Click(object sender, EventArgs e)
        {

        }
    }
}


