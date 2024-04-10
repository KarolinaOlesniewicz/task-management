using System.ComponentModel.DataAnnotations;

namespace task_management_api.entities
{
    public class Workspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public int UserId { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
