namespace task_management_api.entities
{
    public class BoardMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BoardId { get; set; }

        public virtual User User { get; set; }
        public virtual Board Board { get; set; }
    }
}
