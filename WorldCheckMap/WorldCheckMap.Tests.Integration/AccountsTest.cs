using System.Collections.Generic;
using System.Linq;
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
        }

        private async Task TestAddAccount()
        {

            var addAccountCommand = TestData.GetAddAccountCommands().First();
            var addAccountContent = new StringContent(JsonConvert.SerializeObject(addAccountCommand));
            var response = await _client.PostAsync("/api/accounts", addAccountContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var account = JObject.Parse(content).ToObject<AccountDto>();

            Assert.AreEqual(addAccountCommand.Name, account.Name);

            _expectedAccountState = account;
            _expectedAccountState.CountryStates = _expectedAccountState.CountryStates ?? new List<CountryStateDto>();
        }

        private async Task<AccountDto> TestAddCountryState()
        {
            var addStateCommand = new UpdateCountryStateCommand
            {
                AccountGuid = _expectedAccountState.Guid,
                CountryId = TestData.GetCountries().First().Id,
                CountryStatus = CountryStatus.Been
            };

            var addStateContent = new StringContent(JsonConvert.SerializeObject(addStateCommand));
            var response = await _client.PutAsync("/api/accounts", addStateContent);
            response.EnsureSuccessStatusCode();

            _expectedAccountState.CountryStates = _expectedAccountState.CountryStates.

        }

        private async Task<AccountDto> TestUpdateCountryState()
        {

            var addAccountCommand = TestData.GetAddAccountCommands().First();
            var addAccountContent = new StringContent(JsonConvert.SerializeObject(addAccountCommand));
            var response = await _client.PostAsync("/api/accounts", addAccountContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var account = JObject.Parse(content).ToObject<AccountDto>();

            Assert.AreEqual(addAccountCommand.Name, account.Name);

            return account;
        }

        private async Task<AccountDto> TestGetAccountById()
        {
            var response = await _client.GetAsync($"/api/accounts/{accountInfo.Id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            Assert.AreEqual(addAccountCommand.Name, account.Name);

            return account;
        }

        private async Task<AccountDto> TestGetAccountByGuid()
        {

            var addAccountCommand = TestData.GetAddAccountCommands().First();
            var addAccountContent = new StringContent(JsonConvert.SerializeObject(addAccountCommand));
            var response = await _client.PostAsync("/api/accounts", addAccountContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var account = JObject.Parse(content).ToObject<AccountDto>();

            Assert.AreEqual(addAccountCommand.Name, account.Name);

            return account;
        }
    }
}