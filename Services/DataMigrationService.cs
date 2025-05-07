using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SIMS_Web.Data;
using System;
using System.Threading.Tasks;

namespace SIMS_Web.Services
{
    public class DataMigrationService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DataMigrationService> _logger;

        public DataMigrationService(
            ApplicationDbContext context,
            ILogger<DataMigrationService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task MigrateAsync()
        {
            try
            {
                _logger.LogInformation("Starting database migration");
                await _context.Database.MigrateAsync();
                _logger.LogInformation("Database migration completed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during database migration");
                throw;
            }
        }
    }
}