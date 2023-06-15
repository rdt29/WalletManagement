using Microsoft.EntityFrameworkCore;
using WalletManagement.Infra.Contract;
using WalletManagement.Infra.Domain;
using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Infra.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly WalletDbContext _db;

        public UserRepo(WalletDbContext db)
        {
            _db = db;
        }

        public async Task<User> IUserRegister(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<AccountDetails> IAccountNumber()
        {
            return await _db.AccountDetails.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }

        public async Task<User> IGetUserById(int userId)
        {
            var user =  await _db.Users.Where(x => x.Id == userId).Include(x => x.accountDetails).Include(x=>x.Transaction).FirstOrDefaultAsync();
            if(user == null)
            {
                throw new NullReferenceException("No user Found");

            }
            else
            {
                return user;
            }
        }

        public async Task<User> IGetUserByAccountNo(string accountno)
        {
           var userDetails = await _db.Users.Where(x=>x.accountDetails.AccountNumber == accountno).FirstOrDefaultAsync();
            if(userDetails == null)
            {
                throw new NullReferenceException("No Account Details Found !");
            }
            return userDetails;
        }
    }
}