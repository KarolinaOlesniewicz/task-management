namespace task_management_api.models.meeting
{
    public class CreateMeetingDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
    }
}

