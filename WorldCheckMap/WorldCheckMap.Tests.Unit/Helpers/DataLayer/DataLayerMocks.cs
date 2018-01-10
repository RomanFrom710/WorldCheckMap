using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Initialization.Interfaces;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories.Interfaces;

namespace WorldCheckMap.Tests.Unit.Helpers.DataLayer
{
    internal static class DataLayerMocks
    {
        internal static Mock<ICountriesStorage> GetCountryStorageMock()
        {
            var mock = new Mock<ICountriesStorage>();
            mock.Setup(cs => cs.GetCountries()).Returns(new List<Country>(TestData.GetCountries()));
            return mock;
        }

        internal static Mock<ICountryRepository> GetCountryRepositoryMock()
        {
            var mock = new Mock<ICountryRepository>();
            mock.Setup(cr => cr.GetCountries()).Returns(new List<Country>(TestData.GetCountries()));
            return mock;
        }

        internal static Mock<IAccountRepository> GetAccountRepositoryMock()
        {
            var testAccounts = TestData.GetAccounts();

            var mock = new Mock<IAccountRepository>();

            mock
                .Setup(ar => ar.GetAccount(It.IsAny<int>()))
                .Returns((int id) => testAccounts.Find(a => a.Id == id))
                .Verifiable();
            mock
                .Setup(ar => ar.GetAccount(It.IsAny<Guid>()))
                .Returns((Guid guid) => testAccounts.Find(a => a.Guid == guid))
                .Verifiable();

            mock
                .Setup(ar => ar.AddAccount(It.IsAny<Account>()))
                .Returns((int id) => testAccounts.Max(a => a.Id) + 1)
                .Verifiable();

            mock
                .Setup(ar => ar.UpdateCountryState(It.IsAny<Guid>(), It.IsAny<int>(), It.IsAny<CountryStatus>()))
                .Verifiable();

            return mock;
        }
    }
}