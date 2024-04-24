using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/{userId}/user/workspace/board")]
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
            //return Created($"Workspace created with id:{id}", null);
        }

        [HttpPut("{boardId}")]
        public async Task<IActionResult> EditBoard([Required][FromRoute] int id, Board editedBoard)
        {
            await _boardService.editBoard(id, editedBoard);

            return Ok("Board edited succesfully");
        }

        [HttpDelete("{boardId}")]
        public async Task<IActionResult> DeleteBoard([Required][FromRoute] int id)
        {
            await _boardService.deleteBoard(id);
            return Ok("Board deleted succesfully");
        }
    }
}

