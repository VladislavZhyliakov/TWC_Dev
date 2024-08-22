using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TWC_DatabaseLayer.Models;

namespace TWC_Services.TokenService
{
    public class TokenService : ITokenService
    {
        private static readonly DateTime _tokenLifeSpan = DateTime.Now.AddHours(1);
        private const string _tokenKey = "SuperSoSecretKeySuperSoSecretKey"; //i don't know how to get this from json 

        public string CreateToken(int userId, string userEmail, string role)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenKey));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
            issuer: "https://*:7099",
            audience: "https://*:7099",
            claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                    new Claim(ClaimTypes.Email, userEmail),
                    new Claim(ClaimTypes.Role, role)
                },
                expires: _tokenLifeSpan,
                signingCredentials: signinCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
