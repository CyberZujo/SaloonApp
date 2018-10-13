using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [ForeignKey(nameof(Saloon)), Range(1, int.MaxValue)]
        public int SaloonId { get; set; }

        [StringLength(100),Required]
        public string Name { get; set; }

        [Required]
        public DateTime Duration { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Saloon Saloon { get; set; }
    }
}
