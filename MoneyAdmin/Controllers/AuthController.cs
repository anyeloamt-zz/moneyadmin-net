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

        public AuthController(IGenericRepository<User> repository)
        {
            _repository = repository;
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

            var password = PasswordHasher.MD5Hash(loginViewModel.Password);

            var user = _repository.AsQueryable()
                .Where(u => u.Username == loginViewModel.Username)
                .FirstOrDefault(u => u.Password == password);

            if (null != user)
            {
                FormsAuthentication.SetAuthCookie(user.Username, loginViewModel.RememberMe);
                return RedirectHome();
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(loginViewModel);
        }

        public ActionResult LogOut()
        {
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
