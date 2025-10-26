using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin _Admin)
        {
           _adminDal.Insert(_Admin);
        }

        public void AdminUpdate(Admin Admin)
        {
           _adminDal.Update(Admin);
        }

        public void DelteAdmin(Admin Admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            return _adminDal.Get(x=>x.AdminId==id);
        }

        public List<Admin> GetList()
        {
            return _adminDal.List();
        }
    }
}
