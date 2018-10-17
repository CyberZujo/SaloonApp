using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class SalonService
    {
        [Key]
        public int SalonServiceId { get; set; }

        [ForeignKey(nameof(Salon)), Range(1, int.MaxValue), Required]
        public int SalonId { get; set; }

        [ForeignKey(nameof(Service)), Range(1, int.MaxValue), Required]
        public int ServiceId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }


        public Salon Salon { get; set; }
        public Service Service { get; set; }
    }
}
