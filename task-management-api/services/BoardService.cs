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
        Task<IEnumerable<Board>> getBoards(int userID, int workspaceID);
        Task<Board> getBoard(int boardID);
        Task<int> addBoard(CreateBoardDto incomingBoard, int workspaceID, int userID);
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
                        .Include(b => b.BoardMembers) // Załaduj powiązane boardMembers
                        .Where(b => b.BoardMembers.Any(bm => bm.UserId == userID) && b.WorkspaceId == workspaceID)
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

        public async Task<int> addBoard(CreateBoardDto incomingBoard, int workspaceID, int userID)
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

            var targetWorkspace = await _dbContext.workspaces.Include(w => w.Boards)
                .FirstOrDefaultAsync(w => w.Id == workspaceID);

            if (targetWorkspace is null) throw new NotFoundException("workspace not found");

            var newBoard = new Board()
            {
                Name = incomingBoard.Name,
                Description = incomingBoard.Description,
                Background = incomingBoard.Background,
                WorkspaceId = workspaceID,              
                //Workspace = _dbContext.workspaces.Where(work => work.Id == workspaceID).FirstOrDefault()
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
