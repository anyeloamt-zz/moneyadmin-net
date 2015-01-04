using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data.Entities
{
    public class Wallet : BaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double InitialBalance { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
