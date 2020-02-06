using MediatR;

namespace BlendIt.Test.Shared.Commands
{
    public abstract class Command : IRequest<CommandResult>
    {
    }
}
