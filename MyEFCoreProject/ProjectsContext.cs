using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class ProjectsContext : DbContext
    {
        public DbSet<Project> Projects {get; set;}
        public DbSet<Task> Tasks {get; set;}
        public DbSet<TeamMember> TeamMembers {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Database=practice_10_third_course;Username=vikkol04;password=123;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Project-Tasks One-to-Many
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ProjectId);
            
            //Projects-TeamMembers Many-to-Many
            modelBuilder.Entity<Project>()
                .HasMany(p => p.TeamMembers)
                .WithMany(tm => tm.Projects)
                .UsingEntity(j => j.ToTable("Projects-TeamMembers"));

            // Tasks-TeamMembers Many-to-Many
            modelBuilder.Entity<Task>()
                .HasMany(t => t.TeamMembers)
                .WithMany(tm => tm.Tasks)
                .UsingEntity(j => j.ToTable("Tasks-TeamMembers"));
        }
    }
}