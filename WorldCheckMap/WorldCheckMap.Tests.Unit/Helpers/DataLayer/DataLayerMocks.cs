using System;
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
            mock.Setup(cr => cr.GetCountries()).Returns(new List<Country>(TestData.GetCountries()));
            return mock.Object;
        }

        internal static IAccountRepository GetAccountRepositoryMock()
        {
            var testAccounts = TestData.GetAccounts();

            var mock = new Mock<IAccountRepository>();

            mock.Setup(ar => ar.GetAccount(It.IsAny<int>())).Returns((int id) => testAccounts.Find(a => a.Id == id));
            mock.Setup(ar => ar.GetAccount(It.IsAny<Guid>())).Returns((Guid guid) => testAccounts.Find(a => a.Guid == guid));

            return mock.Object;
        }
    }
}