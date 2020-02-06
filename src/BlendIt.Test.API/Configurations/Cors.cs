using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlendIt.Test.API.Configurations
{
    internal static class Cors
    {
        public const string POLICY_NAME = "inlog_interno_operacao_campo_back_policy";

        public static void AdicionarCors(this IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddPolicy(POLICY_NAME, policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static void UsarCors(this IApplicationBuilder app) => app.UseCors(POLICY_NAME);
    }
}
