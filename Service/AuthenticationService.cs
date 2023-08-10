using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Contract;
using WebAPI.DTO;


namespace WebAPI.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;
        private readonly JwtSettings _jwtSettings;
        public AuthenticationService(IConfiguration config, IOptions<JwtSettings> jwtSettings)
        {
              _config = config;
              _jwtSettings = jwtSettings.Value;
        }
        public string GenerateToken(UserLoginDTO user)
        {
            if (IsValidUser(user.Username, user.Password))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                };

                
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
                var token = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            return String.Empty;
        }
        private bool IsValidUser(string username, string password)
        {
            return username == "validuser" && password == "password123";
        }
    }
}
