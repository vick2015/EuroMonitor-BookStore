using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class UserEntity
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

    public class UserTokenResponse
    {
        public UserTokenResponse(string token,Guid userId)
        {
            Token = token;
            UserId = userId;
        }
        public string Token { get;}

        public Guid UserId { get; }
    }
}
