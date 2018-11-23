using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using PlayersApi.Features.Players.Get;
using PlayersApi.Swagger;
using System;
using System.Reflection;
using PlayersApi.Pipeline;

[assembly: ApiConventionType(typeof(MyApiConventions))]
namespace PlayersApi {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IPlayersRepository, PlayersRepository>();
            services.AddHealthChecks().AddCheck<MyHealthCheck>("MyHealthCheck");
            services.AddSwagger();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHttpClient<IBadgesClient, BadgesClient>((s, c) => {
                c.BaseAddress = new Uri("http://localhost:5500");
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseExceptionHandler(new ExceptionHandlerOptions {
                ExceptionHandler = new ErrorHandlerMiddleware(env).Invoke
            });
            app.UseHealthChecks("/hc");
            app.UseSwaggerUi3WithApiExplorer();
            app.UseMvc();
        }
    }
}
