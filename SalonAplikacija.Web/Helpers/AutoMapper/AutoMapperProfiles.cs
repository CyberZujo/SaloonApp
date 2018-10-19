using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment;
using SalonAplikacija.Data;

namespace SalonAplikacija.Web.Helpers.AutoMapper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Client, ClientsGetVM>().ForMember(dest => dest.CityName, option =>
            {
                option.MapFrom(src => src.City.Name);
            }).ForMember(dest => dest.CountryName, option =>
            {
                option.MapFrom(src => src.Country.Name);
            }).ForMember(dest => dest.TypeOfClient, option =>
            {
                option.MapFrom(dest => dest.ClientType.Name);
            });


            CreateMap<AppointmentService, AppointmentsGetVM>().ForMember(dest => dest.Service, option =>
            {
                option.MapFrom(src => src.Service.Name);
            }).ForMember(dest => dest.ServicePrice, option =>
            {
                option.MapFrom(src => src.Service.Price);
            }).ForMember(dest => dest.AppointmentStatus, option =>
            {
                option.MapFrom(src => src.Appointment.AppointmentStatus.Name);
            }).ForMember(dest => dest.ClientName, option =>
            {
                option.MapFrom(src => src.Appointment.Client.FirstName);
            }).ForMember(dest => dest.StartDate, option =>
            {
                option.MapFrom(src => src.Appointment.StartTime);
            }).ForMember(dest => dest.EndDate, option =>
            {
                option.MapFrom(src => src.Appointment.EndTime);
            });
        }
    }
}
