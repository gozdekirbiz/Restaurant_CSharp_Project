using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace rest
{
    class ClassÜrünler
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();


        #region field
        private int _urunid;
        private int _urunturno;
        private string _urunad;
        private decimal _fiyat;
        private string _aciklama;
        #endregion
        #region Properties
        public int Urunid
        {
            get { return _urunid; }
            set { _urunid = value; }
        }
        public int Urunturno
        {
            get { return _urunturno; }
            set { _urunturno = value; }
        }
        public string Urunad
        {
            get { return _urunad; }
            set { _urunad = value; }
        }
        public decimal Fiyat
        {
            get { return _fiyat; }
            set { _fiyat = value; }
        }
        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        }
        #endregion
        //urun adina gore listeleme
        public void ForProductName_ListProducts(ListView lv, string urunadi)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from urunler Where URUNAD like @urunAdi + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@urunAdi", SqlDbType.VarChar).Value = urunadi;
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["FIYAT"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["ACIKLAMA"].ToString()));

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
        // urun ekleme
        public int AddProduct(ClassÜrünler u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into urunler (URUNAD,KATEGORIID,ACIKLAMA,FIYAT) values (@urunAd,@katId,@aciklama,@fiyat) ", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                //throw;
            }
            finally
            {

                con.Dispose();
                con.Close();

            }
            return sonuc;

        }
        //urunler ve kategoriler listeleme
        public void ListProducts(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select urunler.*,KATEGORIADI from urunler inner join kategoriler on kategoriler.ID=urunler.KATEGORIID Where urunler.Durum = 0", con);
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));
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
        //urun guncelleme
        public int UpdateProducts(ClassÜrünler u)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update urunler set URUNAD=@urunad,KATEGORIID=@katID,ACIKLAMA=@aciklama,FIYAT=@fiyat Where ID=@urunID ", con);


            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@urunad", SqlDbType.VarChar).Value = u._urunad;
                cmd.Parameters.Add("@katId", SqlDbType.Int).Value = u._urunturno;
                cmd.Parameters.Add("@aciklama", SqlDbType.VarChar).Value = u._aciklama;
                cmd.Parameters.Add("@fiyat", SqlDbType.Money).Value = u._fiyat;
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
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
        //urunleri sil
        public int DeleteProducts(ClassÜrünler u, int kat)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);

            string sql = "Update urunler set Durum=1 where ";
            if (kat == 0)
                sql += "KATEGORIID=@urunID";
            else
                sql += "ID=@urunID";

            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               
                cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = u._urunid;
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
        //urunleri IDye gore listeleme
        public void WithID_ListProducts(ListView lv, int urunId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand(" select urunler.*,KATEGORIADI from urunler inner join kategoriler on kategoriler.ID=urunler.KATEGORIID Where urunler.Durum = 0 and urunler.KATEGORIID=@urunID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@urunID", SqlDbType.Int).Value = urunId;
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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(string.Format("{0:0#00.0}", dr["FIYAT"].ToString()));

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
        // butun urunleri getiriyor iki tarih arasinda 
        public void WithStatistic_ListAllProducts(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis)
        {
            
                lv.Items.Clear();

                SqlConnection con = new SqlConnection(gnl.conString);
                SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.urunler.URUNAD ,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.urunler ON dbo.kategoriler.ID = dbo.urunler.KATEGORIID INNER JOIN dbo.satislar ON dbo.urunler.ID = dbo.Satislar.URUNID INNER JOIN dbo.adisyonlar ON dbo.Satislar.ADISYONID = dbo.adisyonlar.ID WHERE (CONVERT(datetime,TARIH,104)BETWEEN CONVERT (datetime, @Baslangic ,104) AND CONVERT (datetime, @Bitis ,104)) group by dbo.urunler.URUNAD order by adeti desc", con);
                SqlDataReader dr = null;
                cmd.Parameters.Add("@Baslangic", SqlDbType.DateTime).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.DateTime).Value = Bitis.Value.ToShortDateString();
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

                        
                        lv.Items.Add(dr["URUNAD"].ToString());
                        lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());
                      

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
        //belli kategoriye ait urunleri listeliyor
        public void WithType_ForStatics_ListProducts(ListView lv, DateTimePicker Baslangic, DateTimePicker Bitis, int urunkatId)
        {

            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("SELECT top 10 dbo.urunler.URUNAD ,sum(dbo.satislar.ADET) as adeti FROM dbo.kategoriler INNER JOIN dbo.urunler ON dbo.kategoriler.ID = dbo.urunler.KATEGORIID INNER JOIN dbo.satislar ON dbo.urunler.ID = dbo.Satislar.URUNID INNER JOIN dbo.adisyonlar ON dbo.Satislar.ADISYONID = dbo.adisyonlar.ID WHERE (CONVERT(datetime,TARIH,104)BETWEEN CONVERT (datetime, @Baslangic ,104) AND CONVERT (datetime, @Bitis ,104)) and (dbo.urunler.KATEGORIID = @katId) group by dbo.urunler.URUNAD order by adeti desc ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@Baslangic", SqlDbType.DateTime).Value = Baslangic.Value.ToShortDateString();
            cmd.Parameters.Add("@Bitis", SqlDbType.DateTime).Value = Bitis.Value.ToShortDateString();
            cmd.Parameters.Add("@katId", SqlDbType.Int).Value = urunkatId;
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


                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adeti"].ToString());


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

    }
    }

