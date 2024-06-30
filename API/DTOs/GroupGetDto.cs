using API.Entities;

namespace API.DTOs
{
    public class GroupGetDto
    {
        public int Id { get; set; }
        public IEnumerable<User> Teachers { get; set; }
        public string LocationDescriptor { get; set; }
    }
}
