using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Salons
{
    public class SalonsVM
    {
        [Key]
        public int SaloonId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public Data.Models.ApplicationUser AspNetUser { get; set; }

        public int CityId { get; set; }
        public List<SelectListItem> City { get; set; }

        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(150), Required]
        public string Address { get; set; }

        [StringLength(150), DataType(DataType.PhoneNumber), Phone, Required]
        public string Phone { get; set; }

        [StringLength(150), DataType(DataType.PhoneNumber), Phone, Required]
        public string Mobile { get; set; }

        [StringLength(150), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50), Required]
        public string OpeningTime { get; set; }

        [StringLength(50), Required]
        public string ClosingTime { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

      
      
    }
}
