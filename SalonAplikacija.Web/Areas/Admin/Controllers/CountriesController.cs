using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;

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
            //test
            var countries = _context.Countries.Any() ? _context.Countries.ToList() : null;

            return View(countries);
        }

        [HttpGet]
        public IActionResult LoadDataTable()
        {
            var countries = _context.Countries.Any() ? _context.Countries.ToList() : null;

            return PartialView("_IndexPartial",countries);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();

            return PartialView("_Create",country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Country model)
        {

            if(!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Create", model);
            }

            try
            {
                Country country = new Country
                {
                    Name = model.Name,
                    IsDeleted = false
                };

                _context.Countries.Add(country);
                _context.SaveChanges();

                return PartialView("_Create", model);
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Country country = _context.Countries.Where(x => x.CountryId == id).FirstOrDefault();

            if (country == null)
                return BadRequest("Country could not be found");

            return PartialView("_Edit", country);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Country model)
        {

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Edit", model);
            }

            try
            {
                Country country = _context.Countries.Where(x => x.CountryId == model.CountryId).FirstOrDefault();

                country.Name = model.Name;

                _context.Countries.Update(country);
                _context.SaveChanges();

                return PartialView("_Edit", model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Country country = _context.Countries.Where(x => x.CountryId == id).FirstOrDefault();

            if (country == null)
                return BadRequest("Country could not be found");

            return PartialView("_Delete", country);
        }

        [HttpPost]
        public IActionResult Delete(Country country)
        {
            if (country == null)
                return NotFound("Resource not found");

            var c = _context.Countries.Where(x => x.CountryId == country.CountryId).FirstOrDefault();


            var cities = _context.Cities.Where(x => x.CountryId == c.CountryId).ToList();
            var clients = _context.Clients.Where(x => x.CountryId == c.CountryId).ToList();

            _context.Clients.RemoveRange(clients);
            _context.Cities.RemoveRange(cities);

            _context.Countries.Remove(c);
            _context.SaveChanges();

            return PartialView("_Delete", country);
        }

    }
}