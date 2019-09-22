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
    public class SchoolClassController : ControllerBase
    {

        private readonly ISchoolClassService _schoolClassService;

        public SchoolClassController(ISchoolClassService schoolClassService)
        {
            _schoolClassService = schoolClassService;
        }


        [HttpPost]
        public async Task<ActionResult<SchoolClass>> AddAsync([FromBody] SchoolClass schoolClass)
        {
            var item = await _schoolClassService.AddAsync(schoolClass);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolClass>> GetByIdAsync(Guid id)
        {
            var item = await _schoolClassService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<SchoolClass>> GetResultAsync()
        {
            var item = await _schoolClassService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SchoolClass>> DeleteSchoolClass(Guid id)
        {
            await _schoolClassService.DeleteAsync(id);
            return Ok(id);
        }
    }
}