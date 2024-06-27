using Microsoft.AspNetCore.Mvc;
using task_management_api.entities;
using task_management_api.models.workspace;
using task_management_api.services;

namespace task_management_api.Controllers
{
    /// <summary>
    /// Controller for managing workspaces.
    /// </summary>
    [ApiController]
    [Route("api/{userId}/user/workspace")]
    public class WorkspaceController : ControllerBase
    {

        private readonly IWorkspaceService _workspaceService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceController"/> class.
        /// </summary>
        /// <param name="workspaceService">The workspace service to handle business logic.</param>
        public WorkspaceController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }
        #region http methods

        /// <summary>
        /// Retrieves all workspaces for a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of all workspaces for the specified user.</returns>
        /// <response code="200">If the workspaces were retrieved successfully.</response>
        [HttpGet]
        public ActionResult<IEnumerable<WorkspaceDisplayDto>> getAllByUserId([FromRoute]int userId)
        {
            var results = _workspaceService.GetAllByUserId(userId);
            return Ok(results);
        }

        /// <summary>
        /// Retrieves a specific workspace by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace to retrieve.</param>
        /// <returns>The workspace with the specified ID.</returns>
        /// <response code="200">If the workspace was found.</response>
        /// <response code="404">If the workspace with the specified ID is not found.</response>
        [HttpGet("{workspaceId}")]
        public ActionResult<WorkspaceDisplayDto> getById([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var result = _workspaceService.getById(userId, workspaceId);   
            return Ok(result);
        }

        /// <summary>
        /// Creates a new workspace for a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="dto">The workspace data transfer object containing workspace details.</param>
        /// <returns>The ID of the created workspace.</returns>
        /// <response code="201">If the workspace was created successfully.</response>
        [HttpPost]
        public ActionResult CreateWorkspace([FromRoute] int userId, [FromBody]CreateWorkspaceDto dto) 
        {
            var id = _workspaceService.CreateWorkspace(userId, dto);
            return Created($"Workspace created with id:{id}", null);

        }

        /// <summary>
        /// Deletes a specific workspace by ID.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace to delete.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        /// <response code="200">If the workspace was deleted successfully.</response>
        /// <response code="404">If the workspace with the specified ID is not found.</response>
        [HttpDelete("{workspaceId}")]
        public ActionResult DeleteWorkspace([FromRoute] int userId, [FromRoute] int workspaceId) 
        { 
            _workspaceService.DeleteWorkspace(userId, workspaceId);
            
            return Ok("Workspace deleted succesfully");
        }


        /// <summary>
        /// Edits an existing workspace.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace to edit.</param>
        /// <param name="dto">The workspace data transfer object containing updated workspace details.</param>
        /// <returns>A message indicating the result of the operation.</returns>
        /// <response code="200">If the workspace was edited successfully.</response>
        /// <response code="404">If the workspace with the specified ID is not found.</response>
        [HttpPut("{workspaceId}")]
        public ActionResult EditWorkspace([FromRoute] int userId, [FromRoute] int workspaceId, [FromBody]EditWorkspaceDto dto)
        {
            _workspaceService.EditWorkspace(userId,workspaceId, dto);
            return Ok("Workspace Edited Succesfuly");
        }
        #endregion
    }
}
