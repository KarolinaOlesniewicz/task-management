using Microsoft.AspNetCore.Mvc;
using task_management_api.entities;
using task_management_api.services;
using task_management_api.models.user;

namespace task_management_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> getAll()
        {
            var users = _userService.GetAllUsers();
            if (users.Count() == 0)
            {
                return NotFound("No users found");
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> getUserById([FromRoute] int id)
        {
            var user = _userService.GetById(id);
            if (user is null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult createUser([FromBody] UserDto dto)
        {
            var id = _userService.CreateUser(dto);

            return Created($"User created with id:{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult EditUser([FromRoute]int id,UserDto dto) 
        {
            var actionDone = _userService.EditUser(id, dto);
            if(!actionDone) { return NotFound("User not found"); } 
            return Ok("User Edited Succesfuly");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute]int id) 
        { 
            var isDeleted = _userService.DeleteUser(id);
            if(!isDeleted) { return NotFound("User not found"); } 
            return Ok("User Deleted Succesfuly");
        }

    }
}
