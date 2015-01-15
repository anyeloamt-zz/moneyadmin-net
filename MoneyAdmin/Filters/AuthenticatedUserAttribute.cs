using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyAdmin.Data;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using Ninject;

namespace MoneyAdmin.Filters
{
    public class AuthenticatedUserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated) return;

            if (filterContext.Controller.ControllerContext.HttpContext.Session == null) return;

            if (filterContext.Controller.ControllerContext.HttpContext.Session["User"] != null) return;

            var repository = UsersRepository;

            var user = repository.AsEnumerable()
                .FirstOrDefault(u => u.Username == filterContext.HttpContext.User.Identity.Name);

            filterContext.Controller.ControllerContext.HttpContext.Session.Add("User", user);
        }

        [Inject] 
        public IGenericRepository<User> UsersRepository { private get; set; }
    }
}