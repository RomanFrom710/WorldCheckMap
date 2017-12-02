using System.ComponentModel.DataAnnotations;

namespace WorldCheckMap.Data.Models
{
    public class Country : BaseModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Country otherCountry))
            {
                return false;
            }

            return otherCountry.Id == Id && otherCountry.Name == Name && otherCountry.Code == Code;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * Code.GetHashCode() * Name.GetHashCode();
        }
    }
}
