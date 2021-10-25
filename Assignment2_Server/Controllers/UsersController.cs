﻿using System;
using System.Threading.Tasks;
using Assignment1.Data;
using Assignment2_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment2_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromBody] string userName, [FromBody] string password)
        {
            try
            {
                User validateUser = await _userService.ValidateUser(userName, password);
                return Ok(validateUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] User user)
        {
            try
            {
                User added = await _userService.AddUser(user);
                return Ok(added);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}