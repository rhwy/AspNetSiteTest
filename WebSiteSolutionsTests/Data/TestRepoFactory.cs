using System;

namespace WebSiteSolutionsTests.Data
{
    public static class TestRepoFactory
    {
        public static ITestRepo GetRepoFromString(string name, bool useStats=false)
        {
            ITestRepo repo;
            switch (name)
            {
                case "simpledata":
                    repo = new SimpleDataTestRepo();
                    break;
                case "dapper":
                    repo = new DapperTestRepo();
                    break;
                case "rawsql":
                    repo = new RawSqlTestRepo(useStats);
                    break;
                default:
                    throw new NotSupportedException("data access method not supported");
                    break;
            }
            return repo;
        }
    }

}
