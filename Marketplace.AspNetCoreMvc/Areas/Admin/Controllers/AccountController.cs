using Microsoft.AspNetCore.Mvc;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Security;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Marketplace.AspNetCoreMvc.Filters.ExceptionFilters;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IService _service;

        public AccountController(IService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            DeleteCookies();
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(ValidationExceptionFilter))]
        [TypeFilter(typeof(ErrorInformationExceptionFilter))]
        public IActionResult Login(LoginDto model)
        {
            var info = _service.AdminService.LoginControl(model);
            var roles = new string[info.Roles.Count];
            for (int i = 0; i < info.Roles.Count; i++)
            {
                roles[i] = info.Roles[i].Name;
            }

            var cookie = WebAuthenticationHelper.CreateAutCookie(info.Name + " " + info.Surname, roles, info.Id, info.Email);

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


            return RedirectToAction("Index", controllerName: "Dashboard", new { area = "Admin" });

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
    }
}
