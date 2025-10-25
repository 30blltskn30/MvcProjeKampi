using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInBox(string p);
        List<Message> GetListSendBox(string p);
        void MessageAdd(Message _Message);
        Message GetByID(int id);

        void DelteMessage(Message Message);

        void MessageUpdate(Message Message);
    }
}
