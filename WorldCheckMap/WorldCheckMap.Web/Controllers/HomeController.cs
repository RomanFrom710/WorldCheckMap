using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Interfaces;
using WorldCheckMap.Web.ViewModels;

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
            var initialData = new InitialData { Countries = _countryService.GetCountries() };
            return View(initialData);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
