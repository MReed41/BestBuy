using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


using System;
using System.Collections.Generic;

namespace BestBuy_Corportate
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("appsettings.Debug.json")
#else
                .AddJsonFile("appsettings.release.json")
#endif
                .Build();
            string connection = configBuilder.GetConnectionString("DefaultConnection");

            Product prod = new Product(connection);

            List<string> names = prod.GetMyProductNames();
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();

        }
    }
}
