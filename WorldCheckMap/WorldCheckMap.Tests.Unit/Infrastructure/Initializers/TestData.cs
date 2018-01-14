using System;
using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Tests.Unit.Infrastructure.Initializers
{
    internal static class TestData
    {
        internal static List<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country { Id = 1, Code = "BLR", Name = "Belarus" },
                new Country { Id = 2, Code = "CAF", Name = "Central African Republic" },
                new Country { Id = 3, Code = "ZWE", Name = "Zimbabwe" }
            };
        }

        internal static List<CountryDto> GetCountryDtos()
        {
            return GetCountries().Select(c => new CountryDto
            {
                Id = c.Id,
                Code = c.Code,
                Name = c.Name
            }).ToList();
        }


        internal static List<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account
                {
                    Name = "Roman",
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now.AddDays(-7),
                    CountryStates = new List<CountryState>
                    {
                        new CountryState
                        {
                            CountryId = 1,
                            Status = CountryStatus.None
                        },
                        new CountryState
                        {
                            CountryId = 2,
                            Status = CountryStatus.Been
                        },
                        new CountryState
                        {
                            CountryId = 3,
                            Status = CountryStatus.Lived
                        }
                    }
                },
                new Account
                {
                    Name = "John",
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                }
            };
        }

        internal static List<AccountDto> GetAccountDtos()
        {
            return GetAccounts().Select(a => new AccountDto
            {
                Name = a.Name,
                Guid = a.Guid,
                Created = a.Created,
                CountryStates = a.CountryStates.Select(cs => new CountryStateDto
                {
                    CountryId = cs.CountryId,
                    Status = cs.Status
                }).ToList()
            }).ToList();
        }

        internal static List<AddAccountCommand> GetAddAccountCommands()
        {
            return GetAccounts()
                .Select(a => new AddAccountCommand { Name = a.Name })
                .ToList();
        }

        internal static List<UpdateCountryStateCommand> GetUpdateCountryStateCommands(Account account)
        {
            return account.CountryStates.Select(cs => new UpdateCountryStateCommand
                {
                    AccountGuid = account.Guid,
                    CountryId = cs.CountryId,
                    CountryStatus = cs.Status
                })
                .ToList();
        }
    }
}