using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace rest
{
    class ClassKategoriÜrün
    {

        ClassBilgiGenel gnl = new ClassBilgiGenel();
        #region Fields
        private int _UrunTurNo;
        private string _KategoriAdi;
        private string _Aciklama;
        #endregion
        #region Properties
        public int UrunTurNo
        {
            get { return _UrunTurNo; }
            set { _UrunTurNo = value; }
        }
        public string TurAd
        {
            get { return _KategoriAdi; }
            set { _KategoriAdi = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }

        #endregion
        //ürünün kategorisine göre listviewi dolduruyor
        public void getByProductType(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,urunler.ID from kategoriler Inner Join urunler on kategoriler.ID=urunler.KATEGORIID Where urunler.KATEGORIID=@KATEGORIID", con);
            string aa = btn.Name;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("KATEGORIID", SqlDbType.Int).Value=aa.Substring(uzunluk-1,1);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {

                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[sayac].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[sayac].SubItems.Add(dr["ID"].ToString());
                

                sayac++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        //ürün no ile arama yapıyor
        public void getByProductSearch(ListView Cesitler, int txt)
        {
            Cesitler.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from urunler where ID=@ID ", con);

            cmd.Parameters.Add("ID", SqlDbType.Int).Value = txt;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {

                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[sayac].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[sayac].SubItems.Add(dr["ID"].ToString());


                sayac++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        //Uruncesitlerini getir Combobox
        public void BringProductTypes(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from kategoriler where Durum = 0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    ClassKategoriÜrün uc = new ClassKategoriÜrün();
                    uc.UrunTurNo = Convert.ToInt32(dr["ID"]);
                    uc._KategoriAdi = dr["KATEGORIADI"].ToString();
                    uc._Aciklama = dr["ACIKLAMA"].ToString();

                    cb.Items.Add(uc);

                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();


            }
        }
        //Uruncesitlerini getir Listview
        public void BringProductTypes(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from kategoriler where DURUM=0", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {

                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();


            }
        }
        //Uruncesitlerini getir Listview Arama
        public void BringProductTypes(ListView lv, string source)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from kategoriler where DURUM=0 and KATEGORIADI like '%' + @source + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@source", SqlDbType.VarChar).Value = source;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while (dr.Read())
                {

                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ACIKLAMA"].ToString());
                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();


            }
        }
        //Uruncesitlerini Ekleme
        public int AddNewCategory(ClassKategoriÜrün u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into kategoriler (KATEGORIADI,ACIKLAMA) values (@KATEGORIADI@ACIKLAMA) ", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@KATEGORIADI", SqlDbType.VarChar).Value = u._KategoriAdi;
                cmd.Parameters.Add("@kACIKLAMA", SqlDbType.VarChar).Value = u._Aciklama;


                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {

                con.Dispose();
                con.Close();

            }
            return sonuc;

        }
        //uruncesitleri guncelle
        public int UpdateCategory(ClassKategoriÜrün u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update kategoriler set KATEGORIADI=@KATEGORIADI,ACIKLAMA=@ACIKLAMA Where ID=@KATID ", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@KATEGORIADI", SqlDbType.VarChar).Value = u._KategoriAdi;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.VarChar).Value = u._Aciklama;
                cmd.Parameters.Add("@KATID", SqlDbType.Int).Value = u._UrunTurNo;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {

                con.Dispose();
                con.Close();

            }
            return sonuc;

        }
        //urunCesitleri sil
        public int DeleteCategory(int id)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update kategoriler set Durum = 1 Where ID=@KATID ", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@KATID", SqlDbType.Int).Value = id;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {

                con.Dispose();
                con.Close();

            }
            return sonuc;

        }

        public override string ToString()
        {
            return TurAd;
        }
    }
}
