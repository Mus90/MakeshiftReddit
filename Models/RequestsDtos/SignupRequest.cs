using System;
using System.ComponentModel.DataAnnotations;

namespace MakeshiftReddit.Models.RequestsDtos
{
    public class SignupRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
