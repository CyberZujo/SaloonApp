using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class ClientType
    {
        [Key]
        public int ClientTypeId { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        [StringLength(200), Required]
        public string Description { get; set; }

        [Required, Range(0, 100)]
        public double Discount { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
