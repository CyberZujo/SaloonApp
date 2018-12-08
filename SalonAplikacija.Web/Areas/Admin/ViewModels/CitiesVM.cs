using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.Admin.ViewModels
{
    public class CitiesVM
    {

        [Key]
        public int CityId { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string PostalCode { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public List<SelectListItem> Country { get; set; }
    }
}
