using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin.Controllers
{
    public class TransactionsController : BaseController
    {
        private readonly IGenericRepository<Transaction> _transactionsRepository;
        private readonly IGenericRepository<Wallet> _walletRepository;

        public TransactionsController(IGenericRepository<Transaction> transactionsRepository,
            IGenericRepository<Wallet> walletRepository)
        {
            _transactionsRepository = transactionsRepository;
            _walletRepository = walletRepository;
        }

        //
        // GET: /Transactions/

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult New(int walletId = 0)
        {
            var wallet = _walletRepository
                .FindBy(w => w.Id == walletId)
                .Include(w => w.Transactions)
                .FirstOrDefault();

            if (null == wallet)
            {
                // TODO
            }

            if (wallet.CreatedBy != CurrentUser.Id)
            {
                // TODO
            }

            var transactionVm = Mapper.Map<TransactionViewModel>(new Transaction { Wallet = wallet });

            return PartialView(transactionVm);
        }

        [HttpPost]
        public JsonResult New(TransactionViewModel transactionVm)
        {
            return Json(transactionVm);

            throw new NotImplementedException();
        }
    }
}
