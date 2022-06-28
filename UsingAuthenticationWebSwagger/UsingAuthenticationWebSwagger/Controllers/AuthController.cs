using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using UsingAuthenticationWebSwagger.Models;


namespace UsingAuthenticationWebSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid");

            }
            if (model.UserName == "purva" && model.Password == "purva")
            {
                var secratKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@0307"));
                var SigningCridencial = new SigningCredentials(secratKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "purva",
                    audience: "https://localhost:7067/",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: SigningCridencial) ;
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { tokenString });
            }
                   else
                   {
                        return Unauthorized();
                   }


        }
    }
}


