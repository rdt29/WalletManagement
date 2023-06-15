using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Infra.Contract
{
    public interface IUserRepo
    {
        public Task<User> IUserRegister(User user);

        public Task<AccountDetails> IAccountNumber();

        public Task<User> IGetUserById(int userId);
        public Task<User> IGetUserByAccountNo(string accountno);
    }
}