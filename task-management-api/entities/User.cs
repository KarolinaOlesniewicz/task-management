namespace task_management_api.entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfilePicture { get; set; }

        public virtual ICollection<WorkspaceMember> WorkspaceMembers { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<BoardMember> BoardMembers { get; set; }
    }
}
