using HR.Static;
using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HR.BLL
{
    public class JwtAuthentication : IJwtAuthentication
    {

        #region Fields

        private readonly string _key;

        public JwtAuthentication(string key) => _key = key;

        #endregion

        #region Actions

        public string Authenticate(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new [] { new Claim(ClaimTypes.Name, userId) }),
                Expires = DateTime.UtcNow.AddHours(HourServer.hours).AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
