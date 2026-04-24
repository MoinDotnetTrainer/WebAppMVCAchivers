using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCAchivers.DTO
{
    public class ValidModel
    {
        [Required(ErrorMessage = "Name Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabets are allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress] // only email format is allowed  

        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters and include uppercase, lowercase, number, and special character"
    )]
        public string Password { get; set; }

        [Required(ErrorMessage = "ComparePassword is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        [NotMapped] // This property is not mapped to the database, it's only used for validation
        public string ConfirmPassword { get; set; }  // used to map with new password

        [Required(ErrorMessage = "Dept is required.")]
        public string Dept { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(18, 50, ErrorMessage = "Age must be between 18 and 50.")]

        public string Age { get; set; }
        [Required(ErrorMessage = "Add is required.")]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]

        public string Address { get; set; }

    }
}
