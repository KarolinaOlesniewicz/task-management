namespace task_management_api.entities
{
    public class Team
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
