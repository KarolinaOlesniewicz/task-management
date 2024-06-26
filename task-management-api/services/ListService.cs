using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.list;

namespace task_management_api.services
{
    public interface IListService
    {
        public Task<ICollection<ListDto>> GetAllListsForBoard(int userId, int workspaceId, int boardId);
        public System.Threading.Tasks.Task AddListForBoard(CreateListDto dto, int boardId);
        public System.Threading.Tasks.Task MoveList(int boardId, int listId, int newPosition);
        public System.Threading.Tasks.Task DeleteList(int boardId, int listId);
        public System.Threading.Tasks.Task ChangeListName(int boardId, int listId, string name);
    }

    public class ListService : IListService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public ListService(TaskManagementDbContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ICollection<ListDto>> GetAllListsForBoard(int userId, int workspaceId, int boardId)
        {
            var board = await _dbContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);
            if(board is null) { throw new NotFoundException("Board not found"); }
            var lists = board.Lists.ToList();
            var listsDto = _mapper.Map<List<ListDto>>(lists);
            return listsDto;
        }

        public async System.Threading.Tasks.Task AddListForBoard(CreateListDto dto,int boardId)
        {
            var list = _mapper.Map<List>(dto);
            list.BoardId = boardId;
            // error with foreign key constrains caused by no board controller implementation yet
            _dbContext.Lists.Add(list);
            _dbContext.SaveChanges();
        }

        public async System.Threading.Tasks.Task MoveList(int boardId, int listId, int newPosition)
        {
            var board = _dbContext.Boards.FirstOrDefault(b => b.Id == boardId);

            if(board is null) { throw new NotFoundException("Board not found");  }

            var listToSwap = board.Lists.FirstOrDefault(b => b.Id == listId);

            if(listToSwap is null) { throw new NotFoundException("List you are trying to move is inaccesible");  }

            var lists =  board.Lists.Where(l => l.Position <= listToSwap.Position && l.Position >= newPosition).GroupBy(b => b.Position).ToList();

            foreach(List list in lists) {
                list.Position -= 1;
            }

            listToSwap.Position = newPosition;
            _dbContext.SaveChanges();      
        }

        public async System.Threading.Tasks.Task DeleteList(int boardId, int listId)
        {
            var board = _dbContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);

            if(board is null) { throw new NotFoundException("Board Not Found"); }

            if(board.Result is null){  throw new NotFoundException("Board have no content in current context"); }

            var DeletedList = board.Result.Lists.FirstOrDefault(l => l.Id == listId);

            if(DeletedList is null) { throw new NotFoundException("List you are trying to remove do not exist in current context"); }

            var lists = board.Result.Lists.Where(l => l.Position < DeletedList.Position).GroupBy(b => b.Position).ToList();

            foreach (List list in lists)
            {
                list.Position -= 1;
            }

            _dbContext.Remove(DeletedList);
            _dbContext.SaveChanges();        
        }

        public async System.Threading.Tasks.Task ChangeListName(int boardId, int listId,  string name)
        {
            var board = _dbContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);

            if (board is null) { throw new NotFoundException("Board Not Found"); }

            if (board.Result is null) { throw new NotFoundException("Board have no content in current context"); }

            var list = board.Result.Lists.FirstOrDefault(b => b.Id == listId);

            if (list is null) { throw new NotFoundException("List does not exist"); }
            list.Name = name;
            _dbContext.SaveChanges();
        }
    }
}
