using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void ContactAdd(Contact _contact);
        Contact GetByID(int id);

        void DelteContact(Contact contact);

        void ContactUpdate(Contact contact);
    }
}
