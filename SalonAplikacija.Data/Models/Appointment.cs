using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalonAplikacija.Data.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        [ForeignKey(nameof(Saloon)), Range(1, int.MaxValue), Required]
        public int SaloonId { get; set; }

        [ForeignKey(nameof(Client)), Range(1, int.MaxValue), Required]
        public int ClientId { get; set; }

        [ForeignKey(nameof(AppointmentStatus)), Range(1, int.MaxValue), Required]
        public int AppointmentStatusId { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime EndTime { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        [Required]
        public bool IsDeleted { get; set; }


        public ApplicationUser ApplicationUser { get; set; }

        public Saloon Saloon { get; set; }

        public Client Client { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
