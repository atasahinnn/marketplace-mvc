using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.AspNetCoreMvc.Areas.Website.Controllers
{
    [Area("Website")]
    public class CustomerPreferencesController : Controller
    {
        [HttpPost]
        public IActionResult SetCountryCultureCurrency(string country, string culture, string currency, string returnUrl)
        {

            //Post edilen değerlerin uygun olup olmadığı sorgulanacak. Örn: culture değeri veri tabanında var mı

            Response.Cookies.Append(
                "Country",
                country,
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            Response.Cookies.Append(
                "Localization",
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            Response.Cookies.Append(
                "Currency",
                currency,
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
