namespace ConsoleApp1
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}