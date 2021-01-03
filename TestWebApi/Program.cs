using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                //.UseContentRoot(Directory.GetCurrentDirectory())
                //.UseEnvironment("Development")
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             //.ConfigureServices((context, services) =>
             //{
             //    //services.Configure<KestrelServerOptions>(context.Configuration.GetSection("Kestrel"));
             //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel(options =>
                    //{
                        
                    //});
                    //webBuilder.ConfigureKestrel(serverOptions =>
                    //{
                    //    serverOptions.Limits.Http2.HeaderTableSize = 4096;
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
