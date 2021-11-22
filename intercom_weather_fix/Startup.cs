using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Net;

namespace intercom_weather_fix
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    string Data = System.IO.File.ReadAllLines(System.IO.Path.Combine(env.WebRootPath, "Location.txt"), Encoding.UTF8)[0];
                    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET");
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    //context.Response.Headers.Add("CF-RAY", "65b4b1597e5a2486-KBP");
                    //context.Response.Headers.Add("cf-request-id", "0a84cd2bed00002486848f3000000001");
                    context.Response.Headers.Add("Connection", "close");
                    context.Response.Headers.Add("Content-Length", Data.Length.ToString());
                    context.Response.Headers.Add("Content-Type", "text/plain");
                    //context.Response.Headers.Add("X-OTTER", "🦦");
                    context.Response.Headers.Add("X-RTFM", "Learn about this site at http://bit.ly/icanhazip-faq");
                    context.Response.Headers.Add("X-THANK-YOU", "Many thanks to the fine people at Cloudflare for keeping this site afloat!");
                    await context.Response.WriteAsync(Data); //"Kiev"/*"92.244.125.221"*/
                });            
            });
        }
    }
}


//need rename http://icanhazip.com/