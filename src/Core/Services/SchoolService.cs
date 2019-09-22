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

namespace Core.Services
{

    public class SchoolService : BaseService<School>, ISchoolService
    {

        public SchoolService(
            ApplicationDbContext db, 
            IConfiguration configuration, 
            ILogger<SchoolService> logger) 
            : base(db, configuration, logger) { }

        public async Task<int> CountAsync()
        {
            return await _db.Schools.CountAsync();
        }

        public async Task<School> GetByDomainAsync(string domain)
        {
            return await _db.Schools.FirstOrDefaultAsync(s => s.Domain == domain);
        }
    }
}
