using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment
{
    public class AppointmentsGetVM
    {


        public int AppointmentId { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string AppointmentStatus { get; set; }

        public string Service { get; set; }

        public double ServicePrice { get; set; }

        public string ClientName { get; set; }


        public AppointmentsGetVM()
        {

        }
       
    }
}
