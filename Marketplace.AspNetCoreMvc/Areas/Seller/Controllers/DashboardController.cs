using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Business.Concrete.Utilies.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class DashboardController : Controller
    {
        private readonly IService _service;

        public DashboardController(IService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            try
            {
                var identity = (Identity)User.Identity;
                var seller = _service.SellerService.Get(x => x.Id == Convert.ToInt32(identity.Id));

                if (seller.StoreTypeId == 0)
                {
                    ViewBag.IsSellerANewUser = true;
                    return View();
                }
                return View();
            }
            catch (ErrorInformation ex)
            {
                TempData["ErrorMessage"] = ex.Message.ToString();
                return View();
            }
        }
    }
}

