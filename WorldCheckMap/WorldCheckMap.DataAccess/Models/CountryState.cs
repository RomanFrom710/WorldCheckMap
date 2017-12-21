﻿using System.ComponentModel.DataAnnotations;
using WorldCheckMap.DataAccess.Enums;

namespace WorldCheckMap.DataAccess.Models
{
    public class CountryState : BaseModel
    {
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        public CountryStatus Status { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}