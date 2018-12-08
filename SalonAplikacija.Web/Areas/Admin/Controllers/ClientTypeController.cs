using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;

namespace SalonAplikacija.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientTypeController : Controller
    {
        private readonly Context _context;
        public ClientTypeController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            TempData["errorMessage"] = String.Empty;
            var clientType = _context.ClientType.ToListAsync();
            if (clientType == null)
            {
                return NotFound();
            }
            return View(await clientType);
        }
        public IActionResult LoadDataTable()
        {
            TempData["errorMessage"] = String.Empty;
            //var clientType = _context.ClientType.ToListAsync();
            //if (clientType == null)
            //{
            //    return NotFound();
            //}
            var clientType = _context.ClientType.Any() ? _context.ClientType.ToList() : null;
            return PartialView("_IndexPartial",clientType);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ClientType cType = new ClientType();
            TempData["errorMessage"] = String.Empty;
           
            return PartialView("_Create",cType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientType model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create",model);
            }
            ClientType clientType = new ClientType();
            if (clientType == null)
            {
                return PartialView("_IndexPArtial",clientType);
            }

            clientType.Name = model.Name;
            clientType.Description = model.Description;
            clientType.Discount = model.Discount;
            clientType.IsDeleted = false;
            var item = _context.ClientType.Where(c => c.Name == model.Name).Count();
            if (item > 0)
            {
                TempData["errorMessage"] = "Same data already exists";
                return View();
            }
            _context.ClientType.Add(clientType);
            await _context.SaveChangesAsync();
            return PartialView("_Create",clientType);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var clientType = _context.ClientType.Where(c => c.ClientTypeId == id).Select(c => new ClientType
            {
                ClientTypeId = c.ClientTypeId,
                Name = c.Name,
                Description = c.Description,
                Discount = c.Discount
            }).Single();

            if (clientType == null)
            {
                return NotFound();
            }
            return View(clientType);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var clientType = _context.ClientType.Where(c => c.ClientTypeId == id).Select(c => new ClientType
            {
                ClientTypeId = c.ClientTypeId,
                Name = c.Name,
                Description = c.Description,
                Discount = c.Discount
            }).Single();

            if (clientType == null)
            {
                return NotFound();
            }
            return PartialView("_Edit",clientType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ClientType model)
        {

            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Edit", model);
            }

            try
            {
                ClientType cType = _context.ClientType.Where(x => x.ClientTypeId == model.ClientTypeId).FirstOrDefault();

                cType.Name = model.Name;
                cType.Description = model.Description;
                cType.Discount = model.Discount;
                _context.ClientType.Update(cType);
                _context.SaveChanges();

                return PartialView("_Edit", model);
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ClientType cType = _context.ClientType.Where(x => x.ClientTypeId == id).FirstOrDefault();

            if (cType == null)
                return BadRequest("Country could not be found");

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