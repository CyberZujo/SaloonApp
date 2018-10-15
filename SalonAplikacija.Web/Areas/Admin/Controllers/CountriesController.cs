using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalonAplikacija.Data;

namespace SalonAplikacija.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountriesController : Controller
    {
        private readonly Context _context;


        public CountriesController(Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var countries = _context.Countries.Any() ? _context.Countries.ToList() : null;

            if(countries==null)
            {
                TempData["errorMessage"] = "Not found";
                return NotFound();
            }

            return View(countries);
        }
    }
}