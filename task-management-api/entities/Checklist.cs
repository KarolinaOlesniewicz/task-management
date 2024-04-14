namespace task_management_api.entities
{
    public class Checklist
    {
        public int Id { get; set; }
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
        public virtual ICollection<ChecklistElement> ChecklistElements { get; set; }
    }
}
