using System.ComponentModel.DataAnnotations.Schema;

namespace WalletManagement.Infra.Domain.Entity
{
    public class TransationHistory
    {
        public int Id { get; set; }
        public int? Debit { get; set; }
        public int? Credit { get; set; }
        public int? LastBalance { get; set; }
        public int? UpdatedBalance { get; set; }
        public int UserId { get; set; }
        public string Detail { get; set; }

        public string TransactionType { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }

        [ForeignKey(nameof(UserId))]
        public User user { get; set; }
    }
}