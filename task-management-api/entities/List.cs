namespace task_management_api.entities
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public int Position { get; set; }

        public virtual Board Board { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
