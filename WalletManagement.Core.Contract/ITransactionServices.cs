using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletManagement.Core.Domain.ResponseDTO;

namespace WalletManagement.Core.Contract
{
    public interface ITransactionServices
    {
        public Task<AddMoneyResponseDTO> AddMoneyAsync(int UserId, int Amount);

        public Task<TransactionHistoryuserInfoResponseDTO> TransactionHistoryAsync(int UserId);

        public Task<TransferMoneyResponseDTO> TransferMoney(int userId, int Accountno, int Amount);
    }
}