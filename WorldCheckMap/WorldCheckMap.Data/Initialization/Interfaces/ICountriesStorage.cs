using System.Collections.Generic;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data.Initialization.Interfaces
{
    public interface ICountriesStorage
    {
        List<Country> GetCountries();
    }
}