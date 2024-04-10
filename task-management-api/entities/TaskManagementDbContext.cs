using Microsoft.EntityFrameworkCore;

namespace task_management_api.entities
{
    public class TaskManagementDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }     
    }
}
