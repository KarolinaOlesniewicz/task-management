using Microsoft.AspNetCore.Mvc;
using task_management_api.entities;
using task_management_api.models.workspace;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/{userId}/user/workspace")]
    public class WorkspaceController : ControllerBase
    {

        private readonly IWorkspaceService _workspaceService;
        public WorkspaceController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkspaceDisplayDto>> getAllByUserId([FromRoute]int userId)
        {
            var results = _workspaceService.GetAllByUserId(userId);
            return Ok(results);
        }

        [HttpGet("{workspaceId}")]
        public ActionResult<WorkspaceDisplayDto> getById([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var result = _workspaceService.getById(userId, workspaceId);   
            return Ok(result);
        }
    }
}
