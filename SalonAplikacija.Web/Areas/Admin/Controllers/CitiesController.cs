using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.Admin.ViewModels;

namespace SalonAplikacija.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CitiesController : Controller
    {
        private readonly Context _context;
        public CitiesController(Context context)
        {
            _context = context;
        }
        public List<SelectListItem>GetAllCountries()
        {
            return _context.Countries.Select(c => new SelectListItem
            {
                Value = c.CountryId.ToString(),
                Text = c.Name

            }).ToList();
        }
        public IActionResult Index()
        {
            var city = _context.Cities.Any() ? _context.Cities.Include(c=>c.Country).ToList() : null;
            return View(city);
        }
        [HttpGet]
        public IActionResult LoadDataTable()
        {
            var city = _context.Cities.Any() ? _context.Cities.Include(c => c.Country).ToList() : null;
            return PartialView("_IndexPartial",city);
        }

        [HttpGet]
         public IActionResult Create()
           {
            CitiesVM model = new CitiesVM()
            {
                Country = GetAllCountries()
            };
            return PartialView("_Create", model);
           }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CitiesVM model)
        {
            model.Country = GetAllCountries();


            if(!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Create", model);
            }
            try
            {
                City city = new City();
                if (city == null)
                {
                    return BadRequest();
                }
                city.Name = model.Name;
                city.CountryId = model.CountryId;
                city.PostalCode = model.PostalCode;

                _context.Cities.Add(city);
                _context.SaveChanges();
                return PartialView("_Create", model);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Edit(int?id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var city = _context.Cities.Where(c => c.CityId == id).Select(c => new CitiesVM
            {
                CityId=c.CityId
                ,
                Name = c.Name,
                CountryId = c.CountryId,
                Country = GetAllCountries(),
                PostalCode = c.PostalCode
            }).Single();

            if(city==null)
            {
                return BadRequest();
            }
            return PartialView("_Edit", city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CitiesVM model)
        {
            model.Country = GetAllCountries();
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Edit", model);
            }

            try
            {
                City city = _context.Cities.Where(x => x.CityId == model.CityId).FirstOrDefault();

                city.Name = model.Name;
                city.CountryId = model.CountryId;
                city.PostalCode = model.PostalCode;
                _context.Cities.Update(city);
                _context.SaveChanges();

                return PartialView("_Edit", model);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult Delete (int? id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var city = _context.Cities.Where(c => c.CityId == id).Select(x => new CitiesVM
            {
                CityId = x.CityId,
                CountryId=x.CountryId,
                Name=x.Name,
                PostalCode=x.PostalCode,
                IsDeleted=false
            }).FirstOrDefault();

            if(city==null)
            {
                return BadRequest("City could not be found");
            }

            return PartialView("_Delete",city);
        }

        [HttpPost]
        public IActionResult Delete(CitiesVM model)
        {
            model.Country = GetAllCountries();
            if (model == null)
                return NotFound("Resource not found");

            var c = _context.Cities.Where(x => x.CityId == model.CityId).FirstOrDefault();

            _context.Cities.Remove(c);
            _context.SaveChanges();

            return PartialView("_Delete", model);
        }
    }
}