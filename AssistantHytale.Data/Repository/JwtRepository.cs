using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AssistantHytale.Data.Repository.Interface;
using AssistantHytale.Domain.Configuration.Interface;
using AssistantHytale.Domain.Constants;
using AssistantHytale.Domain.Result;
using AssistantHytale.Persistence.Entity;
using Microsoft.IdentityModel.Tokens;

namespace AssistantHytale.Data.Repository
{
    public class JwtRepository : IJwtRepository
    {
        private readonly IJwt _jwtConfig;

        public JwtRepository(IJwt jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        public ResultWithValue<string> GenerateToken(User user) => GenerateToken(user.Username, user.Guid);

        public ResultWithValue<string> GenerateToken(string username, Guid userGuid)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(CustomClaimTypes.UserId, userGuid.ToString()),
                    new Claim(ClaimTypes.Expiration, _jwtConfig.TimeValidInSeconds.ToString()),
                    new Claim(ClaimTypes.AuthenticationMethod, "JWT"),
                }),
                Expires = DateTime.Now.AddSeconds(_jwtConfig.TimeValidInSeconds),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.Now,
                Audience = _jwtConfig.Audience,
                Issuer = _jwtConfig.Issuer,
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return new ResultWithValue<string>(true, tokenHandler.WriteToken(token), string.Empty);
        }
    }
}
