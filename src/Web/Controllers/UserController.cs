using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<ActionResult<User>> AddAsync([FromBody] User user)
        {
            var item = await _userService.AddAsync(user);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(Guid id)
        {
            var item = await _userService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetResultAsync()
        {
            var item = await _userService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok(id);
        }
    }
}