using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManagement.Core.Domain.ResponseDTO
{
    public class TransactionHistoryResponseDTO
    {
        public int TransactionId { get; set; }
        public int? Debit { get; set; }
        public int? Credit { get; set; }
        public int? LastBalance { get; set; }
        public int? UpdatedBalance { get; set; }

        public string Detail { get; set; }

        public string TransactionType { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }
    }
}