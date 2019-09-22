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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpPost]
        public async Task<ActionResult<Student>> AddAsync([FromBody] Student student)
        {
            var item = await _studentService.AddAsync(student);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetByIdAsync(Guid id)
        {
            var item = await _studentService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<Student>> GetResultAsync()
        {
            var item = await _studentService.ListAllAsync();
            System.Diagnostics.Debug.WriteLine("GET" + item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(Guid id)
        {
            await _studentService.DeleteAsync(id);
            return Ok(id);
        }
    }
}