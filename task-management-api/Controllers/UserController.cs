﻿using Microsoft.AspNetCore.Mvc;
using task_management_api.entities;
using task_management_api.services;
using task_management_api.models.user;
using task_management_api.exceptions;

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

        [HttpPost("login")]
        public async Task<ActionResult> userlogin([FromBody] UserLogInDto user)
        {
            await _userService.LogIn(user);
            return Ok("Succesfull Login");
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> getAll()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> getUserById([FromRoute] int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("register")]
        public ActionResult createUser([FromBody] UserDto dto)
        {
            var id = _userService.CreateUser(dto);

            return Created(string.Empty, $"User created with id:{id}");
        }

        [HttpPut("{id}")]
        public ActionResult EditUser([FromRoute]int id,UserDto dto) 
        {
            _userService.EditUser(id, dto);

            return Ok("User Edited Succesfuly");

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute]int id) 
        { 
            _userService.DeleteUser(id);

            return Ok("User Deleted Succesfuly");
        }
    }
}
