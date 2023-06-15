using WalletManagement.Core.Contract;
using WalletManagement.Core.Domain.ResponseDTO;
using WalletManagement.Infra.Contract;
using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Core.Services
{
    public class TransactionService : ITransactionServices
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IUserRepo _userRepo;

        public TransactionService(ITransactionRepo transactionRepo, IUserRepo userRepo)
        {
            _transactionRepo = transactionRepo;
            _userRepo = userRepo;
        }

        public async Task<AddMoneyResponseDTO> AddMoneyAsync(int UserId, int Amount)
        {
            try
            {
                var UserDetails = await _userRepo.IGetUserById(UserId);
                if (UserDetails == null)
                {
                    throw new NullReferenceException("No user Found");
                }
                TransationHistory transationHistory = new TransationHistory()
                {
                    Credit = Amount,
                    Debit = 0,
                    LastBalance = UserDetails.accountDetails.TotalBalance,
                    UpdatedBalance = UserDetails.accountDetails.TotalBalance += Amount,
                    TransactionDateTime = DateTimeOffset.Now,
                    TransactionType = "Self Added Amount",
                    Detail = "Added",
                    UserId = UserId,
                };

                var response = await _transactionRepo.AddMoney(transationHistory);

                AddMoneyResponseDTO responseDTO = new AddMoneyResponseDTO()
                {
                    CreditAmount = Amount,
                    Name = UserDetails.Name,
                    TransactionDetails = response.TransactionDateTime,
                    TotalBalance = UserDetails.accountDetails.TotalBalance,
                    Details = response.Detail,
                    TransactionId = response.Id,
                };

                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TransactionHistoryuserInfoResponseDTO> TransactionHistoryAsync(int UserId)
        {
            try
            {
                var Userinfo = await _userRepo.IGetUserById(UserId);
                if (Userinfo == null)
                {
                    throw new NullReferenceException("No User Found !");
                }
                //if (Userinfo.Transaction.Count == 0)
                //{
                //    throw new NullReferenceException("No Transaction Found");
                //}
                TransactionHistoryuserInfoResponseDTO transactionHistoryuserInfoResponseDTO = new TransactionHistoryuserInfoResponseDTO()
                {
                    UserId = UserId,
                    UserName = Userinfo.Name,
                    Balance = Userinfo.accountDetails.TotalBalance,
                    AccountNumber = Userinfo.accountDetails.AccountNumber,
                    TransactionDetails = Userinfo.Transaction.Select(x => new TransactionHistoryResponseDTO
                    {
                        TransactionId = x.Id,
                        TransactionType = x.TransactionType,
                        Credit = x.Credit,
                        Debit = x.Debit,
                        Detail = x.Detail,
                        LastBalance = x.LastBalance,
                        TransactionDateTime = x.TransactionDateTime,
                        UpdatedBalance = x.UpdatedBalance,
                    }).ToList(),
                };
                return transactionHistoryuserInfoResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TransferMoneyResponseDTO> TransferMoney(int userId, int Accountno, int Amount)
        {
            try
            {
                var SenderUserDetails = await _userRepo.IGetUserById(userId);
                var ReceiverUserDetails = await _userRepo.IGetUserByAccountNo(Accountno.ToString());

                if (ReceiverUserDetails == null)
                {
                    throw new Exception("No Account Found !");
                }
                if (SenderUserDetails.accountDetails.AccountNumber == Accountno.ToString())
                {
                    throw new Exception("Cant Send Money To Own Account");
                }
                if (SenderUserDetails.accountDetails.TotalBalance < Amount)
                {
                    throw new Exception("Low Balance !");
                }

                TransationHistory SenderUserTransaction = new TransationHistory()
                {
                    Credit = 0,
                    Debit = Amount,
                    Detail = $"Transfer To {ReceiverUserDetails.Name} AccountNo {ReceiverUserDetails.accountDetails.AccountNumber}",
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}