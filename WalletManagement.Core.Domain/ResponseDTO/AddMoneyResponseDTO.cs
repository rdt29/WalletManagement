using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WalletManagement.Core.Domain.ResponseDTO
{
    public class AddMoneyResponseDTO
    {
        public string Name { get; set; }
        public int TransactionId { get; set; }
        public int CreditAmount { get; set; }
        public int TotalBalance { get; set; }

        public DateTimeOffset TransactionDetails { get; set; }
        public string Details { get; set; }
    }
}