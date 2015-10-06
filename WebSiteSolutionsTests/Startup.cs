using Nancy;
using Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebSiteSolutionsTests.Modules;

namespace WebSiteSolutionsTests
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            //config.MessageHandlers.Add(new SimpleHttpMessageHandler());
            //appBuilder.MapWhenAsync(ctx => Task.FromResult(ctx.Request.Path.StartsWithSegments(new Microsoft.Owin.PathString("/middle"))),
            //    app => app.Run(ctx => ctx.Response.WriteAsync("from middleware")));
            appBuilder.UseWebApi(config);
            appBuilder.UseNancy(
                options => options.PerformPassThrough = 
                    context =>
                        context.Response.StatusCode == HttpStatusCode.NotFound);
            appBuilder.Run(context =>
            {
                return context.Response.WriteAsync("No one catched that call, so let's just say Hello world");
            });

        }
    }

    
}