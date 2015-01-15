using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyAdmin.ViewModel
{
    public class BaseViewModel : IViewModel
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}