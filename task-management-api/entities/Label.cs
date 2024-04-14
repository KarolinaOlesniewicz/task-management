namespace task_management_api.entities
{
    public class Label
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int? ColorId { get; set; }

        public virtual Task Task { get; set; }
        public virtual Color Color { get; set; }
    }
}
