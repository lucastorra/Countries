using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Country.Models;

namespace Country.HttpClients
{
    public class CountryDataSourceClient
    {
        private readonly HttpClient _httpClient;

        public CountryDataSourceClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://restcountries.eu/rest/v2/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<Models.Country>> GetAllCountriesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("all");
            Console.WriteLine(response.StatusCode);

            return await response.Content.ReadAsAsync<List<Models.Country>>();
        }

        public async Task<Models.Country> GetCountryByCodeAsync(string alpha3Code)
        {
            HttpResponseMessage response = await _httpClient.GetAsync("alpha/"+alpha3Code);
            Console.WriteLine(response.StatusCode);

            return await response.Content.ReadAsAsync<Models.Country>();
        }
    }
}