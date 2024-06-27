using Microsoft.AspNetCore.Mvc;
using task_management_api.models.tasks;
using task_management_api.services;

namespace task_management_api.Controllers
{
    /// <summary>
    /// Controller for managing tasks within lists on boards.
    /// </summary>
    [ApiController]
    [Route("api/user/{userId}/workspace/{workspaceId}/boards/{boardId}/lists/{listId}/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="taskService">The task service to handle business logic.</param>
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Retrieves all tasks for a specific list on a board.
        /// </summary>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list.</param>
        /// <returns>A collection of tasks for the specified list.</returns>
        /// <response code="200">If the tasks were retrieved successfully.</response>
        [HttpGet]
        public async Task<ActionResult<ICollection<TaskDto>>> getAllTasksForList([FromRoute]int boardId, [FromRoute]int listId)
        {
            var results = await _taskService.getTaskForList(boardId, listId);
            return Ok(results);
        }

        /// <summary>
        /// Retrieves a specific task by ID.
        /// </summary>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list.</param>
        /// <param name="taskId">The ID of the task to retrieve.</param>
        /// <returns>The task with the specified ID.</returns>
        /// <response code="200">If the task was found.</response>
        /// <response code="404">If the task with the specified ID is not found.</response>
        [HttpGet("{taskId}")]
        public async Task<ActionResult<TaskDto>> getTaskById([FromRoute] int boardId, [FromRoute] int listId, [FromRoute]int taskId)
        {
            var result = await _taskService.getTask(boardId, listId, taskId);
            return Ok(result);
        }

        /// <summary>
        /// Edits an existing task.
        /// </summary>
        /// <param name="dto">The task data transfer object containing updated task details.</param>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list.</param>
        /// <param name="taskId">The ID of the task to edit.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        /// <response code="204">If the task was edited successfully.</response>
        /// <response code="404">If the task with the specified ID is not found.</response>
        [HttpPut("{taskId}")]
        public async Task<IActionResult> editTask([FromBody]TaskDto dto,[FromRoute] int boardId, [FromRoute] int listId, [FromRoute] int taskId)
        {
            await _taskService.editTask(dto,boardId,listId,taskId);
            
            return NoContent();
        }

        /// <summary>
        /// Creates a new task in a specific list on a board.
        /// </summary>
        /// <param name="dto">The task data transfer object containing task details.</param>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        /// <response code="201">If the task was created successfully.</response>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto dto, [FromRoute] int boardId, [FromRoute] int listId)
        {
            await _taskService.CreateTask(dto,boardId,listId);
            return Created();
        }

        /// <summary>
        /// Deletes a specific task by ID.
        /// </summary>
        /// <param name="taskId">The ID of the task to delete.</param>
        /// <returns>A result indicating the outcome of the operation.</returns>
        /// <response code="204">If the task was deleted successfully.</response>
        /// <response code="404">If the task with the specified ID is not found.</response>
        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask([FromRoute]int taskId)
        {
            await _taskService.DeleteTask(taskId);
            return NoContent();
                
        }
    }
}
