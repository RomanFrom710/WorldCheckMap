using System.Collections.Generic;
using Moq;
using WorldCheckMap.Data.Initialization.Interfaces;
using WorldCheckMap.Data.Models;

namespace WorldCheckMap.Tests.Helpers
{
    internal static class DataLayerMocks
    {
        internal static List<Country> Countries = new List<Country>
        {
            new Country { Code = "BLR", Name = "Belarus" },
            new Country { Code = "CAF", Name = "Central African Republic" },
            new Country { Code = "ZWE", Name = "Zimbabwe" }
        };

        internal static ICountriesStorage GetCountryStorageMock()
        {
            var mock = new Mock<ICountriesStorage>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(Countries));
            return mock.Object;
        }
    }
}