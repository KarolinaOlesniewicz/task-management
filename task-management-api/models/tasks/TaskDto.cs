using task_management_api.entities;

namespace task_management_api.models.tasks
{
    public class TaskDto
    {
        public int ListId { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Position { get; set; }

    }
}
