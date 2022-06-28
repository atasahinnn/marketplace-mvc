using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Website.Controllers
{
    [Area("Website")]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("Info")]
        public IActionResult Info () {

            return View();
        }

        [HttpGet]
        [Route("Settings")]
        public ActionResult Settings()
        {

            return View();
        }

        [HttpGet]
        [Route("ChangePassword")]
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpGet]
        [Route("Orders")]
        public ActionResult Orders()
        {

            return View();
        }

        [HttpGet]
        [Route("Returns")]
        public ActionResult Returns()
        {

            return View();
        }

        [HttpGet]
        [Route("Refund")]
        public ActionResult Refund()
        {

            return View();
        }

        [HttpGet]
        [Route("ProductComments")]
        public ActionResult ProductComments()
        {

            return View();
        }

        [HttpGet]
        [Route("Addresses")]
        public ActionResult Addresses()
        {

            return View();
        }

        [HttpGet]
        [Route("GiftCard")]
        public ActionResult GiftCard()
        {

            return View();
        }
    }
}
