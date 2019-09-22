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
    public class SurveyController : ControllerBase
    {

        private readonly ISurveyService _surveyService;


        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }


        [HttpPost]
        public async Task<ActionResult<Survey>> AddAsync([FromBody] Survey survey)
        {
            var item = await _surveyService.AddAsync(survey);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetByIdAsync(Guid id)
        {
            var item = await _surveyService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<Survey>> GetResultAsync()
        {
            var item = await _surveyService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Survey>> DeleteSurvey(Guid id)
        {
            await _surveyService.DeleteAsync(id);
            return Ok(id);
        }
    }
}