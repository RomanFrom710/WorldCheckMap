using System;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;

namespace WorldCheckMap.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccount(Guid guid);
        Account GetAccount(int id);

        int AddAccount(Account account);

        void UpdateCountryState(Guid accountGuid, int countryId, CountryStatus countryStatus);
    }
}