using Core.Data;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Core.Services
{

    public class SurveyClassService : BaseService<SurveyClass>, ISurveyClassService
    {

        public SurveyClassService(
            ApplicationDbContext db, 
            IConfiguration configuration, 
            ILogger<SurveyClassService> logger) 
            : base(db, configuration, logger) { }

        public async Task<int> CountAsync()
        {
            return await _db.SurveyClasses.CountAsync();
        }

        public async Task<IReadOnlyList<Student>> GetClassStudents(Guid id)
        {
            var result = (from d in _db.Students
            join f in _db.SurveyClasses
            on d.SchoolClassId equals f.SchoolClassId
            where f.SurveryId==id
            select d).ToList();
            return result;
        }

        /*
        var robotDogs = (from d in context.RobotDogs
        join f in context.RobotFactories
        on d.RobotFactoryId equals f.RobotFactoryId
        where f.Location == "Texas"
        select d).ToList();
        */

    }
}
