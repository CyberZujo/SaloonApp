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
using SalonAplikacija.Web.Helpers.AjaxMessages;
using SalonAplikacija.Web.Helpers.Utils;
namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class ClientsController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IAjaxFlashMessage _ajaxFlashMessage;

        public ClientsController(Context context, IMapper mapper,IAjaxFlashMessage ajaxFlashMessage)
        {
            _context = context;
            _mapper = mapper;
            _ajaxFlashMessage = ajaxFlashMessage;
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
        public IActionResult LoadData()
        {
            //We use this for re-displaying our table after some AJAX request

            var clients = _mapper.Map<List<ClientsGetVM>>(_context.Clients
                                                                .Include(x => x.Country)
                                                                .Include(x => x.City)
                                                                .Include(x => x.ClientType)
                                                                .ToList());

            if (clients == null)
                return NotFound();

            return PartialView("_Index",clients);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Client client = _context.Clients.Where(x => x.ClientId == id).FirstOrDefault();

            ClientDetailsVM model = _context.AppointmentsServices.Include(x => x.Appointment)
                                                               .Include(x => x.Appointment.Client)
                                                               .Include(x => x.Service)
                                                               .Include(x => x.Appointment.Client.ClientType)
                                                               .Include(x => x.Appointment.Client.Country)
                                                               .Include(x => x.Appointment.Client.City)
                                                               .Where(x => x.Appointment.Client.ClientId == id &&
                                                                           !x.IsDeleted)
                                                               .Select(x => new ClientDetailsVM
                                                               {
                                                                  ClientName=$"{x.Appointment.Client.FirstName} {x.Appointment.Client.LastName}",
                                                                  Address=x.Appointment.Client.Address,
                                                                  CityName=x.Appointment.Client.City.Name,
                                                                  CountryName=x.Appointment.Client.Country.Name,
                                                                  Email=x.Appointment.Client.Email,
                                                                  Phone=x.Appointment.Client.Phone,
                                                                  TypeOfClient=x.Appointment.Client.ClientType.Name
                                                               }).FirstOrDefault();

            //Counting and calculating 
            model.CurrentMonthAppointmentsCount = _context.Appointments.Where(x =>x.ClientId==id && 
                                                                                 x.StartTime.Year == DateTime.Now.Year &&
                                                                                 x.EndTime.Year == DateTime.Now.Year &&
                                                                                 x.StartTime.Month==DateTime.Now.Month &&
                                                                                 x.EndTime.Month==DateTime.Now.Month &&
                                                                                 !x.IsDeleted
                                                                             )
                                                                             .Count();

            model.TotalAppointmentsCount = _context.Appointments.Where(x => x.ClientId == id)
                                                                .Count();

            model.TotalMoneySpent = _context.AppointmentsServices.Include(x => x.Appointment)
                                                                 .Where(x => x.Appointment.ClientId == id &&
                                                                       !x.IsDeleted &&
                                                                       !x.Appointment.IsDeleted)
                                                                 .Sum(x => x.Total);


            model.NumberOfServicesUsed = _context.AppointmentsServices.Include(x => x.Appointment)
                                                                .Include(x => x.Service)
                                                                .Where(x => x.Appointment.ClientId == id)
                                                                .Select(x => x.ServiceId)
                                                                .Count();





            return View(model);
        }
        [HttpGet]
        public IActionResult LastAppointments(int id)
        {

            var appointments = _mapper.Map<List<AppointmentsGetVM>>(_context.AppointmentsServices.Include(x=>x.Appointment)
                                                                                                 .Include(x=>x.Service)
                                                                                                 .Include(x=>x.Appointment.AppointmentStatus)
                                                                                                 .Include(x=>x.Appointment.Client)
                                                                                                 .Where(x=>x.Appointment.ClientId==id)).ToList();

            if (appointments == null)
                return NotFound();

            return PartialView("_LastAppointments", appointments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ClientCreateVM model = new ClientCreateVM
            {
                Countries = new SelectList(GetCountries(),"CountryId","Name"),
                ClientTypes=new SelectList(GetClientTypes(),"ClientTypeId","Name")
            };
            return PartialView("_Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]ClientCreateVM model)
        {
            if(!ModelState.IsValid)
            {
                model.Countries = new SelectList(GetCountries(), "CountryId", "Name");
                model.ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name");

                return PartialView("_Create", model);
            }
            try
            {
                Client client = new Client();
                model.CopyObject(client);

                _context.Clients.Add(client);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            ClientUpdateVM model = _context.Clients.Include(x => x.Country)
                                                   .Include(x => x.City)
                                                   .Include(x => x.ClientType)
                                                   .Where(x => x.IsDeleted == false && x.ClientId == id)
                                                   .Select(x => new ClientUpdateVM
                                                   {
                                                         ClientId=x.ClientId,
                                                         CountryId=x.CountryId,
                                                         CityId=x.CityId,
                                                         ClientTypeId=x.ClientTypeId,
                                                         Address=x.Address,
                                                         FirstName=x.FirstName,
                                                         LastName=x.LastName,
                                                         Email=x.Email,
                                                         Phone=x.Phone,
                                                         IsDeleted=x.IsDeleted,
                                                         Countries=new SelectList(GetCountries(),"CountryId","Name",x.CountryId),
                                                         ClientTypes=new SelectList(GetClientTypes(),"ClientTypeId","Name",x.ClientTypeId),
                                                   }).FirstOrDefault();
            return PartialView("_Update", model);
        }
     
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm]ClientUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Countries = new SelectList(GetCountries(), "CountryId", "Name");
                model.ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name");

                var errors = new List<object>();
                foreach(var modelstate in ViewData.ModelState.Values)
                {
                    foreach(var error in modelstate.Errors)
                    {
                        errors.Add(error);
                    }
                }
                return PartialView("_Update", model);

            }


            Client client = new Client();

            client.CopyObject(model);
            try
            {
                _context.Clients.Update(client);

                _context.SaveChanges();
                _ajaxFlashMessage.Success("Client updated");

                model.Countries = new SelectList(GetCountries(), "CountryId", "Name");
                model.ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name");

                return PartialView("_Update", model);
            }
            catch (Exception ex)
            {
                _ajaxFlashMessage.Danger("Error while updating client");
                return View("~/Error");
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return PartialView("_Delete");
        }
        [HttpPost]
        public IActionResult Delete()
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [NonAction]
        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.Any() ? _context.Countries
                                                      .Where(x => x.IsDeleted == false)
                                                      .ToList() : null;
        }
        [NonAction]
        public IEnumerable<ClientType>GetClientTypes()
        {
            return _context.ClientType.Any() ? _context.ClientType
                                                       .Where(x => x.IsDeleted == false)
                                                       .ToList() : null;

        }
        [HttpGet]
        public JsonResult GetCity(int CityId)
        {
            var cityModel = new City();

            foreach (var city in _context.Cities.Where(x => x.CityId == CityId).ToList())
            {
                cityModel.CopyObject(city);

            }
            return Json(cityModel);
        }
        [HttpGet]
        public JsonResult GetCities(int CountryId)
        {
            var cities = new List<City>();

            foreach (var city in _context.Cities.Where(x => x.CountryId == CountryId).ToList())
            {
                cities.Add(new City {
                    CityId = city.CityId,
                    CountryId = city.CountryId,
                    Name = city.Name,
                    PostalCode = city.PostalCode,
                    IsDeleted = city.IsDeleted
                });
            }
            return Json(cities);
        }
    }
}