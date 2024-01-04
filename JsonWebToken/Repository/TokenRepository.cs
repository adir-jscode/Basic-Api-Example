using JsonWebToken.Context;
using JsonWebToken.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebToken.Repository
{
    public class TokenRepository : IToken
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public TokenRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Token Token(UserDto user)
        {
            //create a token
            // 1. Claims

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                new Claim(JwtRegisteredClaimNames.Iss,Guid.NewGuid().ToString()),

            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials

            );
            //var newtoken = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token { Tokens = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
