using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Home
{
    public class HomeInfoVM
    {
        private readonly Context _context;

        public int ClientsCount { get; set; }
        public int ServicesCount { get; set; }
        public int AppointmentsCount { get; set; }
        public int SpecialClientsCount { get; set; }
        public double CurrentMonthIncome { get; set; }
        public double CurrentYearIncome { get; set; }

        public HomeInfoVM(Context context)
        {
            _context = context;

            LoadIncomeData();
        }

        public void LoadCounters()
        {
            ClientsCount = _context.Clients.Any() ? _context.Clients.Where(x=>x.IsDeleted==false).Count() : 0;
            ServicesCount = _context.Services.Any() ? _context.Services.Where(x=>x.IsDeleted==false).Count() : 0;
            AppointmentsCount = _context.Appointments.Any() ? _context.Appointments.Where(x => x.IsDeleted == false).Count() : 0;
            SpecialClientsCount = _context.ClientType.Any() ? _context.ClientType.Where(x => x.IsDeleted == false).Count() : 0;
        }

        public void LoadIncomeData()
        {
            var currentMonthAppointments = _context.AppointmentsServices.Any() ? _context.AppointmentsServices.Where(x => x.IsDeleted == false)
                                                 .Include(y => y.Appointment)
                                                 .Where(x => x.Appointment.StartTime.Month == DateTime.Now.Month && x.Appointment.EndTime.Month == DateTime.Now.Month)
                                                 .Sum(x => x.Total) : 0;

        }
    }
}
