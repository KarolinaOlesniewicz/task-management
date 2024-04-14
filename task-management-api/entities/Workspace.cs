using System.ComponentModel.DataAnnotations;

namespace task_management_api.entities
{
    public class Workspace
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<WorkspaceMember> WorkspaceMembers { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
    }
}
