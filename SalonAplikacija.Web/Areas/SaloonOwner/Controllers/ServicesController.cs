using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalonAplikacija.Web.Helpers.Utils;
using SalonAplikacija.Data;
using SalonAplikacija.Data.Models;
using SalonAplikacija.Web.Areas.SaloonOwner.ViewModels.Services;
using SalonAplikacija.Web.Helpers.AjaxMessages;

namespace SalonAplikacija.Web.Areas.SaloonOwner.Controllers
{
    [Area("SaloonOwner")]
    public class ServicesController : Controller
    {
        private readonly Context _context;
        private readonly IAjaxFlashMessage _ajaxFlashMessage;
        private readonly IMapper _mapper;

        public ServicesController(Context context, IAjaxFlashMessage ajaxFlashMessage, IMapper mapper)
        {
            _context = context;
            _ajaxFlashMessage = ajaxFlashMessage;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var services = _mapper.Map<List<ServicesGetVM>>(_context.Services.Where(x => x.IsDeleted == false)
                                                                             .ToList());

            if (services == null)
                return NotFound();

            return View(services);
        }


        [HttpGet]
        public IActionResult LoadDataTable()
        {
            var services = _mapper.Map<List<ServicesGetVM>>(_context.Services.Where(x => x.IsDeleted == false)
                                                                             .ToList());

            if (services == null)
                return NotFound();


            return PartialView("_LoadDataTable",services);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ServicesCreateVM model = new ServicesCreateVM
            {
               
            };
            return PartialView("_Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServicesCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Create", model);
            }

            try
            {
                Service service = new Service();
                service.CopyObject(model);

                _context.Services.Add(service);
                _context.SaveChanges();

                return PartialView("_Create", model);

            }
            catch (Exception ex)
            {
                return PartialView("_Create", model);
            }
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            ServicesUpdateVM model = _mapper.Map<ServicesUpdateVM>(_context.Services.Where(x => x.IsDeleted == false &&
                                                                                                x.ServiceId == id)
                                                                                    .FirstOrDefault());

            if (model == null)
                return RedirectToAction("Index");

            return PartialView("_Update",model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ServicesUpdateVM model)
        {
            if(!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Update", model);
            }

            if (model == null)
                return RedirectToAction("Index");

            try
            {
                Service service = new Service();

                service.CopyObject(model);

                _context.Services.Update(service);
                _context.SaveChanges();

                _ajaxFlashMessage.Success("Service updated successfully");

                return PartialView("_Update",model);
            }
            catch (Exception ex)
            {

                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            ServicesDeleteVM model = _mapper.Map<ServicesDeleteVM>(_context.Services.Where(x => x.IsDeleted == false &&
                                                                                           x.ServiceId == id)
                                                                                    .FirstOrDefault());

            if (model == null)
                return RedirectToAction("Index");


            return PartialView("_Delete",model);
        }

        [HttpPost]
        public IActionResult Delete(ServicesDeleteVM model)
        {
            if(!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Delete", model);
            }

            if (model == null)
                return RedirectToAction("Index");

            try
            {
                Service service = _context.Services.Where(x => x.IsDeleted == false &&
                                                               x.ServiceId == model.ServiceId)
                                                   .FirstOrDefault();

                if (service == null)
                    return PartialView("_Delete", model);


                _context.Services.Remove(service);
                _context.SaveChanges();

                return PartialView("_Delete",model);
            }
            catch (Exception ex)
            {
                return PartialView("_Delete", model);
            }
        }
    }
}