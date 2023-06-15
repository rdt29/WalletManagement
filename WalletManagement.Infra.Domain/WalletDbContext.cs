using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletManagement.Infra.Domain.Entity;

namespace WalletManagement.Infra.Domain
{
    public class WalletDbContext : DbContext
    {
        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TransationHistory> Transaction { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }
    }
}