using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace AsdaPricingAdministrationTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5059");

    }
    //public class IISServerOptions
    //{
    //    public IServiceProvider ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)=>
    //    services.Configure<IISServerOptions>(options =>
    //{
    //    options.AutomaticAuthentication = false;
    //});

    //}
}
