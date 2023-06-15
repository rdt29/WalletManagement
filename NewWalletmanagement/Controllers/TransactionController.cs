using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletManagement.Core.Contract;

namespace NewWalletmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServices _transactionServices;

        public TransactionController(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
        }

        [HttpPost("add-amount")]
        public async Task<IActionResult> AddAmount(int UserId, int Amount)
        {
            var response = await _transactionServices.AddMoneyAsync(UserId, Amount);
            return Ok(response);
        }

        [HttpGet("get-user-transaction")]
        public async Task<IActionResult> GetTransactionDetails(int UserId)
        {
            var response = await _transactionServices.TransactionHistoryAsync(UserId);
            return Ok(response);
        }

        [HttpPost("transfer-money")]
        public async Task<IActionResult> TransferMoney(int Userid , int Accountno , int Amount)
        {
            
        }

    }
}