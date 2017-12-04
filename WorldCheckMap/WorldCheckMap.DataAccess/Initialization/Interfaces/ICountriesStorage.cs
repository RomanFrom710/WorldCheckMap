using System.Collections.Generic;
using WorldCheckMap.DataAccess.Models;

namespace WorldCheckMap.DataAccess.Initialization.Interfaces
{
    public interface ICountriesStorage
    {
        List<Country> GetCountries();
    }
}