using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Account;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager,
                                 UserManager<ApplicationUser>userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            AccountGetVM model = new AccountGetVM
            {
                UserId=user.Id,
                Email=user.Email,
                PhotoURL=user.PhotoURL,
                Username=user.UserName
            };

            return View(model);
        }



    }
}