using BlendIt.Test.Domain.Users;
using BlendIt.Test.Domain.Users.Repositories;
using BlendIt.Test.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlendIt.Test.Repository.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly EntityContext context;
        private DbSet<User> dbSet;

        public UserRepository(EntityContext context)
        {
            this.context = context;
            dbSet = this.context.Set<User>();
        }
        public async Task Add(User user)
            => await dbSet.AddAsync(user);

        public async Task<User> GetAsync(string email, string password)
            => await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password) && !x.Removed);

        public async Task<User> GetAsync(Guid id) => await dbSet.FirstOrDefaultAsync(x => x.Id == id && !x.Removed);

        public async Task<User> GetUser(string email) => await dbSet.FirstOrDefaultAsync(x => x.Email.Equals(email) && !x.Removed);


        public async Task Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await Task.Run(() => dbSet.Update(user));
        }
    }
}
