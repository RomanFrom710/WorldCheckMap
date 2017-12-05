using System;
using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.DataAccess.Models;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Tests.Unit.Helpers
{
    internal static class TestData
    {
        internal static List<Country> Countries = new List<Country>
        {
            new Country { Id = 1, Code = "BLR", Name = "Belarus" },
            new Country { Id = 2, Code = "CAF", Name = "Central African Republic" },
            new Country { Id = 3, Code = "ZWE", Name = "Zimbabwe" }
        };

        internal static List<CountryDto> CountryDtos = Countries.Select(c => new CountryDto
        {
            Id = c.Id,
            Code = c.Code,
            Name = c.Name
        }).ToList();


        internal static List<Account> Accounts = new List<Account>
        {
            new Account
            {
                Id = 1,
                Name = "Roman",
                Guid = Guid.NewGuid(),
                Created = DateTime.Now.AddDays(-7)
            },
            new Account
            {
                Id = 2,
                Name = "John",
                Guid = Guid.NewGuid(),
                Created = DateTime.Now
            }
        };
    }
}