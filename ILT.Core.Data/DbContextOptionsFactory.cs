using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILT.Core.Data
{
    internal class DbContextOptionsFactory
    {
        private static readonly Dictionary<string, Action<DbContextOptionsBuilder, IConfiguration>> OptionsFactoryLookup = new(StringComparer.OrdinalIgnoreCase)
        {
            //[ConfigurationKeyConstants.PROVIDER_TEMPDB] = SetupSqliteTempDbConnection,
            //[ConfigurationKeyConstants.PROVIDER_TESTDB] = SetupSqliteTestDbConnection,
            //[ConfigurationKeyConstants.PROVIDER_POSTGRESQL] = SetupPostgresConnection,
        };
    }
}
