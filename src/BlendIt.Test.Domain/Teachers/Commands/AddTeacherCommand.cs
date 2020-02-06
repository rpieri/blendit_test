using BlendIt.Test.Shared.Commands;

namespace BlendIt.Test.Domain.Teachers.Commands
{
    public sealed class AddTeacherCommand : Command
    {
        public string Name { get; private set; }
        public string Registration { get; private set; }

        public AddTeacherCommand(string name, string registration)
        {
            Name = name;
            Registration = registration;
        }
    }
}
