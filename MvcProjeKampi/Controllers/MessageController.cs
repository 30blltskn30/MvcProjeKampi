using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Reppositories;
using DataAccessLayer.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using FluentValidation.Results;



namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageValidator _messageValidator = new MessageValidator();
        MessageManager _messageManager = new MessageManager(new  EFMessageDal());

        [Authorize]
        public ActionResult InBox(string p)
        {
            
            var messageList=_messageManager.GetListInBox(p);
            return View(messageList);
        }

        public ActionResult SendBox(string p )
        {
            var messageList = _messageManager.GetListSendBox(p);
            return View(messageList);
        }


        public ActionResult GetInBoxMessageDetails(int id)
        {
            var messageValue = _messageManager.GetByID(id); //mesaj detaylarını getirme için
            return View(messageValue);
        }

        public ActionResult GetInSendMessageDetails(int id)
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
            return View();
        }
    }
}