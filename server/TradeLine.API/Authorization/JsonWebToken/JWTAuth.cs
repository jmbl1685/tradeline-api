using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TradeLine.Core;
using TradeLine.Core.Entities;

namespace TradeLine.API.Authorization.JsonWebToken
{
    public class JWTAuth
    {
        private IConfiguration Configuration;

        public JWTAuth(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public JWTAuth() { }

        public string GenerateToken(User user)
        {
            var user_to_json = JsonConvert.SerializeObject(user);
            var claimData = new[] { new Claim(ClaimTypes.Name, user_to_json) };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                issuer: "mysite.com",
                audience: "mysite.com",
                expires: DateTime.Now.AddMinutes(30),
                claims: claimData,
                signingCredentials: signInCred
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

    }
}
