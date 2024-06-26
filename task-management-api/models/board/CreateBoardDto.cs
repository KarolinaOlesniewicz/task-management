using task_management_api.models.list;

namespace task_management_api.models.board
{
    public class CreateBoardDto
    {
        //public int WorkspaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Background { get; set; }
        public ICollection<CreateListDto> Lists { get; set; }
    }
}
