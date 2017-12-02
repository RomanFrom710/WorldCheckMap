namespace WorldCheckMap.Data.Models
{
    public class Country : BaseModel
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Country otherCountry))
            {
                return false;
            }

            return otherCountry.Name == Name && otherCountry.Code == Code;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode() * Name.GetHashCode();
        }
    }
}
