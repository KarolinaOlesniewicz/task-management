using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.models.milestone;
using task_management_api.services;

namespace task_management_api.Controllers
{
    namespace task_management_api.Controllers
    {
        /// <summary>
        /// Controller for managing milestones within a board.
        /// </summary>
        //[ApiController]
        //[Route("api/{userId}/user/{workspaceId}/workspace/boards/{boardId}/milestones")]
        public class MilestoneController //: ControllerBase
        {
            //private readonly IMilestoneService _milestoneService;

            ///// <summary>
            ///// Initializes a new instance of the <see cref="MilestoneController"/> class.
            ///// </summary>
            ///// <param name="milestoneService">The milestone service to handle business logic.
            //public MilestoneController(IMilestoneService milestoneService)
            //{
            //    _milestoneService = milestoneService;
            //}

            ///// <summary>
            ///// Retrieves all milestones for a specific board.
            ///// </summary>
            ///// <param name="userId">The ID of the user.</param>
            ///// <param name="workspaceId">The ID of the workspace.</param>
            ///// <param name="boardId">The ID of the board.</param>
            ///// <returns>A list of milestones associated with the board.</returns>
            ///// <response code="200">If the milestones were retrieved successfully.</response>
            //[HttpGet]
            //public async Task<ActionResult<IEnumerable<MilestoneDto>>> GetAllMilestonesForBoard(
            //    [FromRoute] int userId,
            //    [FromRoute] int workspaceId,
            //    [FromRoute] int boardId)
            //{
            //    var milestones = await _milestoneService.GetAllMilestonesForBoard(userId, workspaceId, boardId);
            //    return Ok(milestones);
            //}

            ///// <summary>
            ///// Retrieves a specific milestone by ID.
            ///// </summary>
            ///// <param name="userId">The ID of the user.</param>
            ///// <param name="workspaceId">The ID of the workspace.</param>
            ///// <param name="boardId">The ID of the board.</param>
            ///// <param name="milestoneId">The ID of the milestone to retrieve.</param>
            ///// <returns>The milestone with the specified ID.</returns>
            ///// <response code="200">If the milestone was found.</response>
            ///// <response code="404">If the milestone with the specified ID is not found.</response>
            //[HttpGet("{milestoneId}")]
            //public async Task<ActionResult<MilestoneDto>> GetMilestoneById(
            //    [FromRoute] int userId,
            //    [FromRoute] int workspaceId,
            //    [FromRoute] int boardId,
            //    [FromRoute] int milestoneId)
            //{
            //    var milestone = await _milestoneService.GetMilestoneById(milestoneId);
            //    return Ok(milestone);
            //}

            ///// <summary>
            ///// Adds a new milestone to a specific board.
            ///// </summary>
            ///// <param name="dto">The milestone data transfer object containing milestone details.</param>
            ///// <param name="boardId">The ID of the board.</param>
            ///// <returns>A result indicating the outcome of the operation.</returns>
            ///// <response code="204">If the milestone was added successfully.</response>
            ///// <response code="400">If the request is invalid.</response>
            //[HttpPost]
            //public async Task<IActionResult> AddMilestoneForBoard(
            //    [FromBody] CreateMilestoneDto dto,
            //    [FromRoute] int boardId)
            //{
            //    await _milestoneService.AddMilestoneForBoard(dto, boardId);
            //    return NoContent();
            //}

            ///// <summary>
            ///// Adds a new milestone to a specific board.
            ///// </summary>
            ///// <param name="dto">The milestone data transfer object containing milestone details.</param>
            ///// <param name="boardId">The ID of the board.</param>
            ///// <returns>A result indicating the outcome of the operation.</returns>
            ///// <response code="204">If the milestone was added successfully.</response>
            ///// <response code="400">If the request is invalid.</response>
            //[HttpPut("{milestoneId}")]
            //public async Task<IActionResult> UpdateMilestone(
            //    [FromRoute] int userId,
            //    [FromRoute] int workspaceId,
            //    [FromRoute] int boardId,
            //    [FromRoute] int milestoneId,
            //    [FromBody] CreateMilestoneDto dto)
            //{
            //    await _milestoneService.UpdateMilestone(milestoneId, dto);
            //    return NoContent();
            //}

            ///// <summary>
            ///// Deletes a specific milestone by ID.
            ///// </summary>
            ///// <param name="userId">The ID of the user.</param>
            ///// <param name="workspaceId">The ID of the workspace.</param>
            ///// <param name="boardId">The ID of the board.</param>
            ///// <param name="milestoneId">The ID of the milestone to delete.</param>
            ///// <returns>A result indicating the outcome of the operation.</returns>
            ///// <response code="204">If the milestone was deleted successfully.</response>
            ///// <response code="404">If the milestone with the specified ID is not found.</response>
            //[HttpDelete("{milestoneId}")]
            //public async Task<IActionResult> DeleteMilestone(
            //    [FromRoute] int userId,
            //    [FromRoute] int workspaceId,
            //    [FromRoute] int boardId,
            //    [FromRoute] int milestoneId)
            //{
            //    await _milestoneService.DeleteMilestone(milestoneId);
            //    return NoContent();
            //}
        }
    }

}

