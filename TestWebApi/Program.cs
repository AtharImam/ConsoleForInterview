using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TestWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureServices((context, services) =>
             {
                 //services.Configure<KestrelServerOptions>(context.Configuration.GetSection("Kestrel"));
             })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options =>
                    {
                        
                    });
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.Http2.HeaderTableSize = 4096;
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
