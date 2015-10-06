using System;

namespace WebSiteSolutionsTests.Data
{
    public class SimpleData
    {
        private static Func<dynamic> getDb = () => Simple.Data.Database.OpenConnection(AppConfiguration.ConnectionString);

        public static Func<dynamic> SetDbBuilder
        {
            set { getDb = value; }
        }


        public static bool DoWithTransaction(Func<dynamic, bool> action)
        {
            using (var tx = Db.BeginTransaction())
            {
                if (action(tx))
                {
                    var result = tx.Commit();
                    return true;
                }

                return false;
            }

        }
        public static dynamic Db
        {
            get { return getDb(); }
        }
    }
}
