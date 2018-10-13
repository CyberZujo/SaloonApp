using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [StringLength(50),Required]
        public string Name { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
