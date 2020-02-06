using BlendIt.Test.Shared.Commands;
using System;

namespace BlendIt.Test.Domain.Teachers.Commands
{
    public sealed class RemoveTeacherCommand : Command
    {
        public Guid Id { get; private set; }

        public RemoveTeacherCommand(Guid id)
        {
            Id = id;
        }
    }
}
