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
    public class SchoolController : ControllerBase
    {

        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }


        [HttpPost]
        public async Task<ActionResult<School>> AddAsync([FromBody] School schoolAdmin)
        {
            var item = await _schoolService.AddAsync(schoolAdmin);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetByIdAsync(Guid id)
        {
            var item = await _schoolService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<School>> GetResultAsync()
        {
            var item = await _schoolService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<School>> DeleteSchoolAdmin(Guid id)
        {
            await _schoolService.DeleteAsync(id);
            return Ok(id);
        }
    }
}