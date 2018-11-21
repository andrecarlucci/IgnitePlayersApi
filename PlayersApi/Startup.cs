using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using PlayersApi.Swagger;

[assembly: ApiConventionType(typeof(MyApiConventions))]
namespace PlayersApi {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IPlayersRepository, PlayersRepository>();
            services.AddHealthChecks().AddCheck<MyHealthCheck>("MyHealthCheck");
            services.AddSwagger();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseHealthChecks("/hc");
            app.UseSwaggerUi3WithApiExplorer();
            app.UseMvc();
        }
    }
}
