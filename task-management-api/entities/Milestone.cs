namespace task_management_api.entities
{
    public class Milestone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BoardId { get; set; }

        public virtual Board Board { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
