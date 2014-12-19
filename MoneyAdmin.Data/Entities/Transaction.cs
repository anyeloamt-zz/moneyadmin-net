using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data.Entities
{
    public class Transaction : BaseEntity
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public double Amount { get; set; }

        public int WalletId { get; set; }

        public int CategoryId { get; set; }

        public virtual Wallet Wallet { get; set; }

        public virtual Category Category { get; set; }
    }
}
