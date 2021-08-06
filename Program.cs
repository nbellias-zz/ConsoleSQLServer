using ConsoleSQLServer.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleSQLServer
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            PrintCountries();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void PrintCountries()
        {
            var countryDAL = new CountryDAL(_iconfiguration);
            // Fetch All
            var listCountryModelAll = countryDAL.GetList();
            listCountryModelAll.ForEach(item =>
            {
                Console.WriteLine(item.Country);
            });
            Console.WriteLine("------------------------");
            // Fetch only what starts with 'So'
            var listCountryModel = countryDAL.GetList("So");
            listCountryModel.ForEach(item =>
            {
                Console.WriteLine(item.Country);
            });
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
