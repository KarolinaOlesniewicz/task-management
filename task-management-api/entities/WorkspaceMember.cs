namespace task_management_api.entities
{
    public class WorkspaceMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int WorkspaceId { get; set; }

        public int WorkspaceRoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Workspace Workspace { get; set; }
        public virtual WorkspaceRole WorkspaceRole { get; set; }
    }
}
