using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public string Name
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        #region Navigation properties

        public virtual ICollection<Wallet> WalletsCreated { get; set; }

        public virtual ICollection<Wallet> WalletsModified { get; set; }

        public virtual ICollection<Transaction> TransactionsCreated { get; set; }

        public virtual ICollection<Transaction> TransactionsModified { get; set; }
        
        public virtual ICollection<Category> CategoriesCreated { get; set; }

        public virtual ICollection<Category> CategoriesModified { get; set; }

        #endregion
    }
}
