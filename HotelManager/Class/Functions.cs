using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager.Class
{
    class Functions
    {
        public static SqlConnection Con;

        public static void Connect()
        {
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-V56RKEE;Initial Catalog=KS6;Integrated Security=True";
            Con.Open();
        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
                Con.Dispose();
                Con = null;
            }
        }
        public static void UpdateData(string sql)
        {
            Connect();
            SqlCommand sqlcomand = new SqlCommand();
            sqlcomand.Connection = Con;
            sqlcomand.CommandText = sql;
            sqlcomand.ExecuteNonQuery();
            Disconnect();
            sqlcomand.Dispose();
        }
        public static string laygiatri(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public DataTable DataReader(string sqlselect)
        {
            Connect();
            DataTable dttable = new DataTable();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlselect, Con);
            sqlData.Fill(dttable);
            return dttable;

        }
        public static int key()
        {
            int Numrd;
            string Numrd_str;
            Random rd = new Random();
            Numrd = rd.Next(1000, 9999);
            Numrd_str = rd.Next(1000, 9999).ToString();
            return Numrd;
        }
        public static void Chaysql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd = null;
        }
        public static bool ktra(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
    }
}
