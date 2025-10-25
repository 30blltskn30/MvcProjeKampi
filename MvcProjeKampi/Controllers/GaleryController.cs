using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GaleryController : Controller
    {
        ImageFileManager _imageFileManager = new ImageFileManager(new EFImageFileDal());
        // GET: Galery
        public ActionResult Index()
        {
            var files = _imageFileManager.GetList();
            return View(files);
        }
    }
}