namespace ConsoleApp1
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public int ProjectId { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}