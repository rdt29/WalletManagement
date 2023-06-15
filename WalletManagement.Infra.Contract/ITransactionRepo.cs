using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Infra.Contract
{
    public interface ITransactionRepo
    {
        Task<TransationHistory> AddMoney(TransationHistory details);
    }
}