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
    class ClassMasalar
    {
        #region Fields
        private int _ID;
        private int _KAPASITE;
        private int _SERVISTURU;
        private int _DURUM;
        private int _ONAY;
        private string _MasaBilgi;
        #endregion
        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int KAPASITE
        {
            get { return _KAPASITE; }
            set { _KAPASITE = value; }

        }
        public int SERVISTURU
        {
            get { return _SERVISTURU; }
            set { _SERVISTURU = value; }

        }

        public object MasaNo { get; private set; }
        public string MasaBilgi { get => _MasaBilgi; set => _MasaBilgi = value; }
        #endregion

        ClassBilgiGenel gnl = new ClassBilgiGenel();

        //masanın açıldığı süreyi hesaplıyor
        public string SessionSum(int state, string MasaId)
        {
            string dt = "";
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select TARIH, MasaId from adisyonlar Right Join Masalar on Adisyonlar.MasaId= Masalar.ID Where Masalar.DURUM=@durum and Adisyonlar.Durum=0 and Masalar.ID=@MasaId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = Convert.ToInt32(MasaId);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dt = Convert.ToDateTime(dr["TARIH"]).ToString();
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
            return dt;
        }

        public int TableGetByNumber(string TableValue)
        {
            string aa = TableValue;
            int length = aa.Length;
            if (length > 8)
            {
                return Convert.ToInt32(aa.Substring(length - 2, 2));
            }
            else
            {
                return Convert.ToInt32(aa.Substring(length - 1, 1));
            }



        }

        public bool TableGetByState(int ButtonName, int state)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select durum From Masalar Where Id=@TableId and DURUM=@state ", con);
            cmd.Parameters.Add("TableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("state", SqlDbType.Int).Value = state;

            try
            {
                if (con.State == ConnectionState.Closed)

                {
                    con.Open();
                }
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
        //masanın durumunu değiştiriyor
        public void setChangeTableState(string ButonName, int state)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update masalar Set DURUM=@Durum where ID=@MasaNo", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string masaNo = ButonName;
            string aa = ButonName;
            int uzunluk = aa.Length;
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            if (uzunluk > 8)
            {
                masaNo = aa.Substring(uzunluk - 2, 2);
            }
            else
            {
                masaNo = aa.Substring(uzunluk - 1, 1);
            }
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = masaNo;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
        public void setChangeTableStateForBill(string ButonName, int state)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update masalar Set DURUM=@Durum where ID=@MasaNo", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int masaNo = Convert.ToInt32(ButonName);
            cmd.Parameters.Add("@Durum", SqlDbType.Int).Value = state;
            cmd.Parameters.Add("@MasaNo", SqlDbType.Int).Value = masaNo;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }
        public void MasaKapasitesiVeDurumuGetir(ComboBox cm)
        {
            cm.Items.Clear();
            string durum = "";

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select * from masalar", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ClassMasalar c = new ClassMasalar();
                if (c._DURUM == 2)
                    durum = "Dolu";
                else if (c._DURUM == 3)
                    durum = "Rezerve";
                c._KAPASITE = Convert.ToInt32(dr["KAPASITE"]);
                c._MasaBilgi = "Masa No: " + dr["ID"].ToString() + " Kapasitesi: " + dr["KAPASITE"].ToString();
                c._ID = Convert.ToInt32(dr["ID"]);
                cm.Items.Add(c);

            }


            dr.Close();
            con.Dispose();
            con.Close();


        }

        public override string ToString()
        {
            return _MasaBilgi;
        }



    }
}