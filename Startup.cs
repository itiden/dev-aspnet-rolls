using Rolls.Models;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Diagnostics.Entity;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;
using Microsoft.Data.Entity;

namespace Rolls
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);
            Configuration = builder.Build();
        }
        
        public IConfiguration Configuration { get; set; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<RollsContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();
            app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Rolls", action = "Index" });
            });
        }
    }
}