using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkdownSharp;
using Nancy;
using Nancy.Responses.Negotiation;

namespace WebSiteSolutionsTests
{
    public static class Utils
    {
        public static T Median<T>(this IEnumerable<T> list)
        {
            return list.ElementAt(list.Count()/2);
        }

        public static object token = new object();

        public static Negotiator WithMarkdownView(this Negotiator negotiate, string markdownViewName)
        {
            var markdownFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, markdownViewName + ".md"));
            var htmlFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, markdownViewName + ".html"));

            if (!htmlFile.Exists || htmlFile.LastWriteTimeUtc < markdownFile.LastWriteTimeUtc)
            {
                var md = new Markdown();
                md.AutoHyperlink = true;
                md.AutoNewLines = true;
                string content = File.ReadAllText(markdownFile.FullName);
                string htmlContent = md.Transform(content);

                lock (token)
                {
                    File.WriteAllText(htmlFile.FullName, htmlContent);
                }
            }


            return negotiate.WithView(markdownViewName);
        }
    }

    
}
