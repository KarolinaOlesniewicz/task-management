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
        [ApiController]
        [Route("api/{userId}/user/{workspaceId}/workspace/boards/{boardId}/milestones")]
        public class MilestoneController : ControllerBase
        {
            private readonly IMilestoneService _milestoneService;

            public MilestoneController(IMilestoneService milestoneService)
            {
                _milestoneService = milestoneService;
            }

           

            [HttpGet]
            public async Task<ActionResult<IEnumerable<MilestoneDto>>> GetAllMilestonesForBoard(
                [FromRoute] int userId,
                [FromRoute] int workspaceId,
                [FromRoute] int boardId)
            {
                var milestones = await _milestoneService.GetAllMilestonesForBoard(userId, workspaceId, boardId);
                return Ok(milestones);
            }

            [HttpGet("{milestoneId}")]
            public async Task<ActionResult<MilestoneDto>> GetMilestoneById(
                [FromRoute] int userId,
                [FromRoute] int workspaceId,
                [FromRoute] int boardId,
                [FromRoute] int milestoneId)
            {
                var milestone = await _milestoneService.GetMilestoneById(milestoneId);
                return Ok(milestone);
            }

            [HttpPost]
            public async Task<IActionResult> AddMilestoneForBoard(
                [FromBody] CreateMilestoneDto dto,
                [FromRoute] int boardId)
            {
                await _milestoneService.AddMilestoneForBoard(dto, boardId);
                return NoContent();
            }

            [HttpPut("{milestoneId}")]
            public async Task<IActionResult> UpdateMilestone(
                [FromRoute] int userId,
                [FromRoute] int workspaceId,
                [FromRoute] int boardId,
                [FromRoute] int milestoneId,
                [FromBody] CreateMilestoneDto dto)
            {
                await _milestoneService.UpdateMilestone(milestoneId, dto);
                return NoContent();
            }

            [HttpDelete("{milestoneId}")]
            public async Task<IActionResult> DeleteMilestone(
                [FromRoute] int userId,
                [FromRoute] int workspaceId,
                [FromRoute] int boardId,
                [FromRoute] int milestoneId)
            {
                await _milestoneService.DeleteMilestone(milestoneId);
                return NoContent();
            }
        }
    }

}

