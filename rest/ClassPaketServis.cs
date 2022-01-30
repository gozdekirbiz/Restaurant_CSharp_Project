using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace rest
{
    class ClassPaketServis
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();
        #region MyRegion
        private int _ID;
        private int _AdditionID;
        private int _ClientID;
        private string _Description;
        
        private int _PayTypeid;
        #endregion

        #region Properties
        public int ID { get => _ID; set => _ID = value; }
        public int AdditionID { get => _AdditionID; set => _AdditionID = value; }
        public int ClientID { get => _ClientID; set => _ClientID = value; }
        public string Description { get => _Description; set => _Description = value; }
       
        public int PayTypeid { get => _PayTypeid; set => _PayTypeid = value; }
        #endregion
        //paket servisi ekleme
        public bool OrderServiceOpen(ClassPaketServis order)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert into paketSiparis(ADISYONID,MUSTERIID,ODEMETURID,ACIKLAMA)values(@ADISYONID,@MUSTERIID,@ODEMETURID,@ACIKLAMA)", con);
            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = order._AdditionID;
                cmd.Parameters.Add("@MUSTERIID", SqlDbType.Int).Value = order._ClientID;
                cmd.Parameters.Add("@ODEMETURID", SqlDbType.Int).Value = order._PayTypeid;
                cmd.Parameters.Add("@ACIKLAMA", SqlDbType.Text).Value = order._Description;
                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch(SqlException ex)
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
        //paket servisi kapatma
        public void OrderServiceClose(int AdditionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update paketSiparis set paketSiparis.DURUM=1 where paketSiparis.ADISYONID=@AdditionID",con);
            cmd.Parameters.Add("AdditionID", SqlDbType.Int).Value = AdditionID;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
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
            
        }
        //açılan adisyon ve paket siparişe ait ön girilen ödeme tür id
        public int BringPayCheckType(int adisyonId)
        {
            int odemeTurID = 0;
            
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select paketSiparis.ODEMETURID from paketSiparis Inner Join adisyonlar on paketSiparis.ADISYONID=adisyonlar.ID where (adisyonlar.ID=@adisyonId)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("adisyonId", SqlDbType.Int).Value = adisyonId;
               
                odemeTurID = Convert.ToInt32(cmd.ExecuteScalar());
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
            return odemeTurID;


        }
        //Sipariş kontrolü için müşteriye ait açık en sonuncu adisyon nosunu getirir.
        //Bir müşteriye ait 2 veya daha fazla sipariş açık olamayacak.
        public int BringClientLastAdditionID(int musteriID)
        {
            int no = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select adisyonlar.ID from adisyonlar Inner Join paketSiparis on paketSiparis.ADISYONID=adisyonlar.ID where (adisyonlar.DURUM=0) and (paketSiparis.DURUM=0) and (paketSiparis.MUSTERIID=@musteriID)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("musteriID", SqlDbType.Int).Value = musteriID;

                no = Convert.ToInt32(cmd.ExecuteScalar());
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

            return no;
        }
        //müşteri arama ekranında adisyonbul butonu için adisyon açık mı değil mi kontrol eder
        public bool getCheckOpenAdditionID(int additionID)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from adisyonlar where (DURUM=0) and (ID=@additionID) ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("additionID", SqlDbType.Int).Value = additionID;
                
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
        //bundan sonraki iki şeyi ben yazdım kullandım mı hatırlamıyorum gereksiz olabilir
        
        public int MusteriIDgetirPaket(int additionID)
        {
            int clientId = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select MUSTERIID from paketSiparis where ADISYONID=@additionID ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;


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
        public bool PaketDurumGetir(int additionID)
        {
            bool durum = true;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM from paketSiparis where ADISYONID=@additionID ", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@additionID", SqlDbType.Int).Value = additionID;


                durum = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return durum;
        }
        
    }
}
