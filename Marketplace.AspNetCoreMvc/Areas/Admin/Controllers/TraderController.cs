using FluentValidation;
using Marketplace.AspNetCoreMvc.Model;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Model.Concrete.Dto;
using Marketplace.Model.Concrete.Vm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TraderController : Controller
    {
        private readonly IService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public TraderController(IService service, IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult AllTraders()
        {
            try
            {
                var model = _service.SellerService.GetAllSellersVm();
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpGet]
        public IActionResult ActiveTraders()
        {
            try
            {
                var model = _service.SellerService.GetAllSellersVm(x => x.IsAccountConfirmed == true);
                return View(model);
            }
            catch (ErrorInformation)
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult PassiveTraders()
        {
            try
            {
                var model = _service.SellerService.GetAllSellersVm(x => x.IsAccountConfirmed == false); // EVRAK DURUMU DA EKLENECEK
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpGet]
        public IActionResult SellerDetails(int? id)
        {
            try
            {
                var seller = _service.SellerService.GetSellerDetailVm(x => x.Id == id);
                return View(seller);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpGet]
        public IActionResult StoreDetails(int? id)
        {
            try
            {
                ViewBag.DocumentStatus = _service.DocumentService.GetAllDocumentStatuses();
                ViewBag.SellerStatus = _service.SellerService.GetAllSellerStatuses();
                var store = _service.SellerService.GetSellerStoreDetailVm(x => x.Id == id);
                return View(store);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateSellerStatus(SellerStatusEditDto model)
        {
            try
            {
                _service.SellerService.EditSellerStatus(model);
                return Ok(_localizer["Guncellendi"].Value);
            }
            catch (ValidationException ex)
            {
                return Ok(ex.ToString());
            }
            catch (SecurityException ex)
            {
                return Ok(_localizer[ex.ToString()]);
            }
        }

        [HttpPost]
        public IActionResult UpdateSellerDocumentStatus(int documentIdModal, int documentSellerIdModal, int documentStoreTypeIdModal, string documentDescriptionModal, int documentStatusIdModal)
        {
            try
            {
                if (documentStoreTypeIdModal == 1)
                    _service.DocumentService.UpdatePersonalStoreDocument(documentIdModal, documentDescriptionModal, documentStatusIdModal);
                else
                    _service.DocumentService.UpdateCompanyStoreDocument(documentIdModal, documentDescriptionModal, documentStatusIdModal);
                return Ok();
            }
            catch (CriticalOperation)
            {
                return Ok("CriticalOperation");
            }
            catch (SecurityException)
            {
                return Ok(documentSellerIdModal);
            }
        }

        [HttpGet]
        public JsonResult GetCountry(int? id)
        {
            try
            {
                var country = _service.LocationService.GetCountry(x => x.Id == id);
                return Json(country);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetCity(int id)
        {
            try
            {
                var city = _service.LocationService.GetCity(x => x.Id == id);
                return Json(city);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetDistrict(int id)
        {
            try
            {
                var district = _service.LocationService.GetDistrict(x => x.Id == id);
                return Json(district);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetApplicantPosition(int id)
        {
            try
            {
                var applicantPosition = _service.StoreService.GetApplicantPosition(x => x.Id == id);
                return Json(applicantPosition);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetCompanyType(int id)
        {
            try
            {
                var companyType = _service.StoreService.GetCompanyType(x => x.Id == id);
                return Json(companyType);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }
    }
}
