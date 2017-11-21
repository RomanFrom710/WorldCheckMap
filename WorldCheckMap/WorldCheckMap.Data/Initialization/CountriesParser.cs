using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using WorldCheckMap.Data.Initialization.Data;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Data.Initialization
{
    internal static class CountriesParser
    {
        public static List<Country> GetCountries()
        {
            var jsonString = Encoding.Default.GetString(InitializationData.Countries);
            var countryTokens = JArray.Parse(jsonString);
            var countries = countryTokens.Select(ct => ct.ToObject<Country>()).ToList();
            return countries;
        }
    }
}
