using System;
using WorldCheckMap.DataAccess.Enums;

namespace WorldCheckMap.Services.Commands
{
    public class UpdateCountryStateCommand
    {
        public Guid AccountGuid { get; set; }

        public int CountryId { get; set; }

        public CountryStatus CountryStatus { get; set; }
    }
}