namespace task_management_api.entities
{
    public class WorkspaceRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WorkspaceMember> WorkspaceMembers { get; set; }
    }
}
