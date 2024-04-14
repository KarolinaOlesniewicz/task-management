namespace task_management_api.entities
{
    public class ChecklistElement
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public virtual int ChecklistId { get; set; }

        public virtual Checklist Checklist { get; set; }
    }
}
