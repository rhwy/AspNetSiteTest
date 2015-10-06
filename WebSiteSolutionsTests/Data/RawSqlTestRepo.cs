using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace WebSiteSolutionsTests.Data
{
    public class RawSqlTestRepo : ITestRepo, ITestProcedures
    {
        public static Dictionary<string, List<long>> Statistics = new Dictionary<string, List<long>>();

        public RawSqlTestRepo(bool useStats)
        {
            this._useStats = useStats;
        }
        private static Func<IDictionary, bool> storeStatistics = (stats) =>
         {
             var keys = new List<string>();
             foreach (var item in stats.Keys)
             {
                 keys.Add(item.ToString());
             }
             var values = new List<long>();
             foreach (var item in stats.Values)
             {
                 values.Add((long)item);
             }

             for (int i = 0; i < stats.Count; i++)
             {
                 if(!Statistics.ContainsKey(keys[i]))
                 {
                     Statistics.Add(keys[i], new List<long> { values[i] });
                 } else
                 {
                     Statistics[keys[i]].Add(values[i]);
                 }
                 System.Diagnostics.Debug.WriteLine("{0}:{1}", keys[i], values[i]);
             }

             return true;
         };


        private static string getAllCommandText = "SELECT Id,Content,Created,Category FROM [dbo].[WebTestTable]";

        private bool _useStats = false;

        private static SqlCommand staticCommand = new SqlCommand(getAllCommandText);
        public async Task<IEnumerable<TestData>> AllAsync()
        {
            List<TestData> results = new List<TestData>();
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                bool useStaticCommand = false;

                await connection.OpenAsync();
                if(_useStats) connection.StatisticsEnabled = true;

                SqlCommand command;
                if (useStaticCommand)
                {
                    command = staticCommand;
                    command.Connection = connection;
                }
                else
                {
                    command = new SqlCommand(getAllCommandText, connection);
                }
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetString(0) ?? "";
                        var content = reader.GetString(1) ?? "";
                        results.Add(new TestData { Id = id, Content = content });
                    }
                }
                if (_useStats)
                {
                    var stats = connection.RetrieveStatistics();
                    storeStatistics(stats);
                }
            }
            return results;
        }

        public async Task<int> CallScalarStoredProc()
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                string commandText = "EXEC [dbo].[TestProcedureThatDoNothing]";
                SqlCommand command = new SqlCommand(commandText, connection);
                if (_useStats) connection.StatisticsEnabled = true;
                await connection.OpenAsync();

                var procResult = await command.ExecuteScalarAsync();
                if (procResult != null) result = (int) procResult;

                if (_useStats)
                {
                    var stats = connection.RetrieveStatistics();
                    storeStatistics(stats);
                }
                return result;
            }
        }
        public IEnumerable<TestData> All()
        {
            List<TestData> results = new List<TestData>();
            
            using (SqlConnection connection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(getAllCommandText, connection);
                    if (_useStats) connection.StatisticsEnabled = true;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetString(0) ?? "";
                            var content = reader.GetString(1) ?? "";
                            results.Add(new TestData { Id = id, Content = content });
                        }
                    }
                    if (_useStats)
                    {
                        var stats = connection.RetrieveStatistics();
                        storeStatistics(stats);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(
                        "Error {0}: {1}",
                        ex.Number, ex.Message);
                }
            }
            
            return results;
        }
    }

}
