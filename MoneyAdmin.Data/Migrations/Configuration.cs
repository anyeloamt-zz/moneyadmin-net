using MoneyAdmin.Data.Entities;

namespace MoneyAdmin.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoneyAdmin.Data.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoneyAdmin.Data.Database context)
        {
            context.Wallets.Add(new Wallet
            {
                Name = "Dec 15 to dec 30",
                InitialBalance = 15000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = 1,
                UpdatedBy = 1
            });
        }
    }
}
