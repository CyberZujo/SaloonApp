using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SalonAplikacija.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client
{
    public class ClientUpdateVM
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int ClientTypeId { get; set; }

        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage="Phone is required")]
        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public int FromProfileUpdate { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> ClientTypes { get; set; }

        public ClientUpdateVM()
        {
            FromProfileUpdate = 0;
        }

        public static implicit operator SalonAplikacija.Data.Models.Client(ClientUpdateVM model)
        {
            return new SalonAplikacija.Data.Models.Client
            {
                ClientId=model.ClientId,
                CityId=model.CityId,
                CountryId=model.CountryId,
                ClientTypeId=model.ClientTypeId,
                Address=model.Address,
                Email=model.Email,
                FirstName=model.FirstName,
                LastName=model.LastName,
                Phone=model.Phone,
                IsDeleted=model.IsDeleted
            };
        }
    }
}
