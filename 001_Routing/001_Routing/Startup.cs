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

namespace _001_Routing
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

            routeBuilder.MapRoute("{Home}", async (x) =>
            {
                await x.Response.WriteAsync("Home");
            });

            routeBuilder.MapRoute("{Home}/{Page1}", async (x) =>
             {
                 await x.Response.WriteAsync("Home/Page1");
             });

            routeBuilder.MapRoute("{Home}/{Page1}/{Page1.1}", async (x) =>
            {
                await x.Response.WriteAsync("Home/Page1/Page1.1");
            });

            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                if (context.Request.Path.Value == "/")
                    await context.Response.WriteAsync("Def");
                else
                    await context.Response.WriteAsync("Error page!!!");
            });
        }
    }
}
