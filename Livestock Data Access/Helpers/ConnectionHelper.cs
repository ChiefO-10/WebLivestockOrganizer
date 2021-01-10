using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivestockDataAccess
{
    /// <summary>
    /// Helpers for getting connection strings
    /// </summary>
    public class ConnectionHelper
    {
        /// <summary>
        /// Get connection string from appSetting in .Net Framework
        /// </summary>
        /// <param name="name">Name of database</param>
        /// <returns>Connection string</returns>
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
