using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace BestBuy_Corportate
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("appsettings.debug.json")
#else
                .AddJsonFile("appsettings.release.json")
#endif
                .Build();
            string connection = configBuilder.GetConnectionString("DefaultConnection");

        }
    }
}
