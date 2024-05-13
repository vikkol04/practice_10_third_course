using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ConsoleApp1
{
    internal class KolokolnikovVar4
    {
        static void Main (string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Create
            using (var context = new ProjectsContext())
            {
                var project1 = new Project 
                {
                    Name = "Sirius",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3)
                };
                context.Projects.Add(project1);
                context.SaveChanges(); 
                var task1 = new Task
                {
                    Name = "Annigilation",
                    IsCompleted = true,
                    ProjectId = project1.Id,
                };
                var task2 = new Task
                {
                    Name = "Observation",
                    IsCompleted = false,
                    ProjectId = project1.Id
                };
                context.Tasks.Add(task2);
                var teamMember1 = new TeamMember
                {
                    FirstName = "Viktor",
                    LastName = "Syhorykov",
                    Projects = new List<Project> { project1 },
                    Tasks = new List<Task>()
                };
                context.TeamMembers.Add(teamMember1);
                teamMember1.Tasks.Add(task1);
                context.SaveChanges();
            }
            // Read
            using (var context = new ProjectsContext())
            {
                var project = context.Projects.FirstOrDefault(p => p.Name == "Sirius");
                if (project != null) {Console.WriteLine($"Project Id: {project.Id}, Name: {project.Name}");} 
                else {Console.WriteLine("Project not found.");}
            }
            // Update
            using (var context = new ProjectsContext())
            {
                var task = context.Tasks.FirstOrDefault(t => t.Name == "Observation");
                if (task != null)
                {
                    task.IsCompleted = true;
                    context.SaveChanges();
                    Console.WriteLine("Task 'Observation' marked as completed.");
                }
                else {Console.WriteLine("Task 'Observation' not found.");}
            }
            // Delete
            using (var context = new ProjectsContext())
            {
                var teamMember = context.TeamMembers.FirstOrDefault(tm => tm.LastName == "Syhorykov");
                if (teamMember != null)
                {
                    context.TeamMembers.Remove(teamMember);
                    context.SaveChanges();
                    Console.WriteLine("Team member 'Syhorykov' removed.");
                }
                else {Console.WriteLine("Team member 'Syhorykov' not found!");}
            }
        }
    }
}