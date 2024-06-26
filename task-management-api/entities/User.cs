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

        public ICollection<Team> Teams { get; set; }
        public ICollection<TeamMember> TeamMembers { get; set; }
        public ICollection<Workspace> Workspaces { get; set; }
        public ICollection<WorkspaceMember> WorkspaceMembers { get; set; }
        public ICollection<BoardMember> BoardMembers { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<Attendee> Attendees { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Observation> Observations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<NotificationTraget> TargetNotifications { get; set; }
    }
}
