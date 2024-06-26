using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.board;
using task_management_api.models.list;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> getBoards(int userId, int workspaceId);
        Task<Board> getBoard(int boardId);
        Task<int> addBoard(CreateBoardDto incomingBoard, int workspaceId, int userId);
        Task editBoard(int boardId, Board editedBoard);
        Task deleteBoard(int boardId);
    }

    public class BoardService : IBoardService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public BoardService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Board>> getBoards(int userId, int workspaceId)
        {
            //SELECT *
            //FROM boards as B
            //INNER JOIN boardmembers AS BM ON B.Id = BM.BoardId
            //WHERE BM.UserId = ? AND B.WorkspaceId = ?

            //var boards = await _dbContext.boards
            //    .Join(_dbContext.boardMembers,
            //    b => b.Id,
            //    bm => bm.BoardId,
            //    (b, bm) => new { Board = b, BoardMember = bm })
            //    .Where(joinResult => joinResult.BoardMember.UserId == userId && joinResult.Board.WorkspaceId == workspaceId)
            //    .Select(joinResult => joinResult.Board)
            //.ToListAsync();

            //var boards = await _dbContext.boards
            //    .Include(b => b.BoardMembers) // Dołącz tablice członków
            //     .Where(b => b.BoardMembers.Any(bm => bm.UserId == userId && bm.BoardId == b.Id) && b.WorkspaceId == workspaceId)
            //     .ToListAsync();

            var boards = await _dbContext.Boards
                .Where(b => b.BoardMembers.Any(bm => bm.UserId == userId) && b.WorkspaceId == workspaceId)
                .ToListAsync();

            return boards;
        }

        public async Task<Board> getBoard(int boardId)
        {
            var board = await _dbContext.Boards
                  .Where(board => board.Id == boardId)
                  .FirstOrDefaultAsync();

            return board;
        }

        public async Task<int> addBoard(CreateBoardDto incomingBoard, int workspaceId, int userId)
        {
            var listDtos = new List<CreateListDto>
            {
                 new CreateListDto()
                {
                    Name = "To Do",
                    Position = 1
                },
                new CreateListDto()
                {
                    Name = "In Progress",
                    Position = 2
                },
                new CreateListDto()
                {
                    Name = "Done",
                    Position = 3
                }
            };

            var targetWorkspace = await _dbContext.Workspaces.Include(w => w.Boards)
                .FirstOrDefaultAsync(w => w.Id == workspaceId);

            if (targetWorkspace is null) throw new NotFoundException("workspace not found");

            var newBoard = new Board()
            {
                Name = incomingBoard.Name,
                Description = incomingBoard.Description,
                Background = incomingBoard.Background,
                WorkspaceId = workspaceId,
                //Workspace = _dbContext.workspaces.Where(work => work.Id == workspaceId).FirstOrDefault()
            };

            newBoard.Lists = _mapper.Map<List<List>>(listDtos);

            //if(targetWorkspace.Boards is null) {
            //    targetWorkspace.Boards.
            //}
            //else
            //{
            //    targetWorkspace.Boards.Add(newBoard); 
            //}

            targetWorkspace.Boards.Add(newBoard);

            //await _dbContext.boards.AddAsync(newBoard);
            await _dbContext.SaveChangesAsync();

            return newBoard.Id;
        }

        public async Task editBoard(int boardId, Board editedBoard)
        {

            var boardToEdit = await _dbContext.Boards.FirstAsync(board => board.Id == boardId);

            if (boardToEdit == null && editedBoard == null) { throw new NotFoundException("Board not Found"); }

            boardToEdit.Name = editedBoard.Name;
            boardToEdit.Description = editedBoard.Description;
            boardToEdit.Background = editedBoard.Background;

            _dbContext.Update(boardToEdit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task deleteBoard(int boardId)
        {

            var boardToDelete = await _dbContext.Boards.FirstAsync(board => board.Id == boardId);

            if (boardToDelete == null) { throw new NotFoundException("Board not Found"); }

            _dbContext.Boards.Remove(boardToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
