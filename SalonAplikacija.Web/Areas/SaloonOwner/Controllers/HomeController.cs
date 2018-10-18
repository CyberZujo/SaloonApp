using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Home;
using SalonAplikacija.Web.Helpers.AjaxMessages;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    [Authorize(Roles ="SalonOwner")]
    public class HomeController : Controller
    {
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                HomeInfoVM model = new HomeInfoVM
                {
                    #region Counters
                    ClientsCount = _context.Clients.Any() ? _context.Clients.Where(x => x.IsDeleted == false).Count() : 0,
                    ServicesCount = _context.Services.Any() ? _context.Services.Where(x => x.IsDeleted == false).Count() : 0,
                    AppointmentsCount = _context.Appointments.Any() ? _context.Appointments.Where(x => x.IsDeleted == false).Count() : 0,
                    SpecialClientsCount = _context.ClientType.Any() ? _context.ClientType.Where(x => x.IsDeleted == false).Count() : 0,
                    #endregion
                    #region Data sum
                    CurrentMonthIncome = _context.AppointmentsServices.Any() ? _context.AppointmentsServices.Where(x => x.IsDeleted == false)
                                             .Include(y => y.Appointment)
                                             .Where(x => x.Appointment.StartTime.Year == DateTime.Now.Year &&
                                                         x.Appointment.EndTime.Year == DateTime.Now.Year &&
                                                         x.Appointment.StartTime.Month == DateTime.Now.Month &&
                                                         x.Appointment.EndTime.Month == DateTime.Now.Month
                                                    )
                                             .Sum(x => x.Total) : 0,
                    CurrentYearIncome = _context.AppointmentsServices.Any() ? _context.AppointmentsServices.Where(x => x.IsDeleted == false)
                                                  .Include(y => y.Appointment)
                                                  .Where(x => x.Appointment.StartTime.Year == DateTime.Now.Year && x.Appointment.EndTime.Year == DateTime.Now.Year)
                                                  .Sum(x => x.Total) : 0
                    #endregion
                };
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IActionResult GetLastAppointments()
        {
            try
            {
                AppointmentsGetVM model = new AppointmentsGetVM
                {
                    appointments = _context.AppointmentsServices.Any() ? _context.Appointments.Any() ?
                                                              _context.AppointmentsServices
                                                                      .Include(x => x.Service)
                                                                      .Include(x => x.Appointment)
                                                                      .Include(x => x.Appointment.AppointmentStatus)
                                                                      .Include(x=>x.Appointment.Client)
                                                                      .Where(x => x.IsDeleted == false)
                                                                      .OrderByDescending(x => x.AppointmentId)
                                                                      .Take(5)
                                                                      .Select(x => new AppointmentsGetVM.AppointmentInfo
                                                                      {
                                                                          AppointmentId = x.AppointmentId,
                                                                          AppointmentStatus = x.Appointment.AppointmentStatus.Name,
                                                                          Service = x.Service.Name,
                                                                          ServicePrice = x.Service.Price,
                                                                          StartDate = x.Appointment.StartTime.TimeOfDay.ToString(),
                                                                          EndDate = x.Appointment.EndTime.TimeOfDay.ToString(),
                                                                          ClientName=$"{x.Appointment.Client.FirstName} {x.Appointment.Client.LastName}"

                                                                      }).ToList() : null : null
                };
                return PartialView("_GetLastAppointments",model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}