using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WalletManagement.Core.Domain.ResponseDTO
{
    public class TransferMoneyResponseDTO
    {
        public int TransactionId { get; set; }
        public int Amount  { get; set; }
       
        public int RecipientAccountNumber { get; set; }
        public int RecipientName { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }

    }
}
