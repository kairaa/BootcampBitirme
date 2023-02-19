using System.ComponentModel.DataAnnotations;

namespace Mvc.Models.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
