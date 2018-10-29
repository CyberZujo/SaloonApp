using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client
{
    public class ClientDetailsVM
    {
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string ClientName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TypeOfClient { get; set; }
        public string MostUsedService { get; set; }
        public int NumberOfServicesUsed { get; set; }
        public int TotalAppointmentsCount { get; set; }
        public int CurrentMonthAppointmentsCount { get; set; }
        public double TotalMoneySpent { get; set; }
        public bool IsDeleted { get; set; }

        public ClientDetailsVM()
        {

        }
    }
}
