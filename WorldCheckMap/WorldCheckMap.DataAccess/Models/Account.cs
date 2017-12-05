using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldCheckMap.DataAccess.Models
{
    public class Account : BaseModel
    {
        [Required]
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<CountryState> States { get; set; }
    }
}