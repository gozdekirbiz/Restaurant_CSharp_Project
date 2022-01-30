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
    class ClassRezervasyon
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();
        #region MyRegion
        private int _ID;
        private int _TableId;
        private int _ClientId;
        private DateTime _Date;
        private int _ClientCount;
        private string _Description;
        private int _AdditionId;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int TableId { get => _TableId; set => _TableId = value; }
        public int ClientId { get => _ClientId; set => _ClientId = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public int ClientCount { get => _ClientCount; set => _ClientCount = value; }
        public string Description { get => _Description; set => _Description = value; }
        public int AdditionId { get => _AdditionId; set => _AdditionId = value; } 
        #endregion
        //müşteriId masa numarasına göre
        public int getByClientIdFromRezervasyon(int tableId)
        {
            int clientId = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 MUSTERIID from Rezervasyonlar where MASAID=@masaid order by MUSTERIID Desc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("masaid", SqlDbType.Int).Value = tableId;


                clientId = Convert.ToInt32(cmd.ExecuteScalar());
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
            return clientId;
        }
        //hesap kapatırken rezervasyonlu masayı kapat
        public bool reservationClose(int adisyonID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Rezervasyonlar set durum=1 where ADISYONID=@adisyonId", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonID;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;
        }
        // rezervasyonları getir
        public void musteriIdGetirFromRezervasyon(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MUSTERIID,(AD + SOYAD) as musteri from Rezervasyonlar Inner Join musteriler on Rezervasyonlar.MUSTERIID=musteriler.ID where Rezervasyonlar.Durum=0", con);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {

                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[sayac].SubItems.Add(dr["musteri"].ToString());

                sayac++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        // eski rezervasyonları getir
        public void eskiRezervasyonlariGetir(ListView lv, int mId)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MUSTERIID,AD , SOYAD, ADISYONID,Tarih  from Rezervasyonlar Inner Join musteriler on Rezervasyonlar.MUSTERIID=musteriler.ID where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum=0 order by rezervasyonlar.ID Desc", con);

            cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();
            int sayac = 0;
            while (dr.Read())
            {

                lv.Items.Add(dr["MUSTERIID"].ToString());
                lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                lv.Items[sayac].SubItems.Add(dr["TARIH"].ToString());
                lv.Items[sayac].SubItems.Add(dr["ADISYONID"].ToString());

                sayac++;
            }
            dr.Close();
            con.Dispose();
            con.Close();
        }
        // en son rezervasyon tarihini getir
        public DateTime EnsonRezervasyonTarihi(int mId)
        {
            DateTime tar = new DateTime();
            tar = DateTime.Now;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH  from Rezervasyonlar where Rezervasyonlar.MUSTERIID=@mId and Rezervasyonlar.Durum=1 order by rezervasyonlar.ID Desc", con);

            cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            tar = Convert.ToDateTime(cmd.ExecuteScalar());


            con.Dispose();
            con.Close();

            return tar;
        }
        // acık rezervasyonların sayısı
        public int acikRezervasyonSayisi()
        {

            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select count(*) from Rezervasyonlar where Rezervasyonlar.Durum=0", con);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Dispose();
            con.Close();
            return sonuc;
        }
        // rezervasyon acık mı kontrolu
        public bool RezervasyonAcikmiKontrol(int mId)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 Rezervasyonlar.ID from Rezervasyonlar where MUSTERIID=@mID and durum=0 order by ID desc", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("mID", SqlDbType.Int).Value = mId;
                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;
        }
        // rezervasyon aç
        public bool RezervasyonAc(ClassRezervasyon r)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Rezervasyonlar (MUSTERIID, MASAID, ADISYONID,KISISAYISI, TARIH, ACIKLAMA, DURUM) values (@MUSTERIID, @MASAID, @ADISYONID,@KISISAYISI, @TARIH, @ACIKLAMA, 1)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("MUSTERIID", SqlDbType.Int).Value = r._ClientId;
                cmd.Parameters.Add("MASAID", SqlDbType.Int).Value = r._TableId;
                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = r._AdditionId;
                cmd.Parameters.Add("KISISAYISI", SqlDbType.Int).Value = r._ClientCount;
                cmd.Parameters.Add("TARIH", SqlDbType.Date).Value = r._Date;
                cmd.Parameters.Add("ACIKLAMA", SqlDbType.VarChar).Value = r._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return result;
        }
        // rezerve masanın IDsini getir
        public int RezerveMasaIdGetir(int mId)
        {

            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select Rezervasyonlar.MASAID from Rezervasyonlar Inner Join Adisyonlar on Rezervasyonlar.ADISYONID=Adisyonlar.ID where (Rezervasyonlar.Durum=1) and Adisyonlar.Durum=0 and Rezervasyonlar.MUSTERIID=@mId", con);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.Parameters.Add("mId", SqlDbType.Int).Value = mId;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Dispose();
            con.Close();
            return sonuc;
        }
    }
}
