using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Models;
using BookStore.Stores;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtHandler myJwtHandler;

        public LoginController(JwtHandler jwtHandler)
        {
            myJwtHandler = jwtHandler;
        }

        [HttpPost(Name = nameof(Login))]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public ActionResult<UserTokenResponse> Login([FromBody] UserEntity user)
        {
         
            if (user == null )
                return Unauthorized();

            var userFound = Users.GetValidUserEntities().FirstOrDefault(a => a.Email == user.Email && a.Password == user.Password);

            if (userFound == null)
            {
                return Unauthorized();
            }

            var signingCredentials = myJwtHandler.GetSigningCredentials();
            var claims = myJwtHandler.GetClaims(user);
            var tokenOptions = myJwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new UserTokenResponse(token, userFound.UserId));
        }
    }
}
