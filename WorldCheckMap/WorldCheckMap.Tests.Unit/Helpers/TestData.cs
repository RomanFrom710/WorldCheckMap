﻿using System;
using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.Services.Commands;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Tests.Unit.Helpers
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
                    Id = 1,
                    Name = "Roman",
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now.AddDays(-7),
                    CountryStates = new List<CountryState>
                    {
                        new CountryState
                        {
                            Id = 1,
                            AccountId = 1,
                            CountryId = 1,
                            Status = CountryStatus.None
                        },
                        new CountryState
                        {
                            Id = 2,
                            AccountId = 1,
                            CountryId = 2,
                            Status = CountryStatus.Been
                        },
                        new CountryState
                        {
                            Id = 3,
                            AccountId = 1,
                            CountryId = 3,
                            Status = CountryStatus.Lived
                        }
                    }
                },
                new Account
                {
                    Id = 2,
                    Name = "John",
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now,
                    CountryStates = new List<CountryState>
                    {
                        new CountryState
                        {
                            Id = 4,
                            AccountId = 2,
                            CountryId = 1,
                            Status = CountryStatus.Been
                        },
                        new CountryState
                        {
                            Id = 5,
                            AccountId = 2,
                            CountryId = 2,
                            Status = CountryStatus.Wish
                        },
                        new CountryState
                        {
                            Id = 6,
                            AccountId = 2,
                            CountryId = 3,
                            Status = CountryStatus.None
                        }
                    }
                }
            };
        }

        internal static List<AccountDto> GetAccountDtos()
        {
            return GetAccounts().Select(a => new AccountDto
            {
                Id = a.Id,
                Name = a.Name,
                Guid = a.Guid,
                Created = a.Created,
                CountryStates = a.CountryStates.Select(cs => new CountryStateDto
                {
                    Id = cs.Id,
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