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
            var initialState = new InitialState
            {
                Countries = _countryService.GetCountries()
            };
            return View(initialState);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
