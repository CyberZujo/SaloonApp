using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.Admin.ViewModels
{
    public class ClientTypeVM
    {

        [StringLength(100), Required]
        public string Name { get; set; }

        [StringLength(200), Required]
        public string Description { get; set; }

        [Required, Range(0, 100)]
        public double Discount { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public string ErrorMessage { get; set; }
    }
}
