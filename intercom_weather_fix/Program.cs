using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace intercom_weather_fix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseWebRoot("wwwroot")
                        .UseStartup<Startup>();
                });
    }
}
