using System.Collections.Generic;

namespace WorldCheckMap.Services.Dto
{
    public class CoreDataDto
    {
        public IEnumerable<CountryDto> Countries { get; set; }

        public IEnumerable<string> CountryStatuses { get; set; }
    }
}