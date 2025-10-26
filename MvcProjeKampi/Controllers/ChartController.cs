using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        //chartları anlamak burada solidi ezdik. Sadece chart kullanımı anlamak için yapıldı.
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlokList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlokList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>(); 
            categoryClasses.Add(new CategoryClass() { CategoryName = "Yazılım", CategoryCount = 10 });
            categoryClasses.Add(new CategoryClass() { CategoryName = "Seyehat", CategoryCount = 14 });
            return categoryClasses;
        }
    }
}