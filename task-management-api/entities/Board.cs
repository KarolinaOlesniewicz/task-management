namespace task_management_api.entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public virtual int WorkspaceId { get; set; }

        public virtual Workspace Workspace { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<BoardMember> BoardMembers { get; set; }
    }
}
