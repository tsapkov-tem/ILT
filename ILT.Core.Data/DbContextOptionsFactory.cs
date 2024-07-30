using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ILT.Core.Data.Entities;
using Microsoft.Extensions.Logging;

namespace ILT.Core.Data
{
    internal class DbContextOptionsFactory
    {
        /// <summary>
        /// TODO: another db connections
        /// </summary>
        private static readonly Dictionary<string, Action<DbContextOptionsBuilder, IConfiguration>> OptionsFactoryLookup = new(StringComparer.OrdinalIgnoreCase)
        {
            [ConfigurationKeyConstants.PROVIDER_TEMPDB] = SetupSqliteTempDbConnection,
            //[ConfigurationKeyConstants.PROVIDER_TESTDB] = SetupSqliteTestDbConnection,
            //[ConfigurationKeyConstants.PROVIDER_POSTGRESQL] = SetupPostgresConnection,
        };

        public static DbContextOptions GetContextOptions(IConfiguration configuration)
        {
            string? provider = configuration.GetSection(ConfigurationKeyConstants.CONNECTION_PROVIDER).Value;
            if(string.IsNullOrEmpty(provider))
                throw new ArgumentNullException("Data provider is not defined.");

            if (!OptionsFactoryLookup.TryGetValue(provider, out var optionsFactory))
                throw new NotSupportedException("Data provider is not supported.");

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsFactory(optionsBuilder, configuration);

#if DEBUG
            optionsBuilder.LogTo(Console.Write, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
#endif
            return optionsBuilder.Options;
        }

        private static void SetupSqliteTempDbConnection(DbContextOptionsBuilder builder, IConfiguration configuration)
        {
            var dbFilePath = Path.GetTempFileName();
            builder.UseSqlite
                (
                    $"Data Source={dbFilePath}"
                );
        }
    }
}
