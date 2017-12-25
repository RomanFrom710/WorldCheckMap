using WorldCheckMap.DataAccess.Enums;

namespace WorldCheckMap.Services.Dto
{
    public class CountryStateDto : BaseDto
    {
        public int CountryId { get; set; }

        public CountryStatus Status { get; set; }
    }
}