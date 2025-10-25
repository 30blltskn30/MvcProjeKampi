using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void DelteMessage(Message _Message)
        {
            _messageDal.Delete(_Message);
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInBox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

       
        public List<Message> GetListSendBox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message _Message)
        {
            _messageDal.Insert(_Message);
        }

        public void MessageUpdate(Message Message)
        {
            throw new NotImplementedException();
        }
    }
}
