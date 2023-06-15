using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManagement.Core.Services.Helper.Interface
{
    public interface IPasswordManager
    {
        public string CreatePasswordHash(String Password, out byte[] PasswordHash, out byte[] PasswordSalt);
    }
}