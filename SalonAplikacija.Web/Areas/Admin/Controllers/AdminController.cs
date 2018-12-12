using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;

namespace SalonAplikacija.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListOfSaloons()
        {
            var saloons = _context.Salons.Include(s => s.Country).Include(s => s.City).Any() ? _context.Salons.Include(s => s.Country).Include(s => s.City).ToList() : null;
            return View(saloons);
        }
    }
}