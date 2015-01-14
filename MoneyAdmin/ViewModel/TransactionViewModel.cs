using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAdmin.ViewModel
{
    public class TransactionViewModel : IViewModel
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public double Amount { get; set; }

        public int WalletId { get; set; }

        public int CategoryId { get; set; }

        public WalletViewModel Wallet { get; set; }

        public CategoryViewModel Category { get; set; }

        public virtual IEnumerable<FileViewModel> Files { get; set; }
    }
}
