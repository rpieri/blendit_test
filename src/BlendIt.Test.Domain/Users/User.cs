using BlendIt.Test.Domain.Users.Validations;
using BlendIt.Test.Shared.Models;

namespace BlendIt.Test.Domain.Users
{
    public class User : Entity
    {
        public User(string email, string password)
        {
            Update(email, password);
        }

        public string Email { get; private set; }
        public string Password { get; private set; }

        public void Update(string username, string password)
        {
            Email = username;
            Password = password;
            Validate(this, new UserValidator());
        }
    }
}
