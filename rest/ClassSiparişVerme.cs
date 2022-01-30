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
    class ClassSiparişVerme
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();

        #region field
        private int _Id;
        private int _AdisyonId;
        private int _UrunId;
        private int _MasaId;
        private int _Adet;

        #endregion
        #region Properties
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int MasaId
        {
            get { return _MasaId; }
            set { _MasaId = value; }
        }
        public int AdisyonId
        {
            get { return _AdisyonId; }
            set { _AdisyonId = value; }
        }
        public int UrunId
        {
            get { return _UrunId; }
            set { _UrunId = value; }
        }
        public int Adet
        {
            get { return _Adet; }
            set { _Adet = value; }
        }

        #endregion

        //Siparisleri getir
        public void getByOrder(ListView lv, int AdisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select URUNAD,FIYAT,satislar.ID,satislar.URUNID,satislar.ADET from satislar Inner Join urunler on Satislar.URUNID=Urunler.ID Where ADISYONID = @AdisyonId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;
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
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                // throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();


            }

        }
        public bool setSaveOrder(ClassSiparişVerme Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into satislar(ADISYONID,URUNID, ADET,MASAID) values(@AdisyonNo, @UrunId,@Adet,@MasaId)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler._AdisyonId;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler._UrunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler._Adet;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler._MasaId;

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        public void setDeleteOrder(int SatisId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From Satislar Where ID=@SatisID", con);
            cmd.Parameters.Add("@SatisID", SqlDbType.Int).Value = SatisId;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }
        //Genel Toplamı bulur
        public decimal OverallTotal(int musteriId)
        {
            decimal geneltoplam = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            //sondaki durumu 1 olarak değiştirdin unutma
            SqlCommand cmd = new SqlCommand("SELECT SUM(satislar.ADET*urunler.FIYAT) AS fiyat FROM musteri  INNER JOIN paketSiparis ON musteri.ID = paketSiparis.MUSTERIID INNER JOIN adisyonlar on adisyonlar.ID=paketSiparis.ADISYONID INNER JOIN satislar ON adisyonlar.ID = satislar.ADISYONID INNER JOIN urunler ON satislar.URUNID = urunler.ID WHERE(paketSiparis.MUSTERIID =@musteriId) ", con);
            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                geneltoplam = Convert.ToDecimal(cmd.ExecuteScalar());
                

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return geneltoplam;
        }
        //adisyon paket sipariş detayları
        public void AdditionTakeAwayDetails(ListView lv,int adisyonID)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select satislar.ID as satisID,urunler.URUNAD,urunler.FIYAT,satislar.ADET from satislar Inner Join adisyonlar on adisyonlar.ID=satislar.ADISYONID inner join urunler on urunler.ID=satislar.URUNID where satislar.ADISYONID=@adisyonID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("adisyonID", SqlDbType.Int).Value = adisyonID;
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

                    lv.Items.Add(dr["satisID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["FIYAT"].ToString());
                    

                    sayac++;
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                // throw;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();


            }
            
        }
        //paket serviş satışı kaydediliyor
        public bool SaveTakeAwaySales(ClassSiparişVerme Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into satislar(ADISYONID,URUNID,ADET) values(@AdisyonNo, @UrunId,@Adet)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@AdisyonNo", SqlDbType.Int).Value = Bilgiler._AdisyonId;
                cmd.Parameters.Add("@UrunId", SqlDbType.Int).Value = Bilgiler._UrunId;
                cmd.Parameters.Add("@Adet", SqlDbType.Int).Value = Bilgiler._Adet;
                

                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        //gereksiz gibi
        public void TakeAwayUpdateDelete(int musteriId,int adisyonId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            ClassSiparişVerme c = new ClassSiparişVerme();
            decimal sonuc=c.OverallTotal(musteriId);
            if(sonuc==0)
            {
                SqlCommand cmd = new SqlCommand("Delete from paketSiparis where (paketSiparis.MUSTERIID=@musteriId) and (paketSiparis.ADISYONID=@adisyonId)", con);
                bool a = false;
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
                    cmd.Parameters.Add("@adisyonId", SqlDbType.Int).Value = adisyonId;


                    a = Convert.ToBoolean(cmd.ExecuteNonQuery());

                }
                catch (SqlException ex)
                {
                    string hata = ex.Message;
                }
                finally
                {
                    con.Dispose();
                    con.Close();
                }
            }
            
        }
        


    }
}
