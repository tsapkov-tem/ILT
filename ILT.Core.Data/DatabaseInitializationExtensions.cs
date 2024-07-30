using ILT.Core.Data.DatabaseChecker;
using ILT.Core.Data.Entities;
using ILT.Core.Data.Initialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ILT.Core.Data
{
    public static class DatabaseInitializationExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? provider = configuration.GetSection(ConfigurationKeyConstants.CONNECTION_PROVIDER).Value;
            if (string.IsNullOrEmpty(provider))
                throw new ArgumentNullException("Database provider is not defined");

            bool rootPassword = string.IsNullOrEmpty(configuration.GetSection(ConfigurationKeyConstants.CONNECTION_ROOT_PASSWORD).Value);

            IDatabaseInitializer initializer =
                provider switch
                {
                    _ when rootPassword => new SqliteDatabaseInitializer(),
                    // TODO: another initializers
                    _ => new SqliteDatabaseInitializer()
                };

            IDatabaseChecker databaseChecker =
                provider switch
                {
                    ConfigurationKeyConstants.PROVIDER_TESTDB => new SqliteOnlineChecker(),
                    _ => new SqliteOnlineChecker(),
                    // TODO: another checkers
                };

            bool isOnline = databaseChecker.IsDbOnline(configuration);
            if (!isOnline)
                throw new InvalidOperationException("Target database is not online");

            initializer.InitializeDatabase(configuration);

            var dbContextOption = DbContextOptionsFactory.GetContextOptions(configuration);

            services.AddSingleton(databaseChecker);
            services.AddSingleton(initializer);
            services.AddSingleton(dbContextOption);
            services.AddScoped(context => new DatabaseContext(context.GetRequiredService<DbContextOptions<DatabaseContext>>()));
        }
    }
}
