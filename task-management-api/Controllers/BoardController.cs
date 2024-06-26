using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/u/{userId}/w/{workspaceId}")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("/boards")]
        public async Task<IActionResult> GetBoards([FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var boards = await _boardService.getBoards(userId, workspaceId);
            return Ok(boards);
        }

        [HttpGet]
        [Route("{boardId}")]
        public async Task<IActionResult> GetBoard([FromRoute] int boardId)
        {
            var board = await _boardService.getBoard(boardId);
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard([FromBody] CreateBoardDto incomingBoard, [FromRoute] int userId, [FromRoute] int workspaceId)
        {
            var board = await _boardService.addBoard(incomingBoard, workspaceId, userId);
            return Ok(board);
            //return Created($"Workspace created with id:{id}", null);
        }

        [HttpPut("{boardId}")]
        public async Task<IActionResult> EditBoard([FromRoute] int boardId, Board editedBoard)
        {
            await _boardService.editBoard(boardId, editedBoard);

            return Ok("Board edited succesfully");
        }

        [HttpDelete("{boardId}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] int boardId)
        {
            await _boardService.deleteBoard(boardId);
            return Ok("Board deleted succesfully");
        }
    }
}

