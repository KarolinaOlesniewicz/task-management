namespace task_management_api.entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string URL { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }

        public Task Task { get; set; }
        public User User { get; set; }
    }
}
