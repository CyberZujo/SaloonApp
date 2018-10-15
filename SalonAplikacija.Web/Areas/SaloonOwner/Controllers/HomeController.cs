using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    [Authorize(Roles ="SaloonOwner")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}