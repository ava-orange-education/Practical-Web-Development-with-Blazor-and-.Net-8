using CustomTokenBasedAuthAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomTokenBasedAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration) => _configuration = configuration;

        [HttpPost]
        public LoginResult Login(Login objlogin)
        {
            // we are keepoing 1 minute token exipry period
            // In real senario, we can keep longer period 
            var expiry = DateTime.Now.AddMinutes(1);
            return ValidateCredentials(objlogin) ? new LoginResult { Token = GenerateJWT(objlogin.Email, expiry), Expiry = expiry } : new LoginResult();
        }

        // Used for Validating User credentials
        bool ValidateCredentials(Login credentials)
        {
            bool success = false;
            // We have hardcoded the EmailId and Password for demo purpose.
            if (credentials.Email == "Admin@gmail.com" && credentials.Password == "Admin")
            {
                success = true;
            }
            return success;
        }

        // this is used for generating JWT Token
        private string GenerateJWT(string email, DateTime expiry)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                new[] { new Claim(ClaimTypes.Name, email) },
                expires: expiry,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
