namespace ConsoleApp1
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Task> Tasks { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}