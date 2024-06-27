using Microsoft.AspNetCore.Mvc;
using task_management_api.entities;
using task_management_api.services;
using task_management_api.models.user;
using task_management_api.exceptions;

namespace task_management_api.Controllers
{
    /// <summary>
    /// Controller for managing users.
    /// </summary>
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service to handle business logic.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="user">The login data for the user.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the login was successful.</response>
        /// <response code="401">If the login credentials are invalid.</response>
        [HttpPost("login")]
        public async Task<ActionResult> userlogin([FromBody] UserLogInDto user)
        {
            await _userService.LogIn(user);
            return Ok("Succesfull Login");
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        /// <response code="200">If the users were retrieved successfully.</response>
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> getAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }


        /// <summary>
        /// Retrieves a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID.</returns>
        /// <response code="200">If the user was found.</response>
        /// <response code="404">If the user with the specified ID is not found.</response>
        [HttpGet("{id}")]
        public ActionResult<UserDto> getUserById([FromRoute] int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="dto">The data to create the user.</param>
        /// <returns>A response indicating success and the location of the created user.</returns>
        /// <response code="201">If the user was created successfully.</response>
        [HttpPost("register")]
        public ActionResult createUser([FromBody] UserDto dto)
        {
            var id = _userService.CreateUser(dto);

            return Created(string.Empty, $"User created with id:{id}");
        }

        /// <summary>
        /// Edits an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to edit.</param>
        /// <param name="dto">The updated user data.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the user was edited successfully.</response>
        /// <response code="404">If the user with the specified ID is not found.</response>
        [HttpPut("{id}")]
        public ActionResult EditUser([FromRoute]int id,UserDto dto) 
        {
            _userService.EditUser(id, dto);

            return Ok("User Edited Succesfuly");

        }

        /// <summary>
        /// Deletes a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>An <see cref="ActionResult"/> indicating the result of the operation.</returns>
        /// <response code="200">If the user was deleted successfully.</response>
        /// <response code="404">If the user with the specified ID is not found.</response>
        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute]int id) 
        { 
            _userService.DeleteUser(id);

            return Ok("User Deleted Succesfuly");
        }
    }
}
