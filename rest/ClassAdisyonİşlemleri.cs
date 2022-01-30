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
    class ClassAdisyonİşlemleri
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();

        #region field
        private int _ID;
        private int _ServisTurNo;
        private decimal _Tutar;
        private DateTime _Tarih;
        private int _PersonelId;
        private int _MasaId;
        private int _Durum;
        #endregion
        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int MasaId
        {
            get { return _MasaId; }
            set { _MasaId = value; }
        }
        public int ServisTurNo
        {
            get { return _ServisTurNo; }
            set { _ServisTurNo = value; }
        }
        public decimal Tutar
        {
            get { return _Tutar; }
            set { _Tutar = value; }
        }
        public DateTime Tarih

        {
            get { return _Tarih; }
            set { _Tarih = value; }
        }
        public int PersonelId
        {
            get { return _PersonelId; }
            set { _PersonelId = value; }
        }
        public int Durum
        {
            get { return _Durum; }
            set { _Durum = value; }
        }

        #endregion

        public int getByAddition(int MasaId)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID from Adisyonlar Where MASAID=@MasaId order by ID desc", con);
            int sonuc=0;
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = MasaId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return sonuc;
        }

        //acik olan masanin adisyon numarasi

        public bool setByAdditionNew(ClassAdisyonİşlemleri Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into adisyonlar(SERVISTURNO,TARIH,PERSONELID,MASAID,DURUM) values(@ServisTurNo,@Tarih,@PersonelId,@MasaID,@Durum)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                } 

                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelId", SqlDbType.Int).Value = Bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@Durum", SqlDbType.Bit).Value = 0;
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
        public void additionClose(int adisyonID,int durum)
        {
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update adisyonlar set durum=@durum where ID=@adisyonId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                cmd.Parameters.Add("durum", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();
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
        //paket sipariş sayısını bulur
        public int NumberOfTakeAway()
        {
            int miktar = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) as Sayi from paketSiparis where DURUM=0", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                miktar = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return miktar;

        }
        //açık paket adisyonları Listviewa yazar
        public void OpenTakeAwayOrders(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparis.MUSTERIID,musteri.AD + ' ' + musteri.SOYAD as musteri,adisyonlar.ID as adisyonID from paketSiparis Inner Join musteri on musteri.ID=paketSiparis.MUSTERIID Inner join adisyonlar on adisyonlar.ID=paketSiparis.ADISYONID where paketSiparis.DURUM=0", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                int sayac = 0;
                while(dr.Read())
                {
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["musteri"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["adisyonID"].ToString());
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //müşterinin son paketsipariş adisyon idsini bulur
        public int Last_TakeAwayAdditionID_ForClient(int musteriId)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select adisyonlar.ID from adisyonlar Inner join paketSiparis on paketSiparis.ADISYONID=adisyonlar.ID where paketSiparis.DURUM=0 and adisyonlar.DURUM=0 and paketSiparis.MUSTERIID=@musteriId", con);
            SqlDataReader dr = null;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());
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
        //Sipariş kontrolü sayfası için açık paket siparişi olanları listviewa yazdırıyor
        public void ClientDetails(ListView lv,int musteriId)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            //adisyon.durum=0 ı sildin unutma
            SqlCommand cmd = new SqlCommand("Select paketSiparis.MUSTERIID,paketSiparis.ADISYONID,musteri.AD,musteri.SOYAD,CONVERT(varchar(10),adisyonlar.TARIH,104) as TARİH from adisyonlar Inner join paketSiparis on paketSiparis.ADISYONID=adisyonlar.ID Inner join musteri on musteri.ID=paketSiparis.MUSTERIID where (adisyonlar.SERVISTURNO=2) and (paketSiparis.MUSTERIID=@musteriId)", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = musteriId;
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
                    lv.Items.Add(dr["MUSTERIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TARİH"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());
                    sayac++;
                }
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();
            }
        }
        //paket sipariş için adisyon açıyor
        public int OpenAdditionforTakeAway(ClassAdisyonİşlemleri Bilgiler)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyonlar(SERVISTURNO,PERSONELID) values(@ServisTurNo,@PersonelId);select scope_IDENTITY()", con);
            cmd.Parameters.Add("ServisTurNo", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
            cmd.Parameters.Add("PersonelId", SqlDbType.Int).Value = Bilgiler.PersonelId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
               
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());

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
        public int RezervasyonAdisyonAc(ClassAdisyonİşlemleri bilgiler)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyonlar(SERVISTURNO,TARIH,PERSONELID,MASAID) values(@ServisTurNo,@Tarih,@PersonelId,@MasaID); select scope_IDENTITY() ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ServisTurNo", SqlDbType.Int).Value = bilgiler.ServisTurNo;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = bilgiler.Tarih;
                cmd.Parameters.Add("@PersonelId", SqlDbType.Int).Value = bilgiler.PersonelId;
                cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = bilgiler.MasaId;
                sonuc = Convert.ToInt32(cmd.ExecuteScalar());

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
    }
}
