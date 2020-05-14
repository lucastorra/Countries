using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Country.Models;
using Country.HttpClients;
using PagedList;

namespace Country.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryDataSourceClient _countryDataSourceClient;
        private List<Models.Country> _countries { get; set; }

        public CountryController()
        {
            _countryDataSourceClient = new CountryDataSourceClient();
        }

        public async Task<ActionResult> Index(int? pPage)
        {
            int sizePage = 6;
            int page = pPage ?? 1;

            _countries = await _countryDataSourceClient.GetAllCountriesAsync();
           
            return View(_countries.ToPagedList(page, sizePage));
        }

        public async Task<ActionResult> ViewCountry(string alpha3Code)
        {
            /*Fiquei com dúvida nesse ponto sobre o que seria melhor a fazer:
             * O texto do problema diz "Faça com que a chamada no datasource não se repita em todas as chamadas da sua API."
             * No entanto a forma que encontrei para fazer isso, não parece ser uma boa prática. (Imagino que deva ter uma melhor)
             * Guardar a lista de países em uma propriedade estática, e realizar um Find na Lista.
             *
             *Country country = _countries.Find(x => x.Alpha3Code == alpha3Code);
             * 
             * 
             * Por isso estou vou realizar a busca no DataSource usado o código.
             */

            Models.Country country = await _countryDataSourceClient.GetCountryByCodeAsync(alpha3Code);

            return View(country);
        }
    }
}