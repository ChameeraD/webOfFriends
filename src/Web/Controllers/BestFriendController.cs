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
    public class BestFriendController : ControllerBase
    {

        private readonly IBestFriendService _bestFriendService;

        public BestFriendController(IBestFriendService bestFriendService)
        {
            _bestFriendService = bestFriendService;
        }


        [HttpPost]
        public async Task<ActionResult<BestFriend>> AddAsync([FromBody] BestFriend bestFriend)
        {
            var item = await _bestFriendService.AddAsync(bestFriend);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BestFriend>> GetByIdAsync(Guid id)
        {
            var item = await _bestFriendService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<BestFriend>> GetResultAsync()
        {
            var item = await _bestFriendService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BestFriend>> DeleteBestFriend(Guid id)
        {
            await _bestFriendService.DeleteAsync(id);
            return Ok(id);
        }
    }
}