﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletManagement.Core.Domain.RequestDTO
{
    public class UserRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
    }
}