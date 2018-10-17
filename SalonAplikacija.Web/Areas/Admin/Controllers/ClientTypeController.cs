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
            //test
            //aj on dizi
            TempData["errorMessage"] = String.Empty;
            var clientType = _context.ClientType.ToListAsync();
            if (clientType == null)
            {
                return NotFound();
            }
            return View(await clientType);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //???
            TempData["errorMessage"] = String.Empty;
            //nisi nigdje ni stavio ona polja za poruke, nemas spanova ili nesto drugo da se ispise poruka
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientType model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ClientType clientType = new ClientType();
            if (clientType == null)
            {
                return RedirectToAction(nameof(Index));
            }

            clientType.Name = model.Name;
            clientType.Description = model.Description;
            clientType.Discount = model.Discount;
            var item = _context.ClientType.Where(c => c.Name == model.Name).Count();
            if (item > 0)
            {
                TempData["errorMessage"] = "Same data already exists";
                return View();
            }
            _context.ClientType.Add(clientType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
            return View(clientType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, ClientType model)
        {

            ClientType clientType = new ClientType();
            if (model == null)
            {
                if (model.ClientTypeId != 0)
                {
                    return RedirectToAction("Edit", new { Id = model.ClientTypeId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            clientType = _context.ClientType.Where(c => c.ClientTypeId == id).FirstOrDefault();
            clientType.Name = model.Name;
            clientType.Description = model.Description;
            clientType.Discount = model.Discount;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var clientType = _context.ClientType.Where(c => c.ClientTypeId == id).FirstOrDefault();
            if (clientType == null)
            {
                return NotFound();
            }
            _context.ClientType.Remove(clientType);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}