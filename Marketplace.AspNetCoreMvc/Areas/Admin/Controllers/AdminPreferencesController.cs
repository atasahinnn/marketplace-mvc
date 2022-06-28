using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPreferencesController : Controller
    {
        public IActionResult SetCulture( string culture, string returnUrl)
        {
            Response.Cookies.Append(
                "LocalizationAdmin",
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
