using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleCRM.WebAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MyAuthController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Redirect("~/");
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAuth()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int id = Int32.Parse(identity.FindFirst("sub").Value);

            return Ok(id);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return Redirect("~/");
        }
    }
}