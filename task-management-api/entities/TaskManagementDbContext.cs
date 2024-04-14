using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace task_management_api.entities
{
    public class TaskManagementDbContext : DbContext
    {
        private readonly string conString = "server=localhost;database=taskmanagementdb;user=root;password=root";

        public DbSet<User> users { get; set; }
        public DbSet<Workspace> workspaces { get; set; }
        public DbSet<WorkspaceRole> workspaceRoles { get; set; }
        public DbSet<WorkspaceMember> workspaceMembers { get; set; }
        public DbSet<Board> boards { get; set; }
        public DbSet<List> lists { get; set; }
        public DbSet<Task> tasks { get; set; }
        public DbSet<Assignment> assignments { get; set; }
        public DbSet<Comment> comments { get; set; }
        //public DbSet<Priority> priorities { get; set; }
        public DbSet<Label> labels { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Observation> observations { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Checklist> checklists { get; set; }
        public DbSet<ChecklistElement> checklistElements { get; set; }
        public DbSet<BoardMember> boardMembers { get; set; }

        public DbSet<Activity> activities { get; set; }












        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql
                (conString, new MySqlServerVersion(new Version(8, 3, 0)));
        }
    }
}