using WalletManagement.Core.Contract;
using WalletManagement.Core.Services;
using WalletManagement.Core.Services.Helper.Implementation;
using WalletManagement.Core.Services.Helper.Interface;
using WalletManagement.Infra.Contract;
using WalletManagement.Infra.Repo;

namespace NewWalletmanagement.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IUserRepo, UserRepo>();

            services.AddTransient<IPasswordManager, PasswordManager>();

            services.AddTransient<ITransactionRepo, TransactionRepo>();
            services.AddTransient<ITransactionServices, TransactionService>();
        }
    }
}