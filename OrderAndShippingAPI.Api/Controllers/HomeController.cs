using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderAndShippingAPI.Api.Authenticate.Abstract;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Entities.Concrete.Dtos;
using OrderAndShippingAPI.Entities.Utilities.Results.Concrete;
using OrderAndShippingAPI.Services.Abstract;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILoginTokenService _loginService;
        public HomeController(IUserService userService, ILoginTokenService loginService)
        {
            _userService = userService;
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("~/api/login")]
        public async Task<IActionResult> Login(string email,string password)
        {
            try
            {
                var result = await _loginService.Authenticate(email, password);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
