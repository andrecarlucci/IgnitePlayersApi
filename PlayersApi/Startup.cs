using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PlayersApi {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IPlayersRepository, PlayersRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseMvc();
        }
    }
}
