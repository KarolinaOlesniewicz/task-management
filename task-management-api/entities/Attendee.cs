namespace task_management_api.entities
{
    public class Attendee
    {
        public int Id { get; set; }
        public int MeetingId { get; set; }
        public int UserId { get; set; }

        public virtual Meeting Meeting { get; set; }
        public virtual User User { get; set; }
    }
}
