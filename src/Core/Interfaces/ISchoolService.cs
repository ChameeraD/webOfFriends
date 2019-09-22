using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISchoolService : IBaseService<School>
    {
        Task<int> CountAsync();

        Task<School> GetByDomainAsync(string domain);
    }
}
