using task_management_api.entities;
using task_management_api.models.board;

namespace task_management_api.models.workspace
{
    public class CreateWorkspaceDto
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public CreateBoardDto board { get; set; }
    }
}
