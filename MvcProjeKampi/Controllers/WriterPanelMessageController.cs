using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.Web.Services.Description;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        
        MessageValidator _messageValidator = new MessageValidator();
        MessageManager _messageManager = new MessageManager(new EFMessageDal());
        public ActionResult InBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = _messageManager.GetListInBox(p);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = _messageManager.GetListSendBox(p);
            return View(messageList);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var messageValue = _messageManager.GetByID(id); //mesaj detaylarını getirme için
            return View(messageValue);
        }

        public ActionResult GetSendMessageDetails(int id)
        {
            var messageValue = _messageManager.GetByID(id); //mesaj detaylarını getirme için
            return View(messageValue);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message _message)
        {


            MessageValidator MessageValidatior = new MessageValidator();
            ValidationResult result = MessageValidatior.Validate(_message);
            if (result.IsValid)
            {
                string p = (string)Session["WriterMail"];
                var messageList = _messageManager.GetListSendBox(p);

                _message.SenderMail = p;
                _message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                _messageManager.MessageAdd(_message);
                return RedirectToAction("SendBox");
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
    }
}