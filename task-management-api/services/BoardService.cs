using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.board;
using task_management_api.models.list;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for board management services.
    /// This interface specifies methods for board operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface IBoardService
    {
        /// <summary>
        /// Retrieves a collection of boards that a user is a member of within a specific workspace.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>An IEnumerable of Board objects representing all boards the user is a member of within the workspace.</returns>
        Task<IEnumerable<Board>> getBoards(int userId, int workspaceId);

        /// <summary>
        /// Retrieves a specific board by its identifier.
        /// </summary>
        /// <param name="boardId">The unique identifier of the board to retrieve.</param>
        /// <returns>A Board object representing the board with the specified ID.</returns>
        Task<Board> getBoard(int boardId);

        /// <summary>
        /// Creates a new board in a specific workspace and adds the default lists.
        /// </summary>
        /// <param name="incomingBoard">A CreateBoardDto object containing the data for the new board.</param>
        /// <param name="workspaceId">The ID of the workspace where the board will be created.</param>
        /// <param name="userId">The ID of the user creating the board.</param>
        /// <returns>The ID of the newly created board.</returns>
        Task<int> addBoard(CreateBoardDto incomingBoard, int workspaceId, int userId);

        /// <summary>
        /// Edits an existing board's data.
        /// </summary>
        /// <param name="boardId">The unique identifier of the board to edit.</param>
        /// <param name="editedBoard">A Board object containing the updated data for the board.</param>
        Task editBoard(int boardId, BoardDto editedBoard);

        /// <summary>
        /// Deletes a specific board by its identifier.
        /// </summary>
        /// <param name="boardId">The unique identifier of the board to delete.</param>
        Task deleteBoard(int boardId);
    }

    /// <summary>
    /// Service implementation for managing boards.
    /// </summary>
    public class BoardService : IBoardService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
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



            var boards = _dbContext.Boards.Where(w => w.WorkspaceId == workspaceId);

            return boards;
        }

        /// <inheritdoc/>
        public async Task<Board> getBoard(int boardId)
        {
            var board = await _dbContext.Boards
                  .Where(board => board.Id == boardId)
                  .FirstOrDefaultAsync();

            return board;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task editBoard(int boardId, BoardDto editedBoard)
        {

            var boardToEdit = await _dbContext.Boards.FirstAsync(board => board.Id == boardId);

            if (boardToEdit == null && editedBoard == null) { throw new NotFoundException("Board not Found"); }

            boardToEdit.Name = editedBoard.Name;
            boardToEdit.Description = editedBoard.Description;
            boardToEdit.Background = editedBoard.Background;

            _dbContext.Update(boardToEdit);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task deleteBoard(int boardId)
        {

            var boardToDelete = await _dbContext.Boards.FirstAsync(board => board.Id == boardId);

            if (boardToDelete == null) { throw new NotFoundException("Board not Found"); }

            _dbContext.Boards.Remove(boardToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
