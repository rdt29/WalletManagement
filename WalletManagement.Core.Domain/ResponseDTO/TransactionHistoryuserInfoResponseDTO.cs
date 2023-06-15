namespace WalletManagement.Core.Domain.ResponseDTO
{
    public class TransactionHistoryuserInfoResponseDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AccountNumber { get; set; }
        public int Balance { get; set; }

        public ICollection<TransactionHistoryResponseDTO> TransactionDetails { get; set; }
    }
}