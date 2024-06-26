using task_management_api.entities;
using Task = task_management_api.entities.Task;

namespace task_management_api.models.milestone
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class MilestoneDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
