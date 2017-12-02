using System.Collections.Generic;
using Moq;
using WorldCheckMap.Data.Initialization.Interfaces;
using WorldCheckMap.Data.Models;
using WorldCheckMap.Data.Repositories.Interfaces;

namespace WorldCheckMap.Tests.Helpers
{
    internal static class DataLayerMocks
    {
        internal static List<Country> Countries = new List<Country>
        {
            new Country { Id = 1, Code = "BLR", Name = "Belarus" },
            new Country { Id = 2, Code = "CAF", Name = "Central African Republic" },
            new Country { Id = 3, Code = "ZWE", Name = "Zimbabwe" }
        };

        internal static ICountriesStorage GetCountryStorageMock()
        {
            var mock = new Mock<ICountriesStorage>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(Countries));
            return mock.Object;
        }

        internal static ICountryRepository GetCountryRepositoryMock()
        {
            var mock = new Mock<ICountryRepository>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(Countries));
            return mock.Object;
        }
    }
}