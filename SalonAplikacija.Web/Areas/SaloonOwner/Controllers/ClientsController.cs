using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.CountryCityFilter;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class ClientsController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;


        public ClientsController(Context context, IMapper mapper,UserManager<ApplicationUser>userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var clients = _mapper.Map<List<ClientsGetVM>>(_context.Clients
                                                                  .Include(x => x.Country)
                                                                  .Include(x => x.City)
                                                                  .Include(x => x.ClientType)
                                                                  .ToList());

            if (clients == null)
                return NotFound();

            return View(clients);
        }

        [HttpGet]
        public IActionResult LastAppointments(int id)
        {

            var appointments = _mapper.Map<List<AppointmentsGetVM>>(_context.AppointmentsServices.Include(x=>x.Appointment)
                                                                                         .Include(x=>x.Service)
                                                                                         .Include(x=>x.Appointment.AppointmentStatus)
                                                                                         .Include(x=>x.Appointment.Client)).ToList();

            if (appointments == null)
                return NotFound();

            return PartialView("_LastAppointments", appointments);
        }
        #region COUNTRY-CITY DROPDOWN
        public IActionResult TestCountryCity()
        {
            List<Country> Countries = _context.Countries.ToList();

            ViewBag.Countries = new SelectList(Countries, "CountryId","Name");

            return View();
        }

      
        public JsonResult GetCities(int CountryId)
        {
            var cities = new List<City>();
            
            foreach(var city in _context.Cities.Where(x=>x.CountryId==CountryId).ToList())
            {
                cities = new List<City>
                {
                    new City{ CityId=city.CityId,CountryId=city.CountryId,Name=city.Name,PostalCode=city.PostalCode,IsDeleted=city.IsDeleted}
                };
            }
            return Json(cities);
        }
        #endregion
    }
}