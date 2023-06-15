using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WalletManagement.Infra.Domain;

namespace NewWalletmanagement.Configuration
{
    public static class SQLServerConfiguration
    {
        public static void AddSqlConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<WalletDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString, x =>
                {
                    x.MigrationsAssembly("WalletManagement.Infra.Domain");
                    x.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                });
            }, ServiceLifetime.Singleton);
        }
    }
}