using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class ClientsController : Controller
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public ClientsController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var clients = _mapper.Map<List<ClientsGetVM>>(_context.Clients.Include(x=>x.Country).Include(x=>x.City).ToList());

            return View();
        }
    }
}