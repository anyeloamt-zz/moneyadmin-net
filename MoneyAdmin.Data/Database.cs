using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data
{
    public partial class Database : DbContext
    {
        public Database() : 
            base(ConfigurationManager.ConnectionStrings["MoneyAdminConn"].ConnectionString)
        {
            
        }

        public Database(string connectionString) :
            base(connectionString)
        {

        }

        public override int SaveChanges()
        {
            // TODO: Add audit fields before save
            return base.SaveChanges();
        }
    }
}
