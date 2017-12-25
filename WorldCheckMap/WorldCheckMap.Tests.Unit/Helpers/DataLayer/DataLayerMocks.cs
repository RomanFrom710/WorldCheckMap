using System.Collections.Generic;
using Moq;
using WorldCheckMap.DataAccess.Initialization.Interfaces;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories.Interfaces;

namespace WorldCheckMap.Tests.Unit.Helpers.DataLayer
{
    internal static class DataLayerMocks
    {
        internal static ICountriesStorage GetCountryStorageMock()
        {
            var mock = new Mock<ICountriesStorage>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(TestData.GetCountries()));
            return mock.Object;
        }

        internal static ICountryRepository GetCountryRepositoryMock()
        {
            var mock = new Mock<ICountryRepository>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(TestData.GetCountries()));
            return mock.Object;
        }
    }
}