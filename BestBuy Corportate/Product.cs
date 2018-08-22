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
        public void Insert (Product product)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                MySqlConnection cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO products (Name, Price)" +
                    "Values (@name, @price);";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);

                cmd.ExecuteNonQuery();
            }
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

        public void Update(Product product)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                MySqlConnection cmd = new MySqlConnection(connectionString);

                cmd.CommandText = "UPDATE products " + "SET Name = @name, Price = @price " +
                                    "WHERE ProductId = @id;";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("id", product.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delet(Product product)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM products " + "WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", product.Id);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
