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
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace _003_Routing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            RouteHandler routeHandler = new RouteHandler(Handle);

            IRouteBuilder routeBuilder = new RouteBuilder(app, routeHandler);

            routeBuilder.MapRoute("def1",
                "{controller}/{action}/{id}",
                null,
                new { action = "test1" }
                );

            routeBuilder.MapRoute("def2",
                "{controller}/{action}/{id}",
                null,
                new { action = "test2", id = new BoolRouteConstraint()}
                );

            routeBuilder.MapGet("Get/{controller}/{action}/{id?}", Handle);
            routeBuilder.MapPost("Post/{controller}/{action}/{id?}", async x=>
            {
                //doesn't working, because it's post request
                await x.Response.WriteAsync(x.Request.Path.Value);
            });
            

            app.UseRouter(routeBuilder.Build());

            app.Run(async x =>
            {
                await x.Response.WriteAsync("Def page");
            });
        }

        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync(context.Request.Path.Value);
        }
    }
}
