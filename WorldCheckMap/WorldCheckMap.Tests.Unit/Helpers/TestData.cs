using System;
using System.Collections.Generic;
using System.Linq;
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
                new Country { Code = "BLR", Name = "Belarus" },
                new Country { Code = "CAF", Name = "Central African Republic" },
                new Country { Code = "ZWE", Name = "Zimbabwe" }
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
                    Name = "Roman",
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now.AddDays(-7)
                },
                new Account
                {
                    Name = "John",
                    Guid = Guid.NewGuid(),
                    Created = DateTime.Now
                }
            };
        }
    }
}