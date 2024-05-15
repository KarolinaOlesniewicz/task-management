namespace task_management_api.entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }

        public virtual User User { get; set; }
        public virtual Team Team { get; set; }
    }
}
