using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSiteSolutionsTests.Data
{
    public interface ITestRepo
    {
        IEnumerable<TestData> All();
        Task<IEnumerable<TestData>> AllAsync();
    }

    public interface ITestProcedures
    {
        Task<int> CallScalarStoredProc();
    }
}
