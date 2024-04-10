namespace task_management_api.entities
{
    public class Activity
    {
        public int Id { get; set; }

        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int User2Id { get; set; }
        public int BoardID { get; set; }

        public string? Type { get; set; }

        public string? Content { get; set; }

        public DateTime? TimeStamp { get; set; }


        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
        public virtual User User2 { get; set; }

        public virtual Board Board { get; set;}

    }
}

