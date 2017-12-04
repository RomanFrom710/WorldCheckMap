using System.ComponentModel.DataAnnotations;

namespace WorldCheckMap.DataAccess.Models
{
    public class Country : BaseModel
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
