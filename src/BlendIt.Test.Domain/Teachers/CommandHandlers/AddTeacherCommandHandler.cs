using BlendIt.Test.Domain.Teachers.Commands;
using BlendIt.Test.Domain.Teachers.Repositories;
using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Handlers;
using BlendIt.Test.Shared.Interfaces;
using BlendIt.Test.Shared.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace BlendIt.Test.Domain.Teachers.CommandHandlers
{
    public sealed class AddTeacherCommandHandler : CommandHandler<Teacher, AddTeacherCommand>
    {
        private readonly ITeacherRepository repository;

        public AddTeacherCommandHandler(
            ITeacherRepository repository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext, 
            IMediatorHandler mediator) : base(unitOfWork, notificationContext, mediator)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            if(await repository.Exist(request.Registration))
            {
                return await CreateCommandResult(false, $"Ja foi criado um professor com essa matricula {request.Registration}");
            }

            var teacher = new Teacher(request.Name, request.Registration);

            return await Commit(teacher);
        }

        protected override async Task ExecuteCommandDataBase(Teacher entity) => await repository.Add(entity);
    }
}
