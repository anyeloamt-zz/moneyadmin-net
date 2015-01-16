using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Filters;

namespace MoneyAdmin.Controllers
{
    [Authorize]
    [AuthenticatedUser]
    public class BaseController : Controller
    {
        public User CurrentUser
        {
            get { return (Session["User"] as User); }
        }

        protected Func<T, bool> ByCurrentUserPredicate<T>() where T : BaseEntity
        {
            return x => x.CreatedBy == CurrentUser.Id;
        }
    }
}
