using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace BestBuy_Corportate
{
    class Product
    {
        private static string connectionString;

        public Product(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public List<string> GetMyProductNames()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select name from products";
                MySqlDataReader dr = cmd.ExecuteReader();

                List<string> ProductNames = new List<string>();

                while (dr.Read())
                {
                    string name = dr["name"].ToString();
                    ProductNames.Add(name);

                }
                return ProductNames;
            }

        }

    }
}
