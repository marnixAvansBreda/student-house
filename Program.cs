using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentHouse.Infrastructure;

namespace StudentHouse
{
    public class Program
    {
        public static IHostingEnvironment HostingEnvironment { get; set; }
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    HostingEnvironment = hostingContext.HostingEnvironment;
                    Configuration = config.Build();
                })
                .ConfigureServices(services =>
                {
                    services.AddMvc(opt =>
                    {
                        opt.Filters.Add(typeof(LinkRewritingFilter));
                    });
                })
                .UseStartup<Startup>();
    }
}
