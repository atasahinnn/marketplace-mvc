using Marketplace.Model.Concrete.Dto;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Business.Abstract;
using System.Collections.Generic;
using System;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IService _service;

        public DashboardController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
