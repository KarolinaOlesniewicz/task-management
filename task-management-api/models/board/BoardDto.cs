namespace task_management_api.models.board
{
    public class BoardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public int WorkspaceId { get; set; }
    }
}
