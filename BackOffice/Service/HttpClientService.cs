using BackOffice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BackOffice.Service
{
    public class HttpClientService<T>
    {
        private static HttpClient client;

        public static HttpClient Client
        {
            get
            {
                if(client == null)
                {
                    client = new HttpClient();
                }

                return client;
            }
        }

        public static List<T> Get(T obj, string url)
        {
            List<T> objs = new List<T>();

            HttpResponseMessage response = Client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseBody = response.Content.ReadAsStringAsync().Result;
                objs = JsonConvert.DeserializeObject<List<T>>(responseBody);
            }

            return objs;
        }

        public static string Connexion(LoginVM connexion)
        {
            string responseBody = "";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53334/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsJsonAsync("Salaries/Connexion", connexion).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseBody = response.Content.ReadAsStringAsync().Result;
                }
            }
            return responseBody;
        }
    }
}