namespace task_management_api.entities
{
    public class TaskLabel
    {
        public int TaskLabelId { get; set; }
        public int TaskId { get; set; }
        public int LabelId { get; set; }

        public Task Task { get; set; }
        public Label Label { get; set; }
    }
}
