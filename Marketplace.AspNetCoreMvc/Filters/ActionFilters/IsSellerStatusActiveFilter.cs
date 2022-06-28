using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.AspNetCoreMvc.Filters.ActionFilters
{
    public class IsSellerStatusActiveFilter : IActionFilter
    {
        private readonly IService _service;

        public IsSellerStatusActiveFilter(IService service)
        {
            _service = service;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = (Identity)context.HttpContext.User.Identity;
            bool active = _service.SellerService.IsUserStatusActive(x => x.Id == Convert.ToInt32(identity.Id));

            if (!active)
            {
                context.Result = new RedirectToRouteResult(
                     new RouteValueDictionary(new { area = "seller", controller = "account", action = "nonautorize" })
                    );
            }
        }
    }
}
