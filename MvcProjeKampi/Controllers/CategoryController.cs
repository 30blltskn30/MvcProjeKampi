using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFrameWork;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;



namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = categoryManager.GetList();

            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            // categoryManager.CategoryAddBL(category);
            CategoryValidator categoryValidator = new CategoryValidator(); //validation işlemdi şimdili ccontroller tarafında yapılıyor. İlerledikçe bu işlemi core katmanında yapacağız
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid)
            {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //böylece validasyon hatalarını kullanıcıya gösterebiliriz
                    
                }
                return View();
            }

        }
    }
}