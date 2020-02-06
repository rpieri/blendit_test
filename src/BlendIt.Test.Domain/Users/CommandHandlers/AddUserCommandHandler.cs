using BlendIt.Test.Domain.Users.Commands;
using BlendIt.Test.Domain.Users.Repositories;
using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Handlers;
using BlendIt.Test.Shared.Interfaces;
using BlendIt.Test.Shared.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace BlendIt.Test.Domain.Users.CommandHandlers
{
    public sealed class AddUserCommandHandler : CommandHandler<User, AddUserCommand>
    {
        private readonly IUserRepository repository;

        public AddUserCommandHandler(
            IUserRepository repository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext, 
            IMediatorHandler mediator) : base(unitOfWork, notificationContext, mediator)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await repository.GetUser(request.Email);
            if(userExist != null)
            {
                return await CreateCommandResult(false, $"Ja existe usuario cadastrado com o email {request.Email}");
            }

            var user = new User(request.Email, request.Password);

            return await Commit(user);
        }

        protected async override Task ExecuteCommandDataBase(User entity) => await repository.Add(entity);
    }
}
