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
    class ClassMüşteriler
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();
        #region MyRegion
        private int _musteriid;
        private string _musteriad;
        private string _musterisoyad;
        private string _telefon;
        private string _adres;
        private string _email;
        #endregion

        #region Properties
        public int Musteriid { get => _musteriid; set => _musteriid = value; }
        public string Musteriad { get => _musteriad; set => _musteriad = value; }
        public string Musterisoyad { get => _musterisoyad; set => _musterisoyad = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }
        public string Adres { get => _adres; set => _adres = value; }
        public string Email { get => _email; set => _email = value; }
        #endregion
        //müşteri var mı diye bakıyor
        public bool IsClientExist(string tlf)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "IsClientExist";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Telefon", SqlDbType.VarChar).Value = tlf;
            cmd.Parameters.Add("@sonuc", SqlDbType.Int);
            cmd.Parameters["@sonuc"].Direction = ParameterDirection.Output;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                cmd.ExecuteNonQuery();
                sonuc = Convert.ToBoolean(cmd.Parameters["@sonuc"].Value);
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
        //Müşteri ekliyor
        //döndürdüğü değer müşteri ID
        public int AddClient(ClassMüşteriler m)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into musteri(AD,SOYAD,ADRES,TELEFON,EMAIL) values(@ad, @soyad,@adres,@telefon,@email); select SCOPE_IDENTITY()", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = m._musteriad;
                cmd.Parameters.Add("@soyad", SqlDbType.NVarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("@adres", SqlDbType.Text).Value = m._adres;
                cmd.Parameters.Add("@telefon", SqlDbType.NVarChar).Value = m._telefon;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = m._email;

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
        //müşterinin bilgilerini güncelliyor
        public bool UpdateClient(ClassMüşteriler m)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update musteri set AD=@ad,SOYAD=@soyad,ADRES=@adres,TELEFON=@telefon,EMAIL=@email where ID=@musteriId", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("@ad", SqlDbType.NVarChar).Value = m._musteriad;
                cmd.Parameters.Add("@soyad", SqlDbType.NVarChar).Value = m._musterisoyad;
                cmd.Parameters.Add("@adres", SqlDbType.Text).Value = m._adres;
                cmd.Parameters.Add("@telefon", SqlDbType.NVarChar).Value = m._telefon;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = m._email;
                cmd.Parameters.Add("@musteriId", SqlDbType.Int).Value = m._musteriid;
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
        //listviewa müşterileri getirir
        public void ForLv_BringClients(ListView lv)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteri where DURUM=0", con);
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
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

        //Müşterileri ıd'ye göre getirir
        public void WithID_BringClients(int musteriId, TextBox ad, TextBox soyad, TextBox telefon, TextBox adres, TextBox email)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteri where ID=@musteriID", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriID", SqlDbType.Int).Value = musteriId;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ad.Text = dr["AD"].ToString();
                    soyad.Text = dr["SOYAD"].ToString();
                    telefon.Text = dr["TELEFON"].ToString();
                    adres.Text = dr["ADRES"].ToString();
                    email.Text = dr["EMAIL"].ToString();

                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();


        }
        //müşterileri ada göre getiriyor
        public void WithName_BringClients(ListView lv, string musteriAd)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteri where AD like @musteriAd + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAd", SqlDbType.NVarChar).Value = musteriAd;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
                    sayac++;

                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();


        }
        //müşterileri soyada göre getiriyor
        public void WithSurname_BringClients(ListView lv, string musteriSoyad)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteri where SOYAD like @musteriSoyad + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriSoyad", SqlDbType.NVarChar).Value = musteriSoyad;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
                    sayac++;

                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();


        }
        //müşterileri telefon numarasına göre getiriyor
        public void WithPhoneNumber_BringClients(ListView lv, string musteritelefon)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteri where TELEFON like @musteriTelefon + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteritelefon", SqlDbType.NVarChar).Value = musteritelefon;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
                    sayac++;

                }


            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            dr.Close();
            con.Dispose();
            con.Close();


        }
        //müşteriyi siliyor
        public bool DeleteClient(int clientId)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Update musteri set Durum=1 where ID=@clientID", con);
            cmd.Parameters.Add("clientID", SqlDbType.VarChar).Value = clientId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }
            return sonuc;
        }
        //adrese göre müşteri getiriyor
        public void WithAdress_BringClients(ListView lv, string musteriadres)
        {
            lv.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from musteri where ADRES like @musteriAdres + '%' ", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("musteriAdres", SqlDbType.NVarChar).Value = musteriadres;
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
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["EMAIL"].ToString());
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
    }
}
