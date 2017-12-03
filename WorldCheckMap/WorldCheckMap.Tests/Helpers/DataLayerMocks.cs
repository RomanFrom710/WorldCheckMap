using System.Collections.Generic;
using Moq;
using WorldCheckMap.Data.Initialization.Interfaces;
using WorldCheckMap.Data.Models;
using WorldCheckMap.Data.Repositories.Interfaces;

namespace WorldCheckMap.Tests.Helpers
{
    internal static class DataLayerMocks
    {
        internal static ICountriesStorage GetCountryStorageMock()
        {
            var mock = new Mock<ICountriesStorage>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(TestData.Countries));
            return mock.Object;
        }

        internal static ICountryRepository GetCountryRepositoryMock()
        {
            var mock = new Mock<ICountryRepository>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(TestData.Countries));
            return mock.Object;
        }
    }
}