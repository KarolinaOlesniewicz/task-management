using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_management_api.models.list;
using task_management_api.services;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/{userId}/user/{workspaceId}/workspace/boards/{boardId}/lists")]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;
        public ListController(IListService listService)
        {
            _listService = listService;
        }

        //[HttpGet]
        //public async Task<ActionResult<ICollection<ListDto>>> GetAllListsForBoard
        //    ([FromRoute]int userId,[FromRoute]int workspaceId,[FromRoute]int boardId)
        //{
        //    var results = await _listService.GetAllListsForBoard(userId, workspaceId, boardId);
        //    return Ok(results);
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListDto>>> GetAllListsForBoard(
            [FromRoute] int userId,
            [FromRoute] int workspaceId,
            [FromRoute] int boardId)
        {
            var results = await _listService.GetAllListsForBoard(userId, workspaceId, boardId);
            return Ok(results);
        }

        [HttpPost]

        public async Task<IActionResult> AddListForBoard([FromBody] CreateListDto dto, [FromRoute] int boardId)
        {
            await _listService.AddListForBoard(dto, boardId);
            return NoContent();
        }

        [HttpPut("{listId}")]
        public async Task<IActionResult> MoveListOnBoard([FromRoute]int boardId, [FromRoute]int listId,int newPosition)
        {
            await _listService.MoveList(boardId, listId, newPosition);
            return Ok();
        }

        [HttpDelete("{listId}")]
        public async Task<IActionResult> DeleteList([FromRoute] int boardId, [FromRoute] int listId)
        {
            await _listService.DeleteList(boardId,listId);
            return Ok("List Deleted Succesfully");
        }

        [HttpPut("{listId}/{name}")]
        public async Task<IActionResult> ChangeListName([FromRoute] int boardId, [FromRoute] int listId,[FromRoute]string name)
        {
            await _listService.ChangeListName(boardId, listId, name);
            return NoContent();
        }
    }
}
