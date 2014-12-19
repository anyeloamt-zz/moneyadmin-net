using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyAdmin.Data.Entities;

namespace MoneyAdmin.Data
{
    partial class Database
    {
        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Category> Categories{ get; set; }
    }
}
