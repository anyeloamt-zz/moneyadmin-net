using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly IGenericRepository<User> _repository;

        public AuthController(IGenericRepository<User> repository)
        {
            _repository = repository;
        }

        public ActionResult Login(UserViewModel userViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
