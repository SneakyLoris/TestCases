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
        // localhost\\SQLEXPRESS
        private static SqlConnection conn = new SqlConnection(@"Data Source = localhost\SQLEXPRESS;Initial Catalog = 'market';Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static bool Connect(string connString)
        {
            try
            {
                conn = new SqlConnection(connString);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void ExecuteNonQuery(SqlCommand cmd)
        {
            conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }

            conn.Close();
        }


        public static List<string> Task1()
        {
            List<string> list = new List<string>();

            SqlCommand cmd = new SqlCommand();
            var query = "SELECT * FROM Managers WHERE phone IS NOT NULL";
            cmd.CommandText = query;



            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                cmd.Connection = conn;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                            list.Add($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetDouble(2)} {reader.GetInt32(3)} {reader.GetString(4)}");
                        else
                            list.Add($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetDouble(2)} {reader.GetInt32(3)} NULL");

            }
            conn.Close();


            return list;
        }

        public static int Task2()
        {
            int count = 0;

            SqlCommand cmd = new SqlCommand();
            var query = "SELECT COUNT(ID) FROM Sells WHERE Date = '2021-06-20'";
            cmd.CommandText= query;

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                cmd.Connection = conn;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    count = reader.GetInt32(0);
            }
            

            conn.Close();

            return count;
        }
        public static double Task3()
        {
            double mean = 0;

            SqlCommand cmd = new SqlCommand();
            // Считаю что это не совсем верный запрос, так как может быть несколько фанер под разными id, но я не знаю пока как написать по-другому
            var query = "SELECT AVG(Sum) FROM Sells WHERE ID_Prod IN (SELECT ID FROM Products WHERE Name LIKE '%Фанера%')";
            cmd.CommandText = query;

            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                cmd.Connection = conn;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    mean = reader.GetDouble(0);
            }


            conn.Close();

            return mean;
        }

        public static List<string> Task6()
        {
            List<string> list = new List<string>();

            SqlCommand cmd = new SqlCommand();
            var query = "SELECT * FROM Products WHERE Name LIKE '%Фанера%' AND Cost >= 1750";
            cmd.CommandText = query;


            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                cmd.Connection = conn;

                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        if (!reader.IsDBNull(reader.GetOrdinal("Phone")))
                            list.Add($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetDouble(2)} {reader.GetInt32(3)} {reader.GetString(4)}");
                        else
                            list.Add($"{reader.GetInt32(0)} {reader.GetString(1)} {reader.GetDouble(2)} {reader.GetInt32(3)} NULL");

            }
            conn.Close();


            return list;
        }
    }
}
