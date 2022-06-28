using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Website.Controllers
{
    [Area("Website")]
    public class CheckoutController : Controller
    {
        [HttpGet]
        [Route("Basket")]
        public IActionResult Basket()
        {
            return View();
        }

        [HttpGet]
        [Route("Payment")]
        public IActionResult Payment()
        {
            return View();
        }

        [HttpGet]
        [Route("Review")]
        public IActionResult Review()
        {
            return View();
        }

        /*
        [HttpGet]
        [Route("ShippingAddress")]
        public IActionResult ShippingAddress()
        {
            return View();
        }*/


    }
}
