

namespace API.Entities
{
    public class Preschooler
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherInitial { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
