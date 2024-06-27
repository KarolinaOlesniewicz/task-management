using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace task_management_api.entities
{
    /// <summary>
    /// Represents the database context for a task management application.
    /// This class facilitates interaction with the database and provides access to various data sets related to tasks, activities, users, teams, and other entities.
    /// </summary>
    public class TaskManagementDbContext : DbContext
    {
        private readonly string conString = "server=localhost;database=taskmanagementdb;user=root;password=root";

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistElement> ChecklistElements { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationTraget> NotificationTargets { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskLabel> TaskLabels { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<WorkspaceMember> WorkspaceMembers { get; set; }
        public DbSet<WorkspaceRole> WorkspaceRoles { get; set; }


        /// <summary>
        /// Overrides the default behavior for model configuration.
        /// This method is typically used to define relationships between tables or customize table mappings.
        /// </summary>
        /// <param name="modelBuilder">The model builder instance used for configuring the entity model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Configures the database connection for this context.
        /// </summary>
        /// <param name="optionsBuilder">The DbContext options builder instance.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql
                (conString, new MySqlServerVersion(new Version(8, 3, 0)));
        }
    }


}
