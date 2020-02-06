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
    public class UpdateTeacherCommandHandler : CommandHandler<Teacher, UpdateTeacherCommand>
    {
        private readonly ITeacherRepository repository;

        public UpdateTeacherCommandHandler(
            ITeacherRepository repository,
            IUnitOfWork unitOfWork, 
            NotificationContext notificationContext, 
            IMediatorHandler mediator) : base(unitOfWork, notificationContext, mediator)
        {
            this.repository = repository;
        }

        public override async Task<CommandResult> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = await repository.Get(request.Id);
            if(teacher == null)
            {
                return await CreateCommandResult(false, $"Professor com o Id {request.Id} não foi encontrado");
            }

            if(!teacher.Registration.Equals(request.Registration) && await repository.Exist(request.Registration))
            {
                return await CreateCommandResult(false, $"Matricula {request.Registration} já cadastrada para outro professor");
            }

            teacher.Update(request.Name, request.Registration);
            return await Commit(teacher);
        }

        protected override async Task ExecuteCommandDataBase(Teacher entity) => await repository.Update(entity);
    }
}
