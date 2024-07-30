using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILT.Core.Data.Initialization
{
    public class SqliteDatabaseInitializer : IDatabaseInitializer
    {
        public void InitializeDatabase(IConfiguration configuration)
        {
            // Sqlite may not be  initialized
        }
    }
}
