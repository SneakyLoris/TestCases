using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlRequests
{
    public static class DbHelper
    {
        private static SqlConnection _conn;

        public static bool Connect(string connString)
        {
            try
            {
                _conn = new SqlConnection(connString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ExecuteNonQuery(SqlCommand cmd)
        {
            _conn.Open();

                if (_conn.State == ConnectionState.Open)
                {
                    cmd.Connection = _conn;
                    cmd.ExecuteNonQuery();
                }

            _conn.Close();

        }

        private static void ExecuteQueryPC(SqlCommand cmd, out BindingList<Product> comp)
        {
            comp = new BindingList<Product>();

            _conn.Open();

            if (_conn.State == ConnectionState.Open)
            {
                cmd.Connection = _conn;

                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        comp.Add(new Product(
                            dr.GetInt32(0),
                            dr.GetString(1),
                            dr.GetFloat(2),
                            dr.GetInt32(3)
                        ));
                    }
                }
            }
            _conn.Close();
        }

        public static BindingList<Product> GetDataPC()
        {
            BindingList<Product> comp;
            SqlCommand cmd = new SqlCommand();
            var query = "SELECT * FROM Computer;";
            cmd.CommandText = query;

            ExecuteQueryPC(cmd, out comp);
            return comp;
        }
    }
}
