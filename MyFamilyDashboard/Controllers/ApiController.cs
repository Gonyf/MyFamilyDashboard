using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyFamilyDashboard.Controllers
{
    public class ApiController : Controller
    {
        [Route("api/login")]
        public IActionResult LogIn()   
        {
            // TODO: Get users login information and check that it is correct

            var username = "gonyf";
            var email = "qzw@live.dk";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
                new Claim(JwtRegisteredClaimNames.Email, email),

                new Claim("MyKey", "myValue")
            };

            // Create the credentials to generate the token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // generate the Jwt token
            var token = new JwtSecurityToken(
                issuer: IoCContainer.Configuration["Jwt:Issuer"],
                audience: IoCContainer.Configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials
                );

            // return token to user
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;
            return Ok(new { privateData = $"SomeSecret for {HttpContext.User.Identity.Name}" }); 
        }
    }
}
