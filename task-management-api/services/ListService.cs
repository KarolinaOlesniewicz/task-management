using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            var board = await _dbContext.boards.FirstOrDefaultAsync(b => b.Id == boardId);
            if(board is null) { throw new NotFoundException("Board not found"); }
            var lists = board.Lists.ToList();
            var listsDto = _mapper.Map<List<ListDto>>(lists);
            return listsDto;
        }

        public async System.Threading.Tasks.Task AddListForBoard(CreateListDto dto,int boardId)
        {
            var list = _mapper.Map<List>(dto);
            list.BoardId = boardId;
            // error with foreign key constrains
            _dbContext.lists.Add(list);
            _dbContext.SaveChanges();
        }

    }
}
