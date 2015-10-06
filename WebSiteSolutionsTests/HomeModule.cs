using MarkdownSharp;
using Nancy;
using Nancy.Responses.Negotiation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteSolutionsTests.Data;

namespace WebSiteSolutionsTests
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
           Get["/"] = p => Negotiate.WithMarkdownView("Home").WithModel("ok").WithStatusCode(200);
        }
    }

    public class HelperModule : NancyModule
    {
        public HelperModule()
        {
            StaticConfiguration.DisableErrorTraces = false;
            Get["/sql/stats", true] = async (prop, ct) =>
            {
                var values = await Task.Run(() => RawSqlTestRepo.Statistics.ToList()
                .Select(item =>
                   new
                   {
                       Key = item.Key,
                       Total = item.Value.Count(),
                       Median = (int)item.Value.Median(),
                       Avg = (int)item.Value.Average(),
                       Min = (int)item.Value.Min(),
                       Max = (int)item.Value.Max(),
                       P90 = (int)item.Value.Skip((int)(item.Value.Count() * 0.9)).FirstOrDefault()
                   }));
                return Negotiate.WithModel(new { Total = values.FirstOrDefault().Total, List = values }).WithMarkdownView("SqlStats").WithStatusCode(200);
            };
        }
    }

    
}
