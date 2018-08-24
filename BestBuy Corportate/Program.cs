using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BestBuy_Corportate
{
    class Program
    {
        public static void Main(string[] args)
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

            ProductRepository repo = new ProductRepository(connection);

            repo.Delete("iPhone 7");

            List<string> names = repo.GetMyProductNames();
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();

        }
    }
}
