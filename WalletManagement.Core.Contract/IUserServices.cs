using WalletManagement.Core.Domain.RequestDTO;
using WalletManagement.Core.Domain.ResponseDTO;

namespace WalletManagement.Core.Contract
{
    public interface IUserServices
    {
        public Task<UserResponseDTO> RegisterUserAsync(UserRequestDTO User);
    }
}