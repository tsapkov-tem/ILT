using Microsoft.Extensions.Configuration;

namespace ILT.Core.Data.DatabaseChecker
{
    /// <summary>
    /// Sqlite is always online
    /// </summary>
    public class SqliteOnlineChecker : IDatabaseChecker
    {

        public bool IsDbOnline(IConfiguration configuration)
        {
            return true;
        }
    }
}
