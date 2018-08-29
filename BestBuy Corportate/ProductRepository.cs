using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace BestBuy_Corportate
{
    class ProductRepository
    {
        private static string connectionString;

        public ProductRepository(string _connectionString)
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
                cmd.CommandText = "SELECT name FROM products";
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

        public void Insert(Product product)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO products (Name, Price)" +
                    "Values (@name, @price);";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Product product)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE products " +
                                    "SET Name = @name, Price = @price " +
                                    "WHERE ProductId = @id;";
                cmd.Parameters.AddWithValue("name", product.Name);
                cmd.Parameters.AddWithValue("price", product.Price);
                cmd.Parameters.AddWithValue("id", product.ID);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM products WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(string name)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            string prodID = "";
            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT sales.ProductID FROM sales " +
                                    "LEFT JOIN Products " +
                                        "ON sales.ProductID = Products.ProductID " +
                                    "WHERE Name = @name;";
                cmd.Parameters.AddWithValue("name", name);

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    prodID = dr["ProductID"].ToString();
                }
            }

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM sales WHERE ProductID = @id;";
                cmd.Parameters.AddWithValue("id", prodID);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM products WHERE Name = @name;";
                cmd.Parameters.AddWithValue("name", name);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
