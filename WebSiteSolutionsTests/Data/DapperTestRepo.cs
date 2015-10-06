using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;

namespace WebSiteSolutionsTests.Data
{
    public class DapperTestRepo : ITestRepo
    {
        private static string getAllCommandText = "SELECT Id,Content,Created,Category FROM [dbo].[WebTestTable]";
        public IEnumerable<TestData> All()
        {
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                connection.Open();
                IEnumerable<TestData> result = connection.Query<TestData>(getAllCommandText);
                return result;
            }
        }

        public async Task<IEnumerable<TestData>> AllAsync()
        {
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                connection.Open();
                IEnumerable<TestData> result = await connection.QueryAsync<TestData>(getAllCommandText);
                return result;
            }
        }
        
    }
}
