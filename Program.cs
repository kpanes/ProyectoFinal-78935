using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using presupuesto_final;
namespace soap_test
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
                .UseUrls($"http://0.0.0.0:{Environment.GetEnvironmentVariable("PORT") ?? "80"}");
    }
}