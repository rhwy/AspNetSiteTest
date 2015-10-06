using Nancy;
using System.Threading.Tasks;
using WebSiteSolutionsTests.Data;
using System.Linq;
using System.Collections.Generic;

namespace WebSiteSolutionsTests.Controllers
{
    public class NancyTestDataModule : NancyModule
    {
        public NancyTestDataModule() : base("/nancy")
        {
            ITestRepo repo;

            Get["/sync/empty"] = p => "Hello Nancy Empty Sync";
            Get["/async/empty", true] =
                async (p, ct) => await Task.Run(
                    () => "Hello Nancy Empty Async"); //simulates a background task

            Get["/async/{repo}/async", true] = async (p, ct) =>
            {
                string repoType = p.repo;
                repo = TestRepoFactory.GetRepoFromString(repoType, Request.Query.useStats);
                return await repo.AllAsync();
            };

            Get["/async/proc/async", true] = async (p, ct) =>
            {
                string repoType = "rawsql";
                var proc = TestRepoFactory.GetRepoFromString(repoType, Request.Query.useStats) as ITestProcedures;
                if (proc != null)
                    return await proc.CallScalarStoredProc();
                else
                    return -1;
            };


            Get["/async/{repo}/sync", true] = async (p, ct) =>
            {
                string repoType = p.repo;
                repo = TestRepoFactory.GetRepoFromString(repoType, Request.Query.useStats);
                return await Task.Run(() => repo.All());
            };

            Get["/sync/{repo}/async"] = (p) =>
            {
                string repoType = p.repo;
                repo = TestRepoFactory.GetRepoFromString(repoType, Request.Query.useStats);
                return Negotiate.WithModel(repo.AllAsync().Result).WithStatusCode(200);
            };

            Get["/sync/{repo}/sync"] = (p) =>
            {
                string repoType = p.repo;
                repo = TestRepoFactory.GetRepoFromString(repoType, Request.Query.useStats);
                return Negotiate.WithModel(repo.All()).WithStatusCode(200);
            };

            
        }
    }
}
