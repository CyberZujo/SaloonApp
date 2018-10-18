using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Home
{
    public class HomeInfoVM
    {
        public int ClientsCount { get; set; }
        public int ServicesCount { get; set; }
        public int AppointmentsCount { get; set; }
        public int SpecialClientsCount { get; set; }
        public double CurrentMonthIncome { get; set; }
        public double CurrentYearIncome { get; set; }
        
        public HomeInfoVM()
        {

        }
    }
}
