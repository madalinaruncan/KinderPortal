namespace API.DTOs
{
    public class PreschoolerGetDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherInitial { get; set; }
        public string LastName { get; set; }
        public bool IsPresent { get; set; }
        public GroupGetDto Group { get; set; }
    }
}
