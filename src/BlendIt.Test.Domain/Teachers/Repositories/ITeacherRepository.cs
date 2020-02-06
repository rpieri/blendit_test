using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlendIt.Test.Domain.Teachers.Repositories
{
    public interface ITeacherRepository
    {
        Task<bool> Exist(string registration);
        Task<Teacher> Get(Guid id);
        Task<IEnumerable<Teacher>> Get();
        Task Add(Teacher teacher);
        Task Update(Teacher teacher);

    }
}
