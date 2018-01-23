using System.Collections.Generic;

namespace WorldCheckMap.Services.Dto
{
    public class CountriesInitialDataDto
    {
        public IEnumerable<CountryDto> Countries { get; set; }

        public IDictionary<string, CountryStatusEnumMemberDto> CountryStatuses { get; set; }
    }
}