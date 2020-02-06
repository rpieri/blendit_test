using System;
using System.Threading.Tasks;

namespace BlendIt.Test.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(string email, string password);
        Task<User> GetUser(string email);
        Task<User> GetAsync(Guid id);
        Task Add(User user);
        Task Update(User user);
    }
}
