using Microsoft.AspNetCore.Mvc;
using WalletManagement.Core.Contract;
using WalletManagement.Core.Domain.RequestDTO;

namespace NewWalletmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _IUserServices;

        public UserController(IUserServices userServices)
        {
            _IUserServices = userServices;
        }

        [HttpPost("add-new-user")]
        public async Task<IActionResult> RegisterUser(UserRequestDTO User)
        {
            var response = await _IUserServices.RegisterUserAsync(User);

            return Ok(response);
        }
    }
}