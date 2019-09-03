using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthServer.data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelClassLibrary.area.auth;
using ModelClassLibrary.area.respond;
using ModelClassLibrary.area.user;

namespace AuthServer.service.impl
{
    public class Auth : IAuth
    {
        private DataContext m_context;
        private IOptions<Audience> m_audience;
        public Auth(DataContext context, IOptions<Audience> audience)
        {
            m_context = context;
            m_audience = audience;
        }

        public Users getUser(Users user)
        {
            return m_context.Users
                            .Where(m => m.username == user.username)
                            .FirstOrDefault();
        }

        public DataRespond login(Users user)
        {
            DataRespond data = new DataRespond();
            Users us = getUser(user);
            if(us is null)
            {
                data.success = false;
                data.message = "Account not exist";
                return data;
            }
            if (us.password.Equals(user.password))
            {
                data.success = true;
                data.data= new { token = genToken(us), user = us };
                data.message = "Login success";
            }
            return data;
        }
        public string genToken(Users user)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, now.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
            new Claim(ClaimTypes.Role,user.role.ToString())//check quyen
            };

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(m_audience.Value.Secret));
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = m_audience.Value.Iss,
                ValidateAudience = true,
                ValidAudience = m_audience.Value.Aud,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };

            var jwt = new JwtSecurityToken(
                issuer: m_audience.Value.Iss,
                audience: m_audience.Value.Aud,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var responseJson = new
            {
                access_token = encodedJwt,
                expires_in = (int)TimeSpan.FromMinutes(2).TotalSeconds
            };

            return responseJson.ToString();
        }
    }
}
