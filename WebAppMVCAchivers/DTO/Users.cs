using System.ComponentModel.DataAnnotations;

namespace WebAppMVCAchivers.DTO
{
    public class Users
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]  // null , not null values while submit
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]  // null , not null values while submit

        public string Email { get; set; }
        [Required(ErrorMessage = "password is required.")]  // null , not null values while submit
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters and include uppercase, lowercase, number, and special character."
    )]
        public string Password { get; set; }
        [Required(ErrorMessage = "dob is required.")]  // null , not null values while submit

        public DateTime Dob { get; set; }
    }
}
