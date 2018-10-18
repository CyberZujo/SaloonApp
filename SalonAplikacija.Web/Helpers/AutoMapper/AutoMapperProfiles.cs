using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels;
using SalonAplikacija.Data.Models;

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
        }
    }
}
