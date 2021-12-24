using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using OneFin.Models;

namespace OneFin.Client
{
    public class CFClient
    {
        private readonly HttpClient httpClient;
        private readonly CFServiceSettings settings;


        public CFClient(HttpClient httpClient, IOptions<CFServiceSettings> options)
        {
            this.httpClient = httpClient;
            settings = options.Value;
        }

        public async Task<List<CFCustomer>> GetCFList(string searchtype, string searchstring)
        {
            //List<CustomerList> custmerlist = new List<CustomerList>();

            //var forecast = await httpClient.GetFromJsonAsync<Forecast>($"https://{settings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={settings.ApiKey}");
             var custmerlist = await httpClient.GetFromJsonAsync<List<CFCustomer>>($"https://{settings.CFHost}{searchstring}");


            return custmerlist;
        }

        public async Task<CFCustomer> GetCFDetail(string searchstring)
        {
            //List<CustomerList> custmerlist = new List<CustomerList>();

            //var forecast = await httpClient.GetFromJsonAsync<Forecast>($"https://{settings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={settings.ApiKey}");
            var custmerdetail = await httpClient.GetFromJsonAsync<CFCustomer>($"https://{settings.CFHost}{searchstring}");


            return custmerdetail;
        }

    }
}
