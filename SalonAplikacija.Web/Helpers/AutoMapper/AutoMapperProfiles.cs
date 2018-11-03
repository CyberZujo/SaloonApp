using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Client;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Appointment;
using SalonAplikacija.Data;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Services;

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

            CreateMap<Client, ClientDeleteVM>().ForMember(dest => dest.ClientId, option =>
            {
                option.MapFrom(src => src.ClientId);
            }).ForMember(dest => dest.ClientName, option =>
            {
                option.MapFrom(src => src.FirstName + " " + src.LastName);
            }).ForMember(dest => dest.ClientEmail, option =>
            {
                option.MapFrom(src => src.Email);
            });

            CreateMap<Service, ServicesGetVM>().ForMember(dest => dest.ServiceId, option =>
            {
                option.MapFrom(src => src.ServiceId);
            }).ForMember(dest => dest.Name, option =>
            {
                option.MapFrom(src => src.Name);
            }).ForMember(dest => dest.Price, option =>
            {
                option.MapFrom(src => src.Price);
            }).ForMember(dest => dest.Duration, option =>
            {
                option.MapFrom(src => src.Duration);
            }).ForMember(dest => dest.IsDeleted, option =>
            {
                option.MapFrom(src => src.IsDeleted);
            });


            CreateMap<Service, ServicesUpdateVM>().ForMember(dest => dest.ServiceId, option =>
            {
                option.MapFrom(src => src.ServiceId);
            }).ForMember(dest => dest.Name, option =>
            {
                option.MapFrom(src => src.Name);
            }).ForMember(dest => dest.Price, option =>
            {
                option.MapFrom(src => src.Price);
            }).ForMember(dest => dest.Duration, option =>
            {
                option.MapFrom(src => src.Duration);
            }).ForMember(dest => dest.IsDeleted, option =>
            {
                option.MapFrom(src => src.IsDeleted);
            });

            CreateMap<Service, ServicesDeleteVM>().ForMember(dest => dest.ServiceId, option =>
            {
                option.MapFrom(src => src.ServiceId);
            }).ForMember(dest => dest.ServiceName, option =>
            {
                option.MapFrom(src => src.Name);
            });
        }
    }
}
