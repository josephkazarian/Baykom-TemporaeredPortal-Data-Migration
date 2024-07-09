using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration
{
    public class HelperMethods
    {
        public static List<T> ReadCsv<T>(string filename) where T : class
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", filename);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<T>();
                return new List<T>(records);
            }
        }

        public static bool AddIfNotNullOrEmpty(Dictionary<string, object> dictionary, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                dictionary.Add(key, value);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
