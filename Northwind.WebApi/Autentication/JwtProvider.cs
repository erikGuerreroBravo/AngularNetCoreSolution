using Microsoft.IdentityModel.Tokens;
using Northwind.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Northwind.WebApi.Autentication
{
    public class JwtProvider : ITokenProvider
    {
        private RsaSecurityKey _key;
        private string _algoritm;
        private string _issuer;
        private string _audience;

        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters() { KeyContainerName =keyName};
            var provider = new RSACryptoServiceProvider(2048,parameters);
            _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
        }


        public string CreateToken(User user, DateTime expiry)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>() {
                new Claim(ClaimTypes.Name,$"{user.FirstName}"),
                new Claim(ClaimTypes.Role,user.Roles),
                new Claim(ClaimTypes.PrimarySid,user.Id.ToString())
            }, "Custom");
            SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_key, _algoritm),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// este metodo se encarga de validar todos los token que vienen en la peticion
        /// request
        /// </summary>
        /// <returns>retorno un token con los parametros validos</returns>
        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audience,
                ValidIssuer =_issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)

            };
        }
    }
}
