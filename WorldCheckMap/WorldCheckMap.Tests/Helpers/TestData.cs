using System.Collections.Generic;
using System.Linq;
using WorldCheckMap.Data.Models;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Tests.Helpers
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
    }
}