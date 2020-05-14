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
            Models.Country country = await _countryDataSourceClient.GetCountryByCodeAsync(alpha3Code);

            return View(country);
        }
    }
}