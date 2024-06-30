namespace API.DTOs.Account
{
    public class UserViewDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountStatus { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
