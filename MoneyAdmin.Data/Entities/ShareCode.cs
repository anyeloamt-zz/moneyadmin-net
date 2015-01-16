﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data.Entities
{
    public class ShareCode : BaseEntity
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int WalletId { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}
