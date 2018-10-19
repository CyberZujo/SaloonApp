using SalonAplikacija.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.CountryCityFilter
{
    public class CountryCityGet
    {
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}
