using System;
using System.Collections.Generic;

namespace WorldCheckMap.Services.Dto
{
    public class AccountDto : BaseDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public IEnumerable<CountryStateDto> CountryStates { get; set; }
    }
}