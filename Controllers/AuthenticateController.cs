using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IConfiguration _configuration;

        public AuthenticateController(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        [HttpPost("login")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserLoginDTO user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            int expires = Convert.ToInt32(jwtSettings["Expires"]) * 60;
            //if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            return Ok(new
            {
                //access_token = await _service.AuthenticationService.CreateToken(),
                expires = expires,
                token_type = "Bearer",
                refresh_token = "",
                refresh_expires = 0
            });
        }
    }
}
