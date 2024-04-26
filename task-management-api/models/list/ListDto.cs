using task_management_api.models.tasks;

namespace task_management_api.models.list
{
    public class ListDto
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public  ICollection<TaskDto> Tasks { get; set; }

    }
}
