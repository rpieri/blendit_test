using BlendIt.Test.Domain.Teachers;
using BlendIt.Test.Domain.Teachers.Repositories;
using BlendIt.Test.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlendIt.Test.Repository.Repositories
{
    public sealed class TeacherRepository : ITeacherRepository
    {
        private readonly EntityContext context;
        private DbSet<Teacher> dbSet;

        public TeacherRepository(EntityContext context)
        {
            this.context = context;
            dbSet = this.context.Set<Teacher>();
        }
        public async Task Add(Teacher teacher) => await dbSet.AddAsync(teacher);

        public async Task<bool> Exist(string registration) => await dbSet.AnyAsync(x => x.Registration.Equals(registration) && !x.Removed);

        public async Task<Teacher> Get(Guid id) => await dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.Removed);

        public async Task<IEnumerable<Teacher>> Get() => await dbSet.Where(x => !x.Removed).ToListAsync();

        public async Task Update(Teacher teacher)
        {
            context.Entry(teacher).State = EntityState.Modified;
            await Task.Run(() => dbSet.Update(teacher));
        }
    }
}
