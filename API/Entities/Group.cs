using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Groups")]
    public class Group
    {
        public int Id { get; set; }
        public IEnumerable<User> Teachers { get; set; }
        public IEnumerable<Preschooler> Preschoolers { get; set; }
        public string LocationDescriptor { get; set; }
    }
}
