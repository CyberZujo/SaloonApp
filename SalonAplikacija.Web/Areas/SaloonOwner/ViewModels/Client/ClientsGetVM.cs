using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels
{
    public class ClientsGetVM
    {
        public int ClientId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int ClientTypeId { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public string TypeOfClient { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsDeleted { get; set; }

    }
}
