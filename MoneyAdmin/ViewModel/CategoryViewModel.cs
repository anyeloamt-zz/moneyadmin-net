using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAdmin.ViewModel
{
    public class CategoryViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TransactionViewModel> Transactions { get; set; }
    }
}
