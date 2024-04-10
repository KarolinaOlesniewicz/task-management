namespace task_management_api.entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Text { get; set; }
        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
