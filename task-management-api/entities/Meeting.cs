namespace task_management_api.entities
{
    public class Meeting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public int CreatorId { get; set; }
        public int BoardId { get; set; }

        public virtual User User { get; set; }
        public virtual Board Board { get; set; }
        public virtual ICollection<Attendee> Attendees { get; set; }

    }
}
