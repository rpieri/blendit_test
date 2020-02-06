using BlendIt.Test.Shared.Commands;

namespace BlendIt.Test.Domain.Users.Commands
{
    public sealed class AuthenticationCommand : Command
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public AuthenticationCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
