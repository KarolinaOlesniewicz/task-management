using task_management_api.entities;

namespace task_management_api.models.meeting
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public int CreatorId { get; set; }
        public int BoardId { get; set; }
        //public ICollection<Attendee> Attendees { get; set; }
    }
}
