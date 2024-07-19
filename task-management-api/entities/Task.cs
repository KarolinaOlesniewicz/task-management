namespace task_management_api.entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Position { get; set; }
        public int ListID { get; set; }
        public int? PriorityID { get; set; }
        //public int MilestoneID { get; set; }
        public int BoardID { get; set; }

        public List List { get; set; }
        public Priority Priority { get; set; }
        //public Milestone Milestone { get; set; }
        public Board Board { get; set; }
        public ICollection<TaskLabel> TaskLabels { get; set; }
        public ICollection<Checklist> Checklists { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Observation> Observations { get; set; }
    }
}
