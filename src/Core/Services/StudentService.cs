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

    public class StudentService : BaseService<Student>, IStudentService
    {

        public StudentService(
            ApplicationDbContext db, 
            IConfiguration configuration, 
            ILogger<StudentService> logger) 
            : base(db, configuration, logger) { }

        public async Task<int> CountAsync()
        {
            return await _db.Students.CountAsync();
        }
    }
}
