using System.Security.Cryptography;
using WalletManagement.Core.Services.Helper.Interface;

namespace WalletManagement.Core.Services.Helper.Implementation
{
    public class PasswordManager : IPasswordManager
    {
        public string CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }
            return "Password Encrepted";
        }
    }
}