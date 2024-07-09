using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using Data_Migration;
using Data_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

namespace DirectusDataSync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=== Temporäres Portal - Daten Migration ===" +
                "\n 1) Datenbank Leeren" +
                "\n 2) Daten von CSV neu einlesen und in Migration-DB einfügen" +
                "\n 3) Daten ins Direktus übertragen" +
                "\n Auswahl: ");

                int auswahl = int.Parse(Console.ReadLine());
                bool result = false;
                Console.WriteLine();
                switch (auswahl)
                {
                    case 1:
                        result = ApplicationMethods.emptyDatabase();
                        break;
                    case 2:
                        result = ApplicationMethods.readDataToDatabase();
                        break;
                    case 3:
                        result = await ApplicationMethods.transferDataToDirectus();
                        break;
                    default:
                        Console.WriteLine(" Falsche Auswahl !!! ");
                        break;
                }

                Console.Clear();

                if (result)
                {
                    Console.WriteLine("Erfolgreich!");
                }
                else
                {
                    Console.WriteLine("Einen Fehler ist aufgetreten");
                }

                Console.ReadLine();
            }
        }




    }
}
