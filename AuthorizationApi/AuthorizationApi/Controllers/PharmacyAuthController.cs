using AuthorizationApi.DataProvider;
using AuthorizationApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace AuthorizationApi.Controllers
{
    [EnableCors("MyCorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyAuthController : ControllerBase
    {
        private IConfiguration _config;
        private IPharmacyDataProvider pharmacyData=new PharmacyDataProvider();
        public PharmacyAuthController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] PharmacyMembers userLogin)
        {
            var user = Authenticate(userLogin);
            IActionResult response = Unauthorized();
            if(user==null)
            {
                return NotFound();
            }
            if (user != null)
            {
                var token = GenerateJsonWebToken(user);
                return Ok(new { token = token });
            }
            return response;
        }
        private string GenerateJsonWebToken(PharmacyMembers user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private PharmacyMembers Authenticate(PharmacyMembers userLogin)
        {
            var currentUser =pharmacyData.GetPharmacyMembers(userLogin);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

    }
}
