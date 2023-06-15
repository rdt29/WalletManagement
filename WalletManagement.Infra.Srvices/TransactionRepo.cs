using WalletManagement.Infra.Contract;
using WalletManagement.Infra.Domain;
using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Infra.Repo
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly WalletDbContext _db;

        public TransactionRepo(WalletDbContext db)
        {
            _db = db;
        }

        public async Task<TransationHistory> AddMoney(TransationHistory details)
        {
            _db.Transaction.Add(details);
            await _db.SaveChangesAsync();
            return details;
        }
    }
}