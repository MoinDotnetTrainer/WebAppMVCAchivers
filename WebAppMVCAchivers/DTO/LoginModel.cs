using System.ComponentModel.DataAnnotations;

namespace WebAppMVCAchivers.DTO
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]  // null , not null values while submit
        public string Email { get; set; }// eneter true , emoty false

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
