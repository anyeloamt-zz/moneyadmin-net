using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MoneyAdmin.Data.Entities;
using MoneyAdmin.Data.Repositories.Base;
using MoneyAdmin.ViewModel;

namespace MoneyAdmin.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoriesController(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
        //
        // GET: /Categories/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult All()
        {
            var categories = _repository.AsEnumerable()
                .Where(ByCurrentUserPredicate<Category>());

            var categoriesVm = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return Json(categoriesVm, JsonRequestBehavior.AllowGet);
        }
    }
}
