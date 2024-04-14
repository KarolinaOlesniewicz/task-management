using task_management_api.entities;

namespace task_management_api.models.workspace
{
    public class CreateWorkspaceMemberDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
