using System;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Services.Interfaces
{
    public interface IAccountService
    {
        AccountDto GetAccount(Guid guid);
        AccountDto GetAccount(int id);

        int AddAccount(AddAccountCommand command);

        void UpdateCountryState(UpdateCountryStateCommand command);
    }
}