using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using Northwind.WebApi.Autentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [Route("api/token")]
    public class TokenController: Controller
    {
        private ITokenProvider _tokenProvider;
        private readonly IUnitOfWork _unitOfWork;
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var Token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480 ///minutes
            };
            return Token;
        }


    }
}
