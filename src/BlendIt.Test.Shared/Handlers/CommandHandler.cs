using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Interfaces;
using BlendIt.Test.Shared.Models;
using BlendIt.Test.Shared.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlendIt.Test.Shared.Handlers
{
    public abstract class CommandHandler<TEntity, TCommand> : IRequestHandler<TCommand, CommandResult> where TEntity : Entity where TCommand : Command
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly NotificationContext notificationContext;
        private readonly IMediatorHandler mediator;

        public CommandHandler(IUnitOfWork unitOfWork, NotificationContext notificationContext, IMediatorHandler mediator)
        {
            this.unitOfWork = unitOfWork;
            this.notificationContext = notificationContext;
            this.mediator = mediator;
        }


        protected bool Invalid(TEntity entity)
        {
            if (entity.Invalid)
            {
                notificationContext.AddNotification(entity.ValidationResult);
                return true;
            }
            return false;
        }
        protected async Task<CommandResult> Commit(TEntity entity)
        {
            if (Invalid(entity))
            {
                return null;
            }

            await ExecuteCommandDataBase(entity);

            if (await unitOfWork.Commit())
            {
                return await CreateCommandResult(true, "Comando foi executado com sucesso", entity.Code);
            }

            return await CreateCommandResult(false, $"{entity.ToString()} ocorreu um erro ao persistir a entidade");
        }
        protected Task<CommandResult> CreateCommandResult(bool success) => Task.FromResult(new CommandResult(success));
        protected Task<CommandResult> CreateCommandResult(bool success, string message) => Task.FromResult(new CommandResult(success, message));
        protected Task<CommandResult> CreateCommandResult(bool success, object data) => Task.FromResult(new CommandResult(success, data));
        protected Task<CommandResult> CreateCommandResult(bool success, string message, object data) => Task.FromResult(new CommandResult(success, message, data));
        protected async Task<CommandResult> SendCommand(Command command) => await mediator.SendCommand(command);


        public abstract Task<CommandResult> Handle(TCommand request, CancellationToken cancellationToken);

        protected abstract Task ExecuteCommandDataBase(TEntity entity);
    }
}
