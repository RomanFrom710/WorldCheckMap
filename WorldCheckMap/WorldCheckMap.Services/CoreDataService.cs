using System;
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

        public CoreDataDto GetClientInitData()
        {
            var statuses = Enum.GetNames(typeof(CountryStatus));

            return new CoreDataDto
            {
                Countries = _countryService.GetCountries(),
                CountryStatuses = statuses
            };
        }
    }
}