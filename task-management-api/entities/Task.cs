namespace task_management_api.entities
{
    public class Task
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public int BoardId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Position { get; set; }

        public virtual List List { get; set; }

        public virtual Board Board { get; set; }

    }
}
