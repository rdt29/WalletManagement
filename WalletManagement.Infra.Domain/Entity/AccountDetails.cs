using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManagement.Infra.Domain.Entity
{
    public class AccountDetails
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int TotalBalance { get; set; }
        public string AccountType { get; set; }
        public int UserId { get; set; }

        public DateTimeOffset AccountOpeningDetails { get; set; }

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
    }
}