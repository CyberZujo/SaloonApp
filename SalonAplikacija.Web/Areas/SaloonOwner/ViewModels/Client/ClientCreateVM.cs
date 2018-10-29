using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client
{
    public class ClientCreateVM
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int ClientTypeId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> ClientTypes { get; set; }

        public ClientCreateVM()
        {

        }

        public static implicit operator SalonAplikacija.Data.Models.Client(ClientCreateVM model)
        {
            return new SalonAplikacija.Data.Models.Client
            {
                ClientId = model.ClientId,
                CityId = model.CityId,
                CountryId = model.CountryId,
                ClientTypeId = model.ClientTypeId,
                Address = model.Address,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                IsDeleted = model.IsDeleted
            };
        }
    }
}
