using Microsoft.AspNetCore.Mvc.Rendering;
using SalonAplikacija.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment
{
    public class AppointmentCreateVM
    {
        public string UserId { get; set; }

        public int SaloonId { get; set; }

        public int ClientId { get; set; }

        public int AppointmentStatusId { get; set; }

        public int ServiceId { get; set; }

        public int AppointmentId { get; set; }

        public string SalonName { get; set; }

        public string ServiceName { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime EndTime { get; set; }

        [StringLength(200)]
        public string Remark { get; set; }

        public double Total { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
    }
}
