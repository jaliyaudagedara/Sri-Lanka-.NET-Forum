using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebApiOverview
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(o => o.UseSqlServer("Data Source=.;Database=AspNetCoreWebApiOverview;Integrated Security=True"));

            services.AddMvc();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            /* centralized routing */
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("Get", "api/{controller=Employees}/{action=Get}/{id?}");
            //    routes.MapRoute("GetById", "api/{controller}/{id}",
            //        defaults: new { controller = "Employees", action = "GetById" },
            //        constraints: new { id = new IntRouteConstraint() });
            //});

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
