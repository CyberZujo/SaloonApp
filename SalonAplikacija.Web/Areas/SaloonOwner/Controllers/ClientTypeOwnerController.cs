using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.Admin.ViewModels;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.ClientTypeOwner;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class ClientTypeOwnerController : Controller
    {
        private readonly Context _context;
        public ClientTypeOwnerController(Context context)
        {
            _context = context;     
        }
        public IActionResult Index()
        {
            TempData["errorMessage"] = String.Empty;
            var cType = _context.ClientType.Any() ? _context.ClientType.ToList() : null;
            return View(cType);
        }
        public IActionResult LoadDataTable()
        {
            TempData["errorMessage"] = String.Empty;
            var cType = _context.ClientType.Any() ? _context.ClientType.ToList() : null;
            return PartialView("_IndexPartial",cType);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ClientTypeOwnerVM cType = new ClientTypeOwnerVM();
            return PartialView("_Create", cType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientTypeOwnerVM model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Create", model);
            }
            ClientType clientType = new ClientType();
            if (clientType == null)
            {
                return PartialView("_IndexPArtial", clientType);
            }

            clientType.Name = model.Name;
            clientType.Description = model.Description;
            clientType.Discount = model.Discount;
            clientType.IsDeleted = false;
            var item = _context.ClientType.Where(c => c.Name == model.Name).Count();
            model.ErrorMessage = _context.ClientType.Where(x => x.Name == model.Name).FirstOrDefault() != null ? "This client type already exist" : "";

            if (model.ErrorMessage != String.Empty)
            {
                Response.StatusCode = 400;
                return PartialView("_Create", model);
            }

            _context.ClientType.Add(clientType);
             _context.SaveChanges();
            return PartialView("_Create", model);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id==0)
            {
                return NotFound();
            }
            var cType = _context.ClientType.Where(c => c.ClientTypeId == id).Select(c => new ClientType
            {
                ClientTypeId = c.ClientTypeId,
                Name = c.Name,
                Description = c.Description,
                Discount = c.Discount
            }).FirstOrDefault();
            if(cType==null)
            {
                return BadRequest();
            }
            return PartialView("_Edit", cType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientType model)
        {
            if(!ModelState.IsValid)
            {
                return PartialView("_Edit", model);
            }
            var cType = _context.ClientType.Where(c => c.ClientTypeId == model.ClientTypeId).FirstOrDefault();
            if(cType==null)
            {
                return BadRequest();
            }
            cType.Name = model.Name;
            cType.Description = model.Description;
            cType.Discount = model.Discount;

            _context.ClientType.Update(cType);
            _context.SaveChanges();

            return PartialView("_Edit", model);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            ClientType cType = _context.ClientType.Where(x => x.ClientTypeId == id).FirstOrDefault();

            if (cType == null)
                return BadRequest("Client type could not be found");

            return PartialView("_Delete", cType);
        }
        [HttpPost]
        public IActionResult Delete(ClientType clientType)
        {
            if (clientType == null)
                return NotFound("Resource not found");

            var c = _context.ClientType.Where(x => x.ClientTypeId == clientType.ClientTypeId).FirstOrDefault();

            _context.ClientType.Remove(c);
            _context.SaveChanges();

            return PartialView("_Delete", clientType);

        }
    }
}