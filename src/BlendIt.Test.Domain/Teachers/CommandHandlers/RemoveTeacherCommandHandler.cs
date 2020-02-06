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
    public class RemoveTeacherCommandHandler : CommandHandler<Teacher, RemoveTeacherCommand>
    {
        private readonly ITeacherRepository repository;

        public RemoveTeacherCommandHandler(
            ITeacherRepository repository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext, 
            IMediatorHandler mediator) : base(unitOfWork, notificationContext, mediator)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(RemoveTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await repository.Get(request.Id);
            if(teacher == null)
            {
                return await CreateCommandResult(false, $"Professor com o Id {request.Id} não foi encontrado");
            }

            teacher.Remove();
            return await Commit(teacher);
        }

        protected override async Task ExecuteCommandDataBase(Teacher entity) => await repository.Update(entity);
    }
}
