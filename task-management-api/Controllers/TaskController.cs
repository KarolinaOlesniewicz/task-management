using Microsoft.AspNetCore.Mvc;
using task_management_api.models.tasks;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/user/{userId}/workspace/{workspaceId}/boards/{boardId}/lists/{listId}/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TaskDto>>> getAllTasksForList([FromRoute]int boardId, [FromRoute]int listId)
        {
            var results = await _taskService.getTaskForList(boardId, listId);
            return Ok(results);
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskDto>> getTaskById([FromRoute] int boardId, [FromRoute] int listId, [FromRoute]int taskId)
        {
            var result = await _taskService.getTask(boardId, listId, taskId);
            return Ok(result);
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> editTask([FromBody]TaskDto dto,[FromRoute] int boardId, [FromRoute] int listId, [FromRoute] int taskId)
        {
            await _taskService.editTask(dto,boardId,listId,taskId);
            
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto dto, [FromRoute] int boardId, [FromRoute] int listId)
        {
            await _taskService.CreateTask(dto,boardId,listId);
            return Created();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask([FromRoute]int taskId)
        {
            await _taskService.DeleteTask(taskId);
            return NoContent();
                
        }



    }
}
