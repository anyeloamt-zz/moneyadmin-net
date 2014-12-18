using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data.Entities
{
    abstract public class BaseEntity : IEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CreatedBy { get; set; }
        
        public int UpdatedBy { get; set; }
    }
}
