using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using System.Web.ApplicationServices;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;

namespace MvcProjeKampi.Controllers
{
   [AllowAnonymous] // Global.asx dosaysını eklediğimiz GlobalFilters.Filters.Add(new AuthorizeAttribute()); bütün sayfalardan yetkilendirme ister ama login sayfalarından bunu muaf tutmak için allow attributunu kullandık
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin _admin)
        {
            LoginManager loginManager = new LoginManager(new DataAccessLayer.EntityFrameWork.EFLoginDal(new Context()));
            

            var adminUserInfo = loginManager.AddAdmin(_admin.AdminUserName, _admin.AdminPassword);

            if (adminUserInfo != null)
            {
                // Başarılı giriş: Forms Authentication ve Session işlemleri (Presentation'a özgü)
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                // Başarısız giriş: Hata yönetimi
                // Model State'e hata eklemek, View'e geri dönerken hata göstermeyi sağlar.
                ModelState.AddModelError("", "Girdiğiniz kullanıcı adı veya şifre hatalıdır.");

                // Index'e yönlendirmek yerine, Index View'ını mevcut Admin nesnesiyle tekrar gösteriyoruz.
                return View(_admin);
            }
            //mimariye taşınmadan önce solidi ezdiğimiz login şekl
            //Context _context = new Context();
            //var adminUserInfo = _context.Admins.FirstOrDefault(x=>x.AdminUserName == _admin.AdminUserName && x.AdminPassword == _admin.AdminPassword);
            //if(adminUserInfo != null)
            //{
            //    FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);//kullanıcı bilgileriin alıyoruz ve çerez oluşturuyoruz, ayrıca false yaparak tarayıcı kapandığında çerezin silinmesini sağlıyoruz
            //    Session["AdminUserName"] = adminUserInfo.AdminUserName;//session ile kullanıcı adını tutuyoruz
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{
            //    return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }



        [HttpPost]
        public ActionResult WriterLogin(Writer _writer)
        {
            

            WriterLoginManager writerLogin = new WriterLoginManager(new EFWriterDal());
            var writerUserInfo = writerLogin.GetWriter(_writer.WriterMail, _writer.WriterPassword);

            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterName, false);//kullanıcı bilgileriin alıyoruz ve çerez oluşturuyoruz, ayrıca false yaparak tarayıcı kapandığında çerezin silinmesini sağlıyoruz
                Session["WriterMail"] = writerUserInfo.WriterMail;//session ile kullanıcı adını tutuyoruz
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");

            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}