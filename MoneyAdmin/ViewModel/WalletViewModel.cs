using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyAdmin.ViewModel
{
    public class WalletViewModel : BaseViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Balance inicial")]
        public double InitialBalance { get; set; }

        [Required]
        [DisplayName("Balance disponible")]
        public double AvailableBalance { get; set; }

        public virtual IEnumerable<TransactionViewModel> Transactions { get; set; }
    }
}