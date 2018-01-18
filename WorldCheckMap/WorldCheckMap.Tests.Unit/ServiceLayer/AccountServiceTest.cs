using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.Services;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Tests.Common;
using WorldCheckMap.Tests.Unit.Infrastructure.DataLayer;
using WorldCheckMap.Tests.Unit.Infrastructure.ServiceLayer;

namespace WorldCheckMap.Tests.Unit.ServiceLayer
{
    [TestClass]
    public class AccountServiceTest
    {
        [TestMethod]
        public void GetAccountByIdTest()
        {
            var repositoryMock = DataLayerMocks.GetAccountRepositoryMock();
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new AccountService(repositoryMock.Object, mapper);

            var accountId = 1;
            var foundAccount = service.GetAccount(accountId);

            repositoryMock.Verify(ar => ar.GetAccount(It.Is((int id) => id == accountId)), Times.Once);
            Assert.IsNotNull(foundAccount);
            Assert.AreEqual(Guid.Empty, foundAccount.Guid, "GetAccount by Id shouldn't return account's guid");
        }

        [TestMethod]
        public void GetAccountByGuidTest()
        {
            var repositoryMock = DataLayerMocks.GetAccountRepositoryMock();
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new AccountService(repositoryMock.Object, mapper);

            var accountGuid = Guid.NewGuid();
            var foundAccount = service.GetAccount(accountGuid);

            repositoryMock.Verify(ar => ar.GetAccount(It.Is((Guid guid) => guid == accountGuid)), Times.Once);
            Assert.IsNotNull(foundAccount);
        }

        [TestMethod]
        public void AddAccountTest()
        {
            var repositoryMock = DataLayerMocks.GetAccountRepositoryMock();
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new AccountService(repositoryMock.Object, mapper);

            var addCommand = TestData.GetAddAccountCommands().First();
            var accountDto = service.AddAccount(addCommand);

            repositoryMock.Verify(ar => ar.AddAccount(It.Is((Account account) => account.Name == addCommand.Name)), Times.Once);
            Assert.AreNotEqual(Guid.Empty, accountDto.Guid);
            Assert.IsTrue(accountDto.Id > 0);
            Assert.AreEqual(accountDto.Name, addCommand.Name);
        }

        [TestMethod]
        public void UpdateCountryStateTest()
        {
            var repositoryMock = DataLayerMocks.GetAccountRepositoryMock();
            var mapper = ServiceLayerMocks.GetMapperMock();
            var service = new AccountService(repositoryMock.Object, mapper);

            var updateCommand = new UpdateCountryStateCommand
            {
                CountryId = 1,
                AccountGuid = Guid.NewGuid(),
                CountryStatus = CountryStatus.Been
            };
            service.UpdateCountryState(updateCommand);

            repositoryMock.Verify(ar => ar.UpdateCountryState(
                It.Is((Guid guid) => guid == updateCommand.AccountGuid),
                It.Is((int countryId) => countryId == updateCommand.CountryId),
                It.Is((CountryStatus status) => status == updateCommand.CountryStatus)), Times.Once);
        }
    }
}