using WorldCheckMap.Data.Enums;

namespace WorldCheckMap.Data.Models
{
    public class CountryState : BaseModel
    {
        public virtual Country Country { get; set; }

        public CountryStatus Status { get; set; }

        public virtual Account Account { get; set; }
    }
}