using System.Collections.Generic;

namespace WorldCheckMap.Services.Dto
{
    public class ClientInitDataDto
    {
        public IEnumerable<CountryDto> Countries { get; set; }

        public IDictionary<string, int> CountryStatusValues { get; set; }
    }
}