using BlendIt.Test.Domain.Users.Commands;
using BlendIt.Test.Domain.Users.Repositories;
using BlendIt.Test.Domain.Users.Services;
using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlendIt.Test.Domain.Users.CommandHandlers
{
    public sealed class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, CommandResult>
    {
        private readonly IUserRepository repository;
        private readonly ITokenService tokenService;

        public AuthenticationCommandHandler(
            IUserRepository repository,
            ITokenService tokenService)
        {
            this.repository = repository;
            this.tokenService = tokenService;
        }
        public async Task<CommandResult> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            var user = await repository.GetAsync(request.Email, request.Password);
            if(user == null)
            {
                return new CommandResult(false, "Email ou Password inválidos");
            }

            var token = tokenService.GenerateToken(user);
            return new CommandResult(true,"Token gerado com sucesso", token);
        }
    }
}
