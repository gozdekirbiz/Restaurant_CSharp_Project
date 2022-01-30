using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace rest
{
    class ClassPersoneller
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();
        #region Fields
        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;
        #endregion
        #region Properties
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; } 
        #endregion
        //personelin girişini kontrol eder
        public bool EmployeeEntryControl(string password,int UserId)
        {
            bool result = false; //yanlışsa false hep false döner
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@Id and PAROLA=@password", con); // ID ve şifre var mı diye kontrol ediliyor
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                result = Convert.ToBoolean(cmd.ExecuteScalar());
            }
            catch(SqlException ex)
            {
                string hata = ex.Message;
                
            }
            return result;
        }
        //Comboboxa personel bilgilerini getirir
        public void BringEmployeeInfo (ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select * from Personeller", con);
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ClassPersoneller p = new ClassPersoneller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                if(p._PersonelDurum==false)
                {
                    cb.Items.Add(p);
                }
                
            }
            dr.Close();
            con.Close();
        }
        public override string ToString()
        {

            return PersonelAd+" "+PersonelSoyad;
        }
        //listviewa personel bilgilerini yazar
        public void ForLVBringEmployeeInfo(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select Personeller.*,personelGorevleri.GOREV from Personeller Inner join PersonelGorevleri on PersonelGorevleri.ID=Personeller.GOREVID where Personeller.Durum=0", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();
        }
        //id ile listview'a personel bilgilerini yazar
        public void WithID_ForLVBringEmployeeInfo(ListView lv,int perID)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select Personeller.*,personelGorevleri.GOREV from Personeller Inner join PersonelGorevleri on PersonelGorevleri.ID=Personeller.GOREVID where Personeller.Durum=0 and Personeller.ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perID;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                lv.Items.Add(dr["ID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREVID"].ToString());
                lv.Items[i].SubItems.Add(dr["GOREV"].ToString());
                lv.Items[i].SubItems.Add(dr["AD"].ToString());
                lv.Items[i].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[i].SubItems.Add(dr["KULLANICIADI"].ToString());
                i++;
            }
            dr.Close();
            con.Close();
        }
        //personelin adını getirir
        public string BringEmployeeName(int perId)
        {
            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select AD + SOYAD from Personeller where Personeller.Durum=0 and Personeller.ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = perId;
          
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToString(cmd.ExecuteScalar());
            }
            catch
            { }

            
            
            con.Close();
            return sonuc;
        }
        //personelin şifresini değiştirir
        public bool EmployeePasswordChange(int personelID,string pass)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("update personeller set PAROLA=@pass where ID=@perId", con);
            cmd.Parameters.Add("perID", SqlDbType.Int).Value = personelID;
            cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = pass;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch
            { }



            con.Close();
            return sonuc;
        }
        //personel ekler
        public bool AddEmployee(ClassPersoneller cp)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Insert into Personeller(AD,SOYAD,PAROLA,GOREVID) values(@AD,@SOYAD,@PAROLA,@GOREVID)", con);
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
       
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
            
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch
            { }



            con.Close();
            return sonuc;
        }
        //personel günceller
        public bool UpdateEmployee(ClassPersoneller cp,int perId)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Update personeller set AD=@AD,SOYAD=@SOYAD,PAROLA=@PAROLA,GOREVID=@GOREVID where ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.VarChar).Value = perId;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = _PersonelAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = _PersonelSoyad;
            
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = _PersonelParola;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = _PersonelGorevId;
           
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch
            { }



            con.Close();
            return sonuc;
        }
        //personeli siler
        public bool DeleteEmployee(int perId)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Update personeller set Durum=1 where ID=@perID", con);
            cmd.Parameters.Add("perID", SqlDbType.VarChar).Value = perId;
           
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch
            { }



            con.Close();
            return sonuc;
        }

    }
}
