using FluentValidation;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IService _service;
        public CategoryController(IService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Categories()
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                var model = _service.CategoryService.GetAll();

                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                ViewBag.Brands = _service.BrandService.GetAll();
                ViewBag.Properties = _service.PropertyService.GetAll();
                ViewBag.TopCategories = _service.CategoryService.GetAll();
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(CategoryDto model, string[] allCategoryDropdown)
        {
            for (int i = 0; i < allCategoryDropdown.Length; i++)
            {
                model.CategoryGroups[i].Id = Int32.Parse(allCategoryDropdown[i]);
            }

            List<PropertyDto> previosValue = new List<PropertyDto>(model.CategoryGroups.Count);

            for (int i = 0; i < model.CategoryGroups.Count; i++)
            {
                previosValue.Add(model.CategoryGroups[i]);
            }

            for (int i = 0; i < model.CategoryGroups.Count; i++)
            {
                if (model.CategoryGroups[i].Id == 0)
                {
                    model.CategoryGroups.Remove(model.CategoryGroups[i]);
                    i--;
                }
            }

            model.CategoryProperties.Count();

            try
            {
                model.Brands = model.Brands.Where(x => x.Id != 0).ToList();
                model.CategoryProperties = model.CategoryProperties.Where(x => x.PropertyId != 0).ToList();
                _service.CategoryService.Add(model);
                return RedirectToAction("Categories");
            }
            catch (ValidationException)
            {
                model.CategoryGroups = previosValue;
                ViewBag.Languages = _service.LanguageService.GetAll();
                ViewBag.Brands = _service.BrandService.GetAll();
                ViewBag.Properties = _service.PropertyService.GetAll();
                ViewBag.TopCategories = _service.CategoryService.GetAll();

                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }

        static Int32 CategoryId = 0;
        static Int32 PropertiesCount = 0;
        [HttpGet]
        public IActionResult UpdateCategory(int categoryId)
        {
            try
            {
                ViewBag.Languages = _service.LanguageService.GetAll();
                ViewBag.Brands = _service.BrandService.GetAll();
                ViewBag.Properties = _service.PropertyService.GetAll();
                PropertiesCount = ViewBag.Properties.Count;

                ViewBag.TopCategories = _service.CategoryService.GetAll();
                if (ViewBag.TopCategories.Count > 1)
                {
                    ViewBag.TopCategories = _service.CategoryService.GetAll(x => x.Id != categoryId);
                }
                else
                {
                    ViewBag.TopCategories = null;
                }

                ViewBag.TempTop = _service.CategoryService.GetAll(x => x.Id == categoryId);

                CategoryId = categoryId;
                var model = _service.CategoryService.Get(x => x.Id == categoryId);

                for (int j = 0; j < model.CategoryProperties.Count; j++)
                {
                    for (int i = 0; i < model.CategoryProperties.Count - 1; i++)
                    {
                        if (model.CategoryProperties[i].PropertyId > model.CategoryProperties[i + 1].PropertyId)
                        {
                            var lowerValue = model.CategoryProperties[i + 1];
                            model.CategoryProperties[i + 1] = model.CategoryProperties[i];
                            model.CategoryProperties[i] = lowerValue;
                        }
                    }
                }

                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategory(CategoryDto model, string[] allCategoryDropdown)
        {
            var temp = new List<PropertyDto>(PropertiesCount);
            for (int i = 0; i < PropertiesCount; i++)
            {
                var x = new PropertyDto() { Id = 0 };
                temp.Add(x);
            }
            model.CategoryGroups = temp;
            for (int i = 0; i < allCategoryDropdown.Length; i++)
            {
                model.CategoryGroups[i].Id = Int32.Parse(allCategoryDropdown[i]);
            }

            List<PropertyDto> previosValue = new List<PropertyDto>(model.CategoryGroups.Count);
            for (int i = 0; i < model.CategoryGroups.Count; i++)
            {
                previosValue.Add(model.CategoryGroups[i]);
            }

            for (int i = 0; i < model.CategoryGroups.Count; i++)
            {
                if (model.CategoryGroups[i].Id == 0)
                {
                    model.CategoryGroups.Remove(model.CategoryGroups[i]);
                    i--;
                }
            }

            try
            {
                model.Brands = model.Brands.Where(x => x.Id != 0).ToList();
                model.CategoryProperties = model.CategoryProperties.Where(x => x.PropertyId != 0).ToList();
                _service.CategoryService.Update(model);
                return RedirectToAction("Categories");
            }
            catch (ValidationException)
            {
                model.CategoryGroups = previosValue;
                ViewBag.Languages = _service.LanguageService.GetAll();
                ViewBag.Brands = _service.BrandService.GetAll();
                ViewBag.Properties = _service.PropertyService.GetAll();
                ViewBag.TopCategories = _service.CategoryService.GetAll();
                if (ViewBag.TopCategories.Count > 1)
                {
                    ViewBag.TopCategories = _service.CategoryService.GetAll(x => x.Id != CategoryId);
                }
                else
                {
                    ViewBag.TopCategories = null;
                }
                ViewBag.TempTop = _service.CategoryService.GetAll(x => x.Id == CategoryId);

                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpGet]
        public IActionResult RemoveCategory(int categoryId)
        {
            try
            {
                _service.CategoryService.Remove(i => i.Id == categoryId);
                return RedirectToAction("Categories");
            }
            catch (SecurityException)
            {
                return Redirect("/Admin/Account/Login");
            }
        }
    }
}
