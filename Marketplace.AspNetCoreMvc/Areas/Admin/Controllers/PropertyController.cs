using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {

        private readonly IService _service;
        public PropertyController(IService service)
        {
            _service = service;
        }

        public IActionResult Properties()
        {     
            
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                var model = _service.PropertyService.GetAll();
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }

        }

        public IActionResult AddProperty()
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                return View();
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult AddProperty(PropertyDto model)
        {

            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                _service.PropertyService.Add(model);
                return Redirect("/Admin/Property/Properties");
            }
            catch (ValidationException)
            {
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }

        public IActionResult UpdateProperty(int propertyId)
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                var model = _service.PropertyService.Get(i => i.Id == propertyId);
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult UpdateProperty(PropertyDto model)
        {
            try
            {
                int countOfItem = model.PropertyItems.Count;

                for (int i = 0; i < countOfItem; i++)
                {   
                    int counter = model.PropertyItems[i].PropertyItemNames.Count;
                    for (int j = 0; j < counter; j++)
                    {
                        if (model.PropertyItems[i].PropertyItemNames[j].LanguageId == 0)
                        {
                            model.PropertyItems.Remove(model.PropertyItems[i]);
                            countOfItem--;
                            counter--;
                            j--;
                            i--;
                        }
                    }           
                }

                ViewBag.Languages = _service.LanguageService.GetAll();
                _service.PropertyService.Update(model);
                return Redirect("/Admin/Property/Properties");
            }
            catch (ValidationException)
            {
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult RemoveProperty(int propertyId)
        {
            try
            {
                _service.PropertyService.Remove(i => i.Id == propertyId);
                return Redirect("/Admin/Property/Properties");
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }


    }
}
