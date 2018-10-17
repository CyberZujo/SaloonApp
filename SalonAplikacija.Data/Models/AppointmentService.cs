using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class AppointmentService
    {
        [Key]
        public int AppointmentServiceId { get; set; }

        [ForeignKey(nameof(Appointment)),Range(1,int.MaxValue),Required]
        public int AppointmentId { get; set; }

        [ForeignKey(nameof(Service)), Range(1, int.MaxValue), Required]
        public int ServiceId { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public double Total { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public Appointment Appointment { get; set; }

        public Service Service { get; set; }

    }
}
