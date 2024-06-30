using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be at least {2}, and maximum {1} characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be at least {2}, and maximum {1} characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username must be at least {2}, and maximum {1} characters")]
        public string Username { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be at least {2}, and maximum {1} characters")]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
