using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class AppointmentStatus
    {
        [Key]
        public int AppointmentStatusId { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(100), Required]
        public string Description { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
