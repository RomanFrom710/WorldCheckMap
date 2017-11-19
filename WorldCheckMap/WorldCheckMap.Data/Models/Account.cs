using System;
using System.Collections.Generic;

namespace WorldCheckMap.Data.Models
{
    public class Account : BaseModel
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public virtual List<CountryState> States { get; set; }
    }
}