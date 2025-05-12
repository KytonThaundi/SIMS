using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;

namespace SIMS.Web.Data
{
    public static class PostgreSqlDbContextOptionsExtensions
    {
        public static DbContextOptionsBuilder ConfigureNpgsqlOptions(this DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            // Set global Npgsql settings for timestamp handling
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            // Configure Npgsql with specific options
            return optionsBuilder.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorCodesToAdd: null);

                // No need for MapNodaTimeTypes as we're using the global switches

                // Set command timeout
                npgsqlOptions.CommandTimeout(30);

                // Use the legacy timestamp behavior
                npgsqlOptions.SetPostgresVersion(new Version(9, 6));
            });
        }
    }
}
