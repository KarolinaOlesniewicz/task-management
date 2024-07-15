using AutoMapper;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.tasks;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for task management services.
    /// This interface specifies methods for task operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Retrieves all tasks for a specific list within a board.
        /// </summary>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list whose tasks are to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of TaskDto objects.</returns>
        Task<ICollection<TaskDto>> getTaskForList(int boardId, int listId);

        /// <summary>
        /// Retrieves a specific task by its identifier within a board and list.
        /// </summary>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list containing the task.</param>
        /// <param name="taskId">The ID of the task to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a TaskDto object representing the task.</returns>
        Task<TaskDto> getTask(int boardId, int listId, int taskId);

        /// <summary>
        /// Deletes a specific task.
        /// </summary>
        /// <param name="taskId">The ID of the task to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task DeleteTask(int taskId);

        /// <summary>
        /// Edits an existing task.
        /// </summary>
        /// <param name="dto">The TaskDto object containing the updated data for the task.</param>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list containing the task.</param>
        /// <param name="taskId">The ID of the task to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task editTask(TaskDto dto, int boardId, int listId, int taskId);

        /// <summary>
        /// Creates a new task within a specific list and board.
        /// </summary>
        /// <param name="dto">The TaskDto object containing the data for the new task.</param>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list to which the task will be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        System.Threading.Tasks.Task CreateTask(TaskDto dto, int boardId, int listId);
    }

    /// <summary>
    /// Implements the ITaskService interface, providing methods for task operations.
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the TaskService class.
        /// </summary>
        /// <param name="dbContext">The database context for accessing data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping entities to DTOs.</param>
        public TaskService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ICollection<TaskDto>> getTaskForList(int boardId, int listId)
        {
            var board = _dbContext.Boards.FirstOrDefault(b => b.Id == boardId);
            if (board is null) { throw new NotFoundException("Board does not exist in current context"); }

            var list = board.Lists.FirstOrDefault(l => l.Id == listId);
            if (list is null) { throw new NotFoundException("List Does not Exist in current Context"); }

            var tasks = list.Tasks.ToList();
            var tasksDto = _mapper.Map<List<TaskDto>>(tasks);

            return tasksDto;

        }

        /// <inheritdoc />
        public async Task<TaskDto> getTask(int boardId, int listId, int taskId)
        {
            var board = _dbContext.Boards.FirstOrDefault(b => b.Id == boardId);
            if (board is null) { throw new NotFoundException("Board does not exist in current context"); }

            var list = board.Lists.FirstOrDefault(l => l.Id == listId);
            if (list is null) { throw new NotFoundException("List Does not Exist in current Context"); }

            var task = list.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is null) { throw new NotFoundException("Task does not exist"); }

            var taskDto = _mapper.Map<TaskDto>(task);
            return taskDto;
        }

        /// <inheritdoc />
        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task is null) { throw new NotFoundException("Task does not exist in current context"); }

            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public async System.Threading.Tasks.Task editTask(TaskDto dto,int boardId,int listId,int taskId)
        {
            var board = _dbContext.Boards.FirstOrDefault(b => b.Id == boardId);
            if (board is null) { throw new NotFoundException("Board does not exist in current context"); }

            var list = board.Lists.FirstOrDefault(l => l.Id == listId);
            if (list is null) { throw new NotFoundException("List Does not Exist in current Context"); }

            var task = list.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task is null) { throw new NotFoundException("Task does not exist"); }

            task = (entities.Task)ReflectionService.Reflect(dto, task);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public async System.Threading.Tasks.Task CreateTask(TaskDto dto, int boardId, int listId)
        {
            var board = _dbContext.Boards.FirstOrDefault(b => b.Id == boardId);
            if (board is null) { throw new NotFoundException("Board does not exist in current context"); }

            var list = board.Lists.FirstOrDefault(l => l.Id == listId);
            if (list is null) { throw new NotFoundException("List Does not Exist in current Context"); }

            var task = _mapper.Map<entities.Task>(dto);

            list.Tasks.Add(task);
            _dbContext.SaveChanges();
        }

    }
}
