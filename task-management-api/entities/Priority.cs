namespace task_management_api.entities
{
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ColorId { get; set; }

        public virtual Color Color { get; set; }
    }
}
