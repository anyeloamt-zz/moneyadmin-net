using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AutoMapper;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using MoneyAdmin.Extensions;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin.Controllers
{
    public class WalletsController : BaseController
    {
        private readonly IGenericRepository<Wallet> _repository;

        public WalletsController(IGenericRepository<Wallet> repository)
        {
            _repository = repository;
        }

        //
        // GET: /Wallets/

        public ActionResult Index()
        {
           return View();
        }

        //
        // GET: /Wallets/Details/5

        public ActionResult Details(int id)
        {
            return View("Partials/Wallets/_Create");
        }

        public JsonResult Recent()
        {
            var wallets = _repository.RecentWallets()
                .Where(ByCurrentUserPredicate<Wallet>());

            var walletsVm = Mapper.Map<IEnumerable<WalletViewModel>>(wallets);

            return Json(walletsVm, JsonRequestBehavior.AllowGet);
        }
    }
}
