using BlendIt.Test.API.Configurations;
using BlendIt.Test.API.Filters;
using BlendIt.Test.API.Settings;
using BlendIt.Test.CrossCutting.IoC;
using BlendIt.Test.Repository.Contexts;
using BlendIt.Test.Services.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlendIt.Test.API
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
            APISettings.Title = this.configuration["Application"];
            APISettings.Version = this.configuration["Version"];
            APISettings.Description = this.configuration["Description"];
            APISettings.ContactName = this.configuration["ContactName"];
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AdicionarSwagger();
            services.AdicionarCors();
            services.InitializeServices();

            services.AddResponseCompression();
            services.AddMediatR(typeof(Startup));

            services.AddAuthentications();

            services.AddHealthChecks();

            services.AddControllers(c =>
            {
                c.Filters.Add<NotificationViewModelFilter>();
                c.Filters.Add<NotificationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, EntityContext entityContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            entityContext.ExecuteMigrate();

            app.UsarCors();
            app.UsarSwagger();

            app.UseRouting();

            app.UseAuthentications();


            app.UseHealthChecks("/health");
            app.UseResponseCompression();

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
