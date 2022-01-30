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
    class ClassPersonelGörevleri
    {
        ClassBilgiGenel gnl = new ClassBilgiGenel();

        private string _personelGorevId;
        private string _tanim;

        public string PersonelGorevId { get => _personelGorevId; set => _personelGorevId = value; }
        public string Tanim { get => _tanim; set => _tanim = value; }
        //personel görevlerini comboboxa getirir
        public void BringEmployeeDuty(ComboBox cb)
        {
            cb.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select * from personelGorevleri", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClassPersonelGörevleri c = new ClassPersonelGörevleri();
                    c._personelGorevId = dr["ID"].ToString();
                    c._tanim = dr["GOREV"].ToString();
                    cb.Items.Add(c);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;

            }
            dr.Close();
            con.Close();
        }
        //personelin görevinin tanımını getirir
        public string EmployeeDutyDescription(int per)
        {

            string sonuc = "";
            SqlConnection con = new SqlConnection(gnl.conString); //veritabanına bağlanır
            SqlCommand cmd = new SqlCommand("Select GOREV from personelGorevleri where ID=@perId", con);

            cmd.Parameters.Add("perId", SqlDbType.Int).Value = per;

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                sonuc = cmd.ExecuteScalar().ToString();
            }

            catch (SqlException ex)
            {
                string hata = ex.Message;

            }

            con.Close();
            return sonuc;
        }
        public override string ToString()
        {
            return _tanim;
        }
    }
}
