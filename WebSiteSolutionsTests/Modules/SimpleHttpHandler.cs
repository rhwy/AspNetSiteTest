using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebSiteSolutionsTests.Modules
{
    //public class SimpleHttpMessageHandler : DelegatingHandler
    //{
    //    protected override Task<HttpResponseMessage> SendAsync(
    //        HttpRequestMessage request, CancellationToken cancellationToken)
    //    {
    //        if(request.RequestUri.AbsolutePath.StartsWith("/message"))
    //        {
    //            // Create the response.
    //            var response = new HttpResponseMessage(HttpStatusCode.OK)
    //            {
    //                Content = new StringContent("Hello from message!")
    //            };

    //            // Note: TaskCompletionSource creates a task that does not contain a delegate.
    //            var tsc = new TaskCompletionSource<HttpResponseMessage>();
    //            tsc.SetResult(response);   // Also sets the task state to "RanToCompletion"
    //            return tsc.Task;
    //        } else
    //        {
    //            return base.SendAsync(request, cancellationToken);
    //        }
            
    //    }
    //}

    //public class SimpleHttpHandler : HttpTaskAsyncHandler
    //{
    //    public override async Task ProcessRequestAsync(HttpContext context)
    //    {
    //        string hello = "hello world";
    //        string message = $"say : ${hello}";
    //        context.Response.Write(message);
    //        context.Response.Flush();

    //    }
    //    public override void ProcessRequest(HttpContext context)
    //    {
    //        ProcessRequestAsync(context).Wait();
    //    }
    //    public override bool IsReusable
    //    {
    //        get
    //        {
    //            return true;
    //        }
    //    }
    //}
}
