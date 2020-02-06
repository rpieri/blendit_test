using BlendIt.Test.Shared.Commands;
using System;

namespace BlendIt.Test.Domain.Teachers.Commands
{
    public sealed class UpdateTeacherCommand : Command
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Registration { get; private set; }

        public UpdateTeacherCommand(Guid id, string name, string registration)
        {
            Id = id;
            Name = name;
            Registration = registration;
        }
    }
}
