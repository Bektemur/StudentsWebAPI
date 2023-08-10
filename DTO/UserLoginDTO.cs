using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; init; }

        [Required(ErrorMessage = "Password name is required")]
        public string Password { get; init; }
    }
}
