using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/{userId}/user/board")]
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;


        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBoards([FromRoute] int userID, [FromRoute] int workspaceID)
        {
            var boards = await _boardService.getBoards(userID, workspaceID);
            return Ok(boards);
        }

        [HttpGet("{boardId}")]
        public async Task<IActionResult> GetBoard([Required][FromRoute] int id)
        {
            var board = await _boardService.getBoard(id);
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> AddBoard([FromBody]Board incomingBoard)
        {
            var board = await _boardService.addBoard(incomingBoard);
            return Ok(board);
        }

        [HttpPut]
        public async Task<IActionResult> EditBoard([Required][FromRoute] int id, Board editedBoard)
        {
            var boardEditedError = await _boardService.editBoard(id, editedBoard);
            if (boardEditedError == "board edited")
                return Ok(boardEditedError);
            else
                return BadRequest(boardEditedError);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBoard([Required][FromRoute] int id)
        {
            var boardDeletedError = await _boardService.deleteBoard(id);
            if (boardDeletedError == "board deleted")
                return Ok(boardDeletedError);
            else
                return BadRequest(boardDeletedError);
        }
    }
}

