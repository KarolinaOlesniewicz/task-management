using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.services;

namespace task_management_api.Controllers
{
    /// <summary>
    /// API controller for managing boards.
    /// </summary>
    [ApiController]
    [Route("api/u/{userId}/w/{workspaceId}")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardController"/> class.
        /// </summary>
        /// <param name="boardService">The board service.</param>
        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        /// <summary>
        /// Retrieves all boards for a specific user and workspace.
        /// </summary>
        /// <param name="userId">The ID of the user making the request.</param>
        /// <param name="workspaceId">The ID of the workspace containing the boards.</param>
        /// <returns>An <see cref="IActionResult"/> containing a collection of <see cref="Board"/> objects.</returns>
        /// <response code="200">Returns the list of boards.</response>
        [HttpGet("/boards")]
        public async Task<IActionResult> GetBoards([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var boards = await _boardService.getBoards(userId, workspaceId);
            return Ok(boards);
        }

        /// <summary>
        /// Retrieves a specific board by its ID.
        /// </summary>
        /// <param name="boardId">The ID of the board to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the <see cref="Board"/> object.</returns>
        /// <response code="200">Returns the board.</response>
        /// <response code="404">If the board is not found.</response>
        [HttpGet]
        [Route("{boardId}")]
        public async Task<IActionResult> GetBoard([FromRoute] int boardId)
        {
            var board = await _boardService.getBoard(boardId);
            return Ok(board);
        }

        /// <summary>
        /// Adds a new board to a specific workspace.
        /// </summary>
        /// <param name="incomingBoard">The data for the new board.</param>
        /// <param name="userId">The ID of the user making the request.</param>
        /// <param name="workspaceId">The ID of the workspace where the board will be added.</param>
        /// <returns>An <see cref="IActionResult"/> containing the ID of the created board.</returns>
        /// <response code="200">Returns the ID of the created board.</response>
        /// <response code="400">If the incoming data is invalid.</response>
        [HttpPost]
        public async Task<IActionResult> AddBoard([FromBody] CreateBoardDto incomingBoard, [FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var board = await _boardService.addBoard(incomingBoard, workspaceId, userId);
            return Ok(board);
        }

        /// <summary>
        /// Edits an existing board.
        /// </summary>
        /// <param name="boardId">The ID of the board to edit.</param>
        /// <param name="editedBoard">The updated data for the board.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the board was edited successfully.</response>
        /// <response code="404">If the board is not found.</response>
        [HttpPut("{boardId}")]
        public async Task<IActionResult> EditBoard([FromRoute] int boardId, Board editedBoard)
        {
            await _boardService.editBoard(boardId, editedBoard);
            return Ok("Board edited succesfully");
        }

        /// <summary>
        /// Deletes a specific board.
        /// </summary>
        /// <param name="boardId">The ID of the board to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the board was deleted successfully.</response>
        /// <response code="404">If the board is not found.</response>
        [HttpDelete("{boardId}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] int boardId)
        {
            await _boardService.deleteBoard(boardId);
            return Ok("Board deleted succesfully");
        }
    }
}

