using System;
using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Services
{
    public class CoreDataService : ICoreDataService
    {
        private readonly ICountryService _countryService;

        public CoreDataService(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public ClientInitDataDto GetClientInitData()
        {
            var statusValues = Enum.GetValues(typeof(CountryStatus)).Cast<int>()
                .ToDictionary(v => Enum.GetName(typeof(CountryStatus), v));

            return new ClientInitDataDto
            {
                Countries = _countryService.GetCountries(),
                CountryStatusValues = statusValues
            };
        }
    }
}