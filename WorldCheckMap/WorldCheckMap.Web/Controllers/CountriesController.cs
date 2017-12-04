using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/countries")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IEnumerable<CountryDto> Get()
        {
            return _countryService.GetCountries();
        }
    }
}