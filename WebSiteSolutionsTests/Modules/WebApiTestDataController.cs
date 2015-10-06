using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using WebSiteSolutionsTests.Data;

namespace WebSiteSolutionsTests.Modules
{
    public class WebApiTestDataController : ApiController
    {
        ITestRepo repo;


        [HttpGet, Route("webapi/sync/empty")]
        public string GetSyncEmpty()
        {
            return "Hello WebApi2 Empty Sync";
        }

        [HttpGet, Route("webapi/async/empty")]
        public async Task<string> GetAsyncEmpty()
        {
            return await Task.Run(() => "Hello WebApi2 Empty Async");
        }
        [HttpGet, Route("webapi/sync/{name}/sync")]
        public IEnumerable<TestData> GetSyncSimpleDataSync(string name)
        {
            string repoType = name;
            repo = TestRepoFactory.GetRepoFromString(repoType, Request.GetQueryNameValuePairs().Any(x=>x.Key=="usestats"));
            return repo.All();
        }

        [HttpGet, Route("webapi/sync/{name}/async")]
        public IEnumerable<TestData> GetSyncSimpleDataASync(string name)
        {
            string repoType = name;
            repo = TestRepoFactory.GetRepoFromString(repoType, Request.GetQueryNameValuePairs().Any(x => x.Key == "usestats"));
            return repo.AllAsync().Result;
        }

        [HttpGet, Route("webapi/async/{name}/sync")]
        public async Task<IEnumerable<TestData>> GetAsyncSimpleDataSync(string name)
        {
            string repoType = name;
            repo = TestRepoFactory.GetRepoFromString(repoType);
            return await Task.Run(() => repo.All());
        }

        [HttpGet, Route("webapi/async/{name}/async")]
        public async Task<IEnumerable<TestData>> GetAsyncSimpleDataASync(string name)
        {
            string repoType = name;
            repo = TestRepoFactory.GetRepoFromString(repoType, Request.GetQueryNameValuePairs().Any(x => x.Key == "usestats"));
            return await repo.AllAsync();
        }
        
    }
}
