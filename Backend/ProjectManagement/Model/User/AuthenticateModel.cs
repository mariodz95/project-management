using Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class AuthenticateModel : IAuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
