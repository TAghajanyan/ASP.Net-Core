using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace _002_Routing
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
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            IRouteBuilder routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("{controller}=home/{action}", async context =>
            {
                await context.Response.WriteAsync("controller/Action");
            });

            routeBuilder.MapRoute("Test/{action}/{id?}", async context =>
             {
                 await context.Response.WriteAsync("Test/Action/id?");
             });

            routeBuilder.MapRoute("{controller}/{action}/{*catchall}", async context =>
            {
                await context.Response.WriteAsync($"controller/action/");
                foreach (var item in context.Request.Path.Value.Split("/").Skip(3))
                {
                    await context.Response.WriteAsync($"{item}/");
                }
            });

            app.UseRouter(routeBuilder.Build());

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Def");
            });

        }
    }
}
