using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Interfaces;
using MediatR;
using System.Threading.Tasks;

namespace BlendIt.Test.Shared.Handlers
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<CommandResult> SendCommand<TCommand>(TCommand command) where TCommand : IRequest<CommandResult> => await mediator.Send(command);
    }
}
