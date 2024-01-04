using JsonWebToken.Context;
using JsonWebToken.Models;
using JsonWebToken.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        //private readonly ApplicationDbContext _context;
        //private readonly IConfiguration _configuration;
        //public AuthController(ApplicationDbContext context, IConfiguration configuration)
        //{
        //    _context = context;
        //    _configuration = configuration;
        //}

        private readonly IToken _token;
        public AuthController(IToken token)
        {
            _token = token;
        }


        [HttpPost]

        public IActionResult Login(UserDto user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = _token.Token(user);
            if(token == null)
            {
                return Unauthorized();
            }



            return Ok(token);
            ////create a token
            //// 1. Claims

            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub,user.Username),
            //    new Claim(JwtRegisteredClaimNames.Iss,Guid.NewGuid().ToString()),

            //};

            //var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            //var signingCredentials = new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256);

            //var token = new JwtSecurityToken(
            //    issuer : _configuration["Jwt:Issuer"],
            //    audience: _configuration["Jwt:Audience"],
            //    claims: claims,
            //    expires : DateTime.Now.AddDays(7),
            //    signingCredentials : signingCredentials

            //);

            //return Ok(new
            //{
            //    Token = new JwtSecurityTokenHandler().WriteToken(token)
            //}) ;
        }
    }
}
