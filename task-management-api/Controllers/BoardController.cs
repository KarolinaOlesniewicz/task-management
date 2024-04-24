using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/u/{userId}/w/{workspaceId}")]
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet("/boards")]
        public async Task<IActionResult> GetBoards([FromRoute] int userID, [FromRoute] int workspaceID)
        {
            var boards = await _boardService.getBoards(userID, workspaceID);
            return Ok(boards);
        }

        [HttpGet]
        [Route("{boardId}")]
        public async Task<IActionResult> GetBoard([FromRoute] int id)
        {
            var board = await _boardService.getBoard(id);
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard([FromBody] Board incomingBoard)
        {
            var board = await _boardService.addBoard(incomingBoard);
            return Ok(board);
            //return Created($"Workspace created with id:{id}", null);
        }

        [HttpPut("{boardId}")]
        public async Task<IActionResult> EditBoard([FromRoute] int id, Board editedBoard)
        {
            await _boardService.editBoard(id, editedBoard);

            return Ok("Board edited succesfully");
        }

        [HttpDelete("{boardId}")]
        public async Task<IActionResult> DeleteBoard([FromRoute] int id)
        {
            await _boardService.deleteBoard(id);
            return Ok("Board deleted succesfully");
        }
    }
}

