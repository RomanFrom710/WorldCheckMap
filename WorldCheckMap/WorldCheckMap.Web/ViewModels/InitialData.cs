using System.Collections.Generic;
using WorldCheckMap.Services.Dto;

namespace WorldCheckMap.Web.ViewModels
{
    public class InitialData
    {
        public IEnumerable<CountryDto> Countries { get; set; }
    }
}