using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Services;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyClassController : ControllerBase
    {

        private readonly ISurveyClassService _surveyClassService;

        public SurveyClassController(ISurveyClassService surveyClassService)
        {
            _surveyClassService = surveyClassService;
        }


        [HttpPost]
        public async Task<ActionResult<SurveyClass>> AddAsync([FromBody] SurveyClass surveyClass)
        {
            var item = await _surveyClassService.AddAsync(surveyClass);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyClass>> GetByIdAsync(Guid id)
        {
            var item = await _surveyClassService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<SurveyClass>> GetResultAsync()
        {
            var item = await _surveyClassService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SurveyClass>> DeleteSurveyClass(Guid id)
        {
            await _surveyClassService.DeleteAsync(id);
            return Ok(id);
        }

        [HttpGet("studentsByClass/{id}")]
        public async Task<ActionResult<SurveyClass>> GetClassStudents(Guid id)
        {
            var item = await _surveyClassService.GetClassStudents(id);
            return Ok(item);
        }

    }
}