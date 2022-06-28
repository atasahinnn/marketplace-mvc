using System.Security;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marketplace.Business.Abstract;
using Marketplace.Business.Concrete.Utilies.Exceptions;
using Marketplace.Business.Concrete.Utilies.Security;
using Marketplace.Model.Concrete.Dto;

namespace Marketplace.AspNetCoreMvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IService _service;

        public TestController(IService service)
        {
            _service = service;
        }

        //[Route("[action]")]
        //public IActionResult Login()
        //{

        //    var cookie = WebAuthenticationHelper.CreateAutCookie("Sadullah Aslan", new string[] { "Admin" });
        //    HttpContext.Response.Cookies.Append("authCookie", cookie);

        //    return Ok();
        //}

        [Route("[action]")]
        public IActionResult GetUser(int userId)
        {
            try
            {
                return Ok(_service.UserService.Get(x => x.Id == userId));
            }
            catch (ErrorInformation ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("[action]")]
        public IActionResult GetUsers()
        {
            try
            {
                return Ok(_service.UserService.GetAll());
            }
            catch (ErrorInformation ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("[action]")]
        public IActionResult AddUser()
        {
            try
            {
                var userDto = new UserDto()
                {
                    FistName = "Sadullah",
                    LastName = "Aslan",
                    Email = "sadullahaslan@zemedya.com",
                    Password = "111111"
                };

                _service.UserService.Add(userDto);

                return RedirectToAction("GetUsers");
            }
            catch (SecurityException ex)
            {
                return Ok(ex.Message);
            }
            catch (ValidationException ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
