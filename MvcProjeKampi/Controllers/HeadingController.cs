using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading

        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var headinValues = headingManager.GetList();
            return View(headinValues);
        }

        public ActionResult HeadingReport()
        {
            var headinValues = headingManager.GetList();
            return View(headinValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //aşağıdaki iki yapı da listbox için kullanıldı

            List<System.Web.Mvc.SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new System.Web.Mvc.SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();

            List<System.Web.Mvc.SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                                 select new System.Web.Mvc.SelectListItem
                                                                 {
                                                                     Text = x.WriterName+" "+x.WriterSurname,
                                                                     Value = x.WriterId.ToString()
                                                                 }).ToList();


            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");   
        }

        [HttpGet]
      public ActionResult EditHeading(int id)
        {
            List<System.Web.Mvc.SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                                 select new System.Web.Mvc.SelectListItem
                                                                 {
                                                                     Text = x.CategoryName,
                                                                     Value = x.CategoryId.ToString()
                                                                 }).ToList();

            ViewBag.vlc = valueCategory;
            var headinValue = headingManager.GetByID(id);
            return View(headinValue);
        }
        
        
        
        [HttpPost]
        public ActionResult EditHeading(Heading _heading)
        {
            headingManager.HeadingUpdate(_heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var deleteHeading = headingManager.GetByID(id);
            deleteHeading.HeadimgStatus = false;
            headingManager.DelteHeading(deleteHeading);
            return RedirectToAction("Index");
        }

      
    }
}