using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using FluentValidation;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IService _service;
        public BrandController(IService service)
        {
            _service = service;
        }

        public IActionResult Brands()
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                var model = _service.BrandService.GetAll();
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        public IActionResult AddBrand()
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
        public IActionResult AddBrand(BrandDto model)
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                _service.BrandService.Add(model);
                return Redirect("/Admin/Brand/Brands");
            }
            catch (ValidationException)
            {
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }


        public IActionResult UpdateBrand(int brandId)
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                var model = _service.BrandService.Get(i => i.Id == brandId);
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
        public IActionResult UpdateBrand(BrandDto model)
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                _service.BrandService.Update(model);
                return Redirect("/Admin/Brand/Brands");
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
        public IActionResult RemoveBrand(int brandId)
        {
            try
            {
                _service.BrandService.Remove(i => i.Id == brandId);
                return Redirect("/Admin/Brand/Brands");
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }

    }
}
