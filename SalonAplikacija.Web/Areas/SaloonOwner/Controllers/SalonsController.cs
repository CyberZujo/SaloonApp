using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Salons;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class SalonsController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SalonsController(Context context,UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<SelectListItem> GetAllCountrys()
        {
            return _context.Countries.Select(c => new SelectListItem
            {
                Value = c.CountryId.ToString(),
                Text = c.Name
            }).ToList();
        }
        public List<SelectListItem> GetAllCitiesByCountryId(int countryId)
        {
            return _context.Cities.Where(c => c.CountryId == countryId).Select(c => new SelectListItem
            {
                Value = c.CityId.ToString(),
                Text = c.Name
            }).ToList();
        }
       
        public async Task<IActionResult> Index()
        {
            var salons = _context.Salons.Include(s => s.Country).Include(s => s.City).Include(s => s.ApplicationUser).ToListAsync();
            if(salons==null)
            {
                return NotFound();
            }
            return View(await salons);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var saloon = _context.Salons.Include(c => c.Country).Include(c => c.City).Include(c => c.ApplicationUser).Where(c => c.SaloonId == id).FirstOrDefault();
            if(saloon==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(saloon);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SalonsVM salon = new SalonsVM()
            {
                Country = new SelectList(_context.Countries.ToList(), "CountryId", "Name"),
               
            };
            return View(salon);
        }

        public JsonResult GetCities(int CountryId)
        {
            var cities = new List<City>();

            foreach(var city in _context.Cities.Where(x=>x.CountryId==CountryId).ToList())
            {
                cities.Add(new City
                {
                    CityId = city.CityId,
                    CountryId = city.CountryId,
                    Name = city.Name,
                    PostalCode = city.PostalCode,
                    IsDeleted = city.IsDeleted
                });
            }

            return Json(cities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(SalonsVM model)
        {
            if(!ModelState.IsValid)
            {
                var error = ViewData.ModelState.Values.ToList();
                return View(model);
            }
            Salon salon = new Salon();
            if(model==null)
            {
                return RedirectToAction(nameof(Index));
            }
            var user =await _userManager.GetUserAsync(HttpContext.User);
            salon.Name = model.Name;
            salon.CountryId = model.CountryId;
            salon.CityId = model.CityId;
            salon.OpeningTime = model.OpeningTime;
            salon.ClosingTime = model.ClosingTime;
            salon.Email = model.Email;
            salon.Website = model.Website;
            salon.Address = model.Address;
            salon.Phone = model.Phone;
            salon.Mobile = model.Mobile;
            salon.ApplicationUserId = user.Id.ToString();

            _context.Salons.Add(salon);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int?id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var countries = new SelectList(_context.Countries.ToList(), "CountryId", "Name");
            var user = _userManager.GetUserAsync(HttpContext.User);
            var salon = _context.Salons.Where(s => s.SaloonId == id).Select(s => new SalonsVM
            {
                SaloonId = s.SaloonId,
                Name = s.Name,
                CountryId = s.CountryId,
                CityId = s.CityId,
                Address = s.Address,
                OpeningTime = s.OpeningTime,
                ClosingTime = s.ClosingTime,
                Phone = s.Phone,
                Mobile = s.Mobile,
                ApplicationUserId = user.Id.ToString(),
                Email = s.Email,
                Country=countries

            }).Single();
            
            return View(salon);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,SalonsVM model)
        {
            var user = _userManager.GetUserAsync(HttpContext.User);
            if (id==0)
            {
                return NotFound();
            }
            if(model==null)
            {
                if (model.SaloonId != 0)
                {
                    return RedirectToAction("Edit", new { Id = model.SaloonId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            Salon salon = new Salon();
            salon = _context.Salons.Where(s => s.SaloonId == id).FirstOrDefault();
            salon.Name = model.Name;
            salon.CountryId = model.CountryId;
            salon.CityId = model.CityId;
            salon.OpeningTime = model.OpeningTime;
            salon.ClosingTime = model.ClosingTime;
            salon.Address = model.Address;
            salon.Phone = model.Phone;
            salon.Mobile = model.Mobile;
            salon.Website = model.Website;
            salon.ApplicationUserId = user.Id.ToString();

            return View(salon);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var salon = _context.Salons.Where(s => s.SaloonId == id).FirstOrDefault();
            if(salon==null)
            {
                return RedirectToAction(nameof(Index));
            }
            _context.Salons.Remove(salon);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}