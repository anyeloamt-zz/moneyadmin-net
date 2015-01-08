using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;

namespace MoneyAdmin.Extensions
{
    public static class RepositoryExtensions
    {
        public static IEnumerable<Wallet> RecentWallets(this IGenericRepository<Wallet> repository)
        {
            return repository.AsEnumerable()
                .Where(w => w.CreatedAt > DateTime.Now.AddDays(-30));
        }
    }
}