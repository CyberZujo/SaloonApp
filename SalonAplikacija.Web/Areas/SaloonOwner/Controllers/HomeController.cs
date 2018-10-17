using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalonAplikacija.Data;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Home;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    [Authorize(Roles ="SaloonOwner")]
    public class HomeController : Controller
    {
        private readonly Context _context;


        public HomeController(Context context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            HomeInfoVM model = new HomeInfoVM(_context);

            return View();
        }
    }
}