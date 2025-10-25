using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        //Projenin anasayfasının kontrolloru, herkesin erişebileceği sayfa
        // GET: Default

        HeadingManager headingManager = new HeadingManager(new EFHeadingDal()); 
        ContentManager contentManager = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManager.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}