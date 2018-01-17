using System;
using AutoMapper;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.DataAccess.Repositories.Interfaces;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Dto;
using WorldCheckMap.Services.Interfaces;

namespace WorldCheckMap.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AccountDto GetAccount(Guid guid)
        {
            var accountModel = _repository.GetAccount(guid);
            var accountDto = _mapper.Map<AccountDto>(accountModel);
            return accountDto;
        }

        public AccountDto GetAccount(int id)
        {
            var accountModel = _repository.GetAccount(id);
            var accountDto = _mapper.Map<AccountDto>(accountModel);
            accountDto.Guid = Guid.Empty;
            return accountDto;
        }

        public AccountDto AddAccount(AddAccountCommand command)
        {
            var account = new Account
            {
                Name = command.Name,
                Guid = Guid.NewGuid(),
                Created = DateTime.UtcNow
            };

            var id = _repository.AddAccount(account);
            return new AccountDto
            {
                Id = id,
                Guid = account.Guid,
                Created = account.Created
            };
        }

        public void UpdateCountryState(UpdateCountryStateCommand command)
        {
            _repository.UpdateCountryState(command.AccountGuid, command.CountryId, command.CountryStatus);
        }
    }
}