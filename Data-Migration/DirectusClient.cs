using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration
{
    public class DirectusClient
    {
        //private static string BASE_URL = "https://www.baykom-portal.bayern.de";
        private static string BASE_URL = "http://127.0.0.1:8055";
        private static string API_KEY = "W4WV7a3N7d6vAe1jb_B0JjV5dip_bndH";


        public static async Task<bool> PostDataToDirectus(string itemEndpoint, object data)
        {
            using (var client = CreateInsecureHttpClient(BASE_URL))
            {
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Transform data (example: convert to JSON)
                var jsonData = JsonConvert.SerializeObject(data);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync($"/items/{itemEndpoint}?access_token={API_KEY}", content);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return true; // Status code 200
                }
                else
                {
                    return false;
                }
            }
        }

        public static HttpClient CreateInsecureHttpClient(string baseUrl)
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public enum MerkmalsTyp
        {
            KUNDENNUMMER,
            RECHNUNGSKONTO
        }
    }
}
