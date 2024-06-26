namespace task_management_api.entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public  int WorkspaceId { get; set; }

        public Workspace Workspace { get; set; }
        public ICollection<BoardMember> BoardMembers { get; set; }
        public ICollection<Milestone> Milestones { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<List> Lists { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
