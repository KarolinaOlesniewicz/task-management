using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_management_api.models.meeting;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/{userId}/user/{workspaceId}/workspace/boards/{boardId}/meetings")]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeetingDto>>> GetAllMeetingsForBoard(
            [FromRoute] int userId,
            [FromRoute] int workspaceId,
            [FromRoute] int boardId)
        {
            var meetings = await _meetingService.GetAllMeetingsForBoard(userId, workspaceId, boardId);
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDto>> GetMeetingById(
            [FromRoute] int id)
        {
            var meeting = await _meetingService.GetMeetingById(id);
            return Ok(meeting);
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeeting(
            [FromRoute] int id,
            [FromBody] MeetingDto dto)
        {
            await _meetingService.UpdateMeeting(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeeting(
            [FromRoute] int id)
        {
            await _meetingService.DeleteMeeting(id);
            return NoContent();
        }
    }
}

