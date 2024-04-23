using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.models.board;

namespace task_management_api.services
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> getBoards(int userID, int workspaceID);
        Task<Board> getBoard(int boardID);
        Task<string> addBoard(Board incomingBoard);
        Task<string> editBoard(int boardID, Board editedBoard);
        Task<string> deleteBoard(int boardID);
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
                .Include(board => board.Name)
                .Include(board => board.Description)
                .Include(board => board.Background)
                .Where(board => board.Id == boardID)
                .FirstOrDefaultAsync();

            return board;
        }

        public async Task<string> addBoard(Board incomingBoard)
        {
            try
            {
                if (incomingBoard != null)
                {
                    var newBoard = new Board()
                    {
                        Name = incomingBoard.Name,
                        Description = incomingBoard.Description,
                        Background = incomingBoard.Background
                        // ...
                    };

                    await _dbContext.boards.AddAsync(newBoard);
                    await _dbContext.SaveChangesAsync();

                    return "board added";
                }
                else
                    return "invalid input data";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> editBoard(int boardID, Board editedBoard)
        {
            try
            {
                var boardToEdit = await _dbContext.boards.FirstAsync(board => board.Id == boardID);
                
                if (boardToEdit != null && editedBoard != null)
                {
                    boardToEdit.Name = editedBoard.Name;
                    boardToEdit.Description = editedBoard.Description;
                    boardToEdit.Background = editedBoard.Background;

                    return "board edited";
                }
                else
                    return "board not found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> deleteBoard(int boardID)
        {
            try
            {
                var boardToDelete = await _dbContext.boards.FirstAsync(board => board.Id == boardID);

                if (boardToDelete != null)
                {
                    _dbContext.boards.Remove(boardToDelete);
                    await _dbContext.SaveChangesAsync();
                    return "board deleted";
                }
                else
                    return "board not found";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
