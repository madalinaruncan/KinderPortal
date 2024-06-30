using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountStatus { get; set; } = "Pending";
        public int GroupId { get; set; } = 1;
        public Group Group { get; set; }
    }
}
