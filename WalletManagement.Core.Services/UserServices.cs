using AutoMapper;
using System;
using WalletManagement.Core.Contract;
using WalletManagement.Core.Domain.RequestDTO;
using WalletManagement.Core.Domain.ResponseDTO;
using WalletManagement.Core.Services.Helper.Interface;
using WalletManagement.Infra.Contract;
using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Core.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly IPasswordManager _passwordManager;
        private readonly IUserRepo _userRepo;

        public UserServices(IMapper mapper, IPasswordManager passwordManager, IUserRepo userRepo)
        {
            _mapper = mapper;
            _passwordManager = passwordManager;
            _userRepo = userRepo;
        }

        public async Task<UserResponseDTO> RegisterUserAsync(UserRequestDTO users)
        {
            try
            {
                _passwordManager.CreatePasswordHash(users.password, out byte[] Passwordhash, out byte[] PasswordSalt);

                var Newusers = _mapper.Map<User>(users);

                var accountDetails = await _userRepo.IAccountNumber();
                var AccountNo = "";

                if (accountDetails == null)
                {
                    var num = "1";
                    AccountNo = num.PadLeft(6, '0');
                }
                else
                {
                    var LastAccountNumber = Convert.ToInt32(accountDetails.AccountNumber);
                    var newAcc = LastAccountNumber + 1;

                    AccountNo = newAcc.ToString().PadLeft(6, '0');
                }

                AccountDetails acc = new AccountDetails()
                {
                    AccountNumber = AccountNo,
                    TotalBalance = 0,
                    AccountOpeningDetails = DateTimeOffset.Now,
                    AccountType = "Saving"
                };
                Newusers.PasswordHash = Passwordhash;
                Newusers.PasswordSalt = PasswordSalt;
                Newusers.accountDetails = acc;

                var response = await _userRepo.IUserRegister(Newusers);

                var details = _mapper.Map<UserResponseDTO>(response);
                details.AccountNo = response.accountDetails.AccountNumber;

                return (details);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}