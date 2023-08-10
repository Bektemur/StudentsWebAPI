using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Contract;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateController(IConfiguration configuration, IAuthenticationService authenticationService)
        {

            _configuration = configuration;
            _authenticationService = authenticationService;

        }
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO user)
        {
            var token = _authenticationService.GenerateToken(user);
            if (String.IsNullOrWhiteSpace(token))
            {
                return Unauthorized();
            }
            return Ok(token); 
        }
        
    }
}
