namespace task_management_api.entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
        public virtual NotificationTraget NotificationTraget { get; set; }
    }
}
