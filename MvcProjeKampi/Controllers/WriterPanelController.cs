using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());

        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {

            string p = (string)Session["WriterMail"];

            id = context.Writers.Where(x => x.WriterMail == p).Select(z => z.WriterId).FirstOrDefault();

            var writerValues = writerManager.GetByID(id);

            return View(writerValues);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidatior = new WriterValidator();
            ValidationResult result = writerValidatior.Validate(writer);
            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeadings","WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }



        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            //int id = 4; //şuanlık 4 verdik daha sonra sessiondan yazar id alacağız

            //mailden id çekme
            var writerMailIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(z => z.WriterId).FirstOrDefault();

            var values = headingManager.GetListByWriter(writerMailIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<System.Web.Mvc.SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                                 select new System.Web.Mvc.SelectListItem
                                                                 {
                                                                     Text = x.CategoryName,
                                                                     Value = x.CategoryId.ToString()
                                                                 }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string p = (string)Session["WriterMail"];
            var writerMailIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(z => z.WriterId).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerMailIdInfo; //şuanlık 4 verdik daha sonra sessiondan yazar id alacağız
            heading.HeadimgStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");

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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var deleteHeading = headingManager.GetByID(id);
            deleteHeading.HeadimgStatus = false;
            headingManager.DelteHeading(deleteHeading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeadings(int page = 1)
        {
            var headings = headingManager.GetList().ToPagedList(page, 4); // sayfalam için böylr bir yöntem kullandık ve öncesinde projenin references kısmına iki tane page paketi yükledik
            return View(headings);
        }
    }
}