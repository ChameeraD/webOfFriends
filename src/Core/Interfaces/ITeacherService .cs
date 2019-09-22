using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITeacherService : IBaseService<Teacher>
    {
        Task<int> CountAsync(); 
    }
}
