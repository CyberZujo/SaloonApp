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
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Services;
using SalonAplikacija.Web.Helpers.AjaxMessages;
using SalonAplikacija.Web.Helpers.Utils;
using Vereyon.Web;
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

        [HttpGet]
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
        public IActionResult LoadDataTable()
        {
            var clients = _mapper.Map<List<ClientsGetVM>>(_context.Clients
                                                                  .Include(x => x.Country)
                                                                  .Include(x => x.City)
                                                                  .Include(x => x.ClientType)
                                                                  .ToList());

            if (clients == null)
                return NotFound();

            return PartialView("_LoadDataTable", clients);
        }

       
        [HttpGet]
        public IActionResult Details(int? id)
        {
            try
            {
                Client client = _context.Clients.Include(x=>x.Country)
                                                .Include(x=>x.City)
                                                .Include(x=>x.ClientType)
                                                .Where(x => x.ClientId == id).FirstOrDefault();

                ClientDetailsVM model = new ClientDetailsVM();

                if(_context.Appointments.Where(x=>x.ClientId==id).Any())
                {
                    model = _context.AppointmentsServices.Include(x => x.Appointment)
                                                                 .Include(x => x.Appointment.Client)
                                                                 .Include(x => x.Service)
                                                                 .Include(x => x.Appointment.Client.ClientType)
                                                                 .Include(x => x.Appointment.Client.Country)
                                                                 .Include(x => x.Appointment.Client.City)
                                                                 .Where(x => x.Appointment.ClientId == id &&
                                                                             !x.IsDeleted)
                                                                 .Select(x => new ClientDetailsVM
                                                                 {
                                                                     ClientId = x.Appointment.ClientId,
                                                                     ClientTypeId=x.Appointment.Client.ClientTypeId,
                                                                     ClientName = $"{x.Appointment.Client.FirstName} {x.Appointment.Client.LastName}",
                                                                     Address = x.Appointment.Client.Address,
                                                                     CityName = x.Appointment.Client.City.Name,
                                                                     CountryName = x.Appointment.Client.Country.Name,
                                                                     Email = x.Appointment.Client.Email,
                                                                     Phone = x.Appointment.Client.Phone,
                                                                     TypeOfClient = x.Appointment.Client.ClientType.Name
                                                                 }).FirstOrDefault();

                    model.CurrentMonthAppointmentsCount = _context.Appointments.Where(x => x.ClientId == (int)id &&
                                                                                x.StartTime.Year == DateTime.Now.Year &&
                                                                                x.EndTime.Year == DateTime.Now.Year &&
                                                                                x.StartTime.Month == DateTime.Now.Month &&
                                                                                x.EndTime.Month == DateTime.Now.Month &&
                                                                                !x.IsDeleted
                                                                            )
                                                                            .Count();

                    model.TotalAppointmentsCount = _context.Appointments.Where(x => x.ClientId == (int)id)
                                                                        .Count();

                    model.TotalMoneySpent = _context.AppointmentsServices.Include(x => x.Appointment)
                                                                         .Where(x => x.Appointment.ClientId == (int)id &&
                                                                               !x.IsDeleted &&
                                                                               !x.Appointment.IsDeleted)
                                                                         .Sum(x => x.Total);


                    model.NumberOfServicesUsed = _context.AppointmentsServices.Include(x => x.Appointment)
                                                                        .Include(x => x.Service)
                                                                        .Where(x => x.Appointment.ClientId == (int)id)
                                                                        .Select(x => x.ServiceId)
                                                                        .Count();

                   


                    model.MostUsedService = _context.AppointmentsServices.Include(x => x.Service)
                                                                       .GroupBy(x => x.ServiceId)
                                                                       .OrderByDescending(x => x.Count())
                                                                       .Select(s => new
                                                                       {
                                                                           ServiceId = s.Key,
                                                                           Name = s.FirstOrDefault().Service.Name,
                                                                           Count = s.Count()
                                                                       }).Take(1).FirstOrDefault().Name;

                }
                else
                {
                    model.ClientId = client.ClientId;
                    model.ClientTypeId = client.ClientTypeId;
                    model.ClientName = $"{client.FirstName} {client.LastName}";
                    model.Address = client.Address;
                    model.CityName = client.City.Name;
                    model.CountryName = client.Country.Name;
                    model.Phone = client.Phone;
                    model.Email = client.Email;
                    model.TypeOfClient = client.ClientType.Name;
                }

                return View(model);
           
            }
            catch (Exception ex)
            {
                return PartialView("Error");
            }
          
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
                Countries = new SelectList(GetCountries(), "CountryId", "Name"),
                ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name") 
            };
            return PartialView("_Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientCreateVM model)
        {
            model.Countries = new SelectList(GetCountries(), "CountryId", "Name");
            model.ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name");

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Create", model);
            }
            try
            {
                Client client = new Client();
                client.CopyObject(model);

                _context.Clients.Add(client);
                _context.SaveChanges();

                _ajaxFlashMessage.Success("Client created");
                return PartialView("_Create", model);
            }
            catch (Exception ex)
            {
                return PartialView("Error");
            }
        }

        [HttpGet]
        public IActionResult Update(string id,string fromProfileUpdate)
        {

            int clientId = Convert.ToInt32(id);

            ClientUpdateVM model = _context.Clients.Include(x => x.Country)
                                                 .Include(x => x.City)
                                                 .Include(x => x.ClientType)
                                                 .Where(x => x.IsDeleted == false && x.ClientId == clientId)
                                                 .Select(x => new ClientUpdateVM
                                                 {
                                                     ClientId = x.ClientId,
                                                     CountryId = x.CountryId,
                                                     CityId = x.CityId,
                                                     ClientTypeId = x.ClientTypeId,
                                                     Address = x.Address,
                                                     FirstName = x.FirstName,
                                                     LastName = x.LastName,
                                                     Email = x.Email,
                                                     Phone = x.Phone,
                                                     IsDeleted = x.IsDeleted,
                                                     Countries = new SelectList(GetCountries(), "CountryId", "Name", x.CountryId),
                                                     ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name", x.ClientTypeId)
                                                 }).FirstOrDefault();

            if (Convert.ToInt32(fromProfileUpdate)==1)
            {
                model.FromProfileUpdate = Convert.ToInt32(fromProfileUpdate);

                return PartialView("_UpdateFromProfile", model);
            }
          
            return PartialView("_Update", model);
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ClientUpdateVM model)
        {
            model.Countries = new SelectList(GetCountries(), "CountryId", "Name");
            model.ClientTypes = new SelectList(GetClientTypes(), "ClientTypeId", "Name");
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;

                if(model.FromProfileUpdate==1)
                {
                    return PartialView("_UpdateFromProfile", model);
                }
                return PartialView("_Update", model);
            }

            try
            {
                Client client = new Client();

                client.CopyObject(model);

                _context.Clients.Update(client);

                _context.SaveChanges();
                _ajaxFlashMessage.Success("Client updated");

                
                if(model.FromProfileUpdate==1)
                {
                    //return RedirectToAction("Details", new { id = model.ClientId });
                    return PartialView("_UpdateFromProfile", model);

                }

                return PartialView("_Update", model);
            }
            catch (Exception ex)
            {
                _ajaxFlashMessage.Danger("Error while updating client");
                return PartialView("Error");
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _mapper.Map<ClientDeleteVM>(_context.Clients.Include(x => x.Country)
                                                                    .Include(x => x.City)
                                                                    .Include(x => x.ClientType)
                                                                    .FirstOrDefault());
            if (model == null)
                return Index();

            return PartialView("_Delete", model);
        }
        [HttpPost]
        public IActionResult Delete(ClientDeleteVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = 400;
                    return PartialView("_Delete", model);

                }

                var client = _context.Clients.Where(x => x.ClientId == model.ClientId).FirstOrDefault();

                if (client == null)
                    return RedirectToAction("Index");

                var appointmentsServices = _context.AppointmentsServices.Include(x => x.Appointment)
                                                                     .Where(x => x.Appointment.ClientId == client.ClientId)
                                                                     .ToArray();

                var appointments = _context.Appointments.Where(x => x.ClientId == client.ClientId).ToArray();


                _context.AppointmentsServices.RemoveRange(appointmentsServices);
                _context.Appointments.RemoveRange(appointments);
                _context.Remove(client);
                _context.SaveChanges();

                return PartialView("_Delete", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }



        [HttpPost]
        public IActionResult ChangeType(ClientTypeJsonVM data)
        {
            try
            {
                var client = _context.Clients.Where(x => x.ClientId == data.value).FirstOrDefault();

                if (client == null)
                    return new StatusCodeResult(404);

                client.ClientTypeId = Convert.ToInt32(data.text);

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception x)
            {

                throw;
            }
        }

        [HttpGet]
        public JsonResult GetClientTypesJson()
        {
            List<ClientTypeJsonVM> clientTypes = new List<ClientTypeJsonVM>();

            foreach(var type in _context.ClientType.Where(x=>x.IsDeleted==false).ToList())
            {
                clientTypes.Add(new ClientTypeJsonVM {

                    value=type.ClientTypeId,
                    text=type.Name
                });
            }

            clientTypes.Insert(0, new ClientTypeJsonVM { value = 0, text = "Select a type" });
            clientTypes.OrderByDescending(x => x.value);
            return Json(clientTypes);
        }


        [NonAction]
        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.Any() ? _context.Countries
                                                      .Where(x => x.IsDeleted == false)
                                                      .ToList() : new List<Country>();
        }
        [NonAction]
        public IEnumerable<ClientType>GetClientTypes()
        {
            return _context.ClientType.Any() ? _context.ClientType
                                                       .Where(x => x.IsDeleted == false)
                                                       .ToList() : new List<ClientType>();

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