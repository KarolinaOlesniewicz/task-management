namespace task_management_api.entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BackgroundPath { get; set; }
        public int WorkspaceID { get; set; }
        public virtual Workspace Workspace { get; set; }
    }
}
