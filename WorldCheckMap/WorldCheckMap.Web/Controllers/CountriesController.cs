using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web.Controllers
{
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var countries = _countryService.GetCountries();
            return new JsonResult(countries);
        }
    }
}