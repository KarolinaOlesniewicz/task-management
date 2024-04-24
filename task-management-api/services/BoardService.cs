using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.board;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> getBoards(int userID, int workspaceID);
        Task<Board> getBoard(int boardID);
        Task<int> addBoard(Board incomingBoard);
        Task editBoard(int boardID, Board editedBoard);
        Task deleteBoard(int boardID);
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

        public async Task<IEnumerable<Board>> getBoards(int userID, int workspaceID)
        {
            //SELECT *
            //FROM boards as B
            //INNER JOIN boardmembers AS BM ON B.Id = BM.BoardId
            //WHERE BM.UserId = ? AND B.WorkspaceId = ?

            var boards = await _dbContext.boards
                       .Join(_dbContext.boardMembers,
                           board => board.Id,
                           boardMember => boardMember.BoardId,
                           (board, boardMember) => new { Board = board, BoardMember = boardMember })
                       .Where(bb => bb.BoardMember.UserId == userID && bb.Board.WorkspaceId == workspaceID)
                       .Select(bb => bb.Board)
                       .ToListAsync();

            return boards;
        }

        public async Task<Board> getBoard(int boardID)
        {
            var board = await _dbContext.boards
                  .Where(board => board.Id == boardID)
                  .FirstOrDefaultAsync();

            return board;
        }

        public async Task<int> addBoard(Board incomingBoard)
        {

            if (incomingBoard == null) { throw new NotFoundException("Invalid input data"); }

            var newBoard = new Board()
            {
                Name = incomingBoard.Name,
                Description = incomingBoard.Description,
                Background = incomingBoard.Background,
                // ...
                //Workspace = _dbContext.workspaces.Where(work => work.Id == incomingBoard.WorkspaceId).FirstOrDefault()
            };


            await _dbContext.boards.AddAsync(newBoard);
            await _dbContext.SaveChangesAsync();

            return newBoard.Id;
        }

        public async Task editBoard(int boardID, Board editedBoard)
        {

            var boardToEdit = await _dbContext.boards.FirstAsync(board => board.Id == boardID);

            if (boardToEdit == null && editedBoard == null) { throw new NotFoundException("Board not Found"); }

            boardToEdit.Name = editedBoard.Name;
            boardToEdit.Description = editedBoard.Description;
            boardToEdit.Background = editedBoard.Background;

            _dbContext.Update(boardToEdit);
            await _dbContext.SaveChangesAsync();
        }

        public async Task deleteBoard(int boardID)
        {

            var boardToDelete = await _dbContext.boards.FirstAsync(board => board.Id == boardID);

            if (boardToDelete == null) { throw new NotFoundException("Board not Found"); }

            _dbContext.boards.Remove(boardToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
