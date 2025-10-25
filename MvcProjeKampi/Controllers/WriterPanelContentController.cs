using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new DataAccessLayer.EntityFrameWork.EFContentDal()); 
        // GET: WriterPanelContent
        Context context = new Context();
        public ActionResult MyContent(string p)
        { 
            

            //Giriş yapan kullanıcının mailini getirme 
            p = (string)Session["WriterMail"];

            //mailden id çekme
            int mailIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(z => z.WriterId).FirstOrDefault();
           
            var contentValues = contentManager.GetListByHeadingWriter(mailIdInfo);
            
            return View(contentValues);
            
        }


        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id; //başlık id sini addcontent sayfasına taşıdık
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string p = (string)Session["WriterMail"];
            //mailden writerid çekme
            int mailIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(z => z.WriterId).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = mailIdInfo;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}