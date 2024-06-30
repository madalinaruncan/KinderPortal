using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class UserRegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "You must specify passsword between 4 and 16 characters")]
        public string Password { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
