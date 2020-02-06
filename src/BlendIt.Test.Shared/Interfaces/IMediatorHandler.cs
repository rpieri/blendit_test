using BlendIt.Test.Shared.Commands;
using MediatR;
using System.Threading.Tasks;

namespace BlendIt.Test.Shared.Interfaces
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommand<TCommand>(TCommand command) where TCommand : IRequest<CommandResult>;
    }
}
