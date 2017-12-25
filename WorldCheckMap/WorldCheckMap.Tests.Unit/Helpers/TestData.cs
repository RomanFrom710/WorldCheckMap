using System;
using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.DataAccess.Enums;
using WorldCheckMap.DataAccess.Models;
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
            return new List < Account >
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
                            AccountId = 1,
                            CountryId = 1,
                            Status = CountryStatus.None
                        },
                        new CountryState
                        {
                            AccountId = 1,
                            CountryId = 2,
                            Status = CountryStatus.Been
                        },
                        new CountryState
                        {
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
                            AccountId = 2,
                            CountryId = 1,
                            Status = CountryStatus.Been
                        },
                        new CountryState
                        {
                            AccountId = 2,
                            CountryId = 2,
                            Status = CountryStatus.Wish
                        },
                        new CountryState
                        {
                            AccountId = 2,
                            CountryId = 3,
                            Status = CountryStatus.None
                        }
                    }
                }
            };
        }
    }
}