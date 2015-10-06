using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSiteSolutionsTests.Data
{
    public class SimpleDataTestRepo : ITestRepo
    {
        public IEnumerable<TestData> All()
        {
            dynamic db = SimpleData.Db;

            IEnumerable<TestData> data = db.dbo.WebTestTable.All().ToList<TestData>().Result;

            return data;
        }

        public async Task<IEnumerable<TestData>> AllAsync()
        {
            dynamic db = SimpleData.Db;

            IEnumerable<TestData> data = await db.dbo.WebTestTable.All().ToList<TestData>();

            return data;
        }
    }


}
