using Marketplace.AspNetCoreMvc.Filters.ActionFilters;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Business.Concrete.Utilies.Security;
using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProductController : Controller
    {
        private readonly IService _service;
        public ProductController(IService service)
        {
            _service = service;
        }

        //static String fullPath = "";
        //static Int32 matchingId = 0;
        //static ProductDto dynamicModel = new ProductDto();
        [HttpGet]
        [TypeFilter(typeof(IsSellerStatusActiveFilter))]
        public IActionResult AddProduct()
        {

            try
            {
                return View();
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        [TypeFilter(typeof(IsSellerStatusActiveFilter))]
        [ValidateAntiForgeryToken()]
        public IActionResult AddProduct(int categoryId/*string productText, string fullText*/)
        {


            //var allProducts = _service.CategoryService.GetAll();
            //var temporaryText = "";
            //for (int i = 0; i < allProducts.Count; i++)
            //{
            //    for (int j = 0; j < allProducts[i].CategoryNames.Count; j++)
            //    {
            //        if (j == 0)
            //        {
            //            temporaryText += allProducts[i].CategoryNames[j].Name;
            //        }
            //        else
            //        {
            //            temporaryText += " - " + allProducts[i].CategoryNames[j].Name;
            //        }
            //    }
            //    if (productText == temporaryText)
            //    {
            //        if (allProducts[i].CategoryGroups.Count > 0)
            //        {
            //            fullPath = fullText;
            //            matchingId = allProducts[i].Id;
            //            return RedirectToAction("grouping", "seller", new { isGrouping = true, fullPath = fullText, matchingId = allProducts[i].Id });
            //        }
            //    }
            //    temporaryText = "";
            //}


            try
            {
                if (_service.CategoryService.CanCategoryBeGrouped(x => x.Id == categoryId))
                    return RedirectToAction("Grouping", new { categoryId = categoryId });
                else
                    return RedirectToAction("ProductFeatures", new { categoryId = categoryId });
                //return Redirect("/seller/grouping");
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpGet]
        public IActionResult Grouping(int categoryId)
        {
            var home = _service.PropertyService.GetAll();
            try
            {
                ViewBag.CategoryId = categoryId;
                ViewBag.fullPath = _service.CategoryService.GetFullPathOfCategory(categoryId);
                var category = _service.CategoryService.Get(i => i.Id == categoryId);
                //Alt satırda yaptığım işlem değişmeli mi? Bu işlemleri Business katmanında mı yapmalıyım?
                //var properties = _service.PropertyService.GetAll();
                //var result = properties.Where(x => x.Categories.Exists(e => e.Id == categoryId)).ToList();
                ViewBag.CategoryProperties = _service.PropertyService.GetPropertiesRelatedToCategory(categoryId);
                //ViewBag.Languages = _service.LanguageService.GetAll();
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
        public IActionResult Grouping(int categoryId, bool gruopStatus, int? groupPropertyId, string groupItemCode, int? groupPropertyItemId)
        {
            if (gruopStatus)
                return RedirectToAction("ProductFeatures", new { categoryId = categoryId, gruopStatus = gruopStatus, groupPropertyId = groupPropertyId, groupItemCode = groupItemCode, groupPropertyItemId = groupPropertyItemId });
            else
                return RedirectToAction("ProductFeatures", new { categoryId = categoryId, gruopStatus = gruopStatus });
        }

        [HttpGet]
        public IActionResult ProductFeatures(int categoryId, bool gruopStatus, string groupItemCode, int? groupPropertyId, int? groupPropertyItemId)
        {
            ViewBag.FullPath = _service.CategoryService.GetFullPathOfCategory(categoryId);
            ViewBag.Languages = _service.LanguageService.GetAll();
            ViewBag.Brands = _service.BrandService.GetBrandsRelatedToCategory(categoryId);
            ViewBag.Properties = _service.PropertyService.GetAll();
            ViewBag.CategoryId = categoryId;
            ViewBag.GruopStatus = gruopStatus;
            ViewBag.GroupItemCode = groupItemCode;
            ViewBag.GroupPropertyId = groupPropertyId;
            ViewBag.GroupPropertyItemId = groupPropertyItemId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult ProductFeatures()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCategoriesForProduct(int categoryId)
        {
            try
            {
                List<CategoryDto> result;
                if (categoryId == -1)
                    result = _service.CategoryService.GetAll(x => x.TopCategoryId == null);
                else
                    result = _service.CategoryService.GetAll(x => x.TopCategoryId == categoryId);
                return Json(result);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetPropertyItems(int propertyId)
        {
            try
            {
                var result = _service.PropertyService.GetAll(x => x.Id == propertyId).Select(x => x.PropertyItems);
                return Json(result);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetPropertyNames(int propertyId)
        {
            try
            {
                var result = _service.PropertyService.Get(x => x.Id == propertyId).PropertyNames;
                return Json(result);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

    }
}
