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
        #region only workspace realated http methods

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

        [HttpPost]
        public ActionResult CreateWorkspace([FromRoute] int userId, [FromBody]CreateWorkspaceDto dto) 
        {
            var id = _workspaceService.CreateWorkspace(userId, dto);
            return Created($"Workspace created with id:{id}", null);

        }

        [HttpDelete("{workspaceId}")]
        public ActionResult DeleteWorkspace([FromRoute] int userId, [FromRoute] int workspaceId) 
        { 
            _workspaceService.DeleteWorkspace(userId, workspaceId);
            
            return Ok("Workspace deleted succesfully");
        }

        [HttpPut("{workspaceId}")]
        public ActionResult EditWorkspace([FromRoute] int userId, [FromRoute] int workspaceId, [FromBody]EditWorkspaceDto dto)
        {
            _workspaceService.EditWorkspace(userId,workspaceId, dto);
            return Ok("Workspace Edited Succesfuly");
        }
        #endregion

        [HttpGet("{workspaceId}/{workspaceMemberId}")]
        public ActionResult<WorkspaceMember> getWorkspaceMember([FromRoute] int userId, [FromRoute] int workspaceId) 
        {
            return Ok();
        }

        [HttpGet("{workspaceId}/members")]
        public ActionResult<WorkspaceMember> getAllWorkspaceMembers([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            return Ok();
        }
    }
}
