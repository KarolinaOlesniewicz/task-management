namespace task_management_api.entities
{
    public class Notification
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int User2Id { get; set; }



        public virtual User User { get; set; }
        public virtual User User2 { get; set; }


    }
}
