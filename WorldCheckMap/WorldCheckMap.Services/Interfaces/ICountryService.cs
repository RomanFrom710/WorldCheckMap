using System.Collections.Generic;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Services.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetCountries();
    }
}