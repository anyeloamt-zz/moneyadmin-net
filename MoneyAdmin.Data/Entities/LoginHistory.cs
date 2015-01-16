using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyAdmin.Data.Entities
{
    public class LoginHistory
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public ActionType Action { get; set; }

        public virtual User User { get; set; }
    }

    public enum ActionType
    {
        Login = 1, Logout
    }
}
