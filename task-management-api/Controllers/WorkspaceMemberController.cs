using Microsoft.AspNetCore.Mvc;
using task_management_api.models.workspace;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/{userId}/user/{workspaceId}/workspace/members")]
    public class WorkspaceMemberController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;

        public WorkspaceMemberController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        [HttpGet("{workspaceMemberId}")]
        public ActionResult<WorkspaceMemberDto> getWorkspaceMember([FromRoute] int userId, [FromRoute] int workspaceId, [FromRoute] int workspaceMemberId)
        {
            return Ok();
        }

        [HttpGet()]
        public ActionResult<IEnumerable<WorkspaceMemberDto>> getAllWorkspaceMembers([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var resluts = _workspaceService.GetAllWorkspaceMembers(userId, workspaceId);
            return Ok(resluts);
        }
    }
}
