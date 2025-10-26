using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        AdminManager _adminManager = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminValues = _adminManager.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin _admin)
        {
            _adminManager.AdminAdd(_admin);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var categoryValue = _adminManager.GetByID(id);
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin _admin)
        {
            _adminManager.AdminUpdate(_admin);
            return RedirectToAction("Index");
        }

    }
}