using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Business.Concrete.Utilies.Security;
using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using Marketplace.Business.Concrete.Utilies;
using System.IO;
using Marketplace.AspNetCoreMvc.Areas.Seller.Models;
using System.Net;
using System.Text;
using IPGeolocation;
using Microsoft.AspNetCore.Http.Features;

namespace Marketplace.AspNetCoreMvc.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class AccountController : Controller
    {
        private readonly IService _service;
        private readonly IConfiguration _configuration;


        public AccountController(IService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;

        }

        public IActionResult Login()
        {
            DeleteCookies();
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken()]
        public IActionResult Login(LoginDto model) 
        {
            try
            {
                var info = _service.SellerService.LoginControl(model);
                var roles = new string[info.Roles.Count];
                for (int i = 0; i < info.Roles.Count; i++)
                {
                    roles[i] = info.Roles[i].Name;
                }

                var cookie = WebAuthenticationHelper.CreateAutCookie(info.FirstName + " " + info.LastName, roles, info.Id, info.Email);

                if (model.RememberMe)
                {
                    HttpContext.Response.Cookies.Append("authCookie", cookie, new CookieOptions
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(14)
                    });
                }
                else
                {
                    HttpContext.Response.Cookies.Append("authCookie", cookie);
                }

            }
            catch (ValidationException)
            {
                return View(model);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View(model);
            }

            return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Seller" });

        }

        private void DeleteCookies()
        {
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                if (cookie.Key == "authCookie")
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }
        }

        public IActionResult Logout()
        {
            var identity = (Identity)User.Identity;
            var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
            var sellersCountryId = seller.CountryId;
            DeleteCookies();
            return RedirectToAction("Register", new { id = sellersCountryId, isItAfterLogout = true });
        }

        [HttpGet]
        public IActionResult Register(int? id, bool isItAfterLogout)
        {
            try
            {
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == id);
                ViewBag.CountryCodes = _service.CountryCallingCodeService.GetAll();
                ViewBag.IsItAfterLogout = isItAfterLogout;
                return View();
            }
            catch (ErrorInformation ex)
            {
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == id);
                ViewBag.CountryCodes = _service.CountryCallingCodeService.GetAll();
                ViewBag.IsItAfterLogout = isItAfterLogout;
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Register(SellerRegisterDto model)
        {
            try
            {
                int sellerId = _service.SellerService.Add(model);
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(_configuration.GetSection("MySettings").GetSection("Email").Value));
                message.To.Add(MailboxAddress.Parse(model.Email));
                message.Subject = "myshanta.com E-Posta Doğrulama";
                var url = "https://myshanta.com/Seller/Account/ConfirmByEmail/";
                url += "?id=" + sellerId;
                message.Body = new TextPart("html") { Text = "Sayın " + model.FirstName + " " + model.LastName + ", kaydınızı tamamlamak için <a href=" + url + ">linke</a> tıklamanız gerekmektedir." };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("srvm11.trwww.com", Int32.Parse(_configuration.GetSection("MySettings").GetSection("SMTPPort").Value), SecureSocketOptions.StartTls);
                    smtp.Authenticate(_configuration.GetSection("MySettings").GetSection("Email").Value, _configuration.GetSection("MySettings").GetSection("Password").Value);
                    smtp.Send(message);
                    smtp.Disconnect(true);
                }

                return View("EmailVerified");
            }
            catch (ErrorInformation ex)
            {
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == model.CountryId);
                ViewBag.CountryCodes = _service.CountryCallingCodeService.GetAll();
                ViewBag.IsItAfterLogout = false;
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
            catch (ValidationException)
            {
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == model.CountryId);
                ViewBag.CountryCodes = _service.CountryCallingCodeService.GetAll();
                ViewBag.IsItAfterLogout = false;
                return View();
            }
        }

        public IActionResult ConfirmByEmail(int id)
        {
            try
            {
                _service.SellerService.ConfirmByEmail(id);
                return View("EmailConfirmed");
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View("EmailConfirmed");
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult NonAutorize()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditStoreDetails()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                switch (seller.StoreTypeId)
                {
                    case 1:
                        return RedirectToAction("UpdatePersonalStore");
                    case 2:
                        return RedirectToAction("UpdateCompanyStore");
                    default:
                        ViewBag.NotConfirmed = true;
                        ViewBag.IsSellerANewUser = true;
                        return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
                }
            }
            catch (ErrorInformation ex)
            {
                ViewBag.NotConfirmed = true;
                ViewBag.IsSellerANewUser = true;
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
            }
        }

        [HttpGet]
        public IActionResult StoreDocumentManagement()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                switch (seller.StoreTypeId)
                {
                    case 1:
                        return RedirectToAction("PersonalDocumentManagement");
                    case 2:
                        return RedirectToAction("CompanyDocumentManagement");
                    default:
                        ViewBag.NotConfirmed = true;
                        return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
                }
            }
            catch (ErrorInformation ex)
            {
                ViewBag.NotConfirmed = true;
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
            }
        }

        [HttpGet]
        public IActionResult StoreWarehouseManagement()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                switch (seller.StoreTypeId)
                {
                    case 1:
                        return RedirectToAction("PersonalWarehouseManagement");
                    case 2:
                        return RedirectToAction("CompanyWarehouseManagement");
                    default:
                        ViewBag.NotConfirmed = true;
                        return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
                }
            }
            catch (ErrorInformation ex)
            {
                ViewBag.NotConfirmed = true;
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
            }
        }

        [HttpGet]
        public IActionResult AddPersonalStore()
        {
            try
            {
                ViewBag.NotConfirmed = true;
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                if (seller.StoreTypeId != 0)
                    return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
                ViewBag.SellerLocation = seller.CountryId;
                ViewBag.Username = seller.FirstName + " " + seller.LastName;
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                ViewBag.SelectedCityId = seller.CityId;
                ViewBag.SelectedDistrictId = seller.DistrictId;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.SellerId = identity.Id;
                ViewBag.NotConfirmed = true;
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
        public IActionResult AddPersonalStore(PersonalStoreDto model)
        {
            try
            {
                model.Categories = model.Categories.Where(x => x.Id != 0).ToList();
                if (model.Categories.Count > 5)
                {
                    TempData["ErrorMessage"] = "5 taneden fazla Kategori seçilemez!";
                    var identity = (Identity)User.Identity;
                    var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                    ViewBag.SellerLocation = seller.CountryId;
                    ViewBag.Username = seller.FirstName + " " + seller.LastName;
                    ViewBag.Categories = _service.CategoryService.GetAll();
                    ViewBag.Brands = _service.BrandService.GetAll();
                    ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                    ViewBag.SelectedCityId = seller.CityId;
                    ViewBag.SelectedDistrictId = seller.DistrictId;
                    ViewBag.Countries = _service.LocationService.GetAllCountries();
                    ViewBag.SellerId = identity.Id;
                    ViewBag.NotConfirmed = true;
                    return View(model);
                }
                _service.StoreService.AddPersonalStore(model);
                return RedirectToAction("StoreDocumentManagement", controllerName: "Account", new { area = "Seller" });
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View(model);
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                ViewBag.SellerLocation = seller.CountryId;
                ViewBag.Username = seller.FirstName + " " + seller.LastName;
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                ViewBag.SelectedCityId = seller.CityId;
                ViewBag.SelectedDistrictId = seller.DistrictId;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.SellerId = identity.Id;
                ViewBag.NotConfirmed = true;

                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult AddCompanyStore()
        {
            try
            {
                ViewBag.NotConfirmed = true;
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                if (seller.StoreTypeId != 0)
                    return View("~/Areas/Seller/Views/Dashboard/Index.cshtml");
                ViewBag.SellerLocation = seller.CountryId;
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                ViewBag.SelectedCityId = seller.CityId;
                ViewBag.SelectedDistrictId = seller.DistrictId;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.CompanyTypes = _service.StoreService.GetAllCompanyTypes();
                ViewBag.ApplicantPositions = _service.StoreService.GetAllApplicantPositions();
                ViewBag.SellerId = identity.Id;
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
        public IActionResult AddCompanyStore(CompanyStoreDto model)
        {
            try
            {
                model.Categories = model.Categories.Where(x => x.Id != 0).ToList();
                if (model.Categories.Count > 5)
                {
                    TempData["ErrorMessage"] = "5 taneden fazla Kategori seçilemez!";
                    var identity = (Identity)User.Identity;
                    var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                    ViewBag.SellerLocation = seller.CountryId;
                    ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                    ViewBag.SelectedCityId = seller.CityId;
                    ViewBag.SelectedDistrictId = seller.DistrictId;
                    ViewBag.Countries = _service.LocationService.GetAllCountries();
                    ViewBag.Categories = _service.CategoryService.GetAll();
                    ViewBag.Brands = _service.BrandService.GetAll();
                    ViewBag.CompanyTypes = _service.StoreService.GetAllCompanyTypes();
                    ViewBag.ApplicantPositions = _service.StoreService.GetAllApplicantPositions();
                    ViewBag.SellerId = identity.Id;
                    ViewBag.NotConfirmed = true;
                    return View(model);
                }
                _service.StoreService.AddCompanyStore(model);
                return RedirectToAction("StoreDocumentManagement", controllerName: "Account", new { area = "Seller" });
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View(model);
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));
                ViewBag.SellerLocation = seller.CountryId;
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                ViewBag.SelectedCityId = seller.CityId;
                ViewBag.SelectedDistrictId = seller.DistrictId;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.CompanyTypes = _service.StoreService.GetAllCompanyTypes();
                ViewBag.ApplicantPositions = _service.StoreService.GetAllApplicantPositions();
                ViewBag.SellerId = identity.Id;
                ViewBag.NotConfirmed = true;
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult UpdatePersonalStore()
        {
            try
            {
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.Categories = _service.CategoryService.GetAll();
                var identity = (Identity)User.Identity;
                var personalStore = _service.StoreService.GetPersonalStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == personalStore.CountryId);
                ViewBag.SellerLocation = personalStore.CountryId;
                ViewBag.NotConfirmed = true;
                return View(personalStore);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePersonalStore(PersonalStoreDto model)
        {
            try
            {
                model.Categories = model.Categories.Where(x => x.Id != 0).ToList();
                if (model.Categories.Count > 5)
                {
                    TempData["ErrorMessage"] = "5 taneden fazla Kategori seçilemez!";
                    ViewBag.Countries = _service.LocationService.GetAllCountries();
                    ViewBag.Categories = _service.CategoryService.GetAll();
                    ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == model.CountryId);
                    ViewBag.SellerLocation = model.CountryId;
                    ViewBag.NotConfirmed = true;
                    return View(model);
                }
                _service.StoreService.UpdatePersonalStore(model);
                ViewBag.NotConfirmed = true;
                TempData["InformationMessage"] = "MAĞAZA BİLGİLERİNİZ BAŞARILI ŞEKİLDE GÜNCELLENDİ";
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Seller" });
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View(model);
            }
            catch (ValidationException)
            {
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == model.CountryId);
                ViewBag.SellerLocation = model.CountryId;
                ViewBag.NotConfirmed = true;
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult UpdateCompanyStore()
        {
            try
            {
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.CompanyTypes = _service.StoreService.GetAllCompanyTypes();
                ViewBag.ApplicantPositions = _service.StoreService.GetAllApplicantPositions();
                var identity = (Identity)User.Identity;
                var companyStore = _service.StoreService.GetCompanyStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == companyStore.CountryId);
                ViewBag.SellerLocation = companyStore.CountryId;
                ViewBag.NotConfirmed = true;
                return View(companyStore);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCompanyStore(CompanyStoreDto model)
        {
            try
            {
                model.Categories = model.Categories.Where(x => x.Id != 0).ToList();
                if (model.Categories.Count > 5)
                {
                    TempData["ErrorMessage"] = "5 taneden fazla Kategori seçilemez!";
                    ViewBag.Countries = _service.LocationService.GetAllCountries();
                    ViewBag.Categories = _service.CategoryService.GetAll();
                    ViewBag.CompanyTypes = _service.StoreService.GetAllCompanyTypes();
                    ViewBag.ApplicantPositions = _service.StoreService.GetAllApplicantPositions();
                    ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == model.CountryId);
                    ViewBag.SellerLocation = model.CountryId;
                    ViewBag.NotConfirmed = true;
                    return View(model);
                }
                _service.StoreService.UpdateCompanyStore(model);
                ViewBag.NotConfirmed = true;
                TempData["InformationMessage"] = "MAĞAZA BİLGİLERİNİZ BAŞARILI ŞEKİLDE GÜNCELLENDİ";
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Seller" });
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View(model);
            }
            catch (ValidationException)
            {
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.Categories = _service.CategoryService.GetAll();
                ViewBag.CompanyTypes = _service.StoreService.GetAllCompanyTypes();
                ViewBag.ApplicantPositions = _service.StoreService.GetAllApplicantPositions();
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == model.CountryId);
                ViewBag.SellerLocation = model.CountryId;
                ViewBag.NotConfirmed = true;
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult PersonalDocumentManagement()
        {
            try
            {
                var identity = (Identity)User.Identity;
                ViewBag.StoreCategories = _service.StoreService.GetPersonalStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.DocumentStatus = _service.DocumentService.GetAllDocumentStatuses();
                var personalStoreDocuments = _service.StoreService.GetPersonalStoreDocuments(x => x.SellerId == Convert.ToInt32(identity.Id));
                var store = _service.StoreService.GetPersonalStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.StoreId = store.Id;
                ViewBag.NotConfirmed = true;
                return View(personalStoreDocuments);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        public IActionResult PersonalDocumentManagement(PersonalStoreDocumentsDto model)
        {
            try
            {
                _service.StoreService.UpdatePersonalStoreDocuments(model);
                TempData["InformationMessage"] = "EVRAKLARINIZ İLGİLİ BİRİMLER TARAFINDAN İNCELEMEYE ALINDI";
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Seller" });
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                ViewBag.StoreCategories = _service.StoreService.GetPersonalStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.DocumentStatus = _service.DocumentService.GetAllDocumentStatuses();
                ViewBag.NotConfirmed = true;
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult CompanyDocumentManagement()
        {
            try
            {
                var identity = (Identity)User.Identity;
                ViewBag.StoreCategories = _service.StoreService.GetCompanyStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.DocumentStatus = _service.DocumentService.GetAllDocumentStatuses();
                var companyStoreDocuments = _service.StoreService.GetCompanyStoreDocuments(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.NotConfirmed = true;
                return View(companyStoreDocuments);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        public IActionResult CompanyDocumentManagement(CompanyStoreDocumentsDto model)
        {
            try
            {
                _service.StoreService.UpdateCompanyStoreDocuments(model);
                TempData["InformationMessage"] = "EVRAKLARINIZ İLGİLİ BİRİMLER TARAFINDAN İNCELEMEYE ALINDI";
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Seller" });
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                ViewBag.StoreCategories = _service.StoreService.GetCompanyStore(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.DocumentStatus = _service.DocumentService.GetAllDocumentStatuses();
                ViewBag.NotConfirmed = true;
                return View(model);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }


        [HttpGet]
        public IActionResult PersonalWarehouseManagement()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var personalStoreWarehouses = _service.StoreService.GetPersonalStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var personalStoreDefaultWarehouse = _service.StoreService.GetPersonalStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = personalStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View(new Tuple<PersonalStoreWarehousesDto, PersonalStoreDefaultWarehouseDto>(personalStoreWarehouses, personalStoreDefaultWarehouse));
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdatePersonalStoreWarehouses(PersonalStoreWarehousesDto model)
        {
            try
            {
                model.Warehouses = model.Warehouses.Where(x => x.Name != null || x.Address != null || x.CountryId != 0 || x.CityId != 0).ToList();
                _service.StoreService.UpdatePersonalStoreWarehouses(model);
                var identity = (Identity)User.Identity;
                var personalStoreWarehouses = _service.StoreService.GetPersonalStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var personalStoreDefaultWarehouse = _service.StoreService.GetPersonalStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = personalStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/PersonalWarehouseManagement.cshtml", new Tuple<PersonalStoreWarehousesDto, PersonalStoreDefaultWarehouseDto>(personalStoreWarehouses, personalStoreDefaultWarehouse));
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var personalStoreWarehouses = _service.StoreService.GetPersonalStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var personalStoreDefaultWarehouse = _service.StoreService.GetPersonalStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = personalStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/PersonalWarehouseManagement.cshtml", new Tuple<PersonalStoreWarehousesDto, PersonalStoreDefaultWarehouseDto>(model, personalStoreDefaultWarehouse));
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpPost]
        public IActionResult UpdatePersonalStoreDefaultWarehouse(PersonalStoreDefaultWarehouseDto model)
        {
            try
            {
                _service.StoreService.UpdatePersonalStoreDefaultWarehouse(model);
                var identity = (Identity)User.Identity;
                var personalStoreWarehouses = _service.StoreService.GetPersonalStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var personalStoreDefaultWarehouse = _service.StoreService.GetPersonalStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = personalStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/PersonalWarehouseManagement.cshtml", new Tuple<PersonalStoreWarehousesDto, PersonalStoreDefaultWarehouseDto>(personalStoreWarehouses, personalStoreDefaultWarehouse));
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var personalStoreWarehouses = _service.StoreService.GetPersonalStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var personalStoreDefaultWarehouse = _service.StoreService.GetPersonalStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = personalStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/PersonalWarehouseManagement.cshtml", new Tuple<PersonalStoreWarehousesDto, PersonalStoreDefaultWarehouseDto>(personalStoreWarehouses, model));
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult CompanyWarehouseManagement()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var companyStoreWarehouses = _service.StoreService.GetCompanyStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var companyStoreDefaultWarehouse = _service.StoreService.GetCompanyStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = companyStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View(new Tuple<CompanyStoreWarehousesDto, CompanyStoreDefaultWarehouseDto>(companyStoreWarehouses, companyStoreDefaultWarehouse));
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdateCompanyStoreWarehouses(CompanyStoreWarehousesDto model)
        {
            try
            {
                model.Warehouses = model.Warehouses.Where(x => x.Name != null || x.Address != null || x.CountryId != 0 || x.CityId != 0).ToList();
                _service.StoreService.UpdateCompanyStoreWarehouses(model);
                var identity = (Identity)User.Identity;
                var companyStoreWarehouses = _service.StoreService.GetCompanyStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var companyStoreDefaultWarehouse = _service.StoreService.GetCompanyStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = companyStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/CompanyWarehouseManagement.cshtml", new Tuple<CompanyStoreWarehousesDto, CompanyStoreDefaultWarehouseDto>(companyStoreWarehouses, companyStoreDefaultWarehouse));
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var companyStoreWarehouses = _service.StoreService.GetCompanyStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var companyStoreDefaultWarehouse = _service.StoreService.GetCompanyStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = companyStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/CompanyWarehouseManagement.cshtml", new Tuple<CompanyStoreWarehousesDto, CompanyStoreDefaultWarehouseDto>(model, companyStoreDefaultWarehouse));
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpPost]
        public IActionResult UpdateCompanyStoreDefaultWarehouse(CompanyStoreDefaultWarehouseDto model)
        {
            try
            {
                _service.StoreService.UpdateCompanyStoreDefaultWarehouse(model);
                var identity = (Identity)User.Identity;
                var companyStoreWarehouses = _service.StoreService.GetCompanyStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var companyStoreDefaultWarehouse = _service.StoreService.GetCompanyStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = companyStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/CompanyWarehouseManagement.cshtml", new Tuple<CompanyStoreWarehousesDto, CompanyStoreDefaultWarehouseDto>(companyStoreWarehouses, companyStoreDefaultWarehouse));
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var companyStoreWarehouses = _service.StoreService.GetCompanyStoreWarehouses(x => x.SellerId == Convert.ToInt32(identity.Id));
                var companyStoreDefaultWarehouse = _service.StoreService.GetCompanyStoreDefaultWarehouse(x => x.SellerId == Convert.ToInt32(identity.Id));
                ViewBag.Warehouses = companyStoreWarehouses.Warehouses;
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                ViewBag.NotConfirmed = true;
                return View("~/Areas/Seller/Views/Account/CompanyWarehouseManagement.cshtml", new Tuple<CompanyStoreWarehousesDto, CompanyStoreDefaultWarehouseDto>(companyStoreWarehouses, model));
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpGet]
        public IActionResult EditSeller()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.GetForEdit(x => x.Id == Convert.ToInt32(identity.Id));
                ViewBag.CountryCodes = _service.CountryCallingCodeService.GetAll();
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                ViewBag.SelectedCityId = seller.CityId;
                ViewBag.SelectedDistrictId = seller.DistrictId;
                ViewBag.NotConfirmed = true;
                return View(seller);
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditSeller(SellerEditDto model)
        {
            try
            {
                _service.SellerService.Update(model);
                TempData["InformationMessage"] = "HESAP BİLGİLERİNİZ BAŞARILI ŞEKİLDE GÜNCELLENDİ";
                return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Seller" });
            }
            catch (ValidationException)
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.GetForEdit(x => x.Id == Convert.ToInt32(identity.Id));
                ViewBag.CountryCodes = _service.CountryCallingCodeService.GetAll();
                ViewBag.SelectedCountry = _service.LocationService.GetCountry(x => x.Id == seller.CountryId);
                ViewBag.SelectedCityId = seller.CityId;
                ViewBag.SelectedDistrictId = seller.DistrictId;
                ViewBag.NotConfirmed = true;
                return View(seller);
            }
            catch (SecurityException)
            {
                return Redirect("/Seller/Account/Login");
            }
        }

        [HttpPost]
        public IActionResult SellerChangePassword(SellerChangePasswordDto model)
        {
            try
            {
                var identity = (Identity)User.Identity;
                model.Id = Convert.ToInt32(identity.Id);
                _service.SellerService.ChangePassword(model);
                TempData["PasswordMessage"] = "ŞİFRENİZ BAŞARILI ŞEKİLDE GÜNCELLENDİ";
                return RedirectToAction("EditSeller");
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return RedirectToAction("EditSeller");
            }
        }

        [HttpGet]
        public JsonResult GetCities(int? id)
        {
            try
            {
                var cities = _service.LocationService.GetAllCities(x => x.CountryId == id);
                return Json(cities);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        public JsonResult GetDistricts(int? id)
        {
            try
            {
                var districts = _service.LocationService.GetAllDistricts(x => x.CityId == id);
                return Json(districts);
            }
            catch (ErrorInformation)
            {
                return Json(null);
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
        public JsonResult StoreNameControl(string storeName)
        {
            try
            {
                if (storeName != null)
                {
                    var storeNameAnswer = _service.StoreService.StoreNameControl(storeName);
                    if (storeNameAnswer != null)
                        return Json(storeNameAnswer);
                }
                return Json(null);
            }
            catch (ErrorInformation)
            {
                return Json(null);
            }
        }

        [HttpGet]
        [Route("CurrentLocationDefault")]
        public IActionResult CurrentLocationDefault()
        {

            //var responseString = "";
            //var request = (HttpWebRequest)WebRequest.Create("http://localhost:26404/api/CustomersAPI");
            //request.Method = "GET";
            //request.ContentType = "application/json";

            //using (var response1 = request.GetResponse())
            //{
            //    using (var reader = new StreamReader(response1.GetResponseStream()))
            //    {
            //        responseString = reader.ReadToEnd();
            //    }
            //}

            //Türkiye ip    78.183.106.91
            //Libya ip      102.164.96.0

            //Sunucu ip adres
            var feature = HttpContext.Features.Get<IHttpConnectionFeature>();
            var LocalIPAddr = feature?.LocalIpAddress?.ToString();

            //Kullanıcı ip adres
            var ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();


            IPGeolocationAPI api = new IPGeolocationAPI("85d710daa1cd4668888825da70d7a19d");

            GeolocationParams geoParams = new GeolocationParams();
            geoParams.SetIPAddress("78.183.106.91");
            geoParams.SetLang("en");

            Geolocation geolocation = api.GetGeolocation(geoParams);

            var json = "";
            // Check if geolocation lookup was successful
            if (geolocation.GetStatus() == 200)
            {
                json += geolocation.GetIPAddress();
                json += "  -  ";
                json += geolocation.GetCountryName();
                json += "  -  ";
                json += geolocation.GetCountryCode2();
                switch (geolocation.GetCountryCode2())
                {
                    case "TR":
                        ViewBag.Countries = _service.LocationService.GetAllCountries(x => x.Id != 2);
                        ViewBag.Location = _service.LocationService.GetCountry(x => x.Id == 2);
                        return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                    case "LY":
                        ViewBag.Countries = _service.LocationService.GetAllCountries(x => x.Id != 1);
                        ViewBag.Location = _service.LocationService.GetCountry(x => x.Id == 1);
                        return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                    default:
                        return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                }
            }
            else
            {
                json += geolocation.GetMessage();
                return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
            }

            //return Json(json);
        }

        [HttpGet]
        [Route("CurrentLocation")]
        public IActionResult CurrentLocation()
        {
            try
            {
                string info = "";
                //Sunucu ip adres
                var feature = HttpContext.Features.Get<IHttpConnectionFeature>();
                var LocalIPAddr = feature?.LocalIpAddress?.ToString();
                info += "sunucu ip = " + LocalIPAddr;

                //Kullanıcı ip adres
                var ClientIPAddr = HttpContext.Connection.RemoteIpAddress?.ToString();
                info += " - kullanici ip = " + ClientIPAddr;

                ViewBag.Info = info;

                IPGeolocationAPI api = new IPGeolocationAPI("85d710daa1cd4668888825da70d7a19d");

                GeolocationParams geoParams = new GeolocationParams();
                geoParams.SetIPAddress(ClientIPAddr);
                geoParams.SetLang("en");

                Geolocation geolocation = api.GetGeolocation(geoParams);
                var json = "";
                // Check if geolocation lookup was successful
                if (geolocation.GetStatus() == 200)
                {
                    json += geolocation.GetIPAddress();
                    json += "  -  ";
                    json += geolocation.GetCountryName();
                    json += "  -  ";
                    json += geolocation.GetCountryCode2();
                    switch (geolocation.GetCountryCode2())
                    {
                        case "TR":
                            ViewBag.Countries = _service.LocationService.GetAllCountries(x => x.Id != 2);
                            ViewBag.Location = _service.LocationService.GetCountry(x => x.Id == 2);
                            return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                        case "LY":
                            ViewBag.Countries = _service.LocationService.GetAllCountries(x => x.Id != 1);
                            ViewBag.Location = _service.LocationService.GetCountry(x => x.Id == 1);
                            return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                        default:
                            ViewBag.Countries = _service.LocationService.GetAllCountries();
                            return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                    }
                }
                else
                {
                    ViewBag.Countries = _service.LocationService.GetAllCountries();
                    json += geolocation.GetMessage();
                    return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Info = "Hata döndü";
                ViewBag.Countries = _service.LocationService.GetAllCountries();
                return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
            }
            //catch (NullReferenceException ex)
            //{
            //    ViewBag.Info = "Hata döndü";
            //    ViewBag.Countries = _service.CountryService.GetAll();
            //    return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
            //}
            //catch (WebException ex)
            //{
            //    ViewBag.Info = "Hata döndü";
            //    ViewBag.Countries = _service.CountryService.GetAll();
            //    return View("~/Areas/Seller/Views/Account/CurrentLocation.cshtml");
            //}
            //return Json(json);
        }
    }
}
