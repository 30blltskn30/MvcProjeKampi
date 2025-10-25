using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EFAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var aboutValues= _aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult Addabout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Addabout(About _about)
        {
            _aboutManager.AboutAdd(_about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}