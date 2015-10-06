using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteSolutionsTests
{
    public class AppConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                string connectionStringName = ConfigurationManager.AppSettings["connectionToUse"];
                return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            }
        }
    }
}
