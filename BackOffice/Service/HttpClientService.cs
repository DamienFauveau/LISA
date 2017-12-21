using BackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BackOffice.Service
{
    public class HttpClientService
    {
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