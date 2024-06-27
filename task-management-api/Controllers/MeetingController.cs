using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_management_api.models.meeting;
using task_management_api.services;

namespace task_management_api.Controllers
{
    /// <summary>
    /// API controller for managing meetings within a board.
    /// </summary>
    [ApiController]
    [Route("api/{userId}/user/{workspaceId}/workspace/boards/{boardId}/meetings")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingController"/> class.
        /// </summary>
        /// <param name="meetingService">The meeting service.</param>
        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }


        /// <summary>
        /// Retrieves all meetings for a specific board.
        /// </summary>
        /// <param name="userId">The ID of the user making the request.</param>
        /// <param name="workspaceId">The ID of the workspace containing the board.</param>
        /// <param name="boardId">The ID of the board containing the meetings.</param>
        /// <returns>An <see cref="IActionResult"/> containing a collection of <see cref="MeetingDto"/> objects.</returns>
        /// <response code="200">Returns the list of meetings.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetAllMeetingsForBoard(
            [FromRoute] int userId,
            [FromRoute] int workspaceId,
            [FromRoute] int boardId)
        {
            var meetings = await _meetingService.GetAllMeetingsForBoard(userId, workspaceId, boardId);
            return Ok(meetings);
        }


        /// <summary>
        /// Retrieves a specific meeting by its ID.
        /// </summary>
        /// <param name="id">The ID of the meeting to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the <see cref="MeetingDto"/> object.</returns>
        /// <response code="200">Returns the meeting.</response>
        /// <response code="404">If the meeting with the specified ID is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> GetMeetingById(
            [FromRoute] int id)
        {
            var meeting = await _meetingService.GetMeetingById(id);
            return Ok(meeting);
        }

        /// <summary>
        /// Creates a new meeting for a specific board.
        /// </summary>
        /// <param name="userId">The ID of the user creating the meeting.</param>
        /// <param name="workspaceId">The ID of the workspace containing the board.</param>
        /// <param name="boardId">The ID of the board where the meeting will be created.</param>
        /// <param name="dto">The data for creating the new meeting.</param>
        /// <returns>An <see cref="IActionResult"/> containing the ID of the created meeting.</returns>
        /// <response code="201">Returns the ID of the created meeting.</response>
        [HttpPost]
        public async Task<IActionResult> CreateMeeting(
            [FromRoute] int userId,
            [FromRoute] int workspaceId,
            [FromRoute] int boardId,
            [FromBody] CreateMeetingDto dto)
        {
            var id = await _meetingService.CreateMeeting(dto,userId,workspaceId,boardId);
            return CreatedAtAction(nameof(GetMeetingById), new { id }, null);
        }

        /// <summary>
        /// Updates an existing meeting.
        /// </summary>
        /// <param name="id">The ID of the meeting to update.</param>
        /// <param name="dto">The updated data for the meeting.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="204">If the meeting was updated successfully.</response>
        /// <response code="404">If the meeting with the specified ID is not found.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeeting(
            [FromRoute] int id,
            [FromBody] MeetingDto dto)
        {
            await _meetingService.UpdateMeeting(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific meeting from a board.
        /// </summary>
        /// <param name="id">The ID of the meeting to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="204">If the meeting was deleted successfully.</response>
        /// <response code="404">If the meeting with the specified ID is not found.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(
            [FromRoute] int id)
        {
            await _meetingService.DeleteMeeting(id);
            return NoContent();
        }
    }
}

