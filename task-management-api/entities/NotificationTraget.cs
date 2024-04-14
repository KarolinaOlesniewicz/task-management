namespace task_management_api.entities
{
    public class NotificationTraget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public virtual User User { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
