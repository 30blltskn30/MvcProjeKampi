using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        void AdminAdd(Admin _Admin);
        Admin GetByID(int id);

        void DelteAdmin(Admin Admin);

        void AdminUpdate(Admin Admin);
    }
}
