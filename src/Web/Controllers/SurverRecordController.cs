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
    [EnableCors("AllowSpecificOrigin")]

    public class SurveyRecordController : ControllerBase
    {

        private readonly ISurveyRecordService _surveyRecordService;

        public SurveyRecordController(ISurveyRecordService surveyRecordService)
        {
            _surveyRecordService = surveyRecordService;
        }


        [HttpPost]
        public async Task<ActionResult<SurveyRecord>> AddAsync([FromBody] SurveyRecord surveyRecord)
        {
            var item = await _surveyRecordService.AddAsync(surveyRecord);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = item.Id }, item);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyRecord>> GetByIdAsync(Guid id)
        {
            var item = await _surveyRecordService.GetByIdAsync(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<SurveyRecord>> GetResultAsync()
        {
            var item = await _surveyRecordService.ListAllAsync();
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SurveyRecord>> DeleteSurveyRecord(Guid id)
        {
            await _surveyRecordService.DeleteAsync(id);
            return Ok(id);
        }
    }
}