using BlendIt.Test.Shared.Commands;

namespace BlendIt.Test.Domain.Users.Commands
{
    public sealed class AddUserCommand : Command
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public AddUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
