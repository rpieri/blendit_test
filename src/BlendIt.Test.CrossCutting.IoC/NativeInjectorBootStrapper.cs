using BlendIt.Test.Domain.Teachers.CommandHandlers;
using BlendIt.Test.Domain.Teachers.Commands;
using BlendIt.Test.Domain.Teachers.Repositories;
using BlendIt.Test.Domain.Users.CommandHandlers;
using BlendIt.Test.Domain.Users.Commands;
using BlendIt.Test.Domain.Users.Repositories;
using BlendIt.Test.Domain.Users.Services;
using BlendIt.Test.Repository.Contexts;
using BlendIt.Test.Repository.Repositories;
using BlendIt.Test.Repository.UoW;
using BlendIt.Test.Services.Authenticate;
using BlendIt.Test.Shared.Commands;
using BlendIt.Test.Shared.Handlers;
using BlendIt.Test.Shared.Interfaces;
using BlendIt.Test.Shared.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlendIt.Test.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddDbContext<EntityContext>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<NotificationContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<IRequestHandler<AddUserCommand, CommandResult>, AddUserCommandHandler>();
            services.AddScoped<IRequestHandler<AuthenticationCommand, CommandResult>, AuthenticationCommandHandler>();
            services.AddScoped<IRequestHandler<AddTeacherCommand, CommandResult>, AddTeacherCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTeacherCommand, CommandResult>, UpdateTeacherCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTeacherCommand, CommandResult>, RemoveTeacherCommandHandler>();


            services.AddScoped<ITokenService, TokenService>();

            
        }
    }
}
