using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Services
{
    public class ServicesCreateVM
    {
        public int ServiceId { get; set; }

        [StringLength(100), Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Duration is required")]
        public DateTime Duration { get; set; }

        [Required(ErrorMessage ="Price is required")]
        public double Price { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public ServicesCreateVM()
        {
            IsDeleted = false;
        }

        public static implicit operator Data.Models.Service(ServicesCreateVM model)
        {
            return new Data.Models.Service
            {
                ServiceId=model.ServiceId,
                Name=model.Name,
                Price=model.Price,
                Duration=model.Duration,
                IsDeleted=model.IsDeleted
            };
        }
    }
}
