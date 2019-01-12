using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class AppointmentsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Context _context;

        public AppointmentsController(UserManager<ApplicationUser> userManager, Context context)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [NonAction]
        public string GetSalonName()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            return _context.Salons.Where(x => x.ApplicationUserId == userId).FirstOrDefault().Name;
        }

        [NonAction]
        public int GetUserSalonId()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            return _context.Salons.Where(x => x.ApplicationUserId == userId).FirstOrDefault().SaloonId;
        }


        [NonAction]
        public IEnumerable<Service> GetServices()
        {
            return _context.Services.Any() ? _context.Services
                                                      .Where(x => x.IsDeleted == false)
                                                      .ToList() : new List<Service>();
        }

        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            return _context.Clients.Any() ? _context.Clients
                                                      .Where(x => x.IsDeleted == false && x.UserId == userId)
                                                      .ToList() : new List<Client>();
        }


        [NonAction]
        public double SumTotal(int serviceId)
        {
            return _context.Services.Where(x => x.ServiceId == serviceId).Sum(x => x.Price);
        }
        [HttpGet]
        public IActionResult Create()
        {
            AppointmentCreateVM model = new AppointmentCreateVM
            {
                UserId = _userManager.GetUserId(HttpContext.User),
                SalonName = GetSalonName(),
                AppointmentStatusId = _context.AppointmentStatuses.Where(x=>x.Name=="InProcess").FirstOrDefault().AppointmentStatusId,
                
                Clients = new SelectList(GetClients(),"ClientId","FirstName"),
                Services = new SelectList(GetServices(),"ServiceId","Name"),
                IsDeleted = false
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentCreateVM model)
        {
            model.Clients = new SelectList(GetClients(), "ClientId", "FirstName");
            model.Services = new SelectList(GetServices(), "ServiceId", "Name");

            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }
            try
            {
                Appointment appointment = new Appointment
                {
                    ApplicationUserId = _userManager.GetUserId(HttpContext.User),
                    AppointmentStatusId = _context.AppointmentStatuses.Where(x => x.Name == "InProcess").FirstOrDefault().AppointmentStatusId,
                    ClientId = model.ClientId,
                    SaloonId = GetUserSalonId(),
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    Remark = model.Remark,
                    IsDeleted = false
                };

                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                if (appointment.AppointmentId != 0)
                {
                    AppointmentService appointmentService = new AppointmentService
                    {
                        AppointmentId = appointment.AppointmentId,
                        ServiceId = model.ServiceId,
                        Total = SumTotal(model.ServiceId),
                        IsDeleted = false
                    };

                    _context.AppointmentsServices.Add(appointmentService);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return RedirectToAction("Index");
        }

    }
}