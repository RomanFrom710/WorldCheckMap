using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Tests.Common;
using WorldCheckMap.Tests.Integration.Helpers;

namespace WorldCheckMap.Tests.Integration
{
    [TestClass]
    public class AccountsTest
    {
        private HttpClient _client;
        private AccountDto _expectedAccountState;

        [TestMethod]
        public async Task AccountActionsTest()
        {
            _client = ClientBuilder.GetClient();

            await TestAddAccount();
            await TestGetAccountByGuid();
            await TestGetAccountById();

            await TestAddCountryState();
            await TestGetAccountByGuid();

            await TestUpdateCountryState();
            await TestGetAccountById();

            await TestNotFoundAccount();
        }

        private async Task TestAddAccount()
        {
            var addAccountCommand = TestData.GetAddAccountCommands().First();
            var addAccountContent = RequestBuilder.GetStringContentObject(JsonConvert.SerializeObject(addAccountCommand));
            var response = await _client.PostAsync("/api/accounts", addAccountContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var account = JObject.Parse(content).ToObject<AccountDto>();

            Assert.AreEqual(addAccountCommand.Name, account.Name);

            _expectedAccountState = account;
            _expectedAccountState.CountryStates = _expectedAccountState.CountryStates ?? new List<CountryStateDto>();
        }

        private async Task TestAddCountryState()
        {
            var addStateCommand = new UpdateCountryStateCommand
            {
                AccountGuid = _expectedAccountState.Guid,
                CountryId = TestData.GetCountries().First().Id,
                CountryStatus = CountryStatus.Been
            };

            var addStateContent = RequestBuilder.GetStringContentObject(JsonConvert.SerializeObject(addStateCommand));
            var response = await _client.PutAsync("/api/accounts", addStateContent);
            response.EnsureSuccessStatusCode();

            var countryState = new CountryStateDto
            {
                CountryId = addStateCommand.CountryId,
                Status = addStateCommand.CountryStatus
            };
            _expectedAccountState.CountryStates = _expectedAccountState.CountryStates.Concat(new []{ countryState });
        }

        private async Task TestUpdateCountryState()
        {
            var existentCountryState = _expectedAccountState.CountryStates.First();
            var newStatus = Enum.GetValues(typeof(CountryStatus)).Cast<CountryStatus>()
                .First(cs => cs != existentCountryState.Status);

            var updateStateCommand = new UpdateCountryStateCommand
            {
                AccountGuid = _expectedAccountState.Guid,
                CountryId = existentCountryState.CountryId,
                CountryStatus = newStatus
            };

            var updateStateContent = RequestBuilder.GetStringContentObject(JsonConvert.SerializeObject(updateStateCommand));
            var response = await _client.PutAsync("/api/accounts", updateStateContent);
            response.EnsureSuccessStatusCode();

            existentCountryState.Status = newStatus;
        }

        private async Task TestGetAccountById()
        {
            var response = await _client.GetAsync($"/api/accounts/{_expectedAccountState.Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var foundAccount = JObject.Parse(content).ToObject<AccountDto>();

            Assert.AreNotEqual(_expectedAccountState.Guid, foundAccount.Guid, "It shouldn't be possible to get account guid by its id");

            foundAccount.Guid = _expectedAccountState.Guid;
            Assert.IsTrue(_expectedAccountState.IsEqual(foundAccount));
        }

        private async Task TestGetAccountByGuid()
        {
            var response = await _client.GetAsync($"/api/accounts/{_expectedAccountState.Guid}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var foundAccount = JObject.Parse(content).ToObject<AccountDto>();

            Assert.IsTrue(_expectedAccountState.IsEqual(foundAccount));
        }

        private async Task TestNotFoundAccount()
        {
            var nonexistentGuid = Guid.NewGuid();
            var nonexistentId = _expectedAccountState.Id + 1;

            var idResponse = await _client.GetAsync($"/api/accounts/{nonexistentId}");
            Assert.AreEqual(HttpStatusCode.NotFound, idResponse.StatusCode);

            var guidResponse = await _client.GetAsync($"/api/accounts/{nonexistentGuid}");
            Assert.AreEqual(HttpStatusCode.NotFound, guidResponse.StatusCode);
        }
    }
}