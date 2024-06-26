using AutoMapper;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.tasks;

namespace task_management_api.services
{
    public interface ITaskService
    {
        public Task<ICollection<TaskDto>> getTaskForList(int boardId, int listId);
        public Task<TaskDto> getTask(int boardId,int listId,int taskId);
        public System.Threading.Tasks.Task DeleteTask(int taskId);
        public System.Threading.Tasks.Task editTask(TaskDto dto, int boardId, int listId, int taskId);
        public System.Threading.Tasks.Task CreateTask(TaskDto dto, int boardId, int listId);
    }
    public class TaskService : ITaskService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public TaskService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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

        public async System.Threading.Tasks.Task DeleteTask(int taskId)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == taskId);

            if (task is null) { throw new NotFoundException("Task does not exist in current context"); }

            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

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
