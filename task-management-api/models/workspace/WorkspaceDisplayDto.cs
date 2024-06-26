namespace task_management_api.models.workspace
{
    public class WorkspaceDisplayDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
    }
}
