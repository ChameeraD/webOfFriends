using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISurveyClassService : IBaseService<SurveyClass>
    {
        Task<int> CountAsync();
        Task<IReadOnlyList<Student>> GetClassStudents(Guid i);
    }
}
