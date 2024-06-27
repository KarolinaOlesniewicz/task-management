using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.list;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for list management services.
    /// This interface specifies methods for list operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface IListService
    {
        /// <summary>
        /// Retrieves all lists for a specific board.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <param name="boardId">The ID of the board.</param>
        /// <returns>A collection of ListDto objects representing all lists for the specified board.</returns>
        public Task<ICollection<ListDto>> GetAllListsForBoard(int userId, int workspaceId, int boardId);

        /// <summary>
        /// Adds a new list to a specific board.
        /// </summary>
        /// <param name="dto">The CreateListDto object containing the data for the new list.</param>
        /// <param name="boardId">The ID of the board where the list will be added.</param>
        public System.Threading.Tasks.Task AddListForBoard(CreateListDto dto, int boardId);

        /// <summary>
        /// Moves a list to a new position within the board.
        /// </summary>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list to move.</param>
        /// <param name="newPosition">The new position of the list.</param>
        public System.Threading.Tasks.Task MoveList(int boardId, int listId, int newPosition);

        /// <summary>
        /// Deletes a list from a specific board.
        /// </summary>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list to delete.</param>
        public System.Threading.Tasks.Task DeleteList(int boardId, int listId);

        /// <summary>
        /// Changes the name of a specific list.
        /// </summary>
        /// <param name="boardId">The ID of the board.</param>
        /// <param name="listId">The ID of the list to rename.</param>
        /// <param name="name">The new name of the list.</param>
        public System.Threading.Tasks.Task ChangeListName(int boardId, int listId, string name);
    }

    /// <summary>
    /// Service implementation for managing lists.
    /// </summary>
    public class ListService : IListService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public ListService(TaskManagementDbContext dbContext ,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<ICollection<ListDto>> GetAllListsForBoard(int userId, int workspaceId, int boardId)
        {
            var board = await _dbContext.Boards.FirstOrDefaultAsync(b => b.Id == boardId);
            if(board is null) { throw new NotFoundException("Board not found"); }
            var lists = board.Lists.ToList();
            var listsDto = _mapper.Map<List<ListDto>>(lists);
            return listsDto;
        }

        /// <inheritdoc/>
        public async System.Threading.Tasks.Task AddListForBoard(CreateListDto dto,int boardId)
        {
            var list = _mapper.Map<List>(dto);
            list.BoardId = boardId;
            // error with foreign key constrains caused by no board controller implementation yet
            _dbContext.Lists.Add(list);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>ssss
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
