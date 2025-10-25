using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EFMessageDal());
        ContactManager contactManager = new ContactManager(new EFContactDal());
        ContactValidator contactValidator = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }


        public ActionResult ContactDetails(int id)
        {
            var contactValue = contactManager.GetByID(id); //mesaj detaylarını getirme için
            return View(contactValue);
        }

        public PartialViewResult ContactPartial(string p)
        {
            int sendMessageCount = _messageManager.GetListSendBox(p).Count();
            int receiveMessageCount = _messageManager.GetListInBox(p).Count();
            int contactValues = contactManager.GetList().Count();

            ViewBag.sendMessageCount = sendMessageCount;
            ViewBag.receiveMessageCount = receiveMessageCount;
            ViewBag.contactValues = contactValues;
            return PartialView();
        }


    }
}