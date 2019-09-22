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
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        [HttpPost]
        public async Task<ActionResult<Teacher>> AddAsync([FromBody] Teacher teacher)
        {
            var item = await _teacherService.AddAsync(teacher);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetByIdAsync(Guid id)
        {
            var item = await _teacherService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<Teacher>> GetResultAsync()
        {
            var item = await _teacherService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Teacher>> DeleteTeacher(Guid id)
        {
            await _teacherService.DeleteAsync(id);
            return Ok(id);
        }
    }
}