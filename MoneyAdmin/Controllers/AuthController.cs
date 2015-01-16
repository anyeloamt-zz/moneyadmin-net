using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using MoneyAdmin.Data.Util;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IGenericRepository<LoginHistory> _historyRepository;

        public AuthController(IGenericRepository<User> repository, IGenericRepository<LoginHistory> historyRepository)
        {
            _repository = repository;
            _historyRepository = historyRepository;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return Request.IsAuthenticated 
                ? RedirectHome() 
                : View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (Request.IsAuthenticated) return RedirectHome();

            var user = _repository.AsEnumerable()
                .Where(u => u.Username == loginViewModel.Username)
                .FirstOrDefault(u => u.Password == PasswordHasher.MD5Hash(loginViewModel.Password));

            if (null != user)
            {
                FormsAuthentication.SetAuthCookie(user.Username, loginViewModel.RememberMe);
                DoPostLogin(user);
                return RedirectHome();
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(loginViewModel);
        }

        private void DoPostLogin(User user)
        {
            Session.Add("User", user);
            _historyRepository.Add(new LoginHistory
            {
                Action = ActionType.Login,
                Date = DateTime.Now,
                UserId = user.Id
            }).Save();
        }

        private void DoPreLogout()
        {
            _historyRepository.Add(new LoginHistory
            {
                Action = ActionType.Logout,
                Date = DateTime.Now,
                UserId = ((User) Session["User"]).Id
            }).Save();
        }

        public ActionResult LogOut()
        {
            DoPreLogout();
            FormsAuthentication.SignOut();
            return RedirectHome();
        }

        private ActionResult RedirectHome()
        {
            return RedirectToAction(ConfigurationManager.AppSettings["DefaultAction"],
                ConfigurationManager.AppSettings["DefaultController"]);
        }
    }
}
