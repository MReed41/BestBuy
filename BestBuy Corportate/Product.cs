using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace BestBuy_Corportate
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        private int id;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = ID;
            }
        }


        

    }
}
