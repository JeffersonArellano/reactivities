using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4.8}$", ErrorMessage = "Password must have at least 1 uppercase, 1 lowercase, 1 number, between 4 to 8 characteres")]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
