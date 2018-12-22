using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentHouse.Infrastructure;
using StudentHouse.Services;

namespace StudentHouse
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddAutoMapper();
            Mapper.Initialize(cfg =>
                cfg.AddProfile<DefaultAutomapperProfile>()
            );
            
            // Services that consume EF Core objects (DbContext) should be registered as Scoped
            // (see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection#registering-your-own-services)
            services.AddScoped<IStudentService, DefaultStudentService>();
            services.AddScoped<IMealService, DefaultMealService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           app.UseMvc();
        }
    }
}
