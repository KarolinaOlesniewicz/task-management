using Microsoft.AspNetCore.Mvc;
using task_management_api.models.workspace;
using task_management_api.services;

namespace task_management_api.Controllers
{
    /// <summary>
    /// Controller for managing workspace members.
    /// </summary>
    [ApiController]
    [Route("api/{userId}/user/{workspaceId}/workspace/members")]
    public class WorkspaceMemberController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceMemberController"/> class.
        /// </summary>
        /// <param name="workspaceService">The workspace service to handle business logic.</param>
        public WorkspaceMemberController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        /// <summary>
        /// Retrieves a specific workspace member by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <param name="workspaceMemberId">The ID of the workspace member to retrieve.</param>
        /// <returns>The workspace member with the specified ID.</returns>
        /// <response code="200">If the workspace member was found.</response>
        /// <response code="404">If the workspace member with the specified ID is not found.</response>
        [HttpGet("{workspaceMemberId}")]
        public ActionResult<WorkspaceMemberDto> getWorkspaceMember([FromRoute] int userId, [FromRoute] int workspaceId, [FromRoute] int workspaceMemberId)
        {
            return Ok();
        }

        /// <summary>
        /// Retrieves all workspace members for a given workspace.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>A list of all workspace members.</returns>
        /// <response code="200">If the workspace members were retrieved successfully.</response>
        [HttpGet()]
        public ActionResult<IEnumerable<WorkspaceMemberDto>> getAllWorkspaceMembers([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var resluts = _workspaceService.GetAllWorkspaceMembers(userId, workspaceId);
            return Ok(resluts);
        }
    }
}
