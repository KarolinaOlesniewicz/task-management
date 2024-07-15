using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_management_api.models.list;
using task_management_api.services;

namespace task_management_api.Controllers
{
    /// <summary>
    /// API controller for managing lists within a board.
    /// </summary>
    [ApiController]
    [Route("api/{userId}/user/{workspaceId}/workspace/boards/{boardId}/lists")]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListController"/> class.
        /// </summary>
        /// <param name="listService">The list service.</param>
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

        /// <summary>
        /// Retrieves all lists for a specific board.
        /// </summary>
        /// <param name="userId">The ID of the user making the request.</param>
        /// <param name="workspaceId">The ID of the workspace containing the board.</param>
        /// <param name="boardId">The ID of the board containing the lists.</param>
        /// <returns>An <see cref="IActionResult"/> containing a collection of <see cref="ListDto"/> objects.</returns>
        /// <response code="200">Returns the list of lists.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListDto>>> GetAllListsForBoard(
            [FromRoute] int userId,
            [FromRoute] int workspaceId,
            [FromRoute] int boardId)
        {
            var results = await _listService.GetAllListsForBoard(userId, workspaceId, boardId);
            return Ok(results);
        }

        /// <summary>
        /// Adds a new list to a specific board.
        /// </summary>
        /// <param name="dto">The data for creating the new list.</param>
        /// <param name="boardId">The ID of the board where the list will be added.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="204">If the list was added successfully.</response>
        [HttpPost]
        public async Task<IActionResult> AddListForBoard([FromBody] CreateListDto dto, [FromRoute] int boardId)
        {
            await _listService.AddListForBoard(dto, boardId);
            return NoContent();
        }

        /// <summary>
        /// Moves a list to a new position within the board.
        /// </summary>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list to move.</param>
        /// <param name="newPosition">The new position index for the list.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the list was moved successfully.</response>
        [HttpPut("{listId}")]
        public async Task<IActionResult> MoveListOnBoard([FromRoute]int boardId, [FromRoute]int listId,int newPosition)
        {
            await _listService.MoveList(boardId, listId, newPosition);
            return Ok();
        }

        /// <summary>
        /// Deletes a specific list from a board.
        /// </summary>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the list was deleted successfully.</response>
        [HttpDelete("{listId}")]
        public async Task<IActionResult> DeleteList([FromRoute] int boardId, [FromRoute] int listId)
        {
            await _listService.DeleteList(boardId,listId);
            return Ok("List Deleted Succesfully");
        }

        /// <summary>
        /// Changes the name of a specific list.
        /// </summary>
        /// <param name="boardId">The ID of the board containing the list.</param>
        /// <param name="listId">The ID of the list to rename.</param>
        /// <param name="name">The new name for the list.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
        /// <response code="204">If the list name was changed successfully.</response>
        [HttpPut("{listId}/{name}")]
        public async Task<IActionResult> ChangeListName([FromRoute] int boardId, [FromRoute] int listId,[FromRoute]string name)
        {
            await _listService.ChangeListName(boardId, listId, name);
            return NoContent();
        }
    }
}
