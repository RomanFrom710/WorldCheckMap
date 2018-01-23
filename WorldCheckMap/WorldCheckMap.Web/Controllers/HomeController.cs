using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICountryService _countryService;

        public HomeController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public IActionResult Index()
        {
            var initialData = _countryService.GetCountriesInitialData();
            return View(initialData);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
